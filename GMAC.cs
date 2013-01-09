using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class GMAC : MessageReplyListener
    {
        #region Var
        private UInt32 baseAddress;
        private string name;
        private static int REG_COUNT0 = 13;
        private static int REG_COUNT1 = 11;
        public int REG_GMAC0 { get { return REG_COUNT0; } }
        public int REG_GMAC1 { get { return REG_COUNT1; } }
        private static readonly UInt32 GMAC0_BASE = 0xE5738000;
        private static readonly UInt32 GMAC1_BASE = 0xE577E000;
        private static UInt32[] registers0 = { 0xe0458054, 0xe573818c, 0xe5738190, 0xe5738194, 0xe57381c4, 0xe57381d4, 0xe57381d8, 
                    0xe0458050, 0xe573811c, 0xe5738120, 0xe573813c, 0xe5738140, 0xe5738144};
        //private UInt32[] addresses0;
        public String[] registerNames0 = {
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
        public String[] registerNames1 = {
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
        public double[] CurrentCounters_GMAC0 = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] LastCounters_GMAC0 = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] RateCounters_GMAC0 = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public DateTime[] Time_GMAC0 = new DateTime[REG_COUNT0]; //{ };// { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] CurrentCounters_GMAC1 = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public double[] LastCounters_GMAC1 = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0  };
        public double[] RateCounters_GMAC1 = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0  };
        public DateTime[] Time_GMAC1 = new DateTime[REG_COUNT1];// { };// { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private TimeSpan[] LastSample = new TimeSpan[REG_COUNT0]; // long enough for GMAC0
        private UInt32[] addresses;
        DateTime[] dateTimes = new DateTime[]{};
        public string[] RegisterNames { get { return (this.baseAddress == GMAC0_BASE) ? registerNames0 : registerNames1; } }
     //   public double currentCounter(int i) { return CurrentCounters_GMAC0[i]; }
        public double rateCounter_GMAC0(int i) { return RateCounters_GMAC0[i]; }
        public double rateCounter_GMAC1(int i) { return RateCounters_GMAC1[i]; }

        private System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();

        private static UInt32 GMAC_Reset_Counters_Address = 0xe5738100;

        public static GMAC gmac0 = new GMAC("GMAC 0", GMAC0_BASE);
        public static GMAC gmac1 = new GMAC("GMAC 1", GMAC1_BASE);

        #endregion

        private GMAC(string name, UInt32 addr) {
            this.name = name;
            this.baseAddress = addr;
            addresses = (this.baseAddress == GMAC0_BASE) ? registers0 : registers1;
            PcapConnection.pcap.addListener(this);
            st.Start();
        }

        // Returns true if the msg represents data for this gmac; false if 
        // the address is for some other register;
        public bool MessageReplyListenerCallback(DAN_gui_msg msg, DateTime arrivalTime)
        {       
            double elapsedMS = 0;
            double delta;

            if ((GMAC0_BASE == (0xfffff000 & msg.address)) || (0xe045805 == (0xfffffff0 & msg.address)))
            {
                for (int i = 0; i < REG_COUNT0; i++)
                {
                    if (msg.address == registers0[i])
                    {
                        TimeSpan elapsed = DateTime.Now - Time_GMAC0[i];
                        elapsedMS = elapsed.TotalMilliseconds;
                        if (elapsedMS < 5)
                        {
                            // way off, so ignore this sample
                            return true;
                        }
                        LastCounters_GMAC0[i] = CurrentCounters_GMAC0[i];
                        CurrentCounters_GMAC0[i] = msg.data[0];
                        delta = CurrentCounters_GMAC0[i] - LastCounters_GMAC0[i];
                        if ((elapsedMS != 0) && (delta > 0))
                        {
                            RateCounters_GMAC0[i] = (delta / (elapsedMS / 1000));
                        }
                        else
                        {
                            RateCounters_GMAC0[i] = 0;
                        }
                        return true;
                    }
                    
                }
            }
            else if (GMAC1_BASE == (0xfffff000 & msg.address))
            {
                for (int i = 0; i < REG_COUNT1; i++)
                {
                    if (msg.address == registers1[i])
                    {
                        TimeSpan elapsed = DateTime.Now - Time_GMAC1[i];
                        elapsedMS = elapsed.TotalMilliseconds;
                        if (elapsedMS < 5)
                        {
                            // way off, so ignore this sample
                            return true;
                        }
                        LastCounters_GMAC1[i] = CurrentCounters_GMAC1[i];
                        CurrentCounters_GMAC1[i] = msg.data[0];
                        delta = CurrentCounters_GMAC1[i] - LastCounters_GMAC1[i];
                        if ((elapsedMS != 0) && (delta > 0))
                        {
                            RateCounters_GMAC1[i] = (delta / (elapsedMS / 1000));
                        }
                        else
                        {
                            RateCounters_GMAC1[i] = 0;
                        }
                        return true;
                    }
                }
            }

            return false;  // Did I get other register address?  return false so others can use the msg.
        }

        public void getNextValues_GMAC0()
        {
            for (int i = 0; i < REG_COUNT0; i++)
            {
                
                DAN_read_array_msg msg = new DAN_read_array_msg(registers0[i], 1);
                PcapConnection.pcap.sendDanMsg(msg);
                DateTime t1 = DateTime.Now;
                Time_GMAC0[i] = t1;
            }
        }

        public void getNextValues_GMAC1()
        {
            for (int i = 0; i < REG_COUNT1; i++)
            {
                DAN_read_array_msg msg = new DAN_read_array_msg(registers1[i], 1);
                PcapConnection.pcap.sendDanMsg(msg);
                DateTime t1 = DateTime.Now;
                Time_GMAC1[i] = t1;
            }
        }

        public void resetGMACCounters()
        {
            uint Clear_GMAC_Counters_Value = 1;
            DAN_write_msg Msg = new DAN_write_msg(GMAC_Reset_Counters_Address, (uint)Clear_GMAC_Counters_Value);
            PcapConnection.pcap.sendDanMsg(Msg);
        }

    }
}
