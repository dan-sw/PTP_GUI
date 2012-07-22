using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    /*
     *  Represents one dataset for the Matlab process (which takes 4 datasets)
     *  Specifically, there are two for Antenna 1 and two for Antenna 2:
     *  Before and After data.
     */
    class PhyConstellationData : MessageReplyListener
    {
        readonly UInt32[] baseAddr_PLL = { 0xd0118000, 0xd0022000 };  //{0x50000000, 0x50080000};
        //org:
        readonly UInt32[] baseAddr = { 0xd0000000, 0xd0080000 };  //{0x50000000, 0x50080000};
        readonly int CONSTELLATION_ARRAY_LEN = 2048;
        readonly UInt32 AFTER_EQ_OFFSET_PLL = 0x00;
        //org: 
        readonly UInt32 AFTER_EQ_OFFSET = 0x8000;

        // These offsets were used by previous code (in Form1), which fetched 512 words at a time:
        /*  static const uint[] AntOffset_afterEQ = new uint[] { 0x8000, 0xA000, 0xC000, 0xE000 };
            //  uint[] AntOffset_beforeEQ = new uint[] { 0x0800, 0x2800, 0x4800, 0x6800 };
            static const uint[] AntOffset_beforeEQ = new uint[] { 0x0000, 0x2000, 0x4000, 0x6000 };
         */
        // Current limitation in protocol is that the reply fit in one ethernet packet.
        // These addresses based on limit of 256 words per request
        readonly int REQUEST_SIZE_WORDS = 256;
        readonly UInt32[] ADDRESS_OFFSETS = { 0, 0x400, 0x2000, 0x2400, 0x4000, 0x4400, 0x6000, 0x6400 };
        
        public static string folderRoot = @"C:\PTP\";
        readonly string[] fileRoot = { "Ant1_", "Ant2_" };
        readonly string[] fileSuffix = { "BeforeEQ.txt", "AfterEQ.txt" };

        public enum Antenna
        {
            ANT1 = 0,
            ANT2
        }

        public enum EqPosition
        {
            BEFORE = 0,
            AFTER
        }
      
        // I.e.,
        //const UInt32 BaseaddressAnt1_afterEQ = 0x50000000;
        //const UInt32 BaseaddressAnt2_afterEQ = 0x50080000;
        //const UInt32 BaseaddressAnt1_beforeEQ = 0x50000000;
        //const UInt32 BaseaddressAnt2_beforeEQ = 0x50080000;
        public UInt32 baseAddress { get; private set; }
        public Antenna antenna { get; private set; }
        public EqPosition eqPosition { get; private set; }
        public string fileName { get; private set; }
        public string filePath { get { return folderRoot + "Constellation_" + fileName; } }
        
        private UInt32[] data;
        private int dataCollected;

        public PhyConstellationData(Antenna ant, EqPosition eq, bool PLL_Debug)
        {
            this.antenna = ant;
            this.eqPosition = eq;
            this.baseAddress = baseAddr[(int)ant];
 //           if (PLL_Debug)
 //           { this.baseAddress = baseAddr_PLL[(int)ant]; }
 //           else
 //           { this.baseAddress = baseAddr[(int)ant]; }
            if (eq == EqPosition.AFTER)
            {
                if (PLL_Debug)
                { this.baseAddress = baseAddr_PLL[(int)ant] + AFTER_EQ_OFFSET_PLL ; }
                else
                { this.baseAddress = baseAddr[(int)ant] + AFTER_EQ_OFFSET; }
            }
            this.dataCollected = 0;
            this.fileName = fileRoot[(int)ant] + fileSuffix[(int)eq];
            this.data = new UInt32[CONSTELLATION_ARRAY_LEN];
        }

        // Returns true if the msg represents data for this listener; false if 
        // the address is not recognized (reply is for some other listener)
        public bool MessageReplyListenerCallback(DAN_gui_msg msg, DateTime arrivalTime)
        {
            // Need to offset ACK and NACK by base amounts;
            // Scale and translate RSSI and STO
            // Find missing values
            if (msg.address < baseAddress || msg.address > (baseAddress + ADDRESS_OFFSETS[ADDRESS_OFFSETS.Length - 1]))
            {
                return false;
            }
            // debug assert
            if (msg.size != 0) {
                Console.WriteLine("BUG: unexpected reply length for constellation data msg: {0}", msg.size);
                return true;
            }
//            System.Console .WriteLine ("packet {0} rec'd {1}:{2}:{3},{4}  addr {5}",
//                            dataCollected,
//                            arrivalTime.Hour, arrivalTime.Minute, arrivalTime.Second, arrivalTime.Millisecond,
//                            msg.address.ToString("x08"));
            UInt32 addrOffset = msg.address - baseAddress;
            int i;
            for (i = 0; i < ADDRESS_OFFSETS.Length; i++)
            {
                if (addrOffset == ADDRESS_OFFSETS[i])
                {
                    break;
                }
            }
            // debug assert
            if (i >= ADDRESS_OFFSETS.Length)
            {
                Console.WriteLine("BUG: unexpected reply addr for constellation data msg: {0}", msg.address);
                return true;
            }
            int dataOffset = i * REQUEST_SIZE_WORDS;
            Array.Copy(msg.data, 0, this.data, dataOffset, REQUEST_SIZE_WORDS);
            dataCollected++;
            // Stop listening if all replies seen
            // Wed 9 Nov 2011: wondering if this may be an issue, since we're iterating the
            // listeners during this callback?
            if (dataCollected >= ADDRESS_OFFSETS.Length)
            {
                //PcapConnection.pcap.removeListener(this);
                // moved to isDataReady, below
            }
            return true;
        }

        public void refreshData()
        {
            // Register for replies
            PcapConnection.pcap.addListener(this);
            // Mark the array invalid
            dataCollected = 0;
            // issue eight requests (256 words each)
            for (int i = 0; i < ADDRESS_OFFSETS.Length; i++)
            {
                // Note that zero, for length, is interpreted as 256
                DAN_read_array_msg msg = new DAN_read_array_msg(baseAddress + ADDRESS_OFFSETS[i], 0);
                PcapConnection.pcap.sendDanMsg(msg);
            }
        }

        public bool isDataReady()
        {
            if (dataCollected == ADDRESS_OFFSETS.Length)
            {
                PcapConnection.pcap.removeListener(this);
                return true;
            }
            return false;
        }

        /* 
         * Data collection can fail in a number of ways.  This can be
         * detected by the owner of this object by:
         *      flushToFile() returning 'false'
         *      isDataReady() returning 'false' for an excessive interval
         * In any case, the listeners should be removed from pcap.
         * In the current code (Nov 2011), this is invoked by
         * Constellation.shutDown().
         */
        public void cancelListener()
        {
            PcapConnection.pcap.removeListener(this);
        }

        /*
         * Writes the collected data to a temp file, formatted for Matlab.
         * Returns true if OK, false if an IO failure writing the file.
         * 
         * To remain compatible with the compiled Matlab executable logic.exe,
         * this method generates a file in this format:
         * four 8-character hex values per line, separated by spaces.
         * TBD if these characteristics are critical:
         *    1)  each line begins with a space
         *    2)  each hex-formatted value is followed by 2 spaces
         *    3)  each line ends with three chars 0D 0D 0A  (/r/r/n)
         * 
         */
        public bool flushToTempFile()
        {
            string path = folderRoot + fileName;   // e.g., "C:\PTP\Ant2_AfterEQ.txt"
            try
            {
                File.Delete(path);
                TextWriter tw = new StreamWriter(path);
                for (int j = 0; j < (data.Length - 3); j += 4)
                {
                    tw.WriteLine(" {0:x8}  {1:x8}  {2:x8}  {3:x8}  \r", data[j], data[j + 1], data[j + 2], data[j + 3]);
                }

                tw.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error writing temp constellation file {0} - {1} ", path, ex.Message);
                return false;
            }
            return true;
        }
        /*
         * Moves the temp file to the file expected by Matlab.
         * Returns true if OK, false if an IO failure writing the file.
         * 
         */
        public bool moveToMatlabFile()
        {
            string path = folderRoot + fileName;   // e.g., "C:\PTP\Ant2_AfterEQ.txt"
            string newPath = folderRoot + "Constellation_" + fileName; // e.g., "C:\PTP\Constellation_Ant1_beforeEQ.txt"
            //update files (delete the old ones and rename the temp files)
            // This sometimes fails, if matlab is reading the file at the moment.
            // Typically, trying again works.  This tries for 3 seconds, then displays 
            // an error message dialog.
            Exception eSaved = null;
            for (int i = 0; i < 60; i++)
            {
                try
                {
                    File.Delete(newPath);
                }
                catch (Exception e)
                {
                    eSaved = e;
                    System.Threading.Thread.Sleep(50);
                    continue;
                }
                try
                {
                    File.Move(path, newPath);
                    return true;
                }
                catch (Exception e2)
                {
                    // This we don't expect!
                    System.Console.WriteLine("Error writing constellation file {0} - {1}", newPath, e2.Message);
                    return false;
                }
            }
            // Don't expect to fail for a full 3 seconds, unless matlab is really slow!
            System.Console.WriteLine("Error updating constellation file {0} - {1} ", newPath, eSaved.Message);
            return false;
        }

    }
}
