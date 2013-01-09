using System;
using System.IO;

namespace WindowsFormsApplication1
{
    class CDU : MessageReplyListener
    {
        public static string folderRoot = @"C:\PTP\CDU_Scripts\";
        public static string[] Script_Name = { "PRI_Script_Ant0", "PRI_Script_Ant1", "PRI_Script_Ant4", "FIR_Script", "FFT_In_Script", "FFT_Out_Script" };
        private static uint[] CM_address = {0x94000000, 0x95E84800};
        private static uint REQUEST_SIZE_Samples = 100000;
        static uint data_size = REQUEST_SIZE_Samples*2;
        private static uint REQUEST_SIZE_WORDS = 256;
        private static uint Number_of_Req = (data_size / REQUEST_SIZE_WORDS);
        private UInt32[] data_CM0;
        private UInt32[] data_CM1;
        public int message_counter = 0;

        public void CDU_configure(string file_to_upload)
        {
            FileInfo file = new FileInfo(file_to_upload);
            StreamReader reader = file.OpenText();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(' ');
              //  uint address = uint.Parse(items[3]);
                uint address = Convert.ToUInt32(items[3], 16);
                uint value = Convert.ToUInt32(items[5], 16);   
                DAN_write_msg msg = new DAN_write_msg(address, value);
                PcapConnection.pcap.sendDanMsg(msg);
                // refresh my cached values
                getNextValues();
            }
            
        }

        public void CDU_Get_data()
        {
            data_CM0 = new UInt32[data_size];
            data_CM1 = new UInt32[data_size];
            message_counter = 0;
            // Register for replies
            PcapConnection.pcap.addListener(this);

            // issue # of requests (256 words each)
            for (int i = 0; i < CM_address.Length; i++)
            {
                for (uint j = 0; j <= Number_of_Req; j++)
                {
                    // Note that zero, for length, is interpreted as 256
                    DAN_read_array_msg msg = new DAN_read_array_msg((CM_address[i]+(0x400*j)), 0);
                    System.Threading.Thread.Sleep(1);
                    PcapConnection.pcap.sendDanMsg(msg);
                }
            }
        }

        public bool CDU_Write_File(string fileName, int CM )
        {
            UInt32[] data;
            if (CM == 0)
                data = data_CM0;
            else
                data = data_CM1;
            string path = folderRoot + fileName;   // e.g., "C:\PTP\PRI_CM0"
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
                System.Console.WriteLine("Error writing CDU file {0} - {1} ", path, ex.Message);
                PcapConnection.pcap.removeListener(this);
                return false;
            }
            PcapConnection.pcap.removeListener(this);
            return true;
        }

        public void CDU_Matlab(string filename)
        {

        }

        public bool get_all_messages()
        {
            if (message_counter == Number_of_Req)
            { return true; }
            return false;
        }

        public bool MessageReplyListenerCallback(DAN_gui_msg msg, DateTime arrivalTime)
        {
            for (int i = 0; i < CM_address.Length; i++)
            {
                if ((msg.address >= CM_address[i]) || (msg.address <= (CM_address[i] + (0x400*Number_of_Req))))
                {
                    if (msg.size == 0)
                    {
                        UInt32 addrOffset = msg.address - CM_address[i];
                        uint j = addrOffset / 0x400;

                        // debug assert
                        if (j >= Number_of_Req)
                        {
                            Console.WriteLine("BUG: unexpected reply addr for CDU data msg at CM{0}: {1}", i, msg.address);
                            return true;
                        }
                        uint dataOffset = j * REQUEST_SIZE_WORDS;
                        if (i == 0)
                        { Array.Copy(msg.data, 0, this.data_CM0, dataOffset, REQUEST_SIZE_WORDS); }
                        else
                        { Array.Copy(msg.data, 0, this.data_CM1, dataOffset, REQUEST_SIZE_WORDS); }
                        message_counter++;
                        return true;// won't bother any other object with parsing it, since it IS for this object
                    }
                }                
            }
            return false;            
        }

        public void getNextValues()
        {
            // Responses are handled on another thread
            DAN_read_array_msg msg = new DAN_read_array_msg(CM_address[0], 1);
            PcapConnection.pcap.sendDanMsg(msg);
        }
    }
}
