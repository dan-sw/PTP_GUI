using System;
using System.IO;

namespace WindowsFormsApplication1
{
    class PhyChannelGainData : MessageReplyListener
    {
        #region Var

        readonly UInt32 ChannelGainbaseAddr = 0xd0020000;
        readonly UInt32 ChannelGainEnableAddress = 0xd0018210;
        // [CurrentSamplesAddress,HistorySamplesAddress]
        readonly UInt32[] CGSamplesAddressOffset = { 0xac00, 0xcc00 };
        readonly UInt32[] CG_ADDRESS_OFFSETS = { 0 , 0x400};
        //readonly UInt32 HistorySamplesAddress = 0xcc00;
        public UInt32 baseAddress { get; private set; }

        public static string folderRoot = @"C:\PTP\";
        readonly string[] fileRoot = { "Immediate", "History" };
        readonly string fileSuffix = ".txt";
        public string fileName { get; private set; }
        public string filePath { get { return folderRoot + "Rx_ChaneEst_" + fileName; } }
        public SampleTime samplesTiming { get; private set; }

        private UInt32[] data;
        readonly int CHANNELGAIN_ARRAY_LEN = 512;
        readonly int REQUEST_SIZE_WORDS = 256;
        private int dataCollected;

        private UInt32 ChannelGainEnableValue = 0x0;
        public bool ChannelGainReadRegister = false;
        private bool ChannelGainReadFiles = false;

        public enum SampleTime
        {
            Current = 0,
            History
        } 

        #endregion

         public PhyChannelGainData(SampleTime samples)
        {
            this.samplesTiming = samples;
            this.baseAddress = ChannelGainbaseAddr + CGSamplesAddressOffset[(int)samples];
            this.fileName = fileRoot[(int)samples] + fileSuffix;
            this.data = new UInt32[CHANNELGAIN_ARRAY_LEN];
            this.dataCollected = 0;
        }

         /* Writes the Channel Gain data to a temp file, formatted for Matlab.
         * Returns true if OK, false if an IO failure writing the file.
         */
         public bool flushToTempFile()
         {
             string path = folderRoot + fileName;   // e.g., "C:\PTP\Current.txt"
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
                 System.Console.WriteLine("Error writing temp Channel Gain file {0} - {1} ", path, ex.Message);
                 return false;
             }
             return true;
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

         public void refreshData()
         {
             // Register for replies
             PcapConnection.pcap.addListener(this);
             // Mark the array invalid
             dataCollected = 0;
             ChannelGainReadFiles = true;
             // Note that zero, for length, is interpreted as 256
             for (int i = 0; i < CG_ADDRESS_OFFSETS.Length; i++)
             {
                 // Note that zero, for length, is interpreted as 256
                 DAN_read_array_msg msg = new DAN_read_array_msg(baseAddress + CG_ADDRESS_OFFSETS[i], 0);
                 PcapConnection.pcap.sendDanMsg(msg);
             }

         }

         public bool MessageReplyListenerCallback(DAN_gui_msg msg, DateTime arrivalTime)
         {
             //read the register that contine channel gain enable/disable bit
             if (msg.address == ChannelGainEnableAddress)
             {
                 UInt32 temp = Convert.ToUInt32(msg.data[0].ToString());
                 ChannelGainEnableValue = (temp & 0xffff0fff);
                 ChannelGainReadRegister = true;
             }

             if (msg.address < baseAddress || msg.address > (baseAddress + CG_ADDRESS_OFFSETS[CG_ADDRESS_OFFSETS.Length - 1]))
             {
                 return false;
             }
             // debug assert
             if (msg.size != 0)
             {
                 Console.WriteLine("BUG: unexpected reply length for constellation data msg: {0}", msg.size);
                 return true;
             }

             
             UInt32 addrOffset = msg.address - baseAddress;
             int i;
             for (i = 0; i < CG_ADDRESS_OFFSETS.Length; i++)
             {
                 if (addrOffset == CG_ADDRESS_OFFSETS[i])
                 {
                     break;
                 }
             }
             // debug assert
             if (i >= CG_ADDRESS_OFFSETS.Length)
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
             if (dataCollected >= CG_ADDRESS_OFFSETS.Length)
             {
                 //PcapConnection.pcap.removeListener(this);
                 // moved to isDataReady, below
             }
             return true;
         }

         public bool moveToMatlabFile()
         {
             string path = folderRoot + fileName;   // e.g., "C:\PTP\Ant2_AfterEQ.txt"
             string newPath = folderRoot + "Rx_ChaneEst_" + fileName; // e.g., "C:\PTP\Channel_Gain_Current.txt"
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
                     System.Console.WriteLine("Error writing Channel Gain file {0} - {1}", newPath, e2.Message);
                     return false;
                 }
             }
             // Don't expect to fail for a full 3 seconds, unless matlab is really slow!
             System.Console.WriteLine("Error updating Channel Gain file {0} - {1} ", newPath, eSaved.Message);
             return false;
         }

         public bool isDataReady()
         {
             if (dataCollected == CG_ADDRESS_OFFSETS.Length)
             {
                 PcapConnection.pcap.removeListener(this);
                 return true;
             }
             return false;
         }

         public void ChannelGainActivate(bool activate)
         {
             if (ChannelGainReadRegister)
             {
                 if (activate)
                 {
                     UInt32 CG_Activate = ChannelGainEnableValue | 0x00001000;
                     DAN_write_msg wMsg = new DAN_write_msg(ChannelGainEnableAddress, CG_Activate);
                     PcapConnection.pcap.sendDanMsg(wMsg);
                 }
                 else
                 {
                     UInt32 CG_Deactivate = ChannelGainEnableValue & 0xffff0fff;
                     DAN_write_msg wMsg = new DAN_write_msg(ChannelGainEnableAddress, CG_Deactivate);
                     PcapConnection.pcap.sendDanMsg(wMsg);
                 }
             }
         }

         public void ChannelGainEnableRead()
         {
             PcapConnection.pcap.addListener(this);
             DAN_read_array_msg msg = new DAN_read_array_msg(ChannelGainEnableAddress, 1);
             PcapConnection.pcap.sendDanMsg(msg);
             ChannelGainReadRegister = false;
         }
    }
}
