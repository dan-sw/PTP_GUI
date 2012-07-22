#region using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Collections;
using SpPerfChart;

#endregion

namespace WindowsFormsApplication1
{
    public partial class FormSystemStatus : Form
    {
        #region Variables

        // Debugging only:
        Random random = new Random();

        // Twice a second:
        private const int SAMPLING_INTERVAL = 500;
        // Once every 5 seconds:
        public static int ConstellationUpdateIntervalSec = 5;
        private System.Diagnostics.Stopwatch constellationStopwatch = new System.Diagnostics.Stopwatch();

        // Objects that need synchronization must be individually managed (see
        // constellationLock.)   This boolean tells the background message
        // generator to stop requesting updates.  Not currently (Nov 2011) used
        private bool pauseFormUpdates = false;

        private Constellation constellation = null;
        private Object constellationLock = new Int16();
        private Constellation.TRIGGER_RETURN_CODE constellationBackgroundResults;

        // KeepAlive monitor.
        private readonly int KEEP_ALIVE_FAILURE_THRESHOLD = 3;
        private int keepAliveFailure;
        private bool KeepAliveEnable = false;

        // Keeping track of the GMAC and statistic selections,
        // for use by non-GUI thread:
        private GMAC gmacLeft = GMAC.gmac0;
        private GMAC gmacRight = GMAC.gmac0;
        private int gmacLeftSelection;
        private int gmacRightSelection;

        private bool EVB_Connection_up = true;
        private bool StartLog = false;
        private StreamWriter sw;

        public static bool MCS_per_BW = false;

 //       public static FormNodeProperties instance;

        #endregion

        #region SystemStatusForm functionality

        public FormSystemStatus( )
        {
            InitializeComponent();

            this.comboBoxGraph0a.SelectedIndex = 0;  // GMAC0
            this.comboBoxGraph0b.SelectedIndex = 0;  // Rx- MMC ethernet packet count
            this.comboBoxGraph1a.SelectedIndex = 0;  // GMAC0
            this.comboBoxGraph1b.SelectedIndex = 7;  // Tx- MMC ethernet packet count

            this.radioButtonRSSI1.Checked = true;

            // This checkbox is for development only
            chkBxTimerEnabled.Visible = true;
            chkBxTimerEnabled.Checked = true;  // invokes RunTimer()       
            if (!File.Exists(@"C:\PTP\Log.csv"))
            {
                File.Create(@"C:\PTP\Log.csv");
            }
            FileStream _fs = new FileStream(@"C:\PTP\Log.csv", FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            sw = new StreamWriter(_fs);
            string DataToSave = "NACK0" + " , " + "ACK0" + " , " + "NACK1" + " , " + "ACK1"
                              + " , "   + "NackCtrl" + " , " + "AckCtrl" + " , " 
                              + "CINR1avg" + " , " + "RSSI1" + " , " + "STO1" + " , "
                              + "CINR2avg" + " , " + "RSSI2" + " , " + "STO2" + " , "
                              + "MCSRX" + "," + "MCSTX";
            sw.WriteLine(DataToSave);

            FormNodeProperties.instance.Visible = true;
            FormNodeProperties.instance.Visible = false;    
            
        }

        private void comboBoxGraph0a_SelectedIndexChanged(object sender, EventArgs e)
        {
            // gmacLeft is accessed by another, non-gui, thread:
            gmacLeft = ((this.comboBoxGraph0a.SelectedIndex == 0) ? GMAC.gmac0 : GMAC.gmac1);
            spPerfChart0.Clear();
            // Remember previous selection:
            int registerSelection = Math.Min(this.comboBoxGraph0b.SelectedIndex, gmacLeft.RegisterNames.Length - 1);
            // reload combo of register names
            this.comboBoxGraph0b.Items.Clear();
            foreach (string s in gmacLeft.RegisterNames)
            {
                this.comboBoxGraph0b.Items.Add(s);
            }
            // change selection, if beyond end of list
            this.comboBoxGraph0b.SelectedIndex = Math.Max(0, registerSelection);
        }

        private void comboBoxGraph1a_SelectedIndexChanged(object sender, EventArgs e)
        {
            // gmacRight is accessed by another, non-gui, thread:
            gmacRight = ((this.comboBoxGraph1a.SelectedIndex == 0) ? GMAC.gmac0 : GMAC.gmac1);
            spPerfChart1.Clear();
            // Previous selection:
            int registerSelection = Math.Min(this.comboBoxGraph1b.SelectedIndex, gmacRight.RegisterNames.Length - 1);

            // reload combo of register names
            this.comboBoxGraph1b.Items.Clear();
            foreach (string s in gmacRight.RegisterNames)
            {
                this.comboBoxGraph1b.Items.Add(s);
            }
            // Try to restore previous selection (but not -1)
            this.comboBoxGraph1b.SelectedIndex = Math.Max(0, registerSelection); 
        }

        private void comboBoxGraph0b_SelectedIndexChanged(object sender, EventArgs e)
        {
            // gmacLeftSelection is for access by another, non-gui, thread:
            gmacLeftSelection = comboBoxGraph0b.SelectedIndex;
            spPerfChart0.Clear();
        }

        private void comboBoxGraph1b_SelectedIndexChanged(object sender, EventArgs e)
        {
            // gmacRightSelection is for access by another, non-gui, thread:
            gmacRightSelection = comboBoxGraph1b.SelectedIndex;
            spPerfChart1.Clear();
        }

        /*
         * Adjusts GMAC charts to indicate how many seconds of data are shown.  Based on
         * 16 pixel horiz grid spacing, and sampling rate currently employed.
         */
        private void updateGroupboxLabels()
        {
            // The TimerMode.Disabled will draw one datapoint per sample interval,
            // and for each sample scroll the chart valueSpacing pixels.
            int valueSpacing = 5; // from SpPerfChart
            int GRID_SPACING = 16; // Horiz spacing, from SpPerfChart
            // Pixels per second:
            double pixelsPerSecond = valueSpacing * (1000.0 / SAMPLING_INTERVAL);
            // Seconds per gridline:
            double secPerGrid = ((double)GRID_SPACING) / ((double)pixelsPerSecond);
            // Number of vert gridlines:
            double gridlines = ((double)spPerfChart0.Width) / GRID_SPACING;
            int numberOfSecondsDisplayed = (int)(spPerfChart0.Width / pixelsPerSecond);
            // Since the container keeps both charts equal in width, same value applies to both:
            this.groupBoxGMAC0.Text = String.Format("{0}     {1} sec ", comboBoxGraph0a.SelectedItem.ToString(), numberOfSecondsDisplayed);
            this.groupBoxGMAC1.Text = String.Format("{0}     {1} sec ", comboBoxGraph1a.SelectedItem.ToString(), numberOfSecondsDisplayed);
        }
        #endregion

        #region constellation

        /* 
         * Must be reentrant, can be called by the gui or the background worker
         * at the RunWorkerCompleted method.
         */
        private void stopConstellation()
        {
            // Sometimes, will block processing of the button from 'off' to 'on',
            // but if we don't block here, constellation.shutDown can happen at
            // the same time that the bgWrk thread is iterating PhyConstellationData
            // objects, registering with pcap, etc.
            lock (constellationLock)
            {
                if (constellation != null)
                {
                    constellation.shutDown();
                }
                buttonConstellation.Text = "Constellation";
                constellation = null;
                // Don't need to cancel the background task; just let
                // it finish.  It will detect null constellation
                // during RunWorkerCompleted.
            }
        }

        private void buttonConstellation_Click(object sender, EventArgs e)
        {
            if (buttonConstellation.Text == "Constellation")
            {
                lock (constellationLock)
                {
                    if (constellation == null)
                    {
                        constellation = new Constellation();
                        // First time only, check that matlab folder exists
                        if (!File.Exists(Constellation.constellationExecutable ))
                        {
                            MessageBox.Show("The Matlab program is not present, at: " + Constellation.constellationExecutable
                                + "\n\nUse Properties / Constellation page to select a different Matlab executable or location.",
                                "DAN PTP - Installation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            constellation = null;
                            return;
                        }
                    }
                    buttonConstellation.Text = "Close Plot";
                } // unlocked

                // Get constellation data, write files and launch Matlab on a worker thread.
                // It's possible (try double-clicking "Constellation" button) that the worker
                // has already been started, so only invoke RunWorker when not busy:
                if (!bgWrkConstellation.IsBusy)
                {
                    bgWrkConstellation.RunWorkerAsync();
                }
            }
            else
            {
                stopConstellation();
            }
        }

        #endregion

        #region Timer-driven methods, to poll EVB and collate constellation data

        private void bgWrkConstellation_DoWork(object sender, DoWorkEventArgs e)
        {
            int delayDuration = Convert.ToInt32(e.Argument);
            if (delayDuration > 0)
            {
                Thread.Sleep(delayDuration);
            }
            // Although this will be locked for a while, it is important to
            // delay any "Close Constellation" button click until the trigger()
            // completes waiting for EVB replies.  This lock only blocks the GUI
            // if the user clicks the button.
            lock (constellationLock)
            {
                if (constellation != null)
                {
                    // Take note of when the task begins
                    constellationStopwatch.Restart();

                    constellationBackgroundResults = constellation.trigger();
                }
                else
                {
                    // This happens each time "Close Plot" is clicked
                    constellationBackgroundResults = Constellation.TRIGGER_RETURN_CODE.OK;
                }
            }
        }

        /*
         * Requesting, processing constellation data is performed during the DoWork
         * part of this BackgroundWorker.
         * Here, results are considered, user is notified if the process failed,
         * and - if success - the Constellation background worker is restarted.
         */
        private void bgWrkConstellation_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            constellationStopwatch.Stop();
            switch (constellationBackgroundResults)
            {
                case Constellation.TRIGGER_RETURN_CODE.SOC_UNRESPONSIVE:
                    MessageBox.Show("Timeout fetching constellation data - the EVB has stopped responding.",
                        "DAN PTP - Communication Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    stopConstellation();
                    return;
                case Constellation.TRIGGER_RETURN_CODE.EXECUTABLE_FAILURE:
                    MessageBox.Show("The Matlab process failed to start",
                        "DAN PTP - Process Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    stopConstellation();
                    return;
                case Constellation.TRIGGER_RETURN_CODE.FILE_WRITE_FAILURE:
                    MessageBox.Show("Error writing constellation files for the Matlab process",
                        "DAN PTP - File Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    stopConstellation();
                    return;
                default:
                    // TRIGGER_RETURN_CODE_OK
                    if (constellation == null)
                    {
                        // Usually not needed; this is a typical exit from charting mode.
                        stopConstellation();
                        return; // ends
                    }
                    // Restart the task, specifying a certain delay.  (Deduct the time
                    // spent waiting for responses from SOC and filesystem I/O)
                    int delayDuration = (ConstellationUpdateIntervalSec * 1000) - (int)constellationStopwatch.ElapsedMilliseconds;
                    if (delayDuration < 0) { delayDuration = 1; }  // already used up our time
                    // Restart the task (bgWrkConstellation is not 'busy')
                    bgWrkConstellation.RunWorkerAsync(delayDuration);
                    break;
            }
        }

        // This checkbox is helpful for development, not visible for release:
        private void chkBxTimerEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBxTimerEnabled.Checked && !bgWrkTimer.IsBusy)
            {
                RunTimer();
            }
        }

        // The object bgWrkTimer has been configured as a one-shot timer,
        // which may restart itself (if chkBxTimerEnabled) when its work
        // is done.
        private void RunTimer()
        {
            bgWrkTimer.RunWorkerAsync(SAMPLING_INTERVAL);
        }

        // Not allowed to interact with user-interface objects during this event handler!
        private void bgWrkTimer_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // Request Data from EVB for displayed objects
                if (!pauseFormUpdates)
                {
                    // request next values for GMAC graphs
                    gmacLeft.getNextValue(gmacLeftSelection);
                    gmacRight.getNextValue(gmacRightSelection);

                    // Request data for Link Status
                    LinkIndicator.links.getNextValues();
                    // update PHY
                    PHY.phy.getNextValues();
                    // update AMC
                    AMC.amc.getNextValues();
                    //update Debug tabs and unit control
               //     FormNodeProperties.instance.getNextValues();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception {0}", ex.Message);
            }
            Thread.Sleep(Convert.ToInt32(e.Argument));
        }

        /*
         * The sleep is done, DAN msg replies have probably arrived
         */
        private void bgWrkTimer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (KeepAliveEnable)
                {
                    if (keepAliveFailure > KEEP_ALIVE_FAILURE_THRESHOLD)
                    {
                        // looking for heartbeat resume
                        if (PHY.phy.RxNumFrameIndsDelta > 0 && PHY.phy.TxNumFrameIndsDelta > 0)
                        {
                            // reset
                            keepAliveFailure = 0;
                            string msg = global::WindowsFormsApplication1.Properties.Resources.HeartbeatNotificationRegain;
                            MessageBox.Show(msg, "DAN PTP Heartbeat Notification",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            EVB_Connection_up = true;
                        }
                    }
                    else
                    {
                        if (PHY.phy.RxNumFrameIndsDelta == 0 || PHY.phy.TxNumFrameIndsDelta == 0)
                        {
                            if (++keepAliveFailure > KEEP_ALIVE_FAILURE_THRESHOLD)
                            {
                                // Notify user
                                string msg = global::WindowsFormsApplication1.Properties.Resources.HeartbeatNotificationError;
                                MessageBox.Show(msg, "DAN PTP Heartbeat Notification",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                EVB_Connection_up = false;

                            }
                        }
                        else
                        {
                            // One good heartbeat resets the counter
                            keepAliveFailure = 0;
                        }
                    }
                }
                if (EVB_Connection_up)
                {
                    // Link Status
                    this.panelLinkSync.BackColor = (LinkIndicator.links.SyncAchieved ? System.Drawing.Color.LightGreen : System.Drawing.Color.Yellow);
                    this.panelLinkTimingLoop.BackColor = (LinkIndicator.links.TimingLoopOK ? System.Drawing.Color.LightGreen : System.Drawing.Color.Yellow);
                    this.panelLinkTxOn.BackColor = (LinkIndicator.links.TxOn ? System.Drawing.Color.LightGreen : System.Drawing.Color.Yellow);
                    this.panelLinkPllLock.BackColor = (LinkIndicator.links.PllLock ? System.Drawing.Color.LightGreen : System.Drawing.Color.Yellow);
                    // GMACs
                    updateGroupboxLabels();
                    decimal rate = (decimal)gmacLeft.rateCounter(gmacLeftSelection);
                    this.spPerfChart0.AddValue(rate);
                    this.labelGraph0Max.Text = String.Format("Max:  {0:0,0} f/s", spPerfChart0.MaxValue);
                    this.labelGraph0Latest.Text = String.Format("{0:0,0.0} f/s", rate);
                    // Repeat for Graph1:
                    rate = (decimal)gmacRight.rateCounter(gmacRightSelection);
                    this.spPerfChart1.AddValue(rate);
                    this.labelGraph1Max.Text = String.Format("Max:  {0:0,0} f/s", spPerfChart1.MaxValue);
                    this.labelGraph1Latest.Text = String.Format("{0:0,0.0} f/s", rate);

                    ///  RSSI Graph - range {-40..0}
                    ///  (Since graphs don't support neg numbers, for now just chart abs(x) i.e, -1x)
                    try
                    {
                        // TEMP DEBUG: Since both values are identical (I don't have a radio), use a randomizer
                        // for now
                        //double value1 = random.Next(-80, -10);
                        //double value2 = random.NextDouble() * -80;
                        
                        if (FormNodeProperties.instance.SisoMimoMode == "Single SISO")
                        {
                            this.spPerfChartRSSI.AddValues((decimal)-PHY.phy.RSSI1, (decimal)-PHY.phy.RSSI1);
                        }
                        else
                        {
                            this.spPerfChartRSSI.AddValues((decimal)-PHY.phy.RSSI1, (decimal)-PHY.phy.RSSI2 + 1);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error adding values {0} & {1} to RSSI", -PHY.phy.RSSI1, -PHY.phy.RSSI2);
                    }
                    this.labelGraphRSSI0Current.Text = String.Format(" {0:0.0} dBFS", PHY.phy.RSSI1);
                    this.labelGraphRSSI1Current.Text = String.Format(" {0:0.0} dBFS", PHY.phy.RSSI2);

                    /// CINR  -  range {0..50}
                    // this SOC value wasn't changing in Sim mode:  val = (decimal)(radioButtonCINR1.Checked ? PHY.phy.CINR1 : PHY.phy.CINR2);
                    // Temporarily, use the AmcAveraged CINR:
                    //val = (decimal)(radioButtonCINR1.Checked ? PHY.phy.CINR1avg : PHY.phy.CINR2avg); //AMC.amc.CinrAmcAveragedCinr0); 
                    try
                    {
                        decimal CINR_scale = 100.0m / (decimal)PHY.phy.CINR_Max;
                        if (FormNodeProperties.instance.SisoMimoMode == "Single SISO")
                        {
                            this.spPerfChartCINR.AddValues(((decimal)PHY.phy.CINR1) * CINR_scale, ((decimal)PHY.phy.CINR1) * CINR_scale);
                        }
                        else
                        {
                            this.spPerfChartCINR.AddValues(((decimal)PHY.phy.CINR1) * CINR_scale, ((decimal)PHY.phy.CINR2) * CINR_scale + 1);
                        }
               //         MessageBox.Show("CINR1 = " + PHY.phy.CINR1.ToString() + " CINR2 = " + PHY.phy.CINR2.ToString());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error adding values {0} & {1} to CINR", PHY.phy.CINR1, PHY.phy.CINR2);
                    }
                    this.labelGraphCINR0Current.Text = String.Format(" {0:0.00} dB", PHY.phy.CINR1);
                    this.labelGraphCINR1Current.Text = String.Format(" {0:0.00} dB", PHY.phy.CINR2);

                    /// PER  -  % {0..100}
                    /// New 9Nov2011: Using values that Haim told me about, where there is a Nack and Ack
                    /// for each antenna.
                    /// Not sure this percentage is using the correct values.. shouldn't there be two ACK counters?
                    decimal nack = (decimal)PHY.phy.NACK0;
                    decimal ack = (decimal)PHY.phy.ACK0;
                    decimal nackB = (decimal)PHY.phy.NACK1;
                    decimal ackB = (decimal)PHY.phy.ACK1;
                    decimal val = ((ack + nack) == 0) ? 0m : nack / (ack + nack);
                    decimal valB = ((ackB + nackB) == 0) ? 0m : nackB / (ackB + nackB);
                    try
                    {                        
                        if (FormNodeProperties.instance.SisoMimoMode == "Single SISO")
                        {
                            this.spPerfChartPER.AddValues(val * 100, val * 100);
                        }
                        else
                        {
                            this.spPerfChartPER.AddValues(val * 100, valB * 100 + 1);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error adding values {0} & {1} to PER", val * 1000, valB * 1000);
                    }
                    this.labelGraphPER0Current.Text = String.Format(" {0:0.0} %", val * 100);
                    this.labelGraphPER1Current.Text = String.Format(" {0:0.0} %", valB * 100);
                    this.labelGraphPER0Nack.Text = nack.ToString();
                    this.labelGraphPER1Nack.Text = nackB.ToString();

                    /// AMC-Averaged CINR
                    /// // NOTE that, since current code does not provide reliable value
                    /// // in PHY.phy.CINR1, this value displays twice on the screen:
                    //double amcAvg = radioButtonMCSAnt1.Checked ? PHY.phy.CINR1avg : PHY.phy.CINR2avg;
                    // value is in db
                    //labelCinrAvgValue.Text = String.Format("{0:0.0} db", amcAvg);

                    // TODO: Get bandwidth from somewhere... right now, looks like a SOC build #define
                    MCS.BANDWIDTH bw = MCS.BANDWIDTH.MHZ80;

                    // TODO: Did we intend to display just TX values with this graph?
                    // Valid values are enforced by AMC
                    if (PHY.phy.controlChannelTx == null)
                    {
                        // may happen when PHY hasn't received a handleControlChannels
                        // message yet
                        Console.WriteLine("null controlChannelTx...");
                    }
                    else
                    {
                        //uint mcsCurrent = (radioButtonMCSAnt1.Checked ? PHY.phy.controlChannelTx.txAnnounced1 : PHY.phy.controlChannelTx.txAnnounced2);
                        uint mcsCurrent = PHY.phy.controlChannelRx.txAnnounced1;
                        uint mcsCurrentB = PHY.phy.controlChannelTx.txAnnounced2;
                        // Scale to 100
                        try
                        {
                            // Scale based on number of defined modulations
                         //   decimal scale = (100.0m / MCS.getMaxMCS()) * (decimal)0.85;
                            decimal scale = (100.0m / MCS.getMaxMCS());
                            decimal up_graph_offset = (decimal)-0.5;
                            // Multiply to scale {0..8} -> {0..100}, but then add 1/2 Grid_Y_, so they line up with the labels
                            // Note that this chart is in absolute mode.
                            decimal halfGridY = spPerfChartMCS.Grid_Y_Spacing / 2m; // current size of Chart
                            this.spPerfChartMCS.AddValues((mcsCurrent * scale) + up_graph_offset, (mcsCurrentB * scale) + up_graph_offset - 1);
                            this.labelMcsLatest.Text = String.Format("{0} ({1})", mcsCurrent, MCS.getMCS(bw, mcsCurrent).ToString());
//                          this.labelMcsLatest.Text = String.Format("{0} ({1})", mcsCurrent, MCS.getMCS(bw, mcsCurrent,  FormSystemStatus.instance.MCSset).ToString());
                            
                        }
                           
                        catch (Exception)
                        {
                            Console.WriteLine("Error adding value {0} to MCS chart, or getting display string", mcsCurrent);
                        }
                        if (AMC.amc.AutoAMC)
                        {
                            this.labelMcsAuto.Text = "Auto";
                            this.labelMcsManualSetting.Text = "";

                        }
                        else
                        {
                            this.labelMcsAuto.Text = "Manual:";
                            // Note that current SOC uses antenna zero for both; but stores 2 values
                            //    uint specifiedMcs = radioButtonMCSAnt1.Checked ? AMC.amc.McsManualId0 : AMC.amc.McsManualId1;
                            uint specifiedMcs = AMC.amc.McsManualId0;
                            try
                            {
                                this.labelMcsManualSetting.Text = MCS.getMCS(bw, specifiedMcs).ToString();
                            }
                            catch (Exception ex2)
                            {
                                Console.WriteLine("Exception setting labelMcsManualSetting from MCS value {0} - {1}", specifiedMcs, ex2.Message);
                            }
                        }
                    }
                    if (PHY.phy.controlChannelRx != null)
                    {
                        uint txAnnouncedMCS = this.radioButtonMCSAnt1.Checked ? PHY.phy.controlChannelRx.txAnnounced1 : PHY.phy.controlChannelTx.txAnnounced2;
                        // Requested Rx Modulation
                        uint rxRequestedMcs = PHY.phy.controlChannelRx.rxRecommended1;
//                        textBoxReqRxMod0.Text = String.Format("{0} ({1})", rxRequestedMcs, MCS.getMCS(bw, rxRequestedMcs).modulation);
                        rxRequestedMcs = PHY.phy.controlChannelRx.rxRecommended2;
//                        textBoxReqRxMod1.Text = String.Format("{0} ({1})", rxRequestedMcs, MCS.getMCS(bw, rxRequestedMcs).modulation);
                        labelMcsLatest.Text = String.Format("{0} - {1}", txAnnouncedMCS, MCS.getMCS(bw, txAnnouncedMCS).ToString());
                    }
                    // Heartbeat monitor 
                    //  See PHY property RxNumFrameIndsDelta, which uses mmc_num_rx_frame_inds 
                    // for heartbeat (and TxNumFrameIndsDelta which uses mmc_num_tx_frame_inds.)
                    //  If the delta is zero, either this is the first (unlikely) sample
                    // or something is stuck in MMC.  If delta is zero three times in a row,
                    // show a message.
                    //  Once the message is shown, doesn't show it again until things have
                    // been corrected (heartbeat resumes.)


                    // Restart, will no-op if pauseFormUpdates    
                    this.textBoxSTO1.Text = String.Format(" {0:0.0}", PHY.phy.STO1);
                    this.textBoxSTO2.Text = String.Format(" {0:0.0}", PHY.phy.STO2);

                }
                if (FormNodeProperties.instance.SisoMimoMode == "Single SISO")
                {
                    labelGraphRSSI1Current.Visible = false;
                    radioButtonRSSI2.Visible = false;
                    labelGraphCINR1Current.Visible = false;
                    radioButtonCINR2.Visible = false;
                    labelGraphPER1Current.Visible = false;
                    labelGraphPER1Nack.Visible = false;
                    radioButtonPER2.Visible = false;

                }
                if (StartLog)
                {
                    LogToFile();
                }
                if (chkBxTimerEnabled.Checked)
                {
                    RunTimer();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception {0}", ex.Message);
            }
        }

        #endregion

        private void radioButtonRSSI1_CheckedChanged(object sender, EventArgs e)
        {
            // This chart is a DualGraph.  Highlight one or another dataset

            spPerfChartRSSI.PerfChartStyle.ChartLinePen.Width =
                (radioButtonRSSI1.Checked) ? 3 : 2;
            if (!chkBxTimerEnabled.Checked)
            {
                spPerfChartRSSI.Invalidate();
            }
        }

        private void radioButtonRSSI2_CheckedChanged(object sender, EventArgs e)
        {
            spPerfChartRSSI.PerfChartStyle.ChartLinePenB.Width =
                (radioButtonRSSI2.Checked) ? 3 : 2;
            if (!chkBxTimerEnabled.Checked)
            {
                spPerfChartRSSI.Invalidate();
            }
        }

        private void radioButtonCINR1_CheckedChanged(object sender, EventArgs e)
        {
            spPerfChartCINR.PerfChartStyle.ChartLinePen.Width =
                (radioButtonCINR1.Checked) ? 3 : 2;
            if (!chkBxTimerEnabled.Checked)
            {
                spPerfChartCINR.Invalidate();
            }
        }

        private void radioButtonCINR2_CheckedChanged(object sender, EventArgs e)
        {
            spPerfChartCINR.PerfChartStyle.ChartLinePenB.Width =
                (radioButtonCINR2.Checked) ? 3 : 2;
            if (!chkBxTimerEnabled.Checked)
            {
                spPerfChartCINR.Invalidate();
            }
        }

        private void radioButtonPER1_CheckedChanged(object sender, EventArgs e)
        {
            spPerfChartPER.PerfChartStyle.ChartLinePen.Width =
                (radioButtonPER1.Checked) ? 3 : 1;
            spPerfChartPER.PerfChartStyle.ChartLinePenB.Width =
                (radioButtonPER2.Checked) ? 3 : 1;
        }

        private void radioButtonPER2_CheckedChanged(object sender, EventArgs e)
        {
            spPerfChartPER.PerfChartStyle.ChartLinePen.Width =
                (radioButtonPER1.Checked) ? 3 : 1;
            spPerfChartPER.PerfChartStyle.ChartLinePenB.Width =
                (radioButtonPER2.Checked) ? 3 : 1;
            if (!chkBxTimerEnabled.Checked)
            {
                spPerfChartPER.Invalidate();
            }
        }

        private void radioButtonMCSrx_CheckedChanged(object sender, EventArgs e)
        {
            spPerfChartMCS.PerfChartStyle.ChartLinePen.Width =
                (radioButtonMCSAnt1.Checked) ? 3 : 1;
            spPerfChartMCS.PerfChartStyle.ChartLinePenB.Width =
                (radioButtonMCSAnt2.Checked) ? 3 : 1;
            if (!chkBxTimerEnabled.Checked)
            {
                spPerfChartMCS.Invalidate();
            }
        }

        private void radioButtonMCStx_CheckedChanged(object sender, EventArgs e)
        {
            spPerfChartMCS.PerfChartStyle.ChartLinePen.Width =
               (radioButtonMCSAnt1.Checked) ? 3 : 1;
            spPerfChartMCS.PerfChartStyle.ChartLinePenB.Width =
                (radioButtonMCSAnt2.Checked) ? 3 : 1;
            if (!chkBxTimerEnabled.Checked)
            {
                spPerfChartMCS.Invalidate();
            }
        }

        private void buttonResetCounters_Click(object sender, EventArgs e)
        {
            //clear all PHY counters statistics and clear all graphs
            PHY.phy.resetAirlinkCounters();
            spPerfChart0.Clear();
            spPerfChart1.Clear();
            spPerfChartRSSI.Clear();
            spPerfChartCINR.Clear();
            spPerfChartPER.Clear();
            spPerfChartMCS.Clear();
        }

        private void buttonProperties_Click(object sender, EventArgs e)
        {

            if (FormNodeProperties.instance.IsDisposed)
            {
                FormNodeProperties.instance.Show(this);
            }
            else if (!FormNodeProperties.instance.Visible)
            {
                FormNodeProperties.instance.Visible = true;
            }
            else if (FormNodeProperties.instance.WindowState == FormWindowState.Minimized)
            {
                FormNodeProperties.instance.WindowState = FormWindowState.Normal;
            }
            FormNodeProperties.instance.BringToFront();            
        }        

        private void checkBoxStartLog_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStartLog.Checked)
                { StartLog = true; }
            else
                { StartLog = false; }
        }

        private void LogToFile()
        {

            //Save to log file the following information - good for long running investigation
            string DataToSave = Convert.ToString((decimal)PHY.phy.NACK0) + " , "
                        + Convert.ToString((decimal)PHY.phy.ACK0) + " , "
                        + Convert.ToString((decimal)PHY.phy.NACK1) + " , "
                        + Convert.ToString((decimal)PHY.phy.ACK1) + " , "
                        + Convert.ToString((decimal)PHY.phy.NackCtrl) + " , "
                        + Convert.ToString((decimal)PHY.phy.AckCtrl) + " , "
                        + Convert.ToString((decimal)PHY.phy.CINR1avg) + " , "
                        + Convert.ToString((decimal)PHY.phy.RSSI1) + " , "
                        + Convert.ToString((decimal)PHY.phy.STO1) + " , "
                        + Convert.ToString((decimal)PHY.phy.CINR2avg) + " , "
                        + Convert.ToString((decimal)PHY.phy.RSSI2) + " , "
                        + Convert.ToString((decimal)PHY.phy.STO2) + " , "
                        + PHY.phy.controlChannelRx.txAnnounced1 + ","
                        + PHY.phy.controlChannelTx.txAnnounced2;
            
            //write the string to file
            sw.WriteLine(DataToSave);

        }
              
    }

}

        

        

    
        






