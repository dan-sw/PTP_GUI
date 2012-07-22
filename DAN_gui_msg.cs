using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpPcap;
using PacketDotNet;
using PacketDotNet.Utils;
//using System.Net;

using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public class DAN_gui_msg
    {
        // TODO: Why aren't EthernetFields.HeaderLength and IPv4Fields.HeaderLength constant?
        const int EthernetPktHeaderLength = 14;
        const int IPv4PktHeaderLength = 20;  // constant, at least, for the types of packets I've filtered

        // These offsets are used to unmarshal the fields from within a raw ethernet packet ....
        const int DAN_MSG_OFFSET_WITHIN_RAW_PACKET = EthernetPktHeaderLength + IPv4PktHeaderLength;
        const int DAN_MSG_CMD_OFFSET = 0;
        const int DAN_MSG_SIZ_OFFSET = 1;
        const int DAN_MSG_SEQ_OFFSET = 2;
        const int DAN_MSG_ADD_OFFSET = 4;
        const int DAN_MSG_DAT_OFFSET = 8;
        public const int DAN_MSG_CMD_OFFSET_WITHIN_RAW_PACKET = DAN_MSG_OFFSET_WITHIN_RAW_PACKET + DAN_MSG_CMD_OFFSET;
        const int DAN_MSG_SIZ_OFFSET_WITHIN_RAW_PACKET = DAN_MSG_OFFSET_WITHIN_RAW_PACKET + DAN_MSG_SIZ_OFFSET;
        const int DAN_MSG_SEQ_OFFSET_WITHIN_RAW_PACKET = DAN_MSG_OFFSET_WITHIN_RAW_PACKET + DAN_MSG_SEQ_OFFSET;
        const int DAN_MSG_ADD_OFFSET_WITHIN_RAW_PACKET = DAN_MSG_OFFSET_WITHIN_RAW_PACKET + DAN_MSG_ADD_OFFSET;
        const int DAN_MSG_DAT_OFFSET_WITHIN_RAW_PACKET = DAN_MSG_OFFSET_WITHIN_RAW_PACKET + DAN_MSG_DAT_OFFSET;
        const int DAN_MSG_LENGTH = 8;
//        const int DAN_GUI_MESSAGE_IP_V = 1;

        public enum MSG_TYPE {
            CMD_READ32       =    0,
	        CMD_WRITE32      =    1,
	        CMD_READ_ARRAY32 =    2,
	        RSP_READ         = 0x10,
	        RSP_READ_ARRAY   = 0x12
        };

        private static UInt16 nextSeq;

        public byte msgType { get; set; }
        public byte size { get; set; }
        public UInt16 seq { get; set; }
        public UInt32 address { get; set; }
        public UInt32[] data { get; set; }
     //   public double[] data { get; set; }
        // Static constructor called once, automatically, first time class is loaded
        static DAN_gui_msg()
        {
            nextSeq = 0;
        }

        protected UInt16 getNextSeq()
        {
            return nextSeq++;
        }

            public DAN_gui_msg()
            {
                msgType = 0;
                size = 0;
                seq = 0;
                address = 0;
                data = null;
            }

            public DAN_gui_msg(byte type, byte sz, UInt16 sq, UInt32 addr)
            {
                msgType = type;
                size = sz;
                seq = sq;
                address = addr;
                data = null;
            }

        // Unmarshal the DAN message fields from within a byte array.
        // The array is expected to be a raw ethernet packet, so the offset
        // of the DAN message fields include room for an Ethernet header and
        // the standard-size IPv4 header that the SOC sends.
            public static DAN_gui_msg unmarshal(byte[] bytes)
            {
                //Console.WriteLine(" Size of DAN_GUI_msg = {0}; bas.Length = {1}, bas.BytesLength={2}",
                //    Marshal.SizeOf(typeof(DAN_GUI_msg)), bas.Length, bas.BytesLength);
                DAN_gui_msg rv = new DAN_gui_msg();

                rv.msgType = bytes[DAN_MSG_CMD_OFFSET_WITHIN_RAW_PACKET];
                rv.size = bytes[DAN_MSG_SIZ_OFFSET_WITHIN_RAW_PACKET];
                //rv.seq = MiscUtil.Conversion.EndianBitConverter.Little.ToUInt16(bytes, DAN_MSG_SEQ_OFFSET_WITHIN_RAW_PACKET);
                rv.seq = BitConverter.ToUInt16(bytes, DAN_MSG_SEQ_OFFSET_WITHIN_RAW_PACKET);
                rv.address = MiscUtil.Conversion.EndianBitConverter.Little.ToUInt32(bytes, DAN_MSG_ADD_OFFSET_WITHIN_RAW_PACKET);
                
                if (rv.msgType == (byte)MSG_TYPE.RSP_READ || // "OneWord Read" response
                    rv.msgType == (byte)MSG_TYPE.RSP_READ_ARRAY) // "Block Read" response
                {
                    // Data payload is an array of uint32 (memory words from the SOC at address)
                    int offsetOfDanData = DAN_MSG_DAT_OFFSET_WITHIN_RAW_PACKET;
                    // special case - zero length -> 256 
                    int dataWords = rv.size == 0 ? 256 : rv.size;
                    rv.data = new UInt32[dataWords];

                    for (int i = 0; i < dataWords; i++)
                    {
                        rv.data[i] = BitConverter.ToUInt32(bytes, offsetOfDanData);
                        offsetOfDanData += 4;
                    }
                }
                else
                {
                    // todo: Ignore (by filter) packets coming from me (requests)
                    Console.WriteLine(" Ignoring DAN message type = " + rv.msgType);
                }


                return rv;
            }

        // Creates a byte array appropriate for sending to SOC
        // Shortcut:  only supports CMD type messages (which are sent by this app, 
        // not RSP type messages, which are only sent by SOC.)
            public byte[] marshal()
            {
                int sizeNeeded = DAN_MSG_LENGTH;
                if (msgType == (byte) MSG_TYPE.CMD_WRITE32)
                {
                    System.Diagnostics.Debug.Assert(data != null && data.Length == 1);
                    sizeNeeded += 4; // sizeof(UInt32)
                }
                byte[] rv = new byte[sizeNeeded];
                // TODO: stuff
                rv[DAN_MSG_CMD_OFFSET] = msgType;
                rv[DAN_MSG_SIZ_OFFSET] = size;

                //MiscUtil.Conversion.EndianBitConverter.Little.CopyBytes(seq, rv, DAN_MSG_SEQ_OFFSET);
                Array.Copy(BitConverter.GetBytes(seq), 0, rv, DAN_MSG_SEQ_OFFSET, 2); // 2==sizeof(UInt16)
                MiscUtil.Conversion.EndianBitConverter.Little.CopyBytes(address, rv, DAN_MSG_ADD_OFFSET);

                if (msgType == (byte)MSG_TYPE.CMD_WRITE32)
                {
                    MiscUtil.Conversion.EndianBitConverter.Little.CopyBytes(data[0], rv, DAN_MSG_DAT_OFFSET);
                }
                return rv;
            }


            public void print()
            {
                Console.WriteLine(" MsgType 0x{0}   size {1}  seq {2}   address 0x{3}",
                    msgType.ToString("X2"), size, seq, address.ToString("X2"));

                if ((msgType == (byte)MSG_TYPE.RSP_READ || // "OneWord Read" response
                    msgType == (byte)MSG_TYPE.RSP_READ_ARRAY) && // "Block Read" response
                    data != null)
                {
                    for (int i = 0; i < size; i++)
                    {
                        Console.WriteLine("    {0}: {1}", i, data[i].ToString("X2"));
                    }
                }
            }
    }

    public class DAN_read_msg : DAN_gui_msg
    {
        public DAN_read_msg(UInt32 addr)
        {
            this.msgType = (byte) MSG_TYPE.CMD_READ32;
            this.size = 1;
            this.seq = getNextSeq();
            this.address = addr;
        }
    }
    public class DAN_read_array_msg : DAN_gui_msg
    {
        public DAN_read_array_msg(UInt32 addr, byte length)
        {
            this.msgType = (byte)MSG_TYPE.CMD_READ_ARRAY32;
            this.size = length;
            this.seq = getNextSeq();
            this.address = addr;
        }
    }
    public class DAN_write_msg : DAN_gui_msg
    {
        public DAN_write_msg(UInt32 addr, UInt32 val)
        {
            this.msgType = (byte)MSG_TYPE.CMD_WRITE32;
            this.size = 1;
            this.seq = getNextSeq();
            this.address = addr;
            this.data = new UInt32[1];
            this.data[0] = val;
        }
    }
}
