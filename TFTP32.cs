using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class TFTP32
    {
        private static string folderRoot = @"C:\PTP\Tftpd32\";

        public void change_ini(string TFTPFilesFolder)
        {
            StreamWriter sw = new StreamWriter(@"C:\PTP\Tftpd32\tftpd32.ini");
                sw.Write(@"[DHCP]
Lease_NumLeases=0
[TFTPD32]");
                sw.WriteLine("\n");
                sw.WriteLine("\nBaseDirectory= " + TFTPFilesFolder + "\n");
                sw.Write(@"TftpPort=69
Hide=0
WinSize=0
Negociate=1
PXECompatibility=0
DirText=0
ShowProgressBar=1 
Timeout=3         
MaxRetransmit=6   
SecurityLevel=1   
UnixStrings=1     
Beep=0            
VirtualRoot=0     
MD5=0             
LocalIP=          
Services=1
TftpLogFile=      
SaveSyslogFile=   
PipeSyslogMsg=0   
LowestUDPPort=0   
HighestUDPPort=0  
MulticastPort=0   
MulticastAddress= 
PersistantLeases=1
DHCP Ping=1
DHCP LocalIP=
Max Simultaneous Transfers=100
UseEventLog=0
Console Password=tftpd32
Support for port Option=0
Keep transfer Gui=5
Ignore ack for last TFTP packet=0
Enable IPv6=1");
                sw.Close();
            
        }

        public void OpenTFTP32D()
        {
            Kill_TFTP32D();
            string ProcessName = folderRoot + "tftpd32.exe";
            ProcessStartInfo startInfo = new ProcessStartInfo(ProcessName);
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            Process.Start(startInfo);
        }

        public void Kill_TFTP32D()
        {
            try
            {
                Process[] ProcessName = Process.GetProcessesByName("tftpd32");
                foreach (Process p in ProcessName)
                {
                    p.Kill();
                }
            }
            catch (Exception errormessage)
            {
                MessageBox.Show("Error Closing TFTPD32: \n\n" + errormessage);
            }
        }
    }
}
