using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    public partial class FormNodeProperties : Form, MessageReplyListener
    {

        #region Var

        public bool Check_BER_Enable { get; private set; }
        public bool Check_Uncoded_BER_Enable { get; private set; }
        public bool CG_Constelliation_Enable { get; private set; } 
        public int Permissionlevel = 1;
        private const int RF_Info_PAGE = 0;
        private const int PROFILE_PAGE = 1;
        private const int PHY_AMC_PAGE = 2;
        private const int CINR_SIM_PAGE = 3;
        private const int MCS_PAGE = 4;
        private const int SYNC_PAGE = 5;
        private const int PHY_COUNTERS_PAGE = 6;
        private const int PHY_QOS_PAGE = 8;
        private const int Terminal = 9;
        private const int MEM_VIEWER_PAGE = 10;
        private const int CONSTELLATION_PAGE = 11;
        private const int UNIT_CONTROL_PAGE = 12;
        private const int DEBUG_PAGE = 13;
        private const int PLL_DEBUG_PAGE = 14;
        private const int CDU_PAGE = 15;
        private const int ADMINISTRATION_CONTROL_PAGE = 16;
      //  private const int;    zzz need to add new pages
      //  private const int;

        private const int SAMPLING_INTERVAL = 500;

        private const int TAB_COUNT = 17;

        private string[] MCSs = { "", "", "", "", "", "", "", "", "", "" };
        //= { "QPSK 1/2", "QPSK 3/4", "16QAM 1/2", "16QAM 3/4", "64QAM 2/3",
        //                            "256QAM 5/8", "256QAM 6/8", "256QAM 7/8" };

        private double[] CalcRateResults = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private Timer Update_Timer = new Timer();

        private const int Max_Offset_Freq = 50;
        private const int Min_Offset_Freq = 1;

        private const int BLOCK_COUNT = 9;
        private readonly string[] blockNames = { "Memory", "Unit_Profile", "Unit_Type", "SISO_MIMO_Mode", "PLL_Debug", "PLL_Debug_PRI_hypothesis", "Spectral_Inv_Ant0", "Spectral_Inv_Ant1", "Unit_Duplex_Mode" };
        private readonly UInt32[] blockAddrs = { 0xd0190000, 0xe0458C30, 0xd0190084, 0xe0458C38, 0xd0018200, 0xc652a020, 0xC6520008, 0xC6524008, 0xe045640c };
        private readonly byte[] blockWordCounts = { 4, 1, 1, 1, 8, 1, 1, 1, 1 };
        //private readonly byte[] Unit_Control_blockWordCounts = { 1, 1, 1 };

        //Block5
        private const int PLL_Working_Mode = 0;
        private const int PLL_LOOP_BW_B1 = 1;
        private const int PLL_LOOP_BW_B2 = 2;
        private const int PLL_Derotation = 4;
        private const int PLL_Ch_Est_Factor = 5;
        private const int PLL_CINR_Factor = 6;

        //running Profile - for unit control
        public uint RunningProfile { get; private set; }
        public string UnitType { get; private set; }
        public string SisoMimoMode { get; private set; }
        public string SW_Version {get; private set;}    // ZZZ need to implement 
        public string Duplex_Mode { get; private set; }

        public static FormNodeProperties instance = new FormNodeProperties();
        private int outstandingRequestSeq = -1;
        // Needed for cross-thread delegation:
        private delegate void ProcessMessageDelegate(DAN_gui_msg msg);
        private ProcessMessageDelegate[] handlers;
        // Needed for refreshing tabs on activation:
        private delegate void RefreshTabDelegate();
        // Needed for OK and Cancel handling:
        private delegate bool ButtonHandler(object sender, EventArgs e);
        private List<ButtonHandler> cancelHandlers;
        private Dictionary<int, RefreshTabDelegate> refreshTabHandlers;
        // Used to supress edit handlers during form load and tab updates programatically
        private bool withinFormLoad = true;

        private bool SpectralInvAnt0 = false;
        private bool SpectralInvAnt1 = false;

       // public bool MCSset = true;
        public int MCSSet {get; private set;}
        private bool MCSSetAutomatic = true;

        // Matlab ViewTool path & filename
        string fileName = "CM0_PRI_Script.txt";
        string sourcePath = @"C:\PTP\CDU_Scripts";
        string targetPath = @"C:\PTP\CDU_Scripts";
      //  public static string MatlabExecutable = @"C:\PTP\ViewTool\ViewTool.exe";
        public static string MatLabViewToolExecutable = @"C:\PTP\ViewTool\ViewTool.exe";
        public string MatLabViewToolargs = @"C:\PTP\ViewTool\ViewTool_Script.txt";

        //Terminal Parameters
        public int BaudRate {get; private set;} 
        public int DataBits {get; private set;}
        public Parity Parity { get; private set; }
        public Handshake Handshake { get; private set; }
        public StopBits StopBits { get; private set; }
        public int ReadTimeout {get; private set;}
        public int WriteTimeout {get; private set;}
        Terminal PTPSerial = new Terminal();
        string Terminalview = "";

        TFTP32 tftpd32 = new TFTP32();

        private StreamWriter PhyC;
        private FileInfo PhyCfi;
        private StreamWriter PhyS;
        private FileInfo PhySfi;
        private StreamWriter GmacC;
        private FileInfo GmacCfi;
        private StreamWriter UnitI;
        private StreamWriter RFI;
        private string Timer;
        
            
        private const int LOGS_SAMPLING_INTERVAL = 1000;
        public bool LOGS_Enable = false;

        public string linkstatus { get; private set; }
        private enum LinkState
        {
            PTP_POWERUP = 0,
            PTP_INIT,
            PTP_CONF,
            PTP_SYNC,
            PTP_SCAN,
            PTP_LINK,
            PTP_POST_LINK,
            PTP_LINK_STABILIZE,
            PTP_ACTIVE,
            PTP_LOST_LINK,
            PTP_STOP_AMC,
            PTP_LIMIT
        }

        #endregion

        #region General

        public FormNodeProperties()
        {
            InitializeComponent();

            initTabs();
            // hide the tabs.  The tab control is managed programmatically
            // during a TreeView event.
            this.tabControlNodePropertyPages.HideTabs = true;

            // Each page that has cancellable, editable controls should provide
            // a cancel handler.  When user clicks Cancel, each handler is 
            // invoked to reset its controls to the initial form-load state.
            // See buttonPropertiesCancel_click.
            cancelHandlers = new List<ButtonHandler>();
            cancelHandlers.Add(handleCinrSimCancel);
            cancelHandlers.Add(handleMemoryViewCancel);
            cancelHandlers.Add(handleConstellationCancel);

            // Not every tab needs to refresh its contents on activation,
            // but those that do will must have a delegate in this array.  See
            // FormNodeProperties_onActivate.
            refreshTabHandlers = new Dictionary<int, RefreshTabDelegate>(TAB_COUNT + 1);
            refreshTabHandlers.Add(CONSTELLATION_PAGE, new RefreshTabDelegate(refreshConstellationTab));
            refreshTabHandlers.Add(CINR_SIM_PAGE, new RefreshTabDelegate(refreshCinrTab));
            refreshTabHandlers.Add(PHY_AMC_PAGE, new RefreshTabDelegate(refreshAmcTab));
            refreshTabHandlers.Add(MCS_PAGE, new RefreshTabDelegate(refreshMCSTab));
            refreshTabHandlers.Add(Terminal, new RefreshTabDelegate(refreshTerminalTextBox));   
            // Register for msg replies from Pcap.  Note that the addSeqListener
            // method is used (not addListener), which will insert this listener
            // ahead of others which are just listening
            // for any reply containing a specific address (e.g., GMAC, PHY.)  If
            // those listeners were called before this, they would consume this
            // objects replies.


            handlers = new ProcessMessageDelegate[9];
            handlers[0] = this.handleMemoryReadReply;
            handlers[1] = this.handleUnitProfileReadReply;
            handlers[2] = this.handleUnitTypeReadReply;
            handlers[3] = this.handleUnitAntModeReadReply;
            handlers[4] = this.handlePLLReadReply;
            handlers[5] = this.handlehypothesisReadReply;
            handlers[6] = this.handleSpectralInvAnt0ReadReply;
            handlers[7] = this.handleSpectralInvAnt1ReadReply;
            handlers[8] = this.handleUnitDuplexModeReadReply;


            // Register for message responses
            PcapConnection.pcap.addListener(this);

            // Keep track of Activation, to refresh tab values:
            this.Activated += new EventHandler(FormNodeProperties_onActivate);

            // Now that all fields have been filled in (programatically),
            // change events can be processed normally
            withinFormLoad = false;

            //update the PHY counters tab every 500ms
            Update_Timer.Interval = 500;
            Update_Timer.Tick += Timer_Tick;
            Update_Timer.Start();
        }

        public void initTabs()
        {

    //        Check_BER_Enable = false;

            initAmcTab();
            initSimCinrTab();
            // Another tabInit method needed for this:

            initConstellationTab();
            initMCSTab();
            initPHYCountersTab();
            initUnitControl();
            initPhyProfile();
            initPLLDebug();
            initCDUTab();
            initTerminalTab();
            initGMACCountersTab();
            initPHYStatisticsTab();
            initLOGTab();
            initRFInfo();
        }

        public void FormNodeProperties_onActivate(object sender, EventArgs e)
        {
            // if there is an activation handler, call it
            RefreshTabDelegate refreshTab;
            if (refreshTabHandlers.TryGetValue(tabControlNodePropertyPages.SelectedIndex, out refreshTab))
            {
                // withinFormLoad==true indicates that change events are being
                // triggered programatically (not by user editing)
                withinFormLoad = true;
                refreshTab();
                // Now that all fields have been filled in (programatically),
                // change events can be processed normally
                withinFormLoad = false;

            }
        }
       
        private void treeViewNodeProperties_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Currently, tags are strings, set in design mode
            string tag = treeViewNodeProperties.SelectedNode.Tag.ToString();
            int selection = Convert.ToInt16(tag);

            int maxIndex = this.tabControlNodePropertyPages.TabPages.Count;
            if (selection >= maxIndex)
            {
                // bug
                selection = maxIndex;
            }
            // deny access to debug tags.
            if (Permissionlevel == 1)
            {
                if (selection == 14)
                {
                    selection = 13;
                }
            }
            if (selection == PHY_COUNTERS_PAGE)
            {
                buttonInterResetCounters.Visible = true;
            }
            else 
            {
                buttonInterResetCounters.Visible = false;
            }

            this.tabControlNodePropertyPages.SelectedIndex = selection;
            // Any pages that show values that may change (sometimes by another tab),
            // can refresh on focus.  If it's an external app that can change the values,
            // the page should also have an activate listener.
            withinFormLoad = true;
            if (selection == CINR_SIM_PAGE)
            {
                initSimCinrTab();
            }
            else if (selection == PHY_AMC_PAGE)
            {
                initAmcTab();
            }
            else if (selection == MCS_PAGE)
            {
                initMCSTab();
            }
            else if (selection == PLL_DEBUG_PAGE)
            {
                initPLLDebug();
            }
            else if (selection == PROFILE_PAGE)
            {
                initPhyProfile();
            }
            else if (selection == CONSTELLATION_PAGE)
            {
                initConstellationTab();
            }
            else if (selection == UNIT_CONTROL_PAGE)
            {
                initUnitControl();
            }
            else if (selection == RF_Info_PAGE)
            {
                initRFInfo();
            }
            withinFormLoad = false;

        }

        void Timer_Tick(object sender, EventArgs e)
        {
            initPHYCountersTab();
            initGMACCountersTab();
            initPHYStatisticsTab();
            refreshTerminalTextBox();
        }


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

        public void getNextValues()
        {
            for (int i = 0; i < BLOCK_COUNT; i++)
            {
                DAN_read_array_msg msg = new DAN_read_array_msg(blockAddrs[i], blockWordCounts[i]);
                PcapConnection.pcap.sendDanMsg(msg);
            }
        }

        #endregion

        #region OkCancelHandling

        private void buttonPropertiesOK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonPropertiesCancel_Click(object sender, EventArgs e)
        {
            // Cancel changes
            // Give each cancelHandler a chance to undo edits, then hides the form.
            // Sets withinFormLoad, so that controls know the changes are programmatic,
            // not user edits.

            withinFormLoad = true;
            foreach (ButtonHandler b in cancelHandlers)
            {
                b(sender, e);
            }
            withinFormLoad = false;
            this.buttonPropertiesOK.Enabled = true;
            this.Hide();
        }

        #endregion

        #region PHY_Profile

        private void comboBoxPhyProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhyProfile phyProfile = (PhyProfile)comboBoxPhyProfile.SelectedItem;
            this.textBoxPhyBandwidth.Text = phyProfile.Bandwidth.ToString();
            this.textBoxPhyDuplexMode.Text = Duplex_Mode;
            this.textBoxProfileNumber.Text = RunningProfile.ToString();
            // show expected throughput calc.
            // TODO:  Just guessing at MCS, and Antenna right now.
            String antenna = "XPIC";
            int i = 0;
            foreach (MCS mcs in MCS.Current_MCS_scheme)
            {
                CalcRateResults[i] = MCS.CalcTput(phyProfile.Bandwidth,
                        antenna, mcs.modulation, mcs.upDownRatio, phyProfile.Range.ToString(), phyProfile.DuplexMode == "FDD");
                i++;
            }
            //for (int i = 0; i < MCSs.Length; i++)
            //{
            //    String mcs = MCSs[i];
            //    CalcRateResults[i] = PTP.CalcTput(phyProfile.Bandwidth,
            //            antenna, mcs, phyProfile.Range.ToString(), phyProfile.DuplexMode == "FDD");
            //}
            this.textBoxPhyExpectedThroughputMCS1.Text = String.Format("{0:n1} Mb/s", CalcRateResults[0]);
            this.textBoxPhyExpectedThroughputMCS2.Text = String.Format("{0:n1} Mb/s", CalcRateResults[1]);
            this.textBoxPhyExpectedThroughputMCS3.Text = String.Format("{0:n1} Mb/s", CalcRateResults[2]);
            this.textBoxPhyExpectedThroughputMCS4.Text = String.Format("{0:n1} Mb/s", CalcRateResults[3]);
            this.textBoxPhyExpectedThroughputMCS5.Text = String.Format("{0:n1} Mb/s", CalcRateResults[4]);
            this.textBoxPhyExpectedThroughputMCS6.Text = String.Format("{0:n1} Mb/s", CalcRateResults[5]);
            this.textBoxPhyExpectedThroughputMCS7.Text = String.Format("{0:n1} Mb/s", CalcRateResults[6]);
            this.textBoxPhyExpectedThroughputMCS8.Text = String.Format("{0:n1} Mb/s", CalcRateResults[7]);
            this.textBoxPhyExpectedThroughputMCS9.Text = String.Format("{0:n1} Mb/s", CalcRateResults[8]);
            this.textBoxPhyExpectedThroughputMCS10.Text = String.Format("{0:n1} Mb/s", CalcRateResults[9]);
            // this.textBoxPhyExpectedThroughputMCS11.Text = String.Format("{0:n1} Mb/s", CalcRateResults[10]);
        }

        private void initPhyProfile()
        {
            this.comboBoxPhyProfile.Items.Clear();
            foreach (PhyProfile pp in PhyProfile.profiles)
            {
                this.comboBoxPhyProfile.Items.Add(pp);
            }
            if (this.comboBoxPhyProfile.Items.Count > 0)
            {
                this.comboBoxPhyProfile.SelectedIndex = (int)RunningProfile;
            }
        }

        private void refreshProfile()
        {
            initPhyProfile();
        }

        #endregion

        #region RF_Information
         
        private void initRFInfo()
        {
            textBoxConnctedBoardType.Text = PHY.phy.RF_Type;
        }

        private void refreshRFInfo()
        {
            initRFInfo();
        }

        #endregion

        #region memoryViewer

        private void buttonMemoryRead_Click(object sender, EventArgs e)
        {
            try
            {
                UInt32 address = (uint)Convert.ToInt32(textBoxMemoryAddr.Text, 16);
                blockAddrs[0] = address;
                getNextValues();
                //DAN_read_array_msg msg = new DAN_read_array_msg(address, 64);
                //outstandingRequestSeq = msg.seq;
                //PcapConnection.pcap.sendDanMsg(msg);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please enter a hexadecimal number", "Invalid Address",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.textBoxMemoryAddr.Focus();
                this.textBoxMemoryAddr.SelectAll();
            }
        }

        private void handleMemoryReadReply(DAN_gui_msg msg)
        {
            UInt32 addr = msg.address;

            listViewMemory.Items.Clear();
            for (int i = 0; i < msg.size; )
            {
                string[] rowString = new string[5];
                rowString[0] = addr.ToString("x8");
                for (int j = 0; j < 4; j++)
                {

                    if (i >= msg.size)
                    {
                        rowString[j + 1] = "";
                    }
                    else
                    {
                        rowString[j + 1] = msg.data[i++].ToString("x8");
                    }
                }
                listViewMemory.Items.Add(new ListViewItem(rowString));
                addr += 16;
            }
            outstandingRequestSeq = -1;
        }

        private void textBoxMemoryAddr_TextChanged(object sender, EventArgs e)
        {
            if (textBoxMemoryAddr.Text.Length > 0)
            {
                this.buttonMemoryRead.Enabled = true;
            }
            else
            {
                this.buttonMemoryRead.Enabled = false;
            }
        }

        private void textBoxMemoryValue_TextChanged(object sender, EventArgs e)
        {
            if (withinFormLoad)
            {
                return;
            }
            if (textBoxMemoryValue.Text.Length > 0)
            {
                // User has started to edit a memory location. Disable OK, 
                // enable Write
                if (!this.buttonMemoryWrite.Enabled)
                {
                    this.buttonPropertiesOK.Enabled = false;
                    this.buttonMemoryWrite.Enabled = true;
                }
            }
            else
            {
                // Value deleted - disable Write button, etc
                this.buttonPropertiesOK.Enabled = true;
                this.buttonMemoryWrite.Enabled = false;
            }
        }

        private bool handleMemoryViewCancel(object sender, EventArgs e)
        {
            this.textBoxMemoryValue.Text = "";
            // Sometimes this button is disabled in textBoxMemoryValue_TextChanged,
            // above, but sometimes (when withinFormLoad is true) it is not:
            this.buttonMemoryWrite.Enabled = false;
            return false;  // currently ignored
        }

        private void buttonMemoryWrite_Click(object sender, EventArgs e)
        {
            // User has clicked OK after editing a memory location.
            UInt32 address, value;

            try
            {
                address = (uint)Convert.ToInt32(textBoxMemoryAddr.Text, 16);
            }
            catch (System.FormatException)
            {
                // TabControl selection only needed if this was an OK button handler
                //this.tabControlNodePropertyPages.SelectedIndex = MEM_VIEWER_PAGE;
                this.textBoxMemoryAddr.Focus();
                this.textBoxMemoryAddr.SelectAll();
                MessageBox.Show("Please enter a hexadecimal number", "Invalid Address",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                value = (uint)Convert.ToInt32(textBoxMemoryValue.Text, 16);
            }
            catch (System.FormatException)
            {
                //this.tabControlNodePropertyPages.SelectedIndex = MEM_VIEWER_PAGE;
                this.textBoxMemoryValue.Focus();
                this.textBoxMemoryValue.SelectAll();
                MessageBox.Show("Please enter a hexadecimal number", "Invalid Address",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            // Send the write...
            DAN_write_msg wMsg = new DAN_write_msg(address, value);
            PcapConnection.pcap.sendDanMsg(wMsg);

            // ... refresh the display with a new read...
            DAN_read_array_msg msg = new DAN_read_array_msg(address, 64);
            outstandingRequestSeq = msg.seq;
            PcapConnection.pcap.sendDanMsg(msg);

            // and restore button and control state to 'Not Editing'
            handleMemoryViewCancel(sender, e);
        }

        #endregion

        #region AMC & MCS

        private void doAmcEnablement()
        {
            if (!this.checkBoxAMC.Checked)
            {
                this.groupBoxManualAMC.Enabled = true;
                this.comboBoxManualMCS0.Enabled = true;
            }
            else
            {
                this.groupBoxManualAMC.Enabled = false;
            }
        }

        private void setCombosFromMCS()
        {
            // Select current value
            // I use this getter, instead of indexing into MCS.mcsSet80, because
            // the value AMC.amc has from the device might be out of bounds.
            // TODO:  bounds checking and validation should probably be done
            // by AMC, as it gets the data from EVB.
            // TODO: Get correct set based on ... what? Current Profile?
            MCS.BANDWIDTH bw = MCS.BANDWIDTH.MHZ56;
            switch (RunningProfile)
            {
                case 0:
                    bw = MCS.BANDWIDTH.MHZ80;
                    break;
                case 1:
                    bw = MCS.BANDWIDTH.MHZ56;
                    break;
                case 2:
                    bw = MCS.BANDWIDTH.MHZ28;
                    break;
                case 21:
                    bw = MCS.BANDWIDTH.MHZ20;
                    break;
                case 22:
                    bw = MCS.BANDWIDTH.MHZ10;
                    break;
                case 39:
                    bw = MCS.BANDWIDTH.MHZ112;
                    break;
            }
            this.comboBoxManualMCS0.SelectedItem = MCS.getMCS(bw, AMC.amc.McsManualId0);
            this.comboBoxManualMCS1.SelectedItem = MCS.getMCS(bw, AMC.amc.McsManualId1);
        }

        private void initAmcTab()
        {
            this.checkBoxAMC.Checked = AMC.amc.AutoAMC;
            this.comboBoxManualMCS0.Items.Clear();
            this.comboBoxManualMCS1.Items.Clear();
            if (!MCSSetAutomatic)
            {
                MCSSet = (int)PHY.phy.MCS_Set;
            }
            foreach (MCS mcs in MCS.Current_MCS_scheme)
            {
                this.comboBoxManualMCS0.Items.Add(mcs);
                this.comboBoxManualMCS1.Items.Add(mcs);
            }

            setCombosFromMCS();
            doAmcEnablement();
        }

        // A RefreshTabHandler, called when the form is loaded and when reactivated.
        // Note that this must be aware that user's changes may be lost, if the user
        // was editing the tab controls.
        // However, for this tab, that seems to be the expected behavior.
        private void refreshAmcTab() //ZZZ need to verify
        {
            // Reload latest values from EVB
            MCS.Current_MCS(FormSystemStatus.MCS_per_BW, MCS.BANDWIDTH.MHZ80, FormNodeProperties.instance.MCSSet);
            initAmcTab();
        }

        //refresh MCS tab in case the EVB is not running with the defult values.
        private void refreshMCSTab()
        {
            MCS.Current_MCS(FormSystemStatus.MCS_per_BW, MCS.BANDWIDTH.MHZ80, FormNodeProperties.instance.MCSSet);
            initMCSTab();
        }

        private void updateAMCThroughPut()
        {
            // TODO: where to get current profile.  Need bandwidth, FDD and range
            uint currentProfile = RunningProfile;
            //   int currentProfile = 0; // 80 Mhz Demo mode
            //  Selected MCS from combo for antenna zero
            MCS mcsSelection = (MCS)comboBoxManualMCS0.SelectedItem;
            double bandwidth = (double)PhyProfile.profiles[currentProfile].Bandwidth;
            string range = PhyProfile.profiles[currentProfile].Range.ToString();
            string antenna = PhyProfile.profiles[currentProfile].AntennaMode;
            string isFDD = PhyProfile.profiles[currentProfile].DuplexMode;
            double max = MCS.CalcTput(bandwidth, antenna, mcsSelection.modulation, mcsSelection.upDownRatio, range, (isFDD == "FDD"));
            this.textBoxManualAmcMaxThru.Text = max.ToString("n3"); // 3 decimal places
        }

        private void checkBoxAMC_CheckedChanged(object sender, EventArgs e)
        {
            if (!withinFormLoad)
            {
                // Not Cancel-able, writes directly to the EVB:
                AMC.amc.AutoAMC = checkBoxAMC.Checked;
            }
            doAmcEnablement();
        }

        private void comboBoxManualMCS0_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* Not Cancelable, writes directly to EVB when changed. */
            if (!withinFormLoad)
            {
                AMC.amc.McsManualId0 = (uint)((MCS)comboBoxManualMCS0.SelectedItem).id;
            }
        }

        private void comboBoxManualMCS1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* Not Cancelable, writes directly to EVB when changed. */
            if (!withinFormLoad)
            {
                AMC.amc.McsManualId1 = (uint)((MCS)comboBoxManualMCS1.SelectedItem).id;
            }
        }

        private void initMCSTab()
        {
            for (int i = 0; i < MCSs.Length; i++)
            {
                MCSs[i] = MCS.Current_MCS_scheme[i].ToString();
            }
            MCS1.Text = MCSs[0];
            MCS2.Text = MCSs[1];
            MCS3.Text = MCSs[2];
            MCS4.Text = MCSs[3];
            MCS5.Text = MCSs[4];
            MCS6.Text = MCSs[5];
            MCS7.Text = MCSs[6];
            MCS8.Text = MCSs[7];
            MCS9.Text = MCSs[8];
            MCS10.Text = MCSs[9];
            //  MCS11.Text = MCSs[10];
        }

        private void txtType_KeyPress_number(object sender, KeyPressEventArgs e)
        {
            //makes sure that textBox1 is a number
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar)) e.Handled = true;
        }

        private void comboBoxMCSSetSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkMCSSet2();
        }

        private void checkMCSSet2()
        {
            switch (comboBoxMCSSetSelect.Text)
            {
                case ("MCS Set 1"): MCSSet = 1;
                    MCSSetAutomatic = false;
                    break;
                case ("MCS Set 2"): MCSSet = 2;
                    MCSSetAutomatic = false;
                    break;
                case ("MCS Set 3"): MCSSet = 3;
                    MCSSetAutomatic = false;
                    break;
                case ("MCS Set 4"): MCSSet = 4;
                    MCSSetAutomatic = false;
                    break;
                case ("Automatic"): MCSSet = (int)PHY.phy.MCS_Set;
                    MCSSetAutomatic = true;
                    break;
            }
    
            
            this.buttonPropertiesOK.Enabled = true;
        }
        #endregion

        #region PHY_Counters

        private void refreshPHYCOUNTERSTab()
        {
            initPHYCountersTab();
        }

        private void initPHYCountersTab()
        {
            decimal nack = (decimal)PHY.phy.NACK0;
            decimal ack = (decimal)PHY.phy.ACK0;
            decimal nackB = (decimal)PHY.phy.NACK1;
            decimal ackB = (decimal)PHY.phy.ACK1;
            decimal ctrlack = (decimal)PHY.phy.AckCtrl;
            decimal ctrlnack = (decimal)PHY.phy.NackCtrl;
            decimal val = ((ack + nack) == 0) ? 0m : nack / (ack + nack);
            decimal valB = ((ackB + nackB) == 0) ? 0m : nackB / (ackB + nackB);
            decimal valctrl = ((ctrlnack + ctrlack) == 0) ? 0m : ctrlnack / (ctrlnack + ctrlack);
            ulong bit_counter_ant0 = (PHY.phy.BER_Good_bits_Ant0 * 32);
            double error_bit_counter_ant0 = (PHY.phy.BER_Error_bits_Ant0);
            double BER_calc_ant0 = ((bit_counter_ant0 == 0) ? 0 : (error_bit_counter_ant0 / bit_counter_ant0));
            ulong bit_counter_ant1 = (PHY.phy.BER_Good_bits_Ant1 * 32);
            double error_bit_counter_ant1 = (PHY.phy.BER_Error_bits_Ant1);
            double BER_calc_ant1 = ((bit_counter_ant1 == 0) ? 0 : (error_bit_counter_ant1 / bit_counter_ant1));
            double  error_bit_uncoded_ant0 = (PHY.phy.Uncoded_BER_Error_bits_Ant0);
            double  error_bit_uncoded_ant1 = (PHY.phy.Uncoded_BER_Error_bits_Ant1);
            double uncoded_BER_good_bits = (PHY.phy.Uncoded_BER_Good_bits * 8 * 4);
            double  uncoded_BER_Ant0 = (error_bit_uncoded_ant0 / uncoded_BER_good_bits);
            double  uncoded_BER_Ant1 = (error_bit_uncoded_ant1/uncoded_BER_good_bits);

            //Show results at PHY counters tab
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add("Total TBs Counter Ant0:", ack);
            dataGridView1.Rows.Add("Total CRC Counter Ant0:", nack);
            dataGridView1.Rows.Add("Ant0 PER :", String.Format(" {0:0.0e+0}", val));
            dataGridView1.Rows.Add("Total TBs Counter Ant1:", ackB);
            dataGridView1.Rows.Add("Total CRC Counter Ant1:", nackB);
            dataGridView1.Rows.Add("Ant1 PER :", String.Format(" {0:0.0e+0}", valB));
            dataGridView1.Rows.Add("Total CTRL TBs Counter :", ctrlack);
            dataGridView1.Rows.Add("Total CTRL CRC Counter :", ctrlnack);
            dataGridView1.Rows.Add("CTRL PER :", String.Format(" {0:0.0e+0}", valctrl));
            if (Check_BER_Enable)
            {
                dataGridView1.Rows.Add("Ant0 Bit Counter :", bit_counter_ant0);
                dataGridView1.Rows.Add("Ant0 Bit CRC Counter :", error_bit_counter_ant0);
                dataGridView1.Rows.Add("Ant0 BER :", String.Format(" {0:0.0e+0}", BER_calc_ant0));
                dataGridView1.Rows.Add("Ant1 Bit Counter :", bit_counter_ant1);
                dataGridView1.Rows.Add("Ant1 Bit CRC Counter :", error_bit_counter_ant1);
                dataGridView1.Rows.Add("Ant1 BER :", String.Format(" {0:0.0e+0}", BER_calc_ant1));
                for (int i = 9; i < 15; i++)
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                }
            }
            if (Check_Uncoded_BER_Enable)
            {
              //  this.dataGridView1.GridColor = Color.Red;
                dataGridView1.Rows.Add("Ant0 uncoded CRC :", error_bit_uncoded_ant0);
                dataGridView1.Rows.Add("Ant0 uncoded BER :", String.Format(" {0:0.0e+0}", uncoded_BER_Ant0));
                dataGridView1.Rows.Add("Ant1 uncoded CRC :", error_bit_uncoded_ant1);
                dataGridView1.Rows.Add("Ant1 uncoded BER :", String.Format(" {0:0.0e+0}", uncoded_BER_Ant1));
                int j;
                if (Check_BER_Enable)
                { j = 15; }
                else
                { j = 9; }
                for (int i = 0; i < 4; i++)
                {
                    this.dataGridView1.Rows[i + j].DefaultCellStyle.BackColor = Color.OrangeRed;
                }
            }

        }


        private void checkBox_BER_COUNTER_ENABLE_CheckedChanged(object sender, EventArgs e)
        {
            //enable/disable BER counter
            uint BER_Counters_Address = 0xd0190408;
            double Value = 0;
            if (this.checkBox_BER_COUNTER_ENABLE.Checked)
            {
                Value = 1;
                Check_BER_Enable = true;
                MessageBox.Show("Need to remove the data cable from GMAC1",
                                "DAN PTP - Information",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  
            }
            else
            {
                Value = 0;
                Check_BER_Enable = false;
            }
            DAN_write_msg Msg = new DAN_write_msg(BER_Counters_Address, (uint)Value);
            PcapConnection.pcap.sendDanMsg(Msg);

        }

        private void checkBox_Uncoded_BER_COUNTER_ENABLE_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_Uncoded_BER_COUNTER_ENABLE.Checked)
            {
                Check_Uncoded_BER_Enable = true;
                MessageBox.Show(@"Need to upload ptp_init_param file with ""struct PARAMS.init_params.K0Value=0"" ",
                                "DAN PTP - Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
            else
            {
                Check_Uncoded_BER_Enable = false;
                MessageBox.Show(@"Need to upload ptp_init_param file with ""struct PARAMS.init_params.K0Value=1"" ",
                                "DAN PTP - Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }


        }

        private void buttonInterResetCounters_Click_1(object sender, EventArgs e)
        {
            PHY.phy.resetAirlinkCounters();
            GMAC.gmac0.resetGMACCounters();
        }

        #endregion

        #region PHY Statistics

        private void refreshPHYStatisticsTab()
        {
            initPHYStatisticsTab();
        }

        private void initPHYStatisticsTab()
        {
            // STO/CFO/XPIC/RSSI/CINR/DC Offsrt
            dataGridViewPHYStatisticsAnt0.Rows.Clear();
            dataGridViewPHYStatisticsAnt1.Rows.Clear();
            dataGridViewISync.Rows.Clear();
            dataGridViewPHYStatisticsAnt0.Rows.Add("STO:", String.Format(" {0:0.0}", PHY.phy.STO1));
            dataGridViewPHYStatisticsAnt1.Rows.Add("STO:", String.Format(" {0:0.0}", PHY.phy.STO2));
            dataGridViewPHYStatisticsAnt0.Rows.Add("CFO:", String.Format(" {0:0.0}", 0));
            dataGridViewPHYStatisticsAnt1.Rows.Add("CFO:", String.Format(" {0:0.0}", 0));
            dataGridViewPHYStatisticsAnt0.Rows.Add("RSSI:", String.Format(" {0:0.0} dBFS", PHY.phy.RSSI1));
            dataGridViewPHYStatisticsAnt1.Rows.Add("RSSI:", String.Format(" {0:0.0} dBFS", PHY.phy.RSSI2));
            dataGridViewPHYStatisticsAnt0.Rows.Add("CINR:", String.Format(" {0:0.00} dB", PHY.phy.CINR1));
            dataGridViewPHYStatisticsAnt1.Rows.Add("CINR:", String.Format(" {0:0.00} dB", PHY.phy.CINR2));
            dataGridViewPHYStatisticsAnt0.Rows.Add("DC_I:", String.Format(" {0:0.00}", (Int16)PHY.phy.DC1I));
            dataGridViewPHYStatisticsAnt0.Rows.Add("DC_Q:", String.Format(" {0:0.00}", (Int16)PHY.phy.DC1Q));
            dataGridViewPHYStatisticsAnt1.Rows.Add("DC_I:", String.Format(" {0:0.00}", (Int16)PHY.phy.DC2I));
            dataGridViewPHYStatisticsAnt1.Rows.Add("DC_Q:", String.Format(" {0:0.00}", (Int16)PHY.phy.DC2Q));
            if (SisoMimoMode == "XPIC(MIMO)")
            {
                dataGridViewPHYStatisticsAnt0.Rows.Add("XPI:", String.Format(" {0:0.0}", (PHY.phy.XPI1)));
                dataGridViewPHYStatisticsAnt1.Rows.Add("XPI:", String.Format(" {0:0.0}", (PHY.phy.XPI2)));
            }
            //Isync parameters
            if (LinkIndicator.links.SyncAchieved)
            {
                dataGridViewISync.Rows.Add("ISync Achived", "Yes");
            }
            else
            {
                dataGridViewISync.Rows.Add("ISync Achived", "No");
            }
            dataGridViewISync.Rows.Add("Peak Level", String.Format(" {0:0.00}", PHY.phy.IsyncPeak));
            dataGridViewISync.Rows.Add("Frequency Offset", String.Format(" {0:0.00}", PHY.phy.IsyncFreq));
            dataGridViewISync.Rows.Add("Link Status", String.Format(" {0:0.00}", PHY.phy.LinkStatus));
            linkstatus = Enum.GetName(typeof(LinkState), PHY.phy.LinkStatus);
        }

        #endregion

        #region GMAC Counters

        private void refreshGMACCOUNTERSTab()
        {
            initGMACCountersTab();
        }

        private void initGMACCountersTab()
        {
            //Show results at PHY counters tab
            dataGridViewGMAC0.Rows.Clear();
            dataGridViewGMAC1.Rows.Clear();
            for (int i = 0; i < GMAC.gmac0.REG_GMAC0; i++)
            { 
                dataGridViewGMAC0.Rows.Add(GMAC.gmac0.registerNames0[i], String.Format("{0:0,0.0} f/s", GMAC.gmac0.RateCounters_GMAC0[i]), GMAC.gmac0.CurrentCounters_GMAC0[i]);
            }
            for (int i = 0; i < GMAC.gmac1.REG_GMAC1; i++)
            {
                dataGridViewGMAC1.Rows.Add(GMAC.gmac1.registerNames1[i], String.Format("{0:0,0.0} f/s", GMAC.gmac1.RateCounters_GMAC1[i]), GMAC.gmac1.CurrentCounters_GMAC1[i]);
            }          
        }

        #endregion

        #region UnitControl

        private void handleUnitDuplexModeReadReply(DAN_gui_msg msg)
        {
            if (msg.data[0] == 0)
            {
                Duplex_Mode = "FDD";
            }
            else if (msg.data[0] == 1)
            {
                Duplex_Mode = "TDD";
            }
            else
            {
                Duplex_Mode = "NA";
            }
        }

        private void handleUnitProfileReadReply(DAN_gui_msg msg)
        {
            RunningProfile = msg.data[0];
        }

        private void handleUnitTypeReadReply(DAN_gui_msg msg)
        {
            if (msg.data[0] == 0)
            {
                UnitType = "Master";
            }
            else
            {
                UnitType = "Slave";
            }
        }

        private void handleUnitAntModeReadReply(DAN_gui_msg msg)
        {
            if (msg.data[0] == 0)
            {
                SisoMimoMode = "Single SISO";
            }
            else if (msg.data[0] == 1)
            {
                SisoMimoMode = "Double SISO";
            }
            else if (msg.data[0] == 2)
            {
                SisoMimoMode = "XPIC(MIMO)";
            }
        }

        private void initUnitControl()
        {
            getNextValues();

            //update all textbox
            textBoxUnitType.Text = UnitType;
            textBoxRunningProfile.Text = RunningProfile.ToString();
            textBoxDuplexMode.Text = Duplex_Mode;
            textBoxTransmittionMode.Text = SisoMimoMode;
        }

        private void refreshUnitControl()
        {
            initUnitControl();
        }
        #endregion

        #region SimCINR

        private void initSimCinrTab()
        {
            this.checkBoxCinrSimulation.Checked = AMC.amc.CinrSimMode;
            this.textBoxSimCinr0.Text = AMC.amc.CinrManualSetting0.ToString();
            this.textBoxSimCinr1.Text = AMC.amc.CinrManualSetting1.ToString();
            buttonWriteCinrValues.Enabled = false;
        }

        // A RefreshTabHandler, called when the form is loaded and when reactivated.
        // Note that this must be aware that user's changes may be lost, if the user
        // was editing the tab controls.
        //    However, for this tab, that seems to be the expected behavior.
        private void refreshCinrTab()
        {
            // Reload latest values from EVB
            initSimCinrTab();
        }

        private void buttonWriteCinrValues_Click(object sender, EventArgs e)
        {
            UInt32 cinr0, cinr1;

            try
            {
                cinr0 = (uint)Convert.ToInt32(textBoxSimCinr0.Text);
            }
            catch (System.FormatException)
            {
                // TabControl selection only needed if this was an OK button handler
                //this.tabControlNodePropertyPages.SelectedIndex = MEM_VIEWER_PAGE;
                this.textBoxSimCinr0.Focus();
                this.textBoxSimCinr0.SelectAll();
                MessageBox.Show("Please enter a number, or press Cancel", "Invalid Value",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                cinr1 = (uint)Convert.ToInt32(textBoxSimCinr1.Text);
            }
            catch (System.FormatException)
            {
                //this.tabControlNodePropertyPages.SelectedIndex = MEM_VIEWER_PAGE;
                this.textBoxSimCinr0.Focus();
                this.textBoxSimCinr0.SelectAll();
                MessageBox.Show("Please enter a number, or press Cancel", "Invalid Value",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            // Will write the values to EVB:
            AMC.amc.CinrManualSetting0 = cinr0;
            AMC.amc.CinrManualSetting1 = cinr1;
            // Restore buttons
            this.buttonPropertiesOK.Enabled = true;
            this.buttonWriteCinrValues.Enabled = false;
            // Put the focus off the text boxes
            this.treeViewNodeProperties.Focus();

        }

        private void checkBoxCinrSimulation_CheckedChanged(object sender, EventArgs e)
        {
            if (!withinFormLoad)
            {
                // This will write value to the EVB:
                AMC.amc.CinrSimMode = checkBoxCinrSimulation.Checked;
            }
        }

        private void textBoxSimCinr0_TextChanged(object sender, EventArgs e)
        {
            // Once changed, the OK dialog button is disabled, and the WriteValues
            // button is enabled.  If user deletes all text, Write is still enabled,
            // but will show parsing error. 

            // When user starts to edit a memory location, disable OK, enable Write
            // (unless it's being set during init or by cancel handler):
            if (!withinFormLoad)
            {
                this.buttonPropertiesOK.Enabled = false;
                this.buttonWriteCinrValues.Enabled = true;
            }
        }

        private void textBoxSimCinr1_TextChanged(object sender, EventArgs e)
        {
            if (!withinFormLoad)
            {
                this.buttonPropertiesOK.Enabled = false;
                this.buttonWriteCinrValues.Enabled = true;
            }
        }

        private bool handleCinrSimCancel(object sender, EventArgs e)
        {
            initSimCinrTab();
            return false;  // currently ignored
        }

        #endregion

        #region CONSTELLATION

        private void initConstellationTab()
        {
            this.buttonConstellationApply.Enabled = false;
            try
            {
                this.textBoxConstellationUpdateInterval.Text = FormSystemStatus.ConstellationUpdateIntervalSec.ToString();
                this.textBoxConstellationDataFolder.Text = PhyConstellationData.folderRoot;
                this.textBoxConstellationExecutable.Text = Constellation.constellationExecutable;
                this.comboBoxConstellationFFT.Items.Clear();
                int selectionIndex = 0;
                int i = 0;
                foreach (int fft in Constellation.FFTsizes)
                {
                    this.comboBoxConstellationFFT.Items.Add(fft.ToString());
                    if (fft == Constellation.selectedFFT)
                    {
                        selectionIndex = i;
                    }
                    i++;
                }
                this.comboBoxConstellationFFT.SelectedIndex = selectionIndex;

                if (PhyProfile.profiles[FormNodeProperties.instance.RunningProfile].Bandwidth > 30)
                { this.comboBoxConstellationFFT.SelectedIndex = 1; }
                else
                { this.comboBoxConstellationFFT.SelectedIndex = 0; }

            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error {0} {1}", e.ToString(), e.Message);
            }
        }

        // A RefreshTabHandler, called when the form is reactivated, and at form load.
        // Note that this must be aware that user's changes may be lost, if the user
        // was editing the tab controls.
        //    However, for this tab, all the values are local to the GUI app, none
        // come from the EVB.  
        //    Note that the form is reactivated whenever one of the file dialogs (Choose
        // Executable or Choose Data Folder) completes and closes.  But in those cases,
        // the form is updated during the return from ShowDialog. 
        private void refreshConstellationTab()
        {
            //no need to refresh this tab

        }

        private void doConstellationEnablement()
        {
            if (!withinFormLoad)
            {
                buttonPropertiesOK.Enabled = false;
                buttonConstellationApply.Enabled = true;
            }
        }

        private bool handleConstellationCancel(object sender, EventArgs e)
        {
            // Revert any changes to controls on this tab
            initConstellationTab();
            return true;  // currently ignored
        }

        private void textBoxConstellationUpdateInterval_TextChanged(object sender, EventArgs e)
        {
            doConstellationEnablement();
        }

        private void comboBoxConstellationFFT_SelectedIndexChanged(object sender, EventArgs e)
        {
            doConstellationEnablement();
        }

        private void textBoxConstellationExecutable_TextChanged(object sender, EventArgs e)
        {
            doConstellationEnablement();
        }

        private void comboBoxPLLDebug_SelectedIndexChanged(object sender, EventArgs e)
        {
            doConstellationEnablement();
        }

        private void checkBoxMatlabwithChannelEstimation_CheckedChanged(object sender, EventArgs e)
        {
            doConstellationEnablement();
        }

        private void comboBoxEnablePersistence_SelectedIndexChanged(object sender, EventArgs e)
        {
            doConstellationEnablement();
        }

        private void buttonConstellationExecutable_Click(object sender, EventArgs e)
        {
            if (openFileDialogConstellationExecutable.ShowDialog() == DialogResult.OK)
            {
                string executable = openFileDialogConstellationExecutable.FileName;
                textBoxConstellationExecutable.Text = executable;
                doConstellationEnablement();
            }
        }

        private void textBoxConstellationDataFolder_TextChanged(object sender, EventArgs e)
        {
            doConstellationEnablement();
        }

        private void comboBoxChannelGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxChannelGain.Text == "No")
            {
                CG_Constelliation_Enable = false;
            }
            else
            {
                CG_Constelliation_Enable = true;
            }
            doConstellationEnablement();
        }

        private void buttonConstellationDataFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialogConstellationData.SelectedPath = textBoxConstellationDataFolder.Text;
            if (folderBrowserDialogConstellationData.ShowDialog() == DialogResult.OK)
            {
                string dataPath = folderBrowserDialogConstellationData.SelectedPath;
                textBoxConstellationDataFolder.Text = dataPath;
                doConstellationEnablement();
            }
            // Append "//" to datapath is done in buttonConstellationApply_Click, below.
        }

        private void buttonConstellationApply_Click(object sender, EventArgs e)
        {

            if (textBoxConstellationDataFolder.Text.Length == 0)
            {
                this.textBoxConstellationDataFolder.Focus();
                MessageBox.Show("Please select a folder for Matlab data files", "Invalid Data Folder",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!Directory.Exists(textBoxConstellationDataFolder.Text))
            {
                this.textBoxConstellationDataFolder.Focus();
                this.textBoxConstellationDataFolder.SelectAll();
                MessageBox.Show("The selected folder does not exist", "Invalid Data Folder",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (textBoxConstellationExecutable.Text.Length == 0)
            {
                this.textBoxConstellationExecutable.Focus();
                MessageBox.Show("Please select the Matlab executable", "Invalid File Name",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!File.Exists(textBoxConstellationExecutable.Text))
            {
                this.textBoxConstellationExecutable.Focus();
                this.textBoxConstellationExecutable.SelectAll();
                MessageBox.Show("The selected file does not exist", "Invalid File Name",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (textBoxConstellationUpdateInterval.Text.Length == 0)
            {
                this.textBoxConstellationUpdateInterval.Focus();
                MessageBox.Show("Please enter an interval, in seconds (1..20)", "Invalid Interval",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int newInterval = 0;
            if (textBoxConstellationUpdateInterval.Text.Length == 0)
            {
                this.textBoxConstellationUpdateInterval.Focus();
                MessageBox.Show("Please enter an interval, in seconds (1..20)", "Invalid Interval",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                newInterval = Convert.ToInt32(textBoxConstellationUpdateInterval.Text);
                if (newInterval < 1 || newInterval > 20)
                {
                    throw new System.FormatException();
                }
            }
            catch (System.FormatException)
            {
                this.textBoxConstellationUpdateInterval.Focus();
                this.textBoxConstellationUpdateInterval.SelectAll();
                MessageBox.Show("Please enter a number, between 0 and 21, for Matlab update", "Invalid Interval",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            // All OK. Save values:
            buttonConstellationApply.Enabled = false;
            buttonPropertiesOK.Enabled = true;
            FormSystemStatus.ConstellationUpdateIntervalSec = newInterval;
            Constellation.selectedFFT = comboBoxConstellationFFT.SelectedIndex;
            if (checkBoxMatlabwithChannelEstimation.Checked)
            { Constellation.New_Matlab = true; }
            else
            { Constellation.New_Matlab = false; }
            PhyConstellationData.folderRoot = textBoxConstellationDataFolder.Text + "\\";
            Constellation.constellationExecutable = textBoxConstellationExecutable.Text;
            if (comboBoxPLLDebug.Text == "Post PLL")
            { Constellation.PLLDebug = true; }
            else
            { Constellation.PLLDebug = false; }
            if (comboBoxEnablePersistence.Text == "No")
            { Constellation.persistence = 0; }
            else
            { Constellation.persistence = 1; }
            // Like other edits, "Apply" button does not close the form
            //this.Visible = false;
        }

        // check permission level for admin user
        private void buttonApply_Click(object sender, EventArgs e)
        {
            if ((textBoxUserName.Text == "admin") && (textBoxPassword.Text == "admin"))
            {
                Permissionlevel = 2;
            }
            else
            {
                Permissionlevel = 1;
            }
            this.buttonPropertiesOK.Enabled = true;
            this.buttonPasswordApply.Enabled = false;

        }

        #endregion

        #region Debug Tabs

        private void initPLLDebug()
        {
            getNextValues();
        }

        private void handlePLLReadReply(DAN_gui_msg msg)
        {

            //comboBoxPLLWorkingMode
            try
            {
                switch (msg.data[PLL_Working_Mode])
                {
                    case (257):         //0x0101
                        comboBoxPLLWorkingMode.SelectedIndex = 0;
                        break;
                    case (17):          //0x0011
                        comboBoxPLLWorkingMode.SelectedIndex = 1;
                        break;
                    case (1):           //0x0001
                        comboBoxPLLWorkingMode.SelectedIndex = 2;
                        break;
                }
            }
            catch { }

            //comboBoxPLLLoopBW - PLL_LOOP_BW_B1
            try
            {
                switch (msg.data[PLL_LOOP_BW_B1])
                {
                    case (3648):            //0xe40
                        comboBoxPLLLoopBWB1.SelectedIndex = 0;
                        break;
                    case (2736):            //0xab0
                        comboBoxPLLLoopBWB1.SelectedIndex = 1;
                        break;
                    case (1824):            //0x720
                        comboBoxPLLLoopBWB1.SelectedIndex = 2;
                        break;
                    case (912):            //0x390
                        comboBoxPLLLoopBWB1.SelectedIndex = 3;
                        break;
                    default:
                        comboBoxPLLLoopBWB1.SelectedIndex = 4;
                        break;
                }
            }
            catch { }
            //comboBoxPLLLoopBW - PLL_LOOP_BW_B2
            try
            {
                switch (msg.data[PLL_LOOP_BW_B2])
                {
                    case (156):            //0x09c
                        comboBoxPLLLoopBWB2.SelectedIndex = 0;
                        break;
                    case (88):            //0x058
                        comboBoxPLLLoopBWB2.SelectedIndex = 1;
                        break;
                    case (39):            //0x027
                        comboBoxPLLLoopBWB2.SelectedIndex = 2;
                        break;
                    case (10):            //0x00a
                        comboBoxPLLLoopBWB2.SelectedIndex = 3;
                        break;
                    default:
                        comboBoxPLLLoopBWB2.SelectedIndex = 4;
                        break;
                }
            }
            catch { }
            //comboBoxCINRFactor
            try
            {
                int index = (Convert.ToInt32(msg.data[PLL_CINR_Factor].ToString()) / 1638);
                comboBoxCINRFactor.SelectedIndex = (index - 1);
            }
            catch { }
            //comboBoxChannelEstimationFactor
            try
            {
                int index = (Convert.ToInt32(msg.data[PLL_Ch_Est_Factor].ToString()) / 1638);
                comboBoxChannelEstimationFactor.SelectedIndex = (index - 1);
            }
            catch { }
            //comboBoxDisablePLLDerotation
            try
            {
                if (msg.data[PLL_Derotation] == 1)
                {
                    comboBoxDisablePLLDerotation.SelectedIndex = 0;
                }
                else
                {
                    comboBoxDisablePLLDerotation.SelectedIndex = 1;
                }
            }
            catch { }
        }

        private void handlehypothesisReadReply(DAN_gui_msg msg)
        {
            try
            {
                textBoxRXPRIHypothesis.Text = msg.data[0].ToString();
            }
            catch { }
        }

        private void handleSpectralInvAnt0ReadReply(DAN_gui_msg msg)
        {
            try
            {
                if (msg.data[0] == 0x00000808)
                {
                    SpectralInvAnt0 = true;
                }
                else
                {
                    SpectralInvAnt0 = false;
                }
                checkBox_BER_COUNTER_ENABLE_if_Spectral_inv_On();
            }
            catch { }
        }

        private void handleSpectralInvAnt1ReadReply(DAN_gui_msg msg)
        {
            try
            {
                if (msg.data[0] == 0x00000808)
                {
                    SpectralInvAnt1 = true;
                }
                else
                {
                    SpectralInvAnt1 = false;
                }
            }
            catch { }
            checkBox_BER_COUNTER_ENABLE_if_Spectral_inv_On();
        }

        private void checkBox_BER_COUNTER_ENABLE_if_Spectral_inv_On()
        {
            try
            {
                if (SpectralInvAnt0 && SpectralInvAnt1)
                {
                    comboBoxSpectralInversion.SelectedIndex = 1;
                }
                else
                {
                    comboBoxSpectralInversion.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private void comboBoxPLLWorkingMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonPropertiesOK.Enabled = false;
            this.buttonDebugApply.Enabled = true;
        }

        private void comboBoxPLLLoopBWB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonPropertiesOK.Enabled = false;
            this.buttonDebugApply.Enabled = true;
        }

        private void comboBoxPLLLoopBWB2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonPropertiesOK.Enabled = false;
            this.buttonDebugApply.Enabled = true;
        }

        private void comboBoxDisablePLLDerotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonPropertiesOK.Enabled = false;
            this.buttonDebugApply.Enabled = true;
        }

        private void textBoxRXPRIHypothese_TextChanged(object sender, EventArgs e)
        {
            this.buttonPropertiesOK.Enabled = false;
            this.buttonDebugApply.Enabled = true;
        }

        private void comboBoxCINRFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonPropertiesOK.Enabled = false;
            this.buttonDebugApply.Enabled = true;
        }

        private void comboBoxChannelEstimationFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonPropertiesOK.Enabled = false;
            this.buttonDebugApply.Enabled = true;
        }

        private void comboBoxSpectralInversion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonPropertiesOK.Enabled = false;
            this.buttonDebugApply.Enabled = true;
        }

        private void write_new_command(uint address, uint value)
        {
            // Send the write...

            DAN_write_msg wMsg = new DAN_write_msg(address, value);
            PcapConnection.pcap.sendDanMsg(wMsg);
        }

        private void buttonDebugApply_Click(object sender, EventArgs e)
        {
            uint value = 0;
            try
            {
                //Working Mode config
                switch (comboBoxPLLWorkingMode.SelectedIndex)
                {
                    case (0):         // 257                   
                        value = 0x0101;
                        break;
                    case (1):          // 17
                        value = 0x0011;
                        break;
                    case (2):           // 1   
                        value = 0x0001;
                        break;
                }
                write_new_command(blockAddrs[4], value);

                //PLL loop B1 config 
                switch (comboBoxPLLLoopBWB1.SelectedIndex)
                {
                    case (0):            //3648                   
                        value = 0xe40;
                        break;
                    case (1):            //2736
                        value = 0xab0;
                        break;
                    case (2):            //1824
                        value = 0x720;
                        break;
                    case (3):            //912
                        value = 0x390;
                        break;
                    default:
                        value = Convert.ToUInt32(comboBoxPLLLoopBWB1.Text.ToString());
                        break;
                }
                write_new_command(blockAddrs[4] + 0x04, value);

                //PLL loop B2 config
                switch (comboBoxPLLLoopBWB2.SelectedIndex)
                {
                    case (0):            //156
                        comboBoxPLLLoopBWB2.SelectedIndex = 0;
                        value = 0x09c;
                        break;
                    case (1):            //88
                        comboBoxPLLLoopBWB2.SelectedIndex = 1;
                        value = 0x058;
                        break;
                    case (2):            //39
                        comboBoxPLLLoopBWB2.SelectedIndex = 2;
                        value = 0x027;
                        break;
                    case (3):            //10
                        comboBoxPLLLoopBWB2.SelectedIndex = 3;
                        value = 0x00a;
                        break;
                    default:
                        value = Convert.ToUInt32(comboBoxPLLLoopBWB2.Text.ToString());
                        break;
                }
                write_new_command(blockAddrs[4] + 0x08, value);

                //PLL derotation
                if (comboBoxDisablePLLDerotation.SelectedIndex == 0)
                {
                    value = 1;
                }
                else
                {
                    value = 0;
                }
                write_new_command(blockAddrs[4] + 0x10, value);

                //CINRFactor
                uint index = (UInt32)comboBoxCINRFactor.SelectedIndex + 1;
                value = index * 1638;
                write_new_command(blockAddrs[4] + 0x18, value);

                //ChannelEstimationFactor
                index = (UInt32)comboBoxChannelEstimationFactor.SelectedIndex + 1;
                value = index * 1638;
                write_new_command(blockAddrs[4] + 0x14, value);

                //spctral Inversion
                if (comboBoxSpectralInversion.SelectedIndex == 1)
                {
                    value = 0x00000808;
                    write_new_command(blockAddrs[6], value);
                    write_new_command(blockAddrs[7], value);
                }
                else
                {
                    value = 0x00000000;
                    write_new_command(blockAddrs[6], value);
                    write_new_command(blockAddrs[7], value);
                }
            }
            catch { }

            //change buttons mode
            this.buttonPropertiesOK.Enabled = true;
            this.buttonDebugApply.Enabled = false;
        }

        #endregion

        #region CDU & Memory Dump

        private void initCDUTab()
        {
            this.comboBoxChooseCDUScript.Items.Clear();
            setComboCDUScript();
        }

        private void setComboCDUScript()
        {
            foreach (string script_name in CDU.Script_Name)
            {
                comboBoxChooseCDUScript.Items.Add(script_name);
            }
        }

        private void buttonCDURunScript_Click(object sender, EventArgs e)
        {            
        //    string Script_Name = comboBoxChooseCDUScript.Text.ToString() + ".txt";
        //    string path = CDU.folderRoot + Script_Name;
        //    CDU config_cdu = new CDU();
        //    if (File.Exists(path))
        //    {
        //        config_cdu.CDU_configure(path);
        //    }
        //    else
        //    {
        //        Console.WriteLine("CDU file {0} not located in {1}", Script_Name, CDU.folderRoot);
        //    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialogMatlab.ShowDialog() == DialogResult.OK)
            {
                string executable = openFileDialogMatlab.FileName;
                comboBoxMatlabFileName.Text = executable;
            }
        }


        private void buttonCDURunScript_Click_1(object sender, EventArgs e)
        {
            string Script_Name = comboBoxChooseCDUScript.Text.ToString() + ".txt";
            string path = CDU.folderRoot + Script_Name;
            CDU config_cdu = new CDU();
            if (File.Exists(path))
            {
                config_cdu.CDU_configure(path);
            }
            else
            {
                Console.WriteLine("CDU file {0} not located in {1}", Script_Name, CDU.folderRoot);
            }
        }

        private void buttonCDUDownloadResults_Click_1(object sender, EventArgs e)
        {
            CDU get_cdu_results = new CDU();
            MessageBox.Show("this operation will take approximately 1 minute");
            get_cdu_results.CDU_Get_data();
            int i=0;
            while (get_cdu_results.get_all_messages() != true)
            {
                i++;
                if (i > 200000)
                    break;
            }           
            get_cdu_results.CDU_Write_File("CM0_" + comboBoxChooseCDUScript.Text + ".txt", 0);            
            //get_cdu_results.CDU_Write_File("CM1_" + comboBoxChooseCDUScript.Text + ".txt", 1);
            MessageBox.Show("Finish Download CDU Samples");
        }

        private void buttonRunMatlabResult_Click(object sender, EventArgs e)
        {
            string Matlab_file = comboBoxMatlabFileName.Text;
            string sourceFile = System.IO.Path.Combine(sourcePath, Matlab_file);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            if (System.IO.File.Exists(sourceFile))
            {
                System.IO.File.Copy(sourceFile, destFile, true);
                if (System.IO.File.Exists(MatLabViewToolExecutable))
                {
                    Process.Start(MatLabViewToolExecutable, MatLabViewToolargs);
                }
                else
                {
                    MessageBox.Show(@"Missing Matlab executable files (file location: C:\PTP\ViewTool\)");
                }
            }
            else
            {
                MessageBox.Show("Source file error: Missing source file","Matlab Run Error");
            }
            
        }

        private void buttonDownloadMemory_Click_1(object sender, EventArgs e)
        {
            MemoryDump memory_dump = new MemoryDump();

            MessageBox.Show("this operation can take few minute");
            //       uint memory_Address = uint.Parse(comboBoxMemoryDumpDownloadAddress.Text, System.Globalization.NumberStyles.HexNumber);
            uint memory_Address = Convert.ToUInt32(comboBoxMemoryDumpDownloadAddress.Text, 16);
            uint size = Convert.ToUInt32(comboBoxMemoryDumpDownloadSize.Text);
            memory_dump.Memory_Get_data(memory_Address, size);

            int i = 0;
            while (memory_dump.get_all_messages() != true)
            {
                i++;
                if (i > 200000)
                    break;
            }
            memory_dump.Memory_Write_File(comboBoxMemoryDumpDownloadFileName.Text);
  
        }

        private void buttonDownloadMemory_Click(object sender, EventArgs e)
        {
            //MemoryDump memory_dump = new MemoryDump();

            //MessageBox.Show("this operation can take few minute");
            ////       uint memory_Address = uint.Parse(comboBoxMemoryDumpDownloadAddress.Text, System.Globalization.NumberStyles.HexNumber);
            //uint memory_Address = Convert.ToUInt32(comboBoxMemoryDumpDownloadAddress.Text, 16);
            //uint size = Convert.ToUInt32(comboBoxMemoryDumpDownloadSize.Text);
            //memory_dump.Memory_Get_data(memory_Address, size);

            //int i = 0;
            //while (memory_dump.get_all_messages() != true)
            //{
            //    i++;
            //    if (i > 200000)
            //        break;
            //}
            //memory_dump.Memory_Write_File(comboBoxMemoryDumpDownloadFileName.Text);
        }

        #endregion

        #region User Administration

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            this.buttonPropertiesOK.Enabled = false;
            this.buttonPasswordApply.Enabled = true;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            this.buttonPropertiesOK.Enabled = false;
            this.buttonPasswordApply.Enabled = true;
        }

        #endregion

        #region Terminal

        private void initTerminalTab()
        {
            comboBoxSerialNumber.Items.Clear();
            //display the relevant serials for this specific computer
            foreach (string port in PTPSerial.ports)
            {
                comboBoxSerialNumber.Items.Add(port);
            }
            //set shortcuts buttons
            buttonSTerminal1.Text = Properties.Settings.Default.BTNName1;
            buttonSTerminal2.Text = Properties.Settings.Default.BTNName2;
            buttonSTerminal3.Text = Properties.Settings.Default.BTNName3;
            buttonSTerminal4.Text = Properties.Settings.Default.BTNName4;
            buttonSTerminal5.Text = Properties.Settings.Default.BTNName5;
            buttonSTerminal6.Text = Properties.Settings.Default.BTNName6;
            buttonSTerminal7.Text = Properties.Settings.Default.BTNName7;
            buttonSTerminal8.Text = Properties.Settings.Default.BTNName8;
            buttonSTerminal9.Text = Properties.Settings.Default.BTNName9;
            buttonSTerminal10.Text = Properties.Settings.Default.BTNName10;
            buttonSTerminal11.Text = Properties.Settings.Default.BTNName11;
            buttonSTerminal12.Text = Properties.Settings.Default.BTNName12;
            buttonSTerminal13.Text = Properties.Settings.Default.BTNName13;
            buttonSTerminal14.Text = Properties.Settings.Default.BTNName14;
            buttonSTerminal15.Text = Properties.Settings.Default.BTNName15;
       //     buttonSTerminal16.Text = Properties.Settings.Default.BTNName16;
            buttonSerialSendStraing.Enabled = false;
        }

        private void refreshTerminalTextBox()
        {
            Serialrefresh();
        }

        private void refreshTerminal()
        {
            Serialrefresh();
            initTerminalTab();
        }

        private void buttonConnect_Disconnect_Click(object sender, EventArgs e)
        {
            PTPSerial.Serial_Connect_Disconnect();
            //change send string text
            buttonConnect_Disconnect.Text = PTPSerial.Connect_Disconnect;            
            //disable/enable send string button
            if (PTPSerial.Connect_Disconnect == "Connected")
            {
                buttonSerialSendStraing.Enabled = true;
                GetSerialData("");
            }
            else
            {
                buttonSerialSendStraing.Enabled = false;
            }

        }
        
        private void buttonSerialSendStraing_Click(object sender, EventArgs e)
        {
            GetSerialData(textBoxSerialSendStraing.Text);
        }

        private void GetSerialData(string DataToSend)
        {
            PTPSerial.Write(DataToSend);
            Terminalview += DataToSend + "\r";
            Terminalview += PTPSerial.Read();
            Terminalview += PTPSerial.CheckForData();
            richTextBoxSerialrecvStraing.Clear();
            richTextBoxSerialrecvStraing.Text = Terminalview;
        }

        private void Serialrefresh()
        {
            if (PTPSerial.Read() != "")
            {
                Terminalview += PTPSerial.Read();
           //     Terminalview += PTPSerial.CheckForData();
                richTextBoxSerialrecvStraing.Clear();
                richTextBoxSerialrecvStraing.Text = Terminalview;
            }
            
        }

        private void richTextBoxSerialrecvStraing_TextChanged(object sender, EventArgs e)
        {
            //scrall to last line
            richTextBoxSerialrecvStraing.SelectionStart = richTextBoxSerialrecvStraing.Text.Length; //Set the current caret position to the end
            richTextBoxSerialrecvStraing.ScrollToCaret();
        }

        private void buttonClearTerminal_Click(object sender, EventArgs e)
        {
            richTextBoxSerialrecvStraing.Clear();
            Terminalview = "";
        }

        private void buttonEditShortcuts_Click(object sender, EventArgs e)
        {
            if (FormTerminalOptions.TelnetOptioninstance.IsDisposed)
            {
                FormTerminalOptions.TelnetOptioninstance.Show(this);
            }
            else if (!FormTerminalOptions.TelnetOptioninstance.Visible)
            {
                FormTerminalOptions.TelnetOptioninstance.Visible = true;
            }
            else if (FormTerminalOptions.TelnetOptioninstance.WindowState == FormWindowState.Minimized)
            {
                FormTerminalOptions.TelnetOptioninstance.WindowState = FormWindowState.Normal;
            }
            FormTerminalOptions.TelnetOptioninstance.BringToFront();
        }

        private void buttonSTerminal1_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString1);
        }

        private void buttonSTerminal2_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString2);
        }

        private void buttonSTerminal3_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString3);
        }

        private void buttonSTerminal4_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString4);
        }

        private void buttonSTerminal5_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString5);
        }

        private void buttonSTerminal6_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString6);
        }

        private void buttonSTerminal7_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString7);
        }

        private void buttonSTerminal8_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString8);
        }

        private void buttonSTerminal9_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString9);
        }

        private void buttonSTerminal10_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString10);
        }

        private void buttonSTerminal11_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString11);
        }

        private void buttonSTerminal12_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString12);
        }

        private void buttonSTerminal13_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString13);
        }

        private void buttonSTerminal14_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString14);
        }

        private void buttonSTerminal15_Click(object sender, EventArgs e)
        {
            GetSerialData(Properties.Settings.Default.textBoxBTNString15);
        }

        private void buttonRefreshShortcuts_Click(object sender, EventArgs e)
        {
            initTerminalTab();
        }

        #endregion

        #region LOGS

        private void initLOGTab()
        {
            
        }

        private void buttonLogFilePath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogLogs.ShowDialog() == DialogResult.OK)
            {
                string LogPath = folderBrowserDialogLogs.SelectedPath;
                textBoxLogFilePath.Text = LogPath;
            }
        }

        private void buttonStartLog_Click(object sender, EventArgs e)
        {
            StartLogRecording();
        }

        private void StartLogRecording()
        {
            string CurrentDate = DateTime.Now.ToString().Replace('/', '_').Replace(':', '_'); ;
            string Create_File_Name;
  
            if (!System.IO.Directory.Exists(textBoxLogFilePath.Text))
            {
                System.IO.Directory.CreateDirectory(textBoxLogFilePath.Text);
            }

            if (checkBoxLogPhyCounters.Checked)
            {
                try
                {
                    Create_File_Name = textBoxLogFilePath.Text + @"\PhyCountersLog" + CurrentDate + ".csv";
                    System.IO.FileStream fs = System.IO.File.Create(Create_File_Name);
                    fs.Close();
                    
                    FileStream _PHYC = new FileStream(Create_File_Name, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    PhyCfi = new FileInfo(Create_File_Name);
                    PhyC = new StreamWriter(_PHYC);
                    string PHYCDataToSave = "Time, NACK0 , ACK0 , NACK1 , ACK1 ";
                    if (Check_BER_Enable)
                    {
                        PHYCDataToSave = PHYCDataToSave + " , Ant0 Bit Counter , Ant0 Bit CRC Counter" +
                            " , Ant1 Bit Counter , Ant1 Bit CRC Counter";
                    }
                    if (Check_Uncoded_BER_Enable)
                    {
                        PHYCDataToSave = PHYCDataToSave + " , Ant0 uncoded CRC " +
                            " , Ant1 uncoded CRC , Uncoded BER Good bits";
                    }

                    PhyC.WriteLine(PHYCDataToSave);
                    PhyC.Flush();
                }
                catch{}
            }

            if (checkBoxLogGMACCounters.Checked)
            {
                try
                {
                    Create_File_Name = textBoxLogFilePath.Text + @"\GMACCountersLog" + CurrentDate + ".csv";
                    System.IO.FileStream fs = System.IO.File.Create(Create_File_Name);
                    fs.Close();

                    FileStream _GMACC = new FileStream(Create_File_Name, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    GmacCfi = new FileInfo(Create_File_Name);
                    GmacC = new StreamWriter(_GMACC);
                    string GMACDataToSave = "Time, Rx MMC ethernet packet count , Rx Good broadcast frames , Rx Good multicast frames , " +
                "Rx CRC error frames , Rx Good unicast frames , Rx Missed due to FIFO overflow ,  Rx VLAN frames , " +
                "Tx MMC ethernet packet count , Tx Good broadcast frames , Tx - Good multicast frames , Tx - Good and bad unicast frames , " +
                "Tx Good and bad multicast frames , Tx - Good and bad broadcast frames" +
                " , Rx Good broadcast frames , Rx Good multicast frames , " +
                "Rx CRC error frames , Rx Good unicast frames , Rx Missed due to FIFO overflow ,  Rx VLAN frames , " +
                "Tx Good broadcast frames , Tx - Good multicast frames , Tx - Good and bad unicast frames , " +
                "Tx Good and bad multicast frames , Tx - Good and bad broadcast frames";
                    GmacC.WriteLine(GMACDataToSave);
                    GmacC.Flush();
                }
                catch { }

            }
            if (checkBoxLogPhyStatisticss.Checked)
            {
                try
                {
                    Create_File_Name = textBoxLogFilePath.Text + @"\PhyStatisticsLog" + CurrentDate + ".csv";
                    System.IO.FileStream fs = System.IO.File.Create(Create_File_Name);
                    fs.Close();

                    FileStream _PHYS = new FileStream(Create_File_Name, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    PhySfi = new FileInfo(Create_File_Name);
                    PhyS = new StreamWriter(_PHYS);
                    string PHYSDataToSave = "Time, STO0 , CFO0 , XPIC0 , RSSI0 , CINR0, " +
                        "STO1 , CFO1 , XPIC1 , RSSI1 , CINR1, MCS RX , MCS TX , " +
                        "ISYNC achived , ISYNC Peak Level , ISYNC frequency offset , RLM Link State";
                    PhyS.WriteLine(PHYSDataToSave);
                }
                catch { }                
            }
            if (checkBoxUnitInfo.Checked)
            {
                try
                {
                    Create_File_Name = textBoxLogFilePath.Text + @"\UnitInfoLog" + CurrentDate + ".csv";
                    System.IO.FileStream fs = System.IO.File.Create(Create_File_Name);
                    fs.Close();

                    FileStream _UnitInfo = new FileStream(Create_File_Name, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    UnitI = new StreamWriter(_UnitInfo);
                    string UnitInfoDataToSave = "Unit Type , Running Profile , Transmition Mode , SW Version";
                    UnitI.WriteLine(UnitInfoDataToSave);
                    UnitI.Flush();
                }
                catch { }
            }
            if (checkBoxRFInfo.Checked)
            {
                try
                {
                    Create_File_Name = textBoxLogFilePath.Text + @"\RFInfoLog" + CurrentDate + ".csv";
                    System.IO.FileStream fs = System.IO.File.Create(Create_File_Name);
                    fs.Close();

                    FileStream _RFInfo = new FileStream(Create_File_Name, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    RFI = new StreamWriter(_RFInfo);
                    string RFInfoDataToSave = "TX RF Frequnency , TX RF Power , TX Spectrum Inversion , RX RF Frequnency , RX RF Power";
                    RFI.WriteLine(RFInfoDataToSave);
                    RFI.Flush();
                }
                catch { }
            }
            Save_Log_To_Files();
            Save_Info_files();
            LOGS_Enable = true;
            buttonStartLog.Enabled = false;
        }

        public void Save_Log_To_Files()
        {
            Timer = DateTime.Now.ToString("HH:mm:ss tt");
            if (checkBoxLogPhyCounters.Checked)
            {
                LogPHYCToFile();
            }

            if (checkBoxLogGMACCounters.Checked)
            {
                LogGMACCToFile();
            }
            if (checkBoxLogPhyStatisticss.Checked)
            {
                LogPHYSToFile();
            }
            if ((PhyCfi.Length > 10000) && (GmacCfi.Length > 10000) || (PhySfi.Length > 100000))
            {
                StopLogRecording();
                StartLogRecording();
            }
        }

        private void Save_Info_files()
        {
            if (checkBoxUnitInfo.Checked)
            {
                LogsUnitInfoToFile();
            }
            if (checkBoxRFInfo.Checked)
            {
                LogRFInfoToFile();
            }
        }

        private void LogPHYCToFile()
        {
            string PHYCDataToSave = Timer + " , "
                + Convert.ToString((decimal)PHY.phy.NACK0) + " , "
                + Convert.ToString((decimal)PHY.phy.ACK0) + " , "                        
                + Convert.ToString((decimal)PHY.phy.NACK1) + " , "
                + Convert.ToString((decimal)PHY.phy.ACK1) + " , ";
                if (Check_BER_Enable)
                {
                    PHYCDataToSave += Convert.ToString((PHY.phy.BER_Good_bits_Ant0 * 32)) + " , "
                    + Convert.ToString((PHY.phy.BER_Error_bits_Ant0)) + " , "
                    + Convert.ToString((PHY.phy.BER_Good_bits_Ant1 * 32)) + " , "
                    + Convert.ToString((PHY.phy.BER_Error_bits_Ant1)) + " , ";
                }
                if (Check_Uncoded_BER_Enable)
                {
                    PHYCDataToSave += Convert.ToString((PHY.phy.Uncoded_BER_Error_bits_Ant0)) + " , "
                    + Convert.ToString((PHY.phy.Uncoded_BER_Error_bits_Ant0)) + " , "
                    + Convert.ToString((PHY.phy.Uncoded_BER_Good_bits * 8 * 4));
                }
                PhyC.WriteLine(PHYCDataToSave);
                PhyC.Flush();
        }

        private void LogPHYSToFile()
        {
            // save the following:
            //"STO0 , CFO0 , XPIC0 , RSSI0 , CINR0, " +
            //        "STO0 , CFO0 , XPIC0 , RSSI0 , CINR0, MCS RX , MCS TX , " +
            //        "ISYNC achived , 
            // missing : ISYNC Peak Level , ISYNC frequency offset"

            string PHYSDataToSave = Timer + " , "
                    + Convert.ToString((decimal)PHY.phy.STO1) + " , "
                    + Convert.ToString((decimal)PHY.phy.CFO1) + " , "
                    + Convert.ToString((decimal)PHY.phy.XPI1) + " , "
                    + Convert.ToString((decimal)PHY.phy.RSSI1) + " , "
                    + Convert.ToString((decimal)PHY.phy.CINR1avg) + " , "
                    + Convert.ToString((decimal)PHY.phy.STO2) + " , "
                    + Convert.ToString((decimal)PHY.phy.CFO2) + " , "
                    + Convert.ToString((decimal)PHY.phy.XPI2) + " , "
                    + Convert.ToString((decimal)PHY.phy.RSSI2) + " , "
                    + Convert.ToString((decimal)PHY.phy.CINR2avg) + " , "
                    + Convert.ToString(PHY.phy.controlChannelRx.txAnnounced1) + ","
                    + Convert.ToString(PHY.phy.controlChannelTx.txAnnounced2) + ","
                    + Convert.ToString(LinkIndicator.links.SyncAchieved) + ","
                    + Convert.ToString((decimal)PHY.phy.IsyncPeak) + ","
                    + Convert.ToString((decimal)PHY.phy.IsyncFreq) + ","
                    + Convert.ToString((decimal)PHY.phy.LinkStatus)+",";

            PhyS.WriteLine(PHYSDataToSave);
            PhyS.Flush();
        }

        private void LogGMACCToFile()
        {
            string GMACCDataToSave = Timer + " , ";

            for (int i = 0; i < GMAC.gmac0.REG_GMAC0; i++)
            {
                GMACCDataToSave += Convert.ToString(GMAC.gmac0.CurrentCounters_GMAC0[i]) + ",";
            }
            for (int i = 0; i < GMAC.gmac1.REG_GMAC1; i++)
            {
                GMACCDataToSave += Convert.ToString(GMAC.gmac1.CurrentCounters_GMAC1[i]) + ",";
            }
            GmacC.WriteLine(GMACCDataToSave);
            GmacC.Flush();
        }

        private void LogsUnitInfoToFile()
        {
            //No need to rewrite - this information saved only once.
            // "Unit Type , Running Profile , Transmition Mode , SW Version"
            string UnitInfoDataToSave = Convert.ToString(UnitType) + " , "
                 + Convert.ToString(RunningProfile)  + " , "
                 + Convert.ToString(SisoMimoMode)  + " , "
                 + Convert.ToString(SW_Version);
            UnitI.WriteLine(UnitInfoDataToSave);
            UnitI.Flush();
            UnitI.Close();
            
        }

        private void LogRFInfoToFile()
        {
            //No need to rewrite - this information saved only once.
            //"TX RF Frequnency , TX RF Power , TX Spectrum Inversion , RX RF Frequnency , RX RF Power"
            RFI.Close();
        }

        private void buttonStopLog_Click(object sender, EventArgs e)
        {
            StopLogRecording();
        }

        private void StopLogRecording()
        {
            //Stop all log counters and close the streamwriter for all of them.
         
            LOGS_Enable = false;
            if (checkBoxLogPhyCounters.Checked)
            {
                PhyC.Close();
            }

            if (checkBoxLogGMACCounters.Checked)
            {
                GmacC.Close();
            }
            if (checkBoxLogPhyStatisticss.Checked)
            {
                PhyS.Close();
            }    
            
            buttonStartLog.Enabled = true;
        }

        #endregion

        #region TFTPD32

        private void buttonOpenTFTPFile_Click(object sender, EventArgs e)
        {
            folderBrowserDialogTFTP.SelectedPath = textBoxOpenTFTPFile.Text;
            if (folderBrowserDialogTFTP.ShowDialog() == DialogResult.OK)
            {
                string dataPath = folderBrowserDialogTFTP.SelectedPath;
                textBoxOpenTFTPFile.Text = dataPath;
            }

        }

        private void buttonCloseTFTP_Click(object sender, EventArgs e)
        {
            tftpd32.Kill_TFTP32D();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxOpenTFTPFile.Text != "")
            {
                tftpd32.change_ini(textBoxOpenTFTPFile.Text);
            }
            else
            {
                tftpd32.change_ini(@"C:\");
            }
            tftpd32.OpenTFTP32D();
        }
    
        #endregion


    }
}
