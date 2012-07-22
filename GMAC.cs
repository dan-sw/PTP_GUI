using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class GMAC : MessageReplyListener
    {
        private UInt32 baseAddress;
        private string name;
        private const int REG_COUNT0 = 13;
        private const int REG_COUNT1 = 11;
        private static readonly UInt32 GMAC0_BASE = 0xE5738000;
        private static readonly UInt32 GMAC1_BASE = 0xE577E000;
        private static UInt32[] registers0 = { 0xe0458054, 0xe573818c, 0xe5738190, 0xe5738194, 0xe57381c4, 0xe57381d4, 0xe57381d8, 
                    0xe0458050, 0xe573811c, 0xe5738120, 0xe573813c, 0xe5738140, 0xe5738144};
        //private UInt32[] addresses0;
        private static String[] registerNames0 = {
            "Rx - MMC ethernet packet count",
            "Rx - Good broadcast frames",
            "Rx - Good multicast frames",
            "Rx - CRC error frames",
            "Rx - Good unicast frames",
            "Rx - Missed due to FIFO overflow",
            "Rx - VLAN frames",
            "Tx - MMC ethernet packet count",
            "Tx - Good broadcast frames",
            "Tx - Good multicast frames",
            "Tx - Good and bad unicast frames",
            "Tx - Good and bad multicast frames",
            "Tx - Good and bad broadcast frames" };
        private static UInt32[] registers1 = { 0xe577e18c, 0xe577e190, 0xe577e194, 0xe577e1c4, 0xe577e1d4, 0xe577e1d8, 
                    0xe577e11c, 0xe577e120, 0xe577e13c, 0xe577e140, 0xe577e144};
        //private UInt32[] addresses1;
        private static String[] registerNames1 = {
            "Rx - Good broadcast frames",
            "Rx - Good multicast frames",
            "Rx - CRC error frames",
            "Rx - Good unicast frames",
            "Rx - Missed due to FIFO overflow",
            "Rx - VLAN frames",
            "Tx - Good broadcast frames",
            "Tx - Good multicast frames",
            "Tx - Good and bad unicast frames",
            "Tx - Good and bad multicast frames",
            "Tx - Good and bad broadcast frames" };
            
        // Note that these are long enough to accomodate GMAC0, which has more counters:
        private double[] CurrentCounters = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private double[] LastCounters = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private double[] RateCounters = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private TimeSpan[] LastSample = new TimeSpan[REG_COUNT0]; // ditto, long enough for GMAC0
        private UInt32[] addresses;

        // New for 9Nov2011: GMAC will use msg sequence number instead of comparing addresses.
        // Although this limits the ability of each instance to only one outstanding request,
        // it speeds the processing of replies.  And the current design only sends one request per
        // 500 ms, and is only interested in one register at a time, so there are no
        // negative consequences with this approach.
        private int outstandingMessageSeq;

        private System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();

        public static GMAC gmac0 = new GMAC("GMAC 0", GMAC0_BASE);
        public static GMAC gmac1 = new GMAC("GMAC 1", GMAC1_BASE);
        
        private GMAC(string name, UInt32 addr) {
            this.name = name;
            this.baseAddress = addr;
            addresses = (this.baseAddress == GMAC0_BASE) ? registers0 : registers1;
            outstandingMessageSeq = -1;
            //addresses = new UInt32[REG_COUNT];
            //for (int i = 0; i < REG_COUNT; i++)
            //{
            //    addresses[i] = baseAddress + registerOffsets[i];
            //}
            // Register for message responses
            PcapConnection.pcap.addListener(this);
            st.Start();
        }

        public string[] RegisterNames { get { return (this.baseAddress == GMAC0_BASE) ? registerNames0 : registerNames1; } }
        public double currentCounter(int i) { return CurrentCounters[i]; }
        public double rateCounter(int i) { return RateCounters[i]; }
        
        // Returns true if the msg represents data for this gmac; false if 
        // the address is for some other register;
        public bool MessageReplyListenerCallback(DAN_gui_msg msg, DateTime arrivalTime)
        {
            if (outstandingMessageSeq != msg.seq) {
                return false;
            }
            double msInterval = 0;
            double delta;

            bool thisIsGmac0 = this.baseAddress == GMAC0_BASE;
            bool debugOutput = false; // thisIsGmac0;
            int registerCount = addresses.Length;

            for (int i = 0; i < registerCount; i++)
            {
                if (msg.address == addresses[i])
                {
                    TimeSpan timeNow = st.Elapsed;
                    if (debugOutput) {
                        //Console.Write("{2} Addr[{0}]={1} (msg {3})", msg.address.ToString("X8"), msg.data[0].ToString("n"), timeNow.TotalMilliseconds.ToString("n5"), msg.seq);
                        Console.WriteLine("{0}:{1}:{2},{3} = {4}    {5} = {6}",
                            arrivalTime.Hour, arrivalTime.Minute, arrivalTime.Second, arrivalTime.Millisecond,
                            arrivalTime.TimeOfDay.TotalMilliseconds, registerNames0[i], msg.data[0]);
                    }
                    if (LastSample[i].TotalMilliseconds == 0)
                    {
                        // Don't bother with Rate, yet.
                        if (debugOutput) {
                            Console.Write(" (last sample time 0) ");
                        }
                    }
                    else
                    {
                        TimeSpan tSpan = arrivalTime.TimeOfDay - LastSample[i];
                        msInterval = (double)tSpan.TotalMilliseconds;
                        // 10/6: Not sure why I get two in a row - debug stop?  anyway, it throws the rate calc
                        // way off, so ignore this sample
                            // 11/9: may have been from loopback on SOC
                        if (msInterval < 5)
                        {
                            if (debugOutput)
                            {
                                Console.WriteLine("Ignoring this sample!");
                            }
                            return true;
                        }
                        //Console.WriteLine("Reg {0} last read {1} ms ago", msg.address.ToString("X2"), tSpan.Milliseconds);
                        if (debugOutput)
                        {
                            Console.Write(" (last sample time {0} ms ago) ", tSpan.TotalMilliseconds.ToString("n5"));
                            if (msInterval == 0)
                            {
                                Console.Write(" (bug? tSpan.Milliseconds = {0}, LastSample.Milliseconds = {1} )", tSpan.TotalMilliseconds, LastSample[i].TotalMilliseconds);
                            }
                        }
                    }
                    LastSample[i] = arrivalTime.TimeOfDay;
                    LastCounters[i] = CurrentCounters[i];
                    CurrentCounters[i] = msg.data[0];
                    delta = CurrentCounters[i] - LastCounters[i];
                    if ((msInterval != 0) && (delta > 0))
                    {
                        RateCounters[i] = (delta / (msInterval / 1000));
                    }
                    else
                    {
                        RateCounters[i] = 0;
                    }
                    if (debugOutput)
                    {
                        Console.WriteLine(" Delta = {0}, rate = {1}", delta, RateCounters[i].ToString("n"));
                    }
                    outstandingMessageSeq = -1;
                    return true;
                }
            }
            Console.WriteLine("BUG: invalid address in reply to {0}: {1}", this.name, msg.ToString());
            return false;  // Did I get the seq number wrong?  return false so others can use the msg.
        }

        public void getNextValue(int selection)
        {
            // Sanity check
            if (selection >= addresses.Length)
            {
                Console.WriteLine("Bug: Selection index {0} out of range for gmac {1}, limited.", selection, this.name);
                selection = addresses.Length - 1;
            }
            // request next values for 'left' graph GMCA
            DAN_read_msg msg = new DAN_read_msg(addresses[selection]);
            outstandingMessageSeq = msg.seq;
            PcapConnection.pcap.sendDanMsg(msg);
        }


    }
}
