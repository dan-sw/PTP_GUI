using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class PHY : MessageReplyListener
    {
        #region Var
        /* New info from Oren 26-Oct-11:
         *         Phy measurements:
         * dm -4 0xd0190020 4
         * RSSI0 RSS1 CINR0 CINR1
         * 
         * Minimac averaged CINR (affected by simulation mode):
         * Dm -4 0xe0458020 2
         * CINR ant 0, CINR ant 1
         */
        // So, we will issue 3 block requests, for these groups
        private const int BLOCK_COUNT = 8; 
        private readonly string[] blockNames = { "CRCNACKThruCINR", "AVG_CINRsAndTbCounts", "PHY_ctrl_channel", "PLL_TX_Ant0", "PLL_TX_Ant1", "BER_Counters", "Uncoded_BER","Info_structure"};
        private readonly UInt32[] blockAddrs = { 0xd0190000, 0xe0458020, 0xe0458c10, 0xc652002c, 0xc652402c, 0xd0190400, 0xd0190350, 0xe0456c20};
        private readonly byte[] blockWordCounts = { 20, 12, 3, 1, 1, 8, 8, 8};

        // Block 0 
        private const int CRCNACKDATA_index = 0;
        private const int CRCACKDATA_index = 1;
        private const int CRCNACKCTRL_index = 2;
        private const int CRCACKCTRL_index = 3;
        private const int STO1_index = 4;
        private const int STO2_index = 5;
        private const int RSSI1_index = 8;
        private const int RSSI2_index = 9;
        private const int CINR1_index = 10; // 0xd0190028
        private const int CINR2_index = 11;
        private const int DC0_index = 12;
        private const int DC1_index = 13;
        private const int XPI0_index = 14;
        private const int XPI1_index = 15;
        private const int NACK0_index = 16; // 0xd0190040
        private const int ACK0_index = 17;
        private const int NACK1_index = 18;
        private const int ACK1_index = 19;

        // Block 1
        private const int CINR1Avg_index = 0;  // 0xe0458020
        private const int CINR2Avg_index = 1;
        private const int SHAPERVAL_index = 2;
        private const int TXNUMTBS_index = 4;
        private const int TXNUMFRAMES_index = 5;
        private const int RXNUMTBS_index = 6;
        private const int RXNUMFRAMES_index = 7;
        private const int RXBADTBS0_index = 8;
        private const int RXBADTBS1_index = 9;
        private const int TXNUMFRAMEINDS_index = 10;
        private const int RXNUMFRAMEINDS_index = 11;
        // Block 2
        private const int TXCHANHI_index = 0;
        private const int RXCHANHI_index = 2;

        // Block 3
        private const int PLL_TX_Ant0_Freq_Offset = 0;

        // Block 4 
        private const int PLL_TX_Ant1_Freq_Offset = 0;

        // Block 5
        private const int Error_bits_accumulator_Ant0 = 0;
        private const int Error_bits_accumulator_Ant1 = 1;
        private const int Enabling_BER_counting = 2;
        private const int Good_bits_counting1_Ant0 = 4;
        private const int Good_bits_counting2_Ant0 = 5;
        private const int Good_bits_counting1_Ant1 = 6;
        private const int Good_bits_counting2_Ant1 = 7;

        // Block 6 
        private const int PLL_RX_Ant0_Freq_Offset = 0;

        //Block 7
        private const int Uncoded_BER_Acc_Error_bits_Ant0 = 0;
        private const int Uncoded_BER_Acc_Error_bits_Ant1 = 1;
        private const int Uncoded_BER_Error_bits_Last_TB_Ant0 = 2;
        private const int Uncoded_BER_Error_bitsLast_TB_Ant1 = 3;
        private const int Uncoded_BER_Num_Of_Words_Acc = 6;
        private const int Uncoded_BER_Num_Of_Frames_Acc = 7;

        //Block 8
        private const int Isync_Peak_str = 0;
        private const int Isync_Freq_str = 1;
        private const int Link_status_str = 2;
        private const int MCS_Set_str = 3;
        private const int rf_Type_str = 4;

        private delegate void ProcessMessageDelegate(DAN_gui_msg msg); 
        private ProcessMessageDelegate[] handlers;

        // CRC results, data and control
        private UInt32 baseNackData = 0;
        private UInt32 nackData;
        public UInt32 NackData { get { return nackData - baseNackData; } }
        private UInt32 baseAckData = 0;
        private UInt32 ackData;
        public UInt32 AckData { get { return ackData - baseAckData; } }
        private UInt32 baseNackCtrl = 0;
        private UInt32 nackCtrl;
        public UInt32 NackCtrl { get { return nackCtrl - baseNackCtrl; } }
        private UInt32 baseAckCtrl = 0;
        private UInt32 ackCtrl;
        public UInt32 AckCtrl { get { return ackCtrl - baseAckCtrl; } }

        // ACK/NACK per antenna
        private UInt32 baseNack0 = 0;
        private UInt32 nack0;
        public UInt32 NACK0 { get { return nack0 - baseNack0; } }
        private UInt32 baseAck0 = 0;
        private UInt32 ack0;
        public UInt32 ACK0 { get { return ack0 - baseAck0; } }
        private UInt32 baseNack1 = 0;
        private UInt32 nack1;
        public UInt32 NACK1 { get { return nack1 - baseNack1; } }
        private UInt32 baseAck1 = 0;
        private UInt32 ack1;
        public UInt32 ACK1 { get { return ack1 - baseAck1; } }
       
        // BER Check
        public UInt64 BER_Error_bits_Ant0 { get; private set; }
        public UInt64 BER_Good_bits_Ant0 { get; private set; }
        public UInt64 BER_Error_bits_Ant1 { get; private set; }
        public UInt64 BER_Good_bits_Ant1 { get; private set; }
        public UInt32 Enable_BER_Counter { get; private set; }

        //Uncoded BER
        public UInt64 Uncoded_BER_Error_bits_Ant0 { get; private set; }
        public UInt64 Uncoded_BER_Error_bits_Ant1 { get; private set; }
        public UInt64 Uncoded_BER_Good_bits { get; private set; }

        public double STO1 { get; private set; }
        public double STO2 { get; private set; }
        public double CFO1 { get; private set; }        // ZZZ need to implement
        public double CFO2 { get; private set; }        // ZZZ need to implement
        public double RSSI1 { get; private set; }
        public double RSSI2 { get; private set; }
        public double CINR1 { get; private set; }
        public double CINR2 { get; private set; }
        public double DC1I { get; private set; }
        public double DC1Q { get; private set; }
        public double DC2I { get; private set; }
        public double DC2Q { get; private set; }
        public double XPI1 { get; private set; }       
        public double XPI2 { get; private set; }       

        // Thur 27-oct: new attributes
        public double CINR1avg { get; private set; }
        public double CINR2avg { get; private set; }
        public double CINR_Max = 50;
        public UInt32 shaperValue { get; private set; }

        // TB and frame counters
        private UInt32 baseTxNumTbs = 0;
        private UInt32 txNumTbs;
        public UInt32 TxNumTbs { get { return txNumTbs - baseTxNumTbs; } }
        private UInt32 baseTxNumFrames = 0;
        private UInt32 txNumFrames;
        public UInt32 TxNumFrames { get { return txNumFrames - baseTxNumFrames; } }
        private UInt32 baseRxNumTbs = 0;
        private UInt32 rxNumTbs;
        public UInt32 RxNumTbs { get { return rxNumTbs - baseRxNumTbs; } }
        private UInt32 baseRxNumFrames = 0;
        private UInt32 rxNumFrames;
        public UInt32 RxNumFrames { get { return rxNumFrames - baseRxNumFrames; } }
        private UInt32 baseRxNumBadTbs0 = 0;
        private UInt32 rxNumBadTbs0;
        public UInt32 RxNumBadTbs0 { get { return rxNumBadTbs0 - baseRxNumBadTbs0; } }
        private UInt32 baseRxNumBadTbs1 = 0;
        private UInt32 rxNumBadTbs1;
        public UInt32 RxNumBadTbs1 { get { return rxNumBadTbs1 - baseRxNumBadTbs1; } }

        // rx and txNumFrameInds, used for heartbeat
        private UInt32 rxNumFrameInds;
        private UInt32 rxNumFrameDelta;
        private UInt32 txNumFrameInds;
        private UInt32 txNumFrameDelta;
        public UInt32 RxNumFrameIndsDelta { get { return rxNumFrameDelta; } }
        public UInt32 TxNumFrameIndsDelta { get { return txNumFrameDelta; } }

        //Isync values
        public UInt32 IsyncPeak { get; private set; }
        public UInt32 IsyncFreq { get; private set; }
        public UInt32 LinkStatus { get; private set; }
        public UInt32 MCS_Set { get; private set; }
        public String RF_Type { get; private set; }

        private enum LinkStat
        {
            Link = 0,
            disconnect
        }
        
        
        public PhyControlChannel controlChannelTx { get; private set; }
        public PhyControlChannel controlChannelRx { get; private set; }

        //1073741824 = 0x40000000 - offset for profile 1 (= 30M)
        public double TX_Freq_Offset_for_profile1 { get { return 1073741824; } }
        public double RX_Freq_Offset_for_profile1 { get { return 3221225472; } }
        
        private uint BER_Reset_Counters_Address = 0xd0190408;
        private uint Clear_BER_Counters_Value = 1;

        private uint UCBER_Reset_Counters_Address = 0xd0190370;
        private uint Clear_UCBER_Counters_Value = 1;

        public static PHY phy = new PHY();

        #endregion

        private PHY()
        {
            handlers = new ProcessMessageDelegate[8];
            handlers[0] = this.handleACKetc;
            handlers[1] = this.handleAvgCINRsAndTbCounts;
            handlers[2] = this.handleControlChannels;
            handlers[3] = this.handlePLLPRITXAnt0;
            handlers[4] = this.handlePLLPRITXAnt1;
            handlers[5] = this.handleBERCounter;
            handlers[6] = this.handleUncodedBERCounter;
            handlers[7] = this.handleLinkStatistics;

            // Register for message responses
            PcapConnection.pcap.addListener(this);
        }

        public void resetAirlinkCounters()
        {

        //uint Clr_Counters = 0x0;
        //DAN_write_msg msg = new DAN_write_msg(blockAddrs[0],Clr_Counters);
        //PcapConnection.pcap.sendDanMsg(msg);
        //// refresh my cached values
        //getNextValues();

            // Takes note of current values:
            baseNackData = nackData;
            baseAckData = ackData;
            baseNackCtrl = nackCtrl;
            baseAckCtrl = ackCtrl;
            
            baseTxNumTbs = txNumTbs;
            baseTxNumFrames = txNumFrames;
            baseRxNumTbs = rxNumTbs;
            baseRxNumFrames = rxNumFrames;
            baseRxNumBadTbs0 = rxNumBadTbs0;
            baseRxNumBadTbs1 = rxNumBadTbs1;

            baseAck0 = ack0;
            baseNack0 = nack0;
            baseAck1 = ack1;
            baseNack1 = nack1;
            
            if (FormNodeProperties.instance.Check_BER_Enable)
            {
                DAN_write_msg Msg = new DAN_write_msg(BER_Reset_Counters_Address, Clear_BER_Counters_Value);
                PcapConnection.pcap.sendDanMsg(Msg);
                // refresh my cached values
                getNextValues();
            }

            if (FormNodeProperties.instance.Check_Uncoded_BER_Enable)
            {
                DAN_write_msg Msg = new DAN_write_msg(UCBER_Reset_Counters_Address, Clear_UCBER_Counters_Value);
                PcapConnection.pcap.sendDanMsg(Msg);
                // refresh my cached values
                getNextValues();
            }   
        }
        
        private void handleControlChannels(DAN_gui_msg msg)
        {
            controlChannelTx = new PhyControlChannel(msg.data[TXCHANHI_index]);
            controlChannelRx = new PhyControlChannel(msg.data[RXCHANHI_index]);
        }

        private void handleAvgCINRsAndTbCounts(DAN_gui_msg msg)
        {
            // Limit CINR values... which are signed, and sometimes negative
            // (SpPerfCharts don't handle negative values):
            CINR1avg = Math.Min((double)Math.Max(0, (double) msg.data[CINR1Avg_index]), 42);
            CINR2avg = Math.Min((double)Math.Max(0, (double) msg.data[CINR2Avg_index]), 42);
            shaperValue = msg.data[SHAPERVAL_index];
            txNumTbs = msg.data[TXNUMTBS_index];
            txNumFrames = msg.data[TXNUMFRAMES_index];
            rxNumTbs = msg.data[RXNUMTBS_index];
            rxNumFrames = msg.data[RXNUMFRAMES_index];
            rxNumBadTbs0 = msg.data[RXBADTBS0_index];
            rxNumBadTbs1 = msg.data[RXBADTBS1_index];
            // Calc delta and keep last values
            rxNumFrameDelta = msg.data[RXNUMFRAMEINDS_index] - rxNumFrameInds;
            rxNumFrameInds = msg.data[RXNUMFRAMEINDS_index];
            txNumFrameDelta = msg.data[TXNUMFRAMEINDS_index] - txNumFrameInds;
            txNumFrameInds = msg.data[TXNUMFRAMEINDS_index];
        }        

        private void handlePLLPRIRXAnt0(DAN_gui_msg msg)
        {
            //if (msg.data[PLL_RX_Ant0_Freq_Offset] == RX_Freq_Offset_for_profile1)
            //{ RXPLLAnt0FreqOffset = 0; }
            //else
            //{ RXPLLAnt0FreqOffset = (msg.data[PLL_RX_Ant0_Freq_Offset] - RX_Freq_Offset_for_profile1) * (0.0279396772); }
        
        }

        private void handlePLLPRIRXAnt1(DAN_gui_msg msg)
        {
            //if (msg.data[PLL_RX_Ant1_Freq_Offset] == RX_Freq_Offset_for_profile1)
            //{ RXPLLAnt1FreqOffset = 0; }
            //else
            //{ RXPLLAnt1FreqOffset = (msg.data[PLL_RX_Ant1_Freq_Offset] - RX_Freq_Offset_for_profile1) * (0.0279396772); }

        }

        private void handlePLLPRITXAnt0(DAN_gui_msg msg)
        {
            //DEbug = msg.data[PLL_TX_Ant0_Freq_Offset];
            //if (msg.data[PLL_TX_Ant0_Freq_Offset] == TX_Freq_Offset_for_profile1)
            //{ TXPLLAnt0FreqOffset = 0; }
            //else
            //{ TXPLLAnt0FreqOffset = (msg.data[PLL_TX_Ant0_Freq_Offset] - TX_Freq_Offset_for_profile1) * (0.0279396772); }
        }

        private void handlePLLPRITXAnt1(DAN_gui_msg msg)
        {
           
            //if (msg.data[PLL_TX_Ant1_Freq_Offset] == TX_Freq_Offset_for_profile1)
            //{ TXPLLAnt1FreqOffset = 0; }
            //else
            //{ TXPLLAnt1FreqOffset = (msg.data[PLL_TX_Ant1_Freq_Offset] - TX_Freq_Offset_for_profile1) * (0.0279396772); }
        }

        private void handleACKetc(DAN_gui_msg msg)
        {
            // CRC counters:
            nackData = msg.data[CRCNACKDATA_index];
            ackData = msg.data[CRCACKDATA_index];
            nackCtrl = msg.data[CRCNACKCTRL_index];
            ackCtrl = msg.data[CRCACKCTRL_index];
            //STO Reports
            STO1 = (double)((Int16)msg.data[STO1_index]) / 512;
            STO2 = (double)((Int16)msg.data[STO2_index]) / 512;
            // RSSI - previously, I thought it had 5 bits of fraction, and 
            // I divided by 32.  This new equation effection 27-oct-2011:
            RSSI1 = (((double)msg.data[RSSI1_index])/ 32) - 90.5;
            if ((((double)msg.data[RSSI1_index]) / (double)32.0) > 256)
            { RSSI1 = 0; }
            //Console.WriteLine("Rec'd RSSI1 = {0:X8} ({0}), calculated RSSI1={1}", msg.data[8], RSSI1);
            RSSI2 = (((double)msg.data[RSSI2_index]) / 32) - 90.5;
            if ((((double)msg.data[RSSI2_index]) / (double)32.0) > 256)
            { RSSI2 = 0; }

            // Apparently CINR has 5 bits of fractional data
            // CINR1 = ((double)msg.data[CINR1_index]) / (double)32.0;
            // CINR2 = ((double)msg.data[CINR2_index]) / (double)32.0;
            CINR1 = Math.Min((((double)msg.data[CINR1_index]) / (double)32.0), 42);
            if ((((double)msg.data[CINR1_index]) / (double)32.0) > 128)
            { CINR1 = 0; }
            CINR2 = Math.Min((((double)msg.data[CINR2_index]) / (double)32.0), 42);
            if ((((double)msg.data[CINR2_index]) / (double)32.0) > 128)
            { CINR2 = 0; }
            DC1I = (double)((msg.data[DC0_index] & 0xffff0000) >> 16);
            DC1Q = (double)((msg.data[DC0_index] & 0x0000ffff));
            DC2I = (double)((msg.data[DC1_index] & 0xffff0000) >> 16);
            DC2Q = (double)((msg.data[DC1_index] & 0x0000ffff));
            XPI1 = ((((double)(msg.data[XPI0_index])) - ((double)msg.data[RSSI1_index])) / 32.0);
            XPI2 = ((((double)(msg.data[XPI1_index])) - ((double)msg.data[RSSI2_index])) / 32.0); 
            

            // New antenna-specific Ack and Nack (9Nov2011)
            nack0 = msg.data[NACK0_index];
            ack0 = msg.data[ACK0_index];
            nack1 = msg.data[NACK1_index];
            ack1 = msg.data[ACK1_index];
        }

        private void handleBERCounter(DAN_gui_msg msg)
        {
            Enable_BER_Counter = msg.data[Enabling_BER_counting];
            BER_Error_bits_Ant0 = msg.data[Error_bits_accumulator_Ant0];
            BER_Good_bits_Ant0 = msg.data[Good_bits_counting1_Ant0] + ((ulong)msg.data[Good_bits_counting2_Ant0]<<32);
            BER_Error_bits_Ant1 = msg.data[Error_bits_accumulator_Ant1];
            BER_Good_bits_Ant1 = msg.data[Good_bits_counting1_Ant1] + ((ulong)msg.data[Good_bits_counting2_Ant1] << 32);        
        }

        private void handleUncodedBERCounter(DAN_gui_msg msg)
        {
            Uncoded_BER_Error_bits_Ant0 = msg.data[Uncoded_BER_Acc_Error_bits_Ant0];
            Uncoded_BER_Error_bits_Ant1 = msg.data[Uncoded_BER_Acc_Error_bits_Ant1];
            Uncoded_BER_Good_bits = msg.data[Uncoded_BER_Num_Of_Words_Acc];
        }

        private void handleLinkStatistics(DAN_gui_msg msg)
        {
            string RFTypeReg;
            string tempRFType;
            IsyncPeak = msg.data[Isync_Peak_str];
            IsyncFreq = msg.data[Isync_Freq_str];
            LinkStatus = msg.data[Link_status_str];
            MCS_Set = msg.data[MCS_Set_str];
            RF_Type = "";
            RFTypeReg = (msg.data[rf_Type_str + 3].ToString("X") + msg.data[rf_Type_str + 2].ToString("X") + msg.data[rf_Type_str + 1].ToString("X") + msg.data[rf_Type_str].ToString("X"));

            while (RFTypeReg.Length > 0)
            {
                tempRFType = System.Convert.ToChar(System.Convert.ToUInt32(RFTypeReg.Substring(RFTypeReg.Length-2, 2), 16)).ToString();              
                RF_Type = RF_Type + tempRFType;                
                RFTypeReg = RFTypeReg.Substring(0, RFTypeReg.Length - 2);
            }
        }

        // Returns true if the msg represents data for this listener; false if 
        // the address is not recognized (reply is for some other listener)
        public bool MessageReplyListenerCallback(DAN_gui_msg msg, DateTime arrivalTime)
        {
            for (int i = 0; i < BLOCK_COUNT; i++)
            {
                if (msg.address == blockAddrs[i])
                {
                    if (msg.size != blockWordCounts[i])
                    {
                        Console.WriteLine("BUG: msg reply {0} wrong size = {0}", blockNames[i], msg.size);
                        return true; // won't bother any other object with parsing it, since it IS for this object
                    }
                    handlers[i](msg);
                    return true;
                }
            }
            return false;
        }

        // Request register contents (two block requests)
        // Responses are handled on another thread by MessageReplyListenerCallback
        public void getNextValues()
        {
            for (int i = 0; i < BLOCK_COUNT; i++)
            {
                DAN_read_array_msg msg = new DAN_read_array_msg(blockAddrs[i], blockWordCounts[i]);
                PcapConnection.pcap.sendDanMsg(msg);
            }
        }


    }
}
