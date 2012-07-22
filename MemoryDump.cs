using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WindowsFormsApplication1
{
    class MemoryDump : MessageReplyListener
    {
        public static string folderRoot = @"C:\PTP\CDU_Scripts\";
        public static string[] Script_Name = { "PRI_Script", "FIR_Script", "FFT_In_Script", "FFT_Out_Script" };
        private static uint Temp_Dump_Address = 0;
        static uint data_size = 0 ;
        private static uint REQUEST_SIZE_WORDS = 256;
        private UInt32[] data;
        public int message_counter = 0;
        private static uint Number_of_Req = (data_size / REQUEST_SIZE_WORDS);


        private void read_file_to_Memory_dump()
        {

        }



        public void Memory_Get_data(uint Dump_Address, uint Dump_size)
        {
            data = new UInt32[Dump_size];
            
            message_counter = 0;
            Temp_Dump_Address = Dump_Address;
            Number_of_Req = (Dump_size / REQUEST_SIZE_WORDS);

            // Register for replies
            PcapConnection.pcap.addListener(this);

            // issue # of requests (256 words each)
            for (uint j = 0; j <= Number_of_Req; j++)
                {
                    // Note that zero, for length, is interpreted as 256
                    DAN_read_array_msg msg = new DAN_read_array_msg((Dump_Address + (0x400 * j)), 0);
                    System.Threading.Thread.Sleep(1);
                    PcapConnection.pcap.sendDanMsg(msg);
                }
        }

        public bool Memory_Write_File(string fileName)
        {
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
            data = null;
            return true;
        }

        public bool get_all_messages()
        {
            if (message_counter == Number_of_Req)
            { return true; }
            System.Threading.Thread.Sleep(1);
            return false;
        }

        public bool MessageReplyListenerCallback(DAN_gui_msg msg, DateTime arrivalTime)
        {
                if ((msg.address >= Temp_Dump_Address) || (msg.address <= (Temp_Dump_Address + (0x400 * Number_of_Req))))
                {
                    if (msg.size == 0)
                    {
                        UInt32 addrOffset = msg.address - Temp_Dump_Address;
                        uint j = addrOffset / 0x400;

                        // number of req is not 256 multiplayer.
                        if (j >= Number_of_Req)
                        {                           
                            return true;
                        }
                        uint dataOffset = j * REQUEST_SIZE_WORDS;
                        { Array.Copy(msg.data, 0, this.data, dataOffset, REQUEST_SIZE_WORDS); }
                        message_counter++;
                        return true;// won't bother any other object with parsing it, since it is for this object
                    }
                }
            
            return false;
        }
    }
}
