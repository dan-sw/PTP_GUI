using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpPcap;
using SharpPcap.LibPcap;
using PacketDotNet;
using PacketDotNet.Utils;
using System.Net;
using System.Net.NetworkInformation;

using System.Runtime.InteropServices;



namespace WindowsFormsApplication1
{

    class PcapConnection
    {
        public static PcapConnection pcap = new PcapConnection();
        public ICaptureDevice device { get; set; }
        public string targetMAC { get; set; }
        public LibPcapLiveDeviceList devices { get; protected set; }

        static int DAN_GUI_MESSAGE_IP_V = 1;
        private List<MessageReplyListener> listeners;
        private IPAddress ipSrcAddr;
        private IPAddress ipDestAddr;
        private PhysicalAddress ethDstAddr;


        private PcapConnection()
        {
            init();
        }

            // tbd: want to automatically open device, if only one is available?
            void init( )
            {
                listeners = new List<MessageReplyListener>();
                targetMAC = null;
                device = null;
                // Retrieve the device list
                devices = SharpPcap.LibPcap.LibPcapLiveDeviceList.Instance;

                // If no devices were found print an error
                if (devices.Count < 1)
                {
                    Console.WriteLine("No devices were found on this machine");
                    return;
                }

            }

        // TODO: Does not work, does not re-read device list.  
//        public void restart()
//        {
//            stopDevice();
//             
//            devices = SharpPcap.LibPcap.LibPcapLiveDeviceList.Instance;
//        }

        // Intended to be called on the GUI thread; shows a progress dialog as it
        // sends a message and verifies reply.
        // Returns 'true' if success.
        public bool connect()
        {
            bool rv = false;
            if (device == null || targetMAC == null)
            {
                Console.WriteLine("Missing adapter or MAC!");
                return rv;
            }
            try
            {
                device.Open(DeviceMode.Normal, 1500);  // 1.5 sec timeout
                // Set a filter for DAN GUI mgmt type messages
                string myMac = device.MacAddress.ToString();
                myMac = myMac.Insert(10, ":")
                .Insert(8, ":")
                .Insert(6, ":")
                .Insert(4, ":")
                .Insert(2, ":");
                string filter = "ip and ip[0]==21 and not ether src " + myMac;
                device.Filter = filter;

                // Even though this protocol works fine without IP addresses, they
                // are added to the IP packet.  It may help with debugging via Wireshark,
                // and may be needed for other capabilities, such as TFTP. 
                // pcap.sendDanMsg() expects them in ipSrcAddr and ipDestAddr
                string[] parsedDevDescr = parseDeviceDescription(device);
                ipSrcAddr = System.Net.IPAddress.Parse(parsedDevDescr[0]); // IP dotted notation
                ipDestAddr = System.Net.IPAddress.Parse("192.168.1.10"); // default EVB addr
                ethDstAddr = PhysicalAddress.Parse(targetMAC);// "02-DE-AD-BE-EF-03");

                // Send a test message
                {
                    //uint BaseaddressGMAC1 = 0xE577E000;
                    //uint RxBcastFramesRecdOffset = 0x18c;
                    UInt32 PHYbase = 0xe0458000; byte len = 8;
                    //UInt32 PHYdata = 0xd0000000; byte len = 0;
                    uint register = PHYbase; //BaseaddressGMAC1 + RxBcastFramesRecdOffset;
                    //Console.WriteLine("Requesting counter Gmac1.rxBroadcastFramesRecd at {0}", register.ToString("X2"));
                    // TESTING!!
                    //DAN_read_msg msg = new DAN_read_msg(register);
                    DAN_read_array_msg msg = new DAN_read_array_msg(register, len);  // 0 -> 256
                    DAN_gui_msg responseMsg = null;
                    pcap.sendDanMsg(msg);
                    for (int loopCounter = 0; loopCounter < 3; loopCounter++)
                    {  // due to capture filter not filtering out my own packets... repeat
                        SharpPcap.RawCapture rawCapture = pcap.device.GetNextPacket();
                        responseMsg = pcap.parsePacket(rawCapture);
                        if (responseMsg != null)
                        {
                            int msgSize = msg.size == 0 ? 256 : msg.size;
                            Console.WriteLine("Requested {1} 32-bit words at {0}", msg.address.ToString("X8"), msgSize);
                            for (int i = 0; i < msgSize; i += 4)
                            {
                                Console.WriteLine("{0:x8} {1:x8} {2:x8} {3:x8} ", responseMsg.data[i], responseMsg.data[i + 1], responseMsg.data[i + 2], responseMsg.data[i + 3]);
                            }
                            rv = true;

                            break;
                        }
                    }
                    return rv;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error opening device: " + e.Message);
                stopDevice(); // clears property 'device'
                return rv;
            }
        }
            

        public void stopDevice()
        {
            if (device != null)
            {
                device.StopCapture();
                device.Close();
                device = null;
            }
        }

        public DAN_gui_msg parsePacket(RawCapture packet)
        {
            if (packet == null)
            {
                return null;
            }
            int wtf = DAN_gui_msg.DAN_MSG_CMD_OFFSET_WITHIN_RAW_PACKET;
            byte cmd = packet.Data[wtf];
            //Console.WriteLine("Inspecting packet with {0} at byte[{1}]", cmd.ToString("X2"), wtf.ToString("X2"));
            if (packet.Data[12] == 8 &&
                packet.Data[13] == 0 &&
                packet.Data[14] == 0x15 &&
                (packet.Data[DAN_gui_msg.DAN_MSG_CMD_OFFSET_WITHIN_RAW_PACKET] >= (byte)DAN_gui_msg.MSG_TYPE.RSP_READ))
            {
                ByteArraySegment bas = new ByteArraySegment(packet.Data, EthernetFields.HeaderLength, IPv4Fields.HeaderLength);
                IpPacket ipPacket = new IPv4Packet(bas);
                DAN_gui_msg responseMessage = DAN_gui_msg.unmarshal(packet.Data);
                //responseMessage.print();
                return responseMessage;
            }
            else
            {
                return null;
            }
        }
        private static void device_OnPacketArrival(object sender, CaptureEventArgs captureEventArgs)
        {
            LinkLayers ethType = captureEventArgs.Packet.LinkLayerType;

            // Is it my special packet?  (TBD: compile filter)
            if (captureEventArgs.Packet.Data[12] == 8 &&
                captureEventArgs.Packet.Data[13] == 0 &&
                captureEventArgs.Packet.Data[14] == 0x15)  // DAN_GUI_MESSAGE_IP_V << 4 | IP_HEADER_DAN_GUI_LENGTH
            {
                // Quietly ignore packets that were generated by this machine - requests
                byte cmd = captureEventArgs.Packet.Data[DAN_gui_msg.DAN_MSG_CMD_OFFSET_WITHIN_RAW_PACKET];

                if (cmd < (byte) DAN_gui_msg.MSG_TYPE.RSP_READ)
                {
                    // Ignore DAN request messages.  Should never come thru here, if
                    // the packet filter is working as intended.
                    return;
                }
                DateTime time = captureEventArgs.Packet.Timeval.Date;
                //int len = captureEventArgs.Packet.Data.Length;
                //Console.WriteLine("{0}:{1}:{2},{3} Len={4}  type = {5}",
                //    time.Hour, time.Minute, time.Second, time.Millisecond, len, ethType);
                if (ethType != LinkLayers.Ethernet)
                {
                    Console.WriteLine("Unexpected ethType {0}, ignored!", ethType);
                    return;
                }
                ByteArraySegment bas = new ByteArraySegment(captureEventArgs.Packet.Data, EthernetFields.HeaderLength, IPv4Fields.HeaderLength);
                IpPacket ipPacket = new IPv4Packet(bas);
                DAN_gui_msg responseMessage = DAN_gui_msg.unmarshal(captureEventArgs.Packet.Data);
                //responseMessage.print();
                System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
                st.Start();

                // The listeners may remove themselves during the callback.  To avoid
                // concurrentModificationException, use a duplicate of the collection
                // for iteration
                List<MessageReplyListener> listenersCopy = new List<MessageReplyListener>(pcap.listeners);
                MessageReplyListener lastListener = null;
                foreach (MessageReplyListener l in listenersCopy)
                {
                    lastListener = l;
                    st.Restart();
                    if (l.MessageReplyListenerCallback(responseMessage, time))
                    {
                        break; //was handled
                    }
                    if (st.ElapsedMilliseconds > 20)
                    {
                        System.Console.WriteLine("Bug? Handler {2} took {0} ms: {1}", st.ElapsedMilliseconds, responseMessage.ToString(), l.ToString ());
                    }
                }
                if (st.ElapsedMilliseconds > 20 )
                {
                    if (lastListener == null)
                    {
                        System.Console.WriteLine("This is weird");
                    }
                    else
                    {
                        System.Console.WriteLine("Bug? Handler {2} took {0} ms: {1}", st.ElapsedMilliseconds, responseMessage.ToString(), lastListener.ToString());
                    }
                }
            }
        }

        public void startPacketListener()
        {
            if (device == null)
            {
                Console.WriteLine( "no adapter selected");
                // will throw null pointer exception
            }
            // Create listener
            device.OnPacketArrival += new PacketArrivalEventHandler(device_OnPacketArrival);
            device.Open(DeviceMode.Normal, 15000);  // 15 sec timeout
            device.StartCapture();
            Console.WriteLine("Listening for packets");
        }

        public void sendDanMsg(DAN_gui_msg message)
        {
            byte[] bytes = message.marshal();

            // IP addressing is not needed; just keeping entertained...
            IpPacket ipPacket = new IPv4Packet(ipSrcAddr, ipDestAddr);
            ipPacket.PayloadData = bytes;
            ipPacket.UpdateCalculatedValues();

            ipPacket.Version = (PacketDotNet.IpVersion)DAN_GUI_MESSAGE_IP_V;

            EthernetPacket ethernetPacket = new EthernetPacket(device.MacAddress, ethDstAddr, EthernetPacketType.IpV4);
            ethernetPacket.PayloadPacket = ipPacket;

            device.SendPacket(ethernetPacket);
        }


        // Util to parse ICaptureDevice.ToString() into the fields of interest,
        // an array of 3 strings containing Name, GW address, and IP address
        public static string[] parseDeviceDescription(ICaptureDevice dev)
        {
            char[] separators = new char[] { '\n', ':' };
            string name = "";
            string gwAddress = "";
            string ipAddress = "";

            //            Console.WriteLine("Parsing Device: {0}", dev);
            string[] splitStr = dev.ToString().Split(separators);
            for (int i = 0; i < splitStr.Length; i++)
            {
                if (splitStr[i].Equals("FriendlyName"))
                {
                    name = splitStr[i + 1].Trim();
                }
                else if (splitStr[i].Equals("GatewayAddress"))
                {
                    gwAddress = splitStr[i + 1].Trim();
                }
                else if (splitStr[i].Equals("Addr"))
                {
                    // could be IPv6, IPv4 or MAC addr entry
                    if (splitStr[i + 1].Contains('.'))
                    {
                        // The IPv4 addr
                        ipAddress = splitStr[i + 1].Trim();
                    }
                }
            }
            // Fallback, could be needed if constant strings used above
            // are EN-US locale dependent (I haven't tested this in other locales)
            if (name.Length == 0)
            {
                // non english output?
                if (splitStr.Length > 7)
                {
                    name = splitStr[4].Trim();
                    gwAddress = splitStr[6].Trim();
                }
            }
            // one last fallback
            if (name.Length == 0)
            {
                name = dev.ToString();
            }
            return new string[] { ipAddress, name };
        }


        public void addListener(MessageReplyListener listener)
        {
            listeners.Add(listener);
        }

        public void removeListener(MessageReplyListener listener)
        {
            listeners.Remove(listener);
        }

        /*
         * A listener for specific replies (e.g., the Memory Viewer)
         * should use this method to be put at the start of the list.  
         *   Most listeners will consume any message that contains data
         * (specified by address) they know about.  That prevents
         * subsequent listeners from getting messages about the same address.
         */
        public void addSeqListener(MessageReplyListener listener)
        {
            listeners.Insert(0, listener);
        }
    }
}
