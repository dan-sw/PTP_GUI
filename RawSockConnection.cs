using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using PacketDotNet;
using PacketDotNet.Utils;
using SharpPcap;

namespace WindowsFormsApplication1
{
    class RawSockConnection
    {
        Socket sock = null;
        IPEndPoint hostEndPoint;
        IPAddress hostAddress = null;
        int conPort = 80;
        ICaptureDevice device = null;

        public RawSockConnection()
        {
            try
            {

                // Print SharpPcap version
                string ver = SharpPcap.Version.VersionString;
                Console.WriteLine("SharpPcap {0}, Example1.IfList.cs", ver);

                // Retrieve the device list
                //CaptureDeviceList devices = CaptureDeviceList.Instance;
                SharpPcap.LibPcap.LibPcapLiveDeviceList devices = SharpPcap.LibPcap.LibPcapLiveDeviceList.Instance;

                // If no devices were found print an error
                if (devices.Count < 1)
                {
                    Console.WriteLine("No devices were found on this machine");
                    return;
                }

                Console.WriteLine("\nThe following devices are available on this machine:");
                Console.WriteLine("----------------------------------------------------\n");

                // Print out the available network devices
                foreach (ICaptureDevice dev in devices)
                {
                    string descr = dev.ToString();
                    /* try
                     {
                         dev.Open(DeviceMode.Normal);
                         string addr = dev.MacAddress.ToString();
                         Console.WriteLine("Was able to open dev " + dev.Name + " - " + addr);
                         device = dev;
                     }
                     catch (Exception e2)
                     {
                         Console.WriteLine("Couldn't open device " + dev.Name );
                     }
                     * */
                    if (descr.Contains("192.168.0.186"))
                    //if (descr.Contains("10.20.11.11"))
                    {
                        Console.WriteLine("Will use this one for test: \n" + descr);
                        device = dev;
                        break;
                    }
                    Console.WriteLine("{0}\n", dev.ToString());
                }
                //Console.WriteLine("Choose device");
                //String s2 = Console.ReadLine();
                int index = 1;// Convert.ToInt16(s2);
                if (device == null)
                {
                    //    Console.Write("Test device (192.168...) not found. Hit 'Enter' to exit...");
                    //    Console.ReadLine();
                    //    int i = 1;
                    device = devices[index];
                }
                //sock = new Socket(AddressFamily.DataLink, SocketType.Raw, ProtocolType.RAW);
                //sock.SetSocketOption(

            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error creating raw socket: " + e.Message);
            }
        }

        private static void device_OnPacketArrival(object sender, CaptureEventArgs captureEventArgs)
        {
            LinkLayers ethType = captureEventArgs.Packet.LinkLayerType;

            // Is it my special packet?  (TBD: compile filter)
            if (captureEventArgs.Packet.Data[12] == 8 &&
                captureEventArgs.Packet.Data[13] == 0 &&
                captureEventArgs.Packet.Data[14] == 1)
            {

                DateTime time = captureEventArgs.Packet.Timeval.Date;
                int len = captureEventArgs.Packet.Data.Length;
                Console.WriteLine("{0}:{1}:{2},{3} Len={4}  type = {5}",
                    time.Hour, time.Minute, time.Second, time.Millisecond, len, ethType);
                for (int i = 0; i < len; i++)
                {
                    int v = captureEventArgs.Packet.Data[i];
                    string hexValue = v.ToString("X2");
                    Console.Write(hexValue + " ");
                }
                Console.WriteLine();//System.Text.ASCIIEncoding.ASCII.GetString(captureEventArgs.Packet.Data));
            }
        }

        public void shutdown()
        {
            if (device != null)
            {
                device.StopCapture();
                device.Close();
                device = null;
            }
        }

        public void startPacketListener()
        {
            if (device == null)
            {
                Console.WriteLine( "no adapter selected");
                // will throw null pointer exception
            }
//            Byte[] datagram = new Byte[4096];
//            IPEndPoint endPoint;
//            IPAddress address = null;
            // Create listener
            device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);

            device.Open(DeviceMode.Normal, 15000);  // 15 sec timeout
            device.StartCapture();
            Console.WriteLine("Listening for packets");
//            Console.ReadLine();
            // user says 'done'
//            device.StopCapture();
//            device.Close();



//            return System.Text.ASCIIEncoding.ASCII.GetString(datagram);
        }

        private ushort csum(byte[] buf, int nwords)
        {
            ulong sum;
            int i;
            for (sum = 0, i = 0; nwords > 0; nwords--)
            {
                sum += buf[i++];
            }
            sum = (sum >> 16) + (sum & 0xffff);
            sum += (sum >> 16);
            return (ushort)~sum;
        }

        public int sendPacket()
        {
            byte[] bytes = new byte[4096];
            ByteArraySegment bas = new ByteArraySegment(bytes);
            ushort srcPort = 23444;
            ushort dstPort = 12345;

            PacketDotNet.UdpPacket udpPacket = new UdpPacket(srcPort, dstPort);
            string cmdString = "xxxxyyyyHello world!";
            byte[] sendBuffer = Encoding.ASCII.GetBytes(cmdString);
            udpPacket.PayloadData = sendBuffer;

            ICMPv4Packet icmpPacket = new ICMPv4Packet(new ByteArraySegment(sendBuffer));
            // sanity check:
            //bas.BytesLength = 10;
            //Console.WriteLine("bas - Offset = " + bas.Offset + " len= " + bas.Length);
            
            IPAddress ipSrcAddr = System.Net.IPAddress.Parse("192.168.0.186"); // laptop
            IPAddress ipDestAddr = System.Net.IPAddress.Parse("192.168.0.185"); // my linux box
            IpPacket ipPacket = new IPv4Packet(ipSrcAddr, ipDestAddr);
            ipPacket.PayloadPacket = udpPacket;

            icmpPacket.TypeCode = ICMPv4TypeCodes.Unassigned1;
            icmpPacket.Sequence = 1;

            Console.WriteLine("icmpPacket - TypeCode = " + icmpPacket.TypeCode + " Sequence= " + icmpPacket.Sequence);
            Console.WriteLine("icmpPacket : " + icmpPacket.PrintHex());
            icmpPacket.UpdateCalculatedValues();
            Console.WriteLine("icmpPacket : " + icmpPacket.PrintHex());

            //ushort etype = 0xFF00; //EthernetPacketType RAW ?
            System.Net.NetworkInformation.PhysicalAddress ethSrcAddr = System.Net.NetworkInformation.PhysicalAddress.Parse("02-1E-EC-8F-7F-E1");
            System.Net.NetworkInformation.PhysicalAddress ethDstAddr = System.Net.NetworkInformation.PhysicalAddress.Parse("48-5B-39-ED-96-36");
            EthernetPacket ethernetPacket = new EthernetPacket(ethSrcAddr, ethDstAddr, EthernetPacketType.IpV4);
            // I thought "None" for type would fill in type automatically; but it remained zero on the wire and was flagged "Malformed"
            ethernetPacket.PayloadPacket = icmpPacket;
            Console.WriteLine("ethernetPacket : " + ethernetPacket.PrintHex());
            ethernetPacket.Type = EthernetPacketType.IpV4;
            
            Console.WriteLine("ethernetPacket : " + ethernetPacket.PrintHex());

            //ipPacket.PayloadPacket = udpPacket;
            //ethernetPacket.PayloadPacket = gmpPacket; //ipPacket;
            ethernetPacket.UpdateCalculatedValues();
            Console.WriteLine(ethernetPacket.ToString());

            ipPacket.UpdateCalculatedValues();
            //udpPacket.UpdateUDPChecksum();
            // Experiment with raw ip packet?
            ipPacket.Protocol = IPProtocolType.RAW;

            // Why isn't ValidChecksum true?
            //Console.WriteLine("After updating calculated values, ValidUDPChecksum = " + udpPacket.ValidUDPChecksum + " ValidChecksum = " + udpPacket.ValidChecksum);
            //Console.WriteLine(ethernetPacket.ToString());

            device.Open(DeviceMode.Normal, 15000);  // 15 sec timeout

            //ushort checksum = csum(ipPacket.BytesHighPerformance, ipPacket.P);
            device.SendPacket(ethernetPacket);

            return 0;
        }

        public void sendUDP()
        {
            string cmdString = "Hello world!";
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.185"), 12345);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.186"), 10000);
            //Byte[] data = new Byte[120];
            //ByteArraySegment bas = new ByteArraySegment(data);
            //UdpClient udpClient = new UdpClient("192.168.0.186", 12345);
            //UdpPacket udpPacket = new UdpPacket(
            //udpClient.Send(bas);
        //    Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            UdpClient udpClient = new UdpClient(11000);  // local port binding

            byte[] sendBuffer = Encoding.ASCII.GetBytes(cmdString);
            try
            {

        //        sock.SendTo(sendBuffer, ipEndPoint);
                udpClient.Connect(remoteEndPoint);
                udpClient.Send(sendBuffer, sendBuffer.Length);
                Console.WriteLine("Packet sent: " + cmdString);
                udpClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error sending packet: " + e.Message);
            }

            UdpClient udpClientB = new UdpClient();
            udpClientB.Send(sendBuffer, 12, "192.168.0.185", 12345);
            Console.WriteLine("Alt msg sent");
            udpClientB.Close();
        }
    }
}
