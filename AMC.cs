using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class AMC : MessageReplyListener
    {        
        private const UInt32 baseAddress = 0xe0458000;
        private const int AMC_MODE_index = 1;
        private const int CINR_SIM_index = 2;
        private const int MMTX_START_index = 3;
        private const int MAN_MCS_0_index = 4;
        private const int MAN_MCS_1_index = 5;
        private const int CINR_SIM_0_index = 6;
        private const int CINR_SIM_1_index = 7;
        private const int REG_COUNT = 8;
        // The following (adjacent) locations are already present in PHY:
        //private const int CINR_AVG_0_index = 8;
        //private const int CINR_AVG_1_index = 9;
        //private const int SHAPER_VAL_index = 10;

        /* Primarily for documentation, these names do not currently appear in the GUI: */
        private static String[] registerNames = {
            "magic",
            "AMC Mode",
            "CINR Sim Mode",
            "MM Tx Start",
            "Man MCS Ant 0",
            "Man MCS Ant 1",
            "CINR Sim Ant 0",
            "CINR Sim Ant 1"  };

        // TODO: This might belong somewhere else.  Not currently used by FormSystemStatus, which converts decimal -> db.
        // (In fact, not currently used at all.)
       // public static decimal CinrInDb(UInt32 cinr) { return cinr / 32.0m; }

        private bool autoAMC;
        private bool cinrSimMode = false;
        private uint mcsManualId0 = 0;
        private uint mcsManualId1 = 0;
        private uint cinrManualSetting0;
        private uint cinrManualSetting1;

        public static AMC amc = new AMC();

        public bool AutoAMC
        {
            get
            { return autoAMC; }
            set
            {
                if (value != AutoAMC)
                {
                    // write change to EVB
                    uint newVal = (uint)(value ? 0 : 1);
                    DAN_write_msg msg = new DAN_write_msg(baseAddress + (4 * AMC_MODE_index), newVal);
                    PcapConnection.pcap.sendDanMsg(msg);
                    // refresh my cached values
                    getNextValues();
                }
            }
        }
        
        public bool CinrSimMode 
        {
            get
            {
                return cinrSimMode;
            }
            set
            {
                // write value to EVB if different
                if (value != cinrSimMode)
                {
                    DAN_write_msg msg = new DAN_write_msg(baseAddress + (4 * CINR_SIM_index), (uint)(value ? 1 : 0));
                    PcapConnection.pcap.sendDanMsg(msg);
                    // refresh my cached values
                    getNextValues();
                }
            }
        }        

        public uint McsManualId0
        {
            get { return mcsManualId0; }
            set
            {
               if (value > MCS.getMaxMCS())
                {
                    System.Console.WriteLine("Invalid input limited to Max MCS");
                    value = MCS.getMaxMCS();
                }
               if (value != mcsManualId0)
               {
                   mcsManualId0 = value;
                   DAN_write_msg msg = new DAN_write_msg(baseAddress + (4 * MAN_MCS_0_index), value);
                   PcapConnection.pcap.sendDanMsg(msg);
                   // refresh my cached values
                   getNextValues();
               }
                
            }
        }        

        public uint McsManualId1
        {
            get { return mcsManualId1; }
            set
            {
                if (value > MCS.getMaxMCS())
                {
                    System.Console.WriteLine("Invalid input limited to Max MCS");
                    value = MCS.getMaxMCS();
                }
                if (value != mcsManualId1)
                {
                    mcsManualId1 = value;
                    DAN_write_msg msg = new DAN_write_msg(baseAddress + (4 * MAN_MCS_1_index), value);
                    PcapConnection.pcap.sendDanMsg(msg);
                    // refresh my cached values
                    getNextValues();
                }
            }
        }        

        public UInt32 CinrManualSetting0 { get { return cinrManualSetting0; }
            set {
                // Write to EVB if different
                if (value != cinrManualSetting0)
                {
                    DAN_write_msg msg = new DAN_write_msg(baseAddress + (4 * CINR_SIM_0_index), value);
                    PcapConnection.pcap.sendDanMsg(msg);
                    // refresh my cached values
                    getNextValues();
                }

            }
        }

        public UInt32 CinrManualSetting1
        {
            get { return cinrManualSetting1; }
            set
            {
                // Write to EVB if different
                if (value != cinrManualSetting1)
                {
                    DAN_write_msg msg = new DAN_write_msg(baseAddress + (4 * CINR_SIM_1_index), value);
                    PcapConnection.pcap.sendDanMsg(msg);
                    // refresh my cached values
                    getNextValues();
                }

            }
        }                

        private AMC()
        {
            // Register for message responses
            PcapConnection.pcap.addListener(this);
        }

        // Returns true if the msg represents data for this listener; false if 
        // the address is not recognized (reply is for some other listener)
        public bool MessageReplyListenerCallback(DAN_gui_msg msg, DateTime arrivalTime)
        {
            if (msg.address == baseAddress)
            {
                if (msg.size != REG_COUNT) 
                {
                    Console.WriteLine("Bug: AMC unexpected reply, len > REG_COUNT");
                    // Ret TRUE so other objects aren't called to examine this msg
                    return true;
                }
                // AMC Auto mode
                autoAMC = msg.data[AMC_MODE_index] == 0 ? true : false;
                cinrSimMode = msg.data[CINR_SIM_index] == 1 ? true : false;
                mcsManualId0 = msg.data[MAN_MCS_0_index];
                mcsManualId1 = msg.data[MAN_MCS_1_index];
                cinrManualSetting0 = msg.data[CINR_SIM_0_index];
                cinrManualSetting1 = msg.data[CINR_SIM_1_index];

                //cinrAmcAveragedCinr0 = msg.data[CINR_AVG_0_index];
                //cinrAmcAveragedCinr1 = msg.data[CINR_AVG_1_index];
                return true;
            }
            return false;
        }

        // Request register contents
        public void getNextValues()
        {
            // Responses are handled on another thread
            DAN_read_array_msg msg = new DAN_read_array_msg(baseAddress, REG_COUNT);
            PcapConnection.pcap.sendDanMsg(msg);

        }


    }
}
