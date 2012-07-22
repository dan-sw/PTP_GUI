#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Reflection;



using PacketDotNet;
using SharpPcap;

#endregion

public class Pira
{
    public void create_ini(string comport, string baudrate)
    {
        string[] text = new string[22];
        text[0] = "[General]\n";
        text[1] = "Top=104\n";
        text[2] = "Left=764\n";
        text[3] = comport;
        text[4] = baudrate;
        text[5] = "Parity=2\n";
        text[6] = "Databits=4\n";
        text[7] = "Stopbits=0\n";
        text[8] = "FlowControl=0\n";
        text[9] = "TDMA=1\n";
        text[10] = "TXBuffer=12\n";
        text[11] = "Port=200\n";
        text[12] = "Delay=30\n";
        text[13] = "Length=1\n";
        text[14] = "Hidden=1\n";
        text[15] = "Connect=1\n";
        text[16] = "LogTX=0\n";
        text[17] = "LogRX=0\n";
        text[18] = "LogER=0\n";
        text[19] = "LogCC=0\n";
        text[20] = "File=\n";

        string path = @"c:\PTP\Pira\piracom.ini";

        // create a writer and open the file
        TextWriter tw = new StreamWriter(path);

        // write a lines of text to the file
        for (int i = 0;i < 21;i++)
        {
            tw.WriteLine(text[i]);
        }


        // close the stream
        tw.Close();
    }

}//run Pira program + create new ini file End. 

public class Switch
{
    public enum ports
    {
        Port0 = 0x10,
        Port1 = 0x11,
        Port2 = 0x12,
        Port3 = 0x13,
        Port4 = 0x14,
        Port5 = 0x15,
        Port6 = 0x16,
        Global1 = 0x1B,
        Global2 = 0x1C
    }
 
    public int calc_address(int reg, ports port, bool RD_WR)
    {
        int value = 1;
        if (RD_WR) //read
        {
            value = ((reg << 6 & 0x000007c0) |
                ((int)port << 0xB & 0x0000F800) |
                (1));
        }
        else //Write
        {
            value = ((reg << 6 & 0x000007c0) |
               ((int)port << 0xB & 0x0000F800) |
               (3));
        }
        return value;
    }

}

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void testRepeatedReqResponse()
        {
            try
            {
                uint BaseaddressGMAC1 = 0xE577E000;
                uint[] CountersOffset = new uint[] { 0x18c, 0X190, 0X194, 0X1c4, 0X1d4, 0X1d8, 
                    0X11c, 0X120, 0X13c, 0X140, 0X144};

                // Read the GMAC1 TX counter
                while (true)
                {
                    for (int i = 3; i <= 10; i += 5)
                    {
                        uint register = BaseaddressGMAC1 + CountersOffset[i];
                        Console.WriteLine("Requesting counter {0} Gmac1 at {1}", i, register.ToString("X2"));
                        DAN_read_msg msg = new DAN_read_msg(register);
                        PcapConnection.pcap.sendDanMsg(msg);
                        DAN_gui_msg responseMsg = null;
                        while (responseMsg == null)
                        {
                            SharpPcap.RawCapture rawCapture = PcapConnection.pcap.device.GetNextPacket();
                            responseMsg = PcapConnection.pcap.parsePacket(rawCapture);
                        }
                        System.Threading.Thread.Sleep(500);
                    }
                }


            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error getMessage: " + e.Message);
            }
        }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //FormChartDevelopment form = new FormChartDevelopment();
            //form.ShowDialog();

            //FormSystemStatus formSystemStatusTest = new FormSystemStatus();
            //formSystemStatusTest.ShowDialog();

            // Show the Discovery Dialog, to get adapters, etc.
            FormDiscover formDiscover = new FormDiscover();
            try
            {
                formDiscover.testDll();
            }
            catch (PcapException)
            {
                // Not expecting this
                string msg = global::WindowsFormsApplication1.Properties.Resources.NoNetworkDevices;
                MessageBox.Show(msg, "DAN PTP Startup Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // Don't return, but fall thru and let it try again in FormDiscover
            }
            catch (PcapNotRunningException)
            {
                // The SharpPcap assembly was loaded, but no devices reported
                string msg = global::WindowsFormsApplication1.Properties.Resources.NoNetworkDevices;
                MessageBox.Show(msg, "DAN PTP Startup Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed loading pcap: {0} - {1}", ex.ToString(), ex.Message);
                string msg = global::WindowsFormsApplication1.Properties.Resources.MissingSharpPcap;
                MessageBox.Show(msg, "DAN PTP Startup Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult rv = formDiscover.ShowDialog();
            if (rv == DialogResult.OK)
            {
                PcapConnection.pcap.startPacketListener();
                //FormSystemMonitor.getInstance().ShowDialog();
                FormSystemStatus formSystemStatus = new FormSystemStatus();
                formSystemStatus.ShowDialog();
                PcapConnection.pcap.stopDevice();
            }
            
        }
    }
}
