﻿using System.Windows.Forms;
namespace WindowsFormsApplication1
{

partial class FormSystemStatus
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {   
            
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
           
        }
   public System.Windows.Forms.Button[] ButtonArray;
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            SpPerfChart.ChartPen chartPen1 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen2 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen3 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen4 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen5 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen6 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen7 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen8 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen9 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen10 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen11 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen12 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen13 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen14 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen15 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen16 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen17 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen18 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen19 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen20 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen21 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen22 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen23 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen24 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen25 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen26 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen27 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen28 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen29 = new SpPerfChart.ChartPen();
            SpPerfChart.ChartPen chartPen30 = new SpPerfChart.ChartPen();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSystemStatus));
            this.bgWrkTimer = new System.ComponentModel.BackgroundWorker();
            this.groupBoxGMAC0 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelGMACleft = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxGraph0b = new System.Windows.Forms.ComboBox();
            this.labelGraph0Max = new System.Windows.Forms.Label();
            this.comboBoxGraph0a = new System.Windows.Forms.ComboBox();
            this.labelGraph0Latest = new System.Windows.Forms.Label();
            this.groupBoxGMAC1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelGMACright = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxGraph1b = new System.Windows.Forms.ComboBox();
            this.comboBoxGraph1a = new System.Windows.Forms.ComboBox();
            this.labelGraph1Max = new System.Windows.Forms.Label();
            this.labelGraph1Latest = new System.Windows.Forms.Label();
            this.tableLayoutPanelStatusBottom = new System.Windows.Forms.TableLayoutPanel();
            this.buttonResetSOC = new System.Windows.Forms.Button();
            this.buttonResetCounters = new System.Windows.Forms.Button();
            this.buttonConstellation = new System.Windows.Forms.Button();
            this.buttonProperties = new System.Windows.Forms.Button();
            this.chkBxTimerEnabled = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelPHY = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxMCS = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelMCS = new System.Windows.Forms.TableLayoutPanel();
            this.labelMcsManualSetting = new System.Windows.Forms.Label();
            this.labelMcsLatest = new System.Windows.Forms.Label();
            this.radioButtonMCSAnt1 = new System.Windows.Forms.RadioButton();
            this.radioButtonMCSAnt2 = new System.Windows.Forms.RadioButton();
            this.labelMcsAuto = new System.Windows.Forms.Label();
            this.groupBoxPER = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelPER = new System.Windows.Forms.TableLayoutPanel();
            this.labelGraphPER1Current = new System.Windows.Forms.Label();
            this.labelGraphPER1Nack = new System.Windows.Forms.Label();
            this.labelGraphPER0Current = new System.Windows.Forms.Label();
            this.radioButtonPER1 = new System.Windows.Forms.RadioButton();
            this.radioButtonPER2 = new System.Windows.Forms.RadioButton();
            this.labelGraphPER0Nack = new System.Windows.Forms.Label();
            this.groupBoxCINR = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelCINR = new System.Windows.Forms.TableLayoutPanel();
            this.labelGraphCINR1Current = new System.Windows.Forms.Label();
            this.labelGraphCINR0Current = new System.Windows.Forms.Label();
            this.radioButtonCINR1 = new System.Windows.Forms.RadioButton();
            this.radioButtonCINR2 = new System.Windows.Forms.RadioButton();
            this.groupBoxRSSI = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelRSSI = new System.Windows.Forms.TableLayoutPanel();
            this.labelGraphRSSI1Current = new System.Windows.Forms.Label();
            this.labelGraphRSSI0Current = new System.Windows.Forms.Label();
            this.radioButtonRSSI1 = new System.Windows.Forms.RadioButton();
            this.radioButtonRSSI2 = new System.Windows.Forms.RadioButton();
            this.panelPhySectionSeparator = new System.Windows.Forms.Panel();
            this.labelPHY = new System.Windows.Forms.Label();
            this.toolTipTBs = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipMSC = new System.Windows.Forms.ToolTip(this.components);
            this.bgWrkConstellation = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanelWholeForm = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLinkStatus = new System.Windows.Forms.TableLayoutPanel();
            this.panelLinkPllLock = new System.Windows.Forms.Panel();
            this.labelLinkPllLock = new System.Windows.Forms.Label();
            this.panelLinkTxOn = new System.Windows.Forms.Panel();
            this.labelLinkTxOn = new System.Windows.Forms.Label();
            this.panelLinkTimingLoop = new System.Windows.Forms.Panel();
            this.labelLinkTimingLoop = new System.Windows.Forms.Label();
            this.labelLinkStatus = new System.Windows.Forms.Label();
            this.labelRLMLinkStatus = new System.Windows.Forms.Label();
            this.tableLayoutPanelGMAC = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelGraphic = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSTO = new System.Windows.Forms.GroupBox();
            this.textBoxSTO2 = new System.Windows.Forms.TextBox();
            this.textBoxSTO1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxXPI = new System.Windows.Forms.GroupBox();
            this.textBoxXPIAnt1 = new System.Windows.Forms.TextBox();
            this.textBoxXPIAnt0 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DesignArtNetworks = new System.Windows.Forms.LinkLabel();
            this.toolTipLinkStatus = new System.Windows.Forms.ToolTip(this.components);
            this.spPerfChart0 = new SpPerfChart.SpPerfChart();
            this.spPerfChart1 = new SpPerfChart.SpPerfChart();
            this.spPerfChartMCS = new SpPerfChart.SpPerfChart();
            this.spPerfChartPER = new SpPerfChart.SpPerfChart();
            this.spPerfChartCINR = new SpPerfChart.SpPerfChart();
            this.spPerfChartRSSI = new SpPerfChart.SpPerfChart();
            this.groupBoxGMAC0.SuspendLayout();
            this.tableLayoutPanelGMACleft.SuspendLayout();
            this.groupBoxGMAC1.SuspendLayout();
            this.tableLayoutPanelGMACright.SuspendLayout();
            this.tableLayoutPanelStatusBottom.SuspendLayout();
            this.tableLayoutPanelPHY.SuspendLayout();
            this.groupBoxMCS.SuspendLayout();
            this.tableLayoutPanelMCS.SuspendLayout();
            this.groupBoxPER.SuspendLayout();
            this.tableLayoutPanelPER.SuspendLayout();
            this.groupBoxCINR.SuspendLayout();
            this.tableLayoutPanelCINR.SuspendLayout();
            this.groupBoxRSSI.SuspendLayout();
            this.tableLayoutPanelRSSI.SuspendLayout();
            this.panelPhySectionSeparator.SuspendLayout();
            this.tableLayoutPanelWholeForm.SuspendLayout();
            this.tableLayoutPanelLinkStatus.SuspendLayout();
            this.tableLayoutPanelGMAC.SuspendLayout();
            this.tableLayoutPanelGraphic.SuspendLayout();
            this.groupBoxSTO.SuspendLayout();
            this.groupBoxXPI.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgWrkTimer
            // 
            this.bgWrkTimer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWrkTimer_DoWork);
            this.bgWrkTimer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWrkTimer_RunWorkerCompleted);
            // 
            // groupBoxGMAC0
            // 
            this.groupBoxGMAC0.AutoSize = true;
            this.groupBoxGMAC0.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxGMAC0.Controls.Add(this.tableLayoutPanelGMACleft);
            this.groupBoxGMAC0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGMAC0.Location = new System.Drawing.Point(3, 3);
            this.groupBoxGMAC0.Name = "groupBoxGMAC0";
            this.groupBoxGMAC0.Size = new System.Drawing.Size(415, 225);
            this.groupBoxGMAC0.TabIndex = 0;
            this.groupBoxGMAC0.TabStop = false;
            this.groupBoxGMAC0.Text = "GMAC";
            // 
            // tableLayoutPanelGMACleft
            // 
            this.tableLayoutPanelGMACleft.ColumnCount = 3;
            this.tableLayoutPanelGMACleft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelGMACleft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanelGMACleft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelGMACleft.Controls.Add(this.comboBoxGraph0b, 2, 1);
            this.tableLayoutPanelGMACleft.Controls.Add(this.spPerfChart0, 0, 0);
            this.tableLayoutPanelGMACleft.Controls.Add(this.labelGraph0Max, 0, 2);
            this.tableLayoutPanelGMACleft.Controls.Add(this.comboBoxGraph0a, 1, 1);
            this.tableLayoutPanelGMACleft.Controls.Add(this.labelGraph0Latest, 0, 1);
            this.tableLayoutPanelGMACleft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGMACleft.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelGMACleft.Name = "tableLayoutPanelGMACleft";
            this.tableLayoutPanelGMACleft.RowCount = 3;
            this.tableLayoutPanelGMACleft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGMACleft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanelGMACleft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanelGMACleft.Size = new System.Drawing.Size(409, 206);
            this.tableLayoutPanelGMACleft.TabIndex = 1;
            // 
            // comboBoxGraph0b
            // 
            this.comboBoxGraph0b.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxGraph0b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGraph0b.FormattingEnabled = true;
            this.comboBoxGraph0b.Items.AddRange(new object[] {
            "Rx - Good broadcast frames",
            "Rx - Good ..."});
            this.comboBoxGraph0b.Location = new System.Drawing.Point(178, 179);
            this.comboBoxGraph0b.Name = "comboBoxGraph0b";
            this.tableLayoutPanelGMACleft.SetRowSpan(this.comboBoxGraph0b, 2);
            this.comboBoxGraph0b.Size = new System.Drawing.Size(228, 21);
            this.comboBoxGraph0b.TabIndex = 12;
            this.comboBoxGraph0b.SelectedIndexChanged += new System.EventHandler(this.comboBoxGraph0b_SelectedIndexChanged);
            // 
            // labelGraph0Max
            // 
            this.labelGraph0Max.AutoSize = true;
            this.labelGraph0Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGraph0Max.Location = new System.Drawing.Point(3, 191);
            this.labelGraph0Max.Name = "labelGraph0Max";
            this.labelGraph0Max.Size = new System.Drawing.Size(94, 15);
            this.labelGraph0Max.TabIndex = 10;
            this.labelGraph0Max.Text = "Max:  123.4 Mb";
            this.labelGraph0Max.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxGraph0a
            // 
            this.comboBoxGraph0a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxGraph0a.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGraph0a.FormattingEnabled = true;
            this.comboBoxGraph0a.Items.AddRange(new object[] {
            "GMAC0",
            "GMAC1"});
            this.comboBoxGraph0a.Location = new System.Drawing.Point(103, 179);
            this.comboBoxGraph0a.Name = "comboBoxGraph0a";
            this.comboBoxGraph0a.Size = new System.Drawing.Size(69, 21);
            this.comboBoxGraph0a.TabIndex = 7;
            this.comboBoxGraph0a.SelectedIndexChanged += new System.EventHandler(this.comboBoxGraph0a_SelectedIndexChanged);
            // 
            // labelGraph0Latest
            // 
            this.labelGraph0Latest.AutoSize = true;
            this.labelGraph0Latest.BackColor = System.Drawing.Color.White;
            this.labelGraph0Latest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGraph0Latest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGraph0Latest.Location = new System.Drawing.Point(3, 176);
            this.labelGraph0Latest.Name = "labelGraph0Latest";
            this.labelGraph0Latest.Size = new System.Drawing.Size(94, 15);
            this.labelGraph0Latest.TabIndex = 9;
            this.labelGraph0Latest.Text = "123.4 Mb";
            this.labelGraph0Latest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxGMAC1
            // 
            this.groupBoxGMAC1.AutoSize = true;
            this.groupBoxGMAC1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxGMAC1.Controls.Add(this.tableLayoutPanelGMACright);
            this.groupBoxGMAC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGMAC1.Location = new System.Drawing.Point(424, 3);
            this.groupBoxGMAC1.Name = "groupBoxGMAC1";
            this.groupBoxGMAC1.Size = new System.Drawing.Size(416, 225);
            this.groupBoxGMAC1.TabIndex = 12;
            this.groupBoxGMAC1.TabStop = false;
            this.groupBoxGMAC1.Text = "GMAC";
            // 
            // tableLayoutPanelGMACright
            // 
            this.tableLayoutPanelGMACright.ColumnCount = 3;
            this.tableLayoutPanelGMACright.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelGMACright.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanelGMACright.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelGMACright.Controls.Add(this.comboBoxGraph1b, 2, 1);
            this.tableLayoutPanelGMACright.Controls.Add(this.comboBoxGraph1a, 1, 1);
            this.tableLayoutPanelGMACright.Controls.Add(this.labelGraph1Max, 0, 2);
            this.tableLayoutPanelGMACright.Controls.Add(this.labelGraph1Latest, 0, 1);
            this.tableLayoutPanelGMACright.Controls.Add(this.spPerfChart1, 0, 0);
            this.tableLayoutPanelGMACright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGMACright.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelGMACright.Name = "tableLayoutPanelGMACright";
            this.tableLayoutPanelGMACright.RowCount = 3;
            this.tableLayoutPanelGMACright.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGMACright.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanelGMACright.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanelGMACright.Size = new System.Drawing.Size(410, 206);
            this.tableLayoutPanelGMACright.TabIndex = 1;
            // 
            // comboBoxGraph1b
            // 
            this.comboBoxGraph1b.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxGraph1b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGraph1b.FormattingEnabled = true;
            this.comboBoxGraph1b.Items.AddRange(new object[] {
            "Rx - Good broadcast frames",
            "Rx - Good ..."});
            this.comboBoxGraph1b.Location = new System.Drawing.Point(178, 179);
            this.comboBoxGraph1b.Name = "comboBoxGraph1b";
            this.tableLayoutPanelGMACright.SetRowSpan(this.comboBoxGraph1b, 2);
            this.comboBoxGraph1b.Size = new System.Drawing.Size(229, 21);
            this.comboBoxGraph1b.TabIndex = 15;
            this.comboBoxGraph1b.SelectedIndexChanged += new System.EventHandler(this.comboBoxGraph1b_SelectedIndexChanged);
            // 
            // comboBoxGraph1a
            // 
            this.comboBoxGraph1a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxGraph1a.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGraph1a.FormattingEnabled = true;
            this.comboBoxGraph1a.Items.AddRange(new object[] {
            "GMAC0",
            "GMAC1"});
            this.comboBoxGraph1a.Location = new System.Drawing.Point(103, 179);
            this.comboBoxGraph1a.Name = "comboBoxGraph1a";
            this.comboBoxGraph1a.Size = new System.Drawing.Size(69, 21);
            this.comboBoxGraph1a.TabIndex = 14;
            this.comboBoxGraph1a.SelectedIndexChanged += new System.EventHandler(this.comboBoxGraph1a_SelectedIndexChanged);
            // 
            // labelGraph1Max
            // 
            this.labelGraph1Max.AutoSize = true;
            this.labelGraph1Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGraph1Max.Location = new System.Drawing.Point(3, 191);
            this.labelGraph1Max.Name = "labelGraph1Max";
            this.labelGraph1Max.Size = new System.Drawing.Size(94, 15);
            this.labelGraph1Max.TabIndex = 13;
            this.labelGraph1Max.Text = "Max:  123.4 Mb";
            this.labelGraph1Max.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelGraph1Latest
            // 
            this.labelGraph1Latest.AutoSize = true;
            this.labelGraph1Latest.BackColor = System.Drawing.Color.White;
            this.labelGraph1Latest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGraph1Latest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGraph1Latest.Location = new System.Drawing.Point(3, 176);
            this.labelGraph1Latest.Name = "labelGraph1Latest";
            this.labelGraph1Latest.Size = new System.Drawing.Size(94, 15);
            this.labelGraph1Latest.TabIndex = 12;
            this.labelGraph1Latest.Text = "123.4 Mb";
            this.labelGraph1Latest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanelStatusBottom
            // 
            this.tableLayoutPanelStatusBottom.AutoSize = true;
            this.tableLayoutPanelStatusBottom.ColumnCount = 6;
            this.tableLayoutPanelStatusBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelStatusBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelStatusBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelStatusBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelStatusBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelStatusBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanelStatusBottom.Controls.Add(this.buttonResetSOC, 2, 0);
            this.tableLayoutPanelStatusBottom.Controls.Add(this.buttonResetCounters, 2, 0);
            this.tableLayoutPanelStatusBottom.Controls.Add(this.buttonConstellation, 1, 0);
            this.tableLayoutPanelStatusBottom.Controls.Add(this.buttonProperties, 4, 0);
            this.tableLayoutPanelStatusBottom.Controls.Add(this.chkBxTimerEnabled, 5, 0);
            this.tableLayoutPanelStatusBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanelStatusBottom.Location = new System.Drawing.Point(3, 619);
            this.tableLayoutPanelStatusBottom.Name = "tableLayoutPanelStatusBottom";
            this.tableLayoutPanelStatusBottom.RowCount = 1;
            this.tableLayoutPanelStatusBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelStatusBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelStatusBottom.Size = new System.Drawing.Size(843, 27);
            this.tableLayoutPanelStatusBottom.TabIndex = 10;
            // 
            // buttonResetSOC
            // 
            this.buttonResetSOC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonResetSOC.Location = new System.Drawing.Point(274, 3);
            this.buttonResetSOC.Name = "buttonResetSOC";
            this.buttonResetSOC.Size = new System.Drawing.Size(95, 21);
            this.buttonResetSOC.TabIndex = 1;
            this.buttonResetSOC.Text = "Reset SOC";
            this.buttonResetSOC.UseVisualStyleBackColor = true;
            this.buttonResetSOC.Click += new System.EventHandler(this.buttonResetSOC_Click);
            // 
            // buttonResetCounters
            // 
            this.buttonResetCounters.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonResetCounters.Location = new System.Drawing.Point(475, 3);
            this.buttonResetCounters.Name = "buttonResetCounters";
            this.buttonResetCounters.Size = new System.Drawing.Size(95, 21);
            this.buttonResetCounters.TabIndex = 0;
            this.buttonResetCounters.Text = "Reset Counters";
            this.buttonResetCounters.UseVisualStyleBackColor = true;
            this.buttonResetCounters.Click += new System.EventHandler(this.buttonResetCounters_Click);
            // 
            // buttonConstellation
            // 
            this.buttonConstellation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonConstellation.Location = new System.Drawing.Point(83, 3);
            this.buttonConstellation.Name = "buttonConstellation";
            this.buttonConstellation.Size = new System.Drawing.Size(75, 21);
            this.buttonConstellation.TabIndex = 2;
            this.buttonConstellation.Text = "Constellation";
            this.buttonConstellation.UseVisualStyleBackColor = true;
            this.buttonConstellation.Click += new System.EventHandler(this.buttonConstellation_Click);
            // 
            // buttonProperties
            // 
            this.buttonProperties.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonProperties.Location = new System.Drawing.Point(686, 3);
            this.buttonProperties.Name = "buttonProperties";
            this.buttonProperties.Size = new System.Drawing.Size(75, 21);
            this.buttonProperties.TabIndex = 3;
            this.buttonProperties.Text = "Properties";
            this.buttonProperties.UseVisualStyleBackColor = true;
            this.buttonProperties.Click += new System.EventHandler(this.buttonProperties_Click);
            // 
            // chkBxTimerEnabled
            // 
            this.chkBxTimerEnabled.AutoSize = true;
            this.chkBxTimerEnabled.Enabled = false;
            this.chkBxTimerEnabled.Location = new System.Drawing.Point(827, 3);
            this.chkBxTimerEnabled.Name = "chkBxTimerEnabled";
            this.chkBxTimerEnabled.Size = new System.Drawing.Size(13, 17);
            this.chkBxTimerEnabled.TabIndex = 20;
            this.chkBxTimerEnabled.Text = "Update";
            this.chkBxTimerEnabled.UseVisualStyleBackColor = true;
            this.chkBxTimerEnabled.Visible = false;
            this.chkBxTimerEnabled.CheckedChanged += new System.EventHandler(this.chkBxTimerEnabled_CheckedChanged);
            // 
            // tableLayoutPanelPHY
            // 
            this.tableLayoutPanelPHY.BackColor = System.Drawing.Color.LightGray;
            this.tableLayoutPanelPHY.ColumnCount = 4;
            this.tableLayoutPanelPHY.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPHY.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPHY.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPHY.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelPHY.Controls.Add(this.groupBoxMCS, 3, 1);
            this.tableLayoutPanelPHY.Controls.Add(this.groupBoxPER, 2, 1);
            this.tableLayoutPanelPHY.Controls.Add(this.groupBoxCINR, 1, 1);
            this.tableLayoutPanelPHY.Controls.Add(this.groupBoxRSSI, 0, 1);
            this.tableLayoutPanelPHY.Controls.Add(this.panelPhySectionSeparator, 0, 0);
            this.tableLayoutPanelPHY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPHY.Location = new System.Drawing.Point(3, 272);
            this.tableLayoutPanelPHY.MinimumSize = new System.Drawing.Size(843, 235);
            this.tableLayoutPanelPHY.Name = "tableLayoutPanelPHY";
            this.tableLayoutPanelPHY.RowCount = 2;
            this.tableLayoutPanelPHY.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelPHY.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPHY.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPHY.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPHY.Size = new System.Drawing.Size(843, 235);
            this.tableLayoutPanelPHY.TabIndex = 11;
            // 
            // groupBoxMCS
            // 
            this.groupBoxMCS.AutoSize = true;
            this.groupBoxMCS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxMCS.Controls.Add(this.tableLayoutPanelMCS);
            this.groupBoxMCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMCS.Location = new System.Drawing.Point(633, 33);
            this.groupBoxMCS.Name = "groupBoxMCS";
            this.groupBoxMCS.Size = new System.Drawing.Size(207, 199);
            this.groupBoxMCS.TabIndex = 5;
            this.groupBoxMCS.TabStop = false;
            this.groupBoxMCS.Text = "MCS - Rx && Tx";
            // 
            // tableLayoutPanelMCS
            // 
            this.tableLayoutPanelMCS.ColumnCount = 3;
            this.tableLayoutPanelMCS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.37313F));
            this.tableLayoutPanelMCS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.80099F));
            this.tableLayoutPanelMCS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.32836F));
            this.tableLayoutPanelMCS.Controls.Add(this.labelMcsManualSetting, 1, 2);
            this.tableLayoutPanelMCS.Controls.Add(this.spPerfChartMCS, 0, 0);
            this.tableLayoutPanelMCS.Controls.Add(this.labelMcsLatest, 0, 1);
            this.tableLayoutPanelMCS.Controls.Add(this.radioButtonMCSAnt1, 2, 1);
            this.tableLayoutPanelMCS.Controls.Add(this.radioButtonMCSAnt2, 2, 2);
            this.tableLayoutPanelMCS.Controls.Add(this.labelMcsAuto, 0, 2);
            this.tableLayoutPanelMCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMCS.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelMCS.Name = "tableLayoutPanelMCS";
            this.tableLayoutPanelMCS.RowCount = 3;
            this.tableLayoutPanelMCS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMCS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanelMCS.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanelMCS.Size = new System.Drawing.Size(201, 180);
            this.tableLayoutPanelMCS.TabIndex = 1;
            // 
            // labelMcsManualSetting
            // 
            this.labelMcsManualSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMcsManualSetting.AutoSize = true;
            this.labelMcsManualSetting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMcsManualSetting.Location = new System.Drawing.Point(54, 158);
            this.labelMcsManualSetting.Name = "labelMcsManualSetting";
            this.labelMcsManualSetting.Size = new System.Drawing.Size(74, 22);
            this.labelMcsManualSetting.TabIndex = 15;
            this.labelMcsManualSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTipMSC.SetToolTip(this.labelMcsManualSetting, "Tx Announced Modulation");
            // 
            // labelMcsLatest
            // 
            this.labelMcsLatest.AutoSize = true;
            this.labelMcsLatest.BackColor = System.Drawing.Color.White;
            this.labelMcsLatest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanelMCS.SetColumnSpan(this.labelMcsLatest, 2);
            this.labelMcsLatest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMcsLatest.Location = new System.Drawing.Point(3, 136);
            this.labelMcsLatest.Name = "labelMcsLatest";
            this.labelMcsLatest.Size = new System.Drawing.Size(125, 22);
            this.labelMcsLatest.TabIndex = 9;
            this.labelMcsLatest.Text = "2";
            this.labelMcsLatest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioButtonMCSAnt1
            // 
            this.radioButtonMCSAnt1.AutoSize = true;
            this.radioButtonMCSAnt1.Checked = true;
            this.radioButtonMCSAnt1.Location = new System.Drawing.Point(134, 139);
            this.radioButtonMCSAnt1.Name = "radioButtonMCSAnt1";
            this.radioButtonMCSAnt1.Size = new System.Drawing.Size(64, 16);
            this.radioButtonMCSAnt1.TabIndex = 12;
            this.radioButtonMCSAnt1.TabStop = true;
            this.radioButtonMCSAnt1.Text = "Rx MCS";
            this.radioButtonMCSAnt1.UseVisualStyleBackColor = true;
            this.radioButtonMCSAnt1.CheckedChanged += new System.EventHandler(this.radioButtonMCSrx_CheckedChanged);
            // 
            // radioButtonMCSAnt2
            // 
            this.radioButtonMCSAnt2.AutoSize = true;
            this.radioButtonMCSAnt2.Location = new System.Drawing.Point(134, 161);
            this.radioButtonMCSAnt2.Name = "radioButtonMCSAnt2";
            this.radioButtonMCSAnt2.Size = new System.Drawing.Size(63, 16);
            this.radioButtonMCSAnt2.TabIndex = 13;
            this.radioButtonMCSAnt2.Text = "Tx MCS";
            this.radioButtonMCSAnt2.UseVisualStyleBackColor = true;
            this.radioButtonMCSAnt2.CheckedChanged += new System.EventHandler(this.radioButtonMCStx_CheckedChanged);
            // 
            // labelMcsAuto
            // 
            this.labelMcsAuto.AutoSize = true;
            this.labelMcsAuto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMcsAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMcsAuto.Location = new System.Drawing.Point(3, 158);
            this.labelMcsAuto.Name = "labelMcsAuto";
            this.labelMcsAuto.Size = new System.Drawing.Size(45, 22);
            this.labelMcsAuto.TabIndex = 14;
            this.labelMcsAuto.Text = "manual";
            this.labelMcsAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTipMSC.SetToolTip(this.labelMcsAuto, "Automatic Modulation Control");
            // 
            // groupBoxPER
            // 
            this.groupBoxPER.AutoSize = true;
            this.groupBoxPER.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxPER.Controls.Add(this.tableLayoutPanelPER);
            this.groupBoxPER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPER.Location = new System.Drawing.Point(423, 33);
            this.groupBoxPER.Name = "groupBoxPER";
            this.groupBoxPER.Size = new System.Drawing.Size(204, 199);
            this.groupBoxPER.TabIndex = 3;
            this.groupBoxPER.TabStop = false;
            this.groupBoxPER.Text = "PER % (Rx CRC Errors)";
            // 
            // tableLayoutPanelPER
            // 
            this.tableLayoutPanelPER.AutoSize = true;
            this.tableLayoutPanelPER.ColumnCount = 3;
            this.tableLayoutPanelPER.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanelPER.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanelPER.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanelPER.Controls.Add(this.labelGraphPER1Current, 0, 2);
            this.tableLayoutPanelPER.Controls.Add(this.labelGraphPER1Nack, 1, 2);
            this.tableLayoutPanelPER.Controls.Add(this.spPerfChartPER, 0, 0);
            this.tableLayoutPanelPER.Controls.Add(this.labelGraphPER0Current, 0, 1);
            this.tableLayoutPanelPER.Controls.Add(this.radioButtonPER1, 2, 1);
            this.tableLayoutPanelPER.Controls.Add(this.radioButtonPER2, 2, 2);
            this.tableLayoutPanelPER.Controls.Add(this.labelGraphPER0Nack, 1, 1);
            this.tableLayoutPanelPER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPER.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelPER.MinimumSize = new System.Drawing.Size(198, 180);
            this.tableLayoutPanelPER.Name = "tableLayoutPanelPER";
            this.tableLayoutPanelPER.RowCount = 3;
            this.tableLayoutPanelPER.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPER.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanelPER.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanelPER.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelPER.Size = new System.Drawing.Size(198, 180);
            this.tableLayoutPanelPER.TabIndex = 1;
            // 
            // labelGraphPER1Current
            // 
            this.labelGraphPER1Current.AutoSize = true;
            this.labelGraphPER1Current.BackColor = System.Drawing.Color.White;
            this.labelGraphPER1Current.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGraphPER1Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGraphPER1Current.Location = new System.Drawing.Point(3, 158);
            this.labelGraphPER1Current.Name = "labelGraphPER1Current";
            this.labelGraphPER1Current.Size = new System.Drawing.Size(65, 22);
            this.labelGraphPER1Current.TabIndex = 16;
            this.labelGraphPER1Current.Text = "49.9 %";
            this.labelGraphPER1Current.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelGraphPER1Nack
            // 
            this.labelGraphPER1Nack.AutoSize = true;
            this.labelGraphPER1Nack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGraphPER1Nack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGraphPER1Nack.Location = new System.Drawing.Point(74, 158);
            this.labelGraphPER1Nack.Name = "labelGraphPER1Nack";
            this.labelGraphPER1Nack.Size = new System.Drawing.Size(65, 22);
            this.labelGraphPER1Nack.TabIndex = 15;
            this.labelGraphPER1Nack.Text = "00000000";
            this.labelGraphPER1Nack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipTBs.SetToolTip(this.labelGraphPER1Nack, "Antenna 1 Rx TBs with CRC error");
            // 
            // labelGraphPER0Current
            // 
            this.labelGraphPER0Current.AutoSize = true;
            this.labelGraphPER0Current.BackColor = System.Drawing.Color.White;
            this.labelGraphPER0Current.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGraphPER0Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGraphPER0Current.Location = new System.Drawing.Point(3, 136);
            this.labelGraphPER0Current.Name = "labelGraphPER0Current";
            this.labelGraphPER0Current.Size = new System.Drawing.Size(65, 22);
            this.labelGraphPER0Current.TabIndex = 9;
            this.labelGraphPER0Current.Text = "49.9 %";
            this.labelGraphPER0Current.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioButtonPER1
            // 
            this.radioButtonPER1.AutoSize = true;
            this.radioButtonPER1.Checked = true;
            this.radioButtonPER1.Location = new System.Drawing.Point(145, 139);
            this.radioButtonPER1.Name = "radioButtonPER1";
            this.radioButtonPER1.Size = new System.Drawing.Size(50, 16);
            this.radioButtonPER1.TabIndex = 12;
            this.radioButtonPER1.TabStop = true;
            this.radioButtonPER1.Text = "Ant 0";
            this.radioButtonPER1.UseVisualStyleBackColor = true;
            this.radioButtonPER1.CheckedChanged += new System.EventHandler(this.radioButtonPER1_CheckedChanged);
            // 
            // radioButtonPER2
            // 
            this.radioButtonPER2.AutoSize = true;
            this.radioButtonPER2.Location = new System.Drawing.Point(145, 161);
            this.radioButtonPER2.Name = "radioButtonPER2";
            this.radioButtonPER2.Size = new System.Drawing.Size(50, 16);
            this.radioButtonPER2.TabIndex = 13;
            this.radioButtonPER2.Text = "Ant 1";
            this.radioButtonPER2.UseVisualStyleBackColor = true;
            this.radioButtonPER2.CheckedChanged += new System.EventHandler(this.radioButtonPER2_CheckedChanged);
            // 
            // labelGraphPER0Nack
            // 
            this.labelGraphPER0Nack.AutoSize = true;
            this.labelGraphPER0Nack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelGraphPER0Nack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGraphPER0Nack.Location = new System.Drawing.Point(74, 136);
            this.labelGraphPER0Nack.Name = "labelGraphPER0Nack";
            this.labelGraphPER0Nack.Size = new System.Drawing.Size(65, 22);
            this.labelGraphPER0Nack.TabIndex = 14;
            this.labelGraphPER0Nack.Text = "00000000";
            this.labelGraphPER0Nack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipTBs.SetToolTip(this.labelGraphPER0Nack, "Antenna 0 Rx TBs with CRC error");
            // 
            // groupBoxCINR
            // 
            this.groupBoxCINR.AutoSize = true;
            this.groupBoxCINR.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxCINR.Controls.Add(this.tableLayoutPanelCINR);
            this.groupBoxCINR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCINR.Location = new System.Drawing.Point(213, 33);
            this.groupBoxCINR.Name = "groupBoxCINR";
            this.groupBoxCINR.Size = new System.Drawing.Size(204, 199);
            this.groupBoxCINR.TabIndex = 2;
            this.groupBoxCINR.TabStop = false;
            this.groupBoxCINR.Text = "CINR  dB";
            // 
            // tableLayoutPanelCINR
            // 
            this.tableLayoutPanelCINR.ColumnCount = 3;
            this.tableLayoutPanelCINR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelCINR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanelCINR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelCINR.Controls.Add(this.labelGraphCINR1Current, 0, 2);
            this.tableLayoutPanelCINR.Controls.Add(this.spPerfChartCINR, 0, 0);
            this.tableLayoutPanelCINR.Controls.Add(this.labelGraphCINR0Current, 0, 1);
            this.tableLayoutPanelCINR.Controls.Add(this.radioButtonCINR1, 2, 1);
            this.tableLayoutPanelCINR.Controls.Add(this.radioButtonCINR2, 2, 2);
            this.tableLayoutPanelCINR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCINR.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelCINR.Name = "tableLayoutPanelCINR";
            this.tableLayoutPanelCINR.RowCount = 3;
            this.tableLayoutPanelCINR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCINR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanelCINR.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanelCINR.Size = new System.Drawing.Size(198, 180);
            this.tableLayoutPanelCINR.TabIndex = 1;
            // 
            // labelGraphCINR1Current
            // 
            this.labelGraphCINR1Current.AutoSize = true;
            this.labelGraphCINR1Current.BackColor = System.Drawing.Color.White;
            this.labelGraphCINR1Current.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanelCINR.SetColumnSpan(this.labelGraphCINR1Current, 2);
            this.labelGraphCINR1Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGraphCINR1Current.Location = new System.Drawing.Point(3, 158);
            this.labelGraphCINR1Current.Name = "labelGraphCINR1Current";
            this.labelGraphCINR1Current.Size = new System.Drawing.Size(105, 22);
            this.labelGraphCINR1Current.TabIndex = 14;
            this.labelGraphCINR1Current.Text = "49.9 dB";
            this.labelGraphCINR1Current.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelGraphCINR0Current
            // 
            this.labelGraphCINR0Current.AutoSize = true;
            this.labelGraphCINR0Current.BackColor = System.Drawing.Color.White;
            this.labelGraphCINR0Current.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanelCINR.SetColumnSpan(this.labelGraphCINR0Current, 2);
            this.labelGraphCINR0Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGraphCINR0Current.Location = new System.Drawing.Point(3, 136);
            this.labelGraphCINR0Current.Name = "labelGraphCINR0Current";
            this.labelGraphCINR0Current.Size = new System.Drawing.Size(105, 22);
            this.labelGraphCINR0Current.TabIndex = 9;
            this.labelGraphCINR0Current.Text = "49.9 dB";
            this.labelGraphCINR0Current.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioButtonCINR1
            // 
            this.radioButtonCINR1.AutoSize = true;
            this.radioButtonCINR1.Checked = true;
            this.radioButtonCINR1.Location = new System.Drawing.Point(114, 139);
            this.radioButtonCINR1.Name = "radioButtonCINR1";
            this.radioButtonCINR1.Size = new System.Drawing.Size(74, 16);
            this.radioButtonCINR1.TabIndex = 12;
            this.radioButtonCINR1.TabStop = true;
            this.radioButtonCINR1.Text = "Antenna 0";
            this.radioButtonCINR1.UseVisualStyleBackColor = true;
            this.radioButtonCINR1.CheckedChanged += new System.EventHandler(this.radioButtonCINR1_CheckedChanged);
            // 
            // radioButtonCINR2
            // 
            this.radioButtonCINR2.AutoSize = true;
            this.radioButtonCINR2.Location = new System.Drawing.Point(114, 161);
            this.radioButtonCINR2.Name = "radioButtonCINR2";
            this.radioButtonCINR2.Size = new System.Drawing.Size(74, 16);
            this.radioButtonCINR2.TabIndex = 13;
            this.radioButtonCINR2.Text = "Antenna 1";
            this.radioButtonCINR2.UseVisualStyleBackColor = true;
            this.radioButtonCINR2.CheckedChanged += new System.EventHandler(this.radioButtonCINR2_CheckedChanged);
            // 
            // groupBoxRSSI
            // 
            this.groupBoxRSSI.AutoSize = true;
            this.groupBoxRSSI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxRSSI.Controls.Add(this.tableLayoutPanelRSSI);
            this.groupBoxRSSI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRSSI.Location = new System.Drawing.Point(3, 33);
            this.groupBoxRSSI.Name = "groupBoxRSSI";
            this.groupBoxRSSI.Size = new System.Drawing.Size(204, 199);
            this.groupBoxRSSI.TabIndex = 1;
            this.groupBoxRSSI.TabStop = false;
            this.groupBoxRSSI.Text = "RSSI  dBFS";
            // 
            // tableLayoutPanelRSSI
            // 
            this.tableLayoutPanelRSSI.ColumnCount = 3;
            this.tableLayoutPanelRSSI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelRSSI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanelRSSI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelRSSI.Controls.Add(this.labelGraphRSSI1Current, 0, 2);
            this.tableLayoutPanelRSSI.Controls.Add(this.spPerfChartRSSI, 0, 0);
            this.tableLayoutPanelRSSI.Controls.Add(this.labelGraphRSSI0Current, 0, 1);
            this.tableLayoutPanelRSSI.Controls.Add(this.radioButtonRSSI1, 2, 1);
            this.tableLayoutPanelRSSI.Controls.Add(this.radioButtonRSSI2, 2, 2);
            this.tableLayoutPanelRSSI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRSSI.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelRSSI.Name = "tableLayoutPanelRSSI";
            this.tableLayoutPanelRSSI.RowCount = 3;
            this.tableLayoutPanelRSSI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRSSI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanelRSSI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanelRSSI.Size = new System.Drawing.Size(198, 180);
            this.tableLayoutPanelRSSI.TabIndex = 1;
            // 
            // labelGraphRSSI1Current
            // 
            this.labelGraphRSSI1Current.AutoSize = true;
            this.labelGraphRSSI1Current.BackColor = System.Drawing.Color.White;
            this.labelGraphRSSI1Current.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanelRSSI.SetColumnSpan(this.labelGraphRSSI1Current, 2);
            this.labelGraphRSSI1Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGraphRSSI1Current.Location = new System.Drawing.Point(3, 158);
            this.labelGraphRSSI1Current.Name = "labelGraphRSSI1Current";
            this.labelGraphRSSI1Current.Size = new System.Drawing.Size(105, 22);
            this.labelGraphRSSI1Current.TabIndex = 14;
            this.labelGraphRSSI1Current.Text = "- 40.4 dBFS";
            this.labelGraphRSSI1Current.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelGraphRSSI0Current
            // 
            this.labelGraphRSSI0Current.AutoSize = true;
            this.labelGraphRSSI0Current.BackColor = System.Drawing.Color.White;
            this.labelGraphRSSI0Current.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanelRSSI.SetColumnSpan(this.labelGraphRSSI0Current, 2);
            this.labelGraphRSSI0Current.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGraphRSSI0Current.Location = new System.Drawing.Point(3, 136);
            this.labelGraphRSSI0Current.Name = "labelGraphRSSI0Current";
            this.labelGraphRSSI0Current.Size = new System.Drawing.Size(105, 22);
            this.labelGraphRSSI0Current.TabIndex = 9;
            this.labelGraphRSSI0Current.Text = "- 40.4 dBFS";
            this.labelGraphRSSI0Current.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioButtonRSSI1
            // 
            this.radioButtonRSSI1.AutoSize = true;
            this.radioButtonRSSI1.Checked = true;
            this.radioButtonRSSI1.Location = new System.Drawing.Point(114, 139);
            this.radioButtonRSSI1.Name = "radioButtonRSSI1";
            this.radioButtonRSSI1.Size = new System.Drawing.Size(74, 16);
            this.radioButtonRSSI1.TabIndex = 12;
            this.radioButtonRSSI1.TabStop = true;
            this.radioButtonRSSI1.Text = "Antenna 0";
            this.radioButtonRSSI1.UseVisualStyleBackColor = true;
            this.radioButtonRSSI1.CheckedChanged += new System.EventHandler(this.radioButtonRSSI1_CheckedChanged);
            // 
            // radioButtonRSSI2
            // 
            this.radioButtonRSSI2.AutoSize = true;
            this.radioButtonRSSI2.Location = new System.Drawing.Point(114, 161);
            this.radioButtonRSSI2.Name = "radioButtonRSSI2";
            this.radioButtonRSSI2.Size = new System.Drawing.Size(74, 16);
            this.radioButtonRSSI2.TabIndex = 13;
            this.radioButtonRSSI2.Text = "Antenna 1";
            this.radioButtonRSSI2.UseVisualStyleBackColor = true;
            this.radioButtonRSSI2.CheckedChanged += new System.EventHandler(this.radioButtonRSSI2_CheckedChanged);
            // 
            // panelPhySectionSeparator
            // 
            this.panelPhySectionSeparator.BackColor = System.Drawing.Color.LightGray;
            this.panelPhySectionSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanelPHY.SetColumnSpan(this.panelPhySectionSeparator, 4);
            this.panelPhySectionSeparator.Controls.Add(this.labelPHY);
            this.panelPhySectionSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPhySectionSeparator.Location = new System.Drawing.Point(3, 3);
            this.panelPhySectionSeparator.Name = "panelPhySectionSeparator";
            this.panelPhySectionSeparator.Size = new System.Drawing.Size(837, 24);
            this.panelPhySectionSeparator.TabIndex = 4;
            // 
            // labelPHY
            // 
            this.labelPHY.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPHY.AutoSize = true;
            this.labelPHY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPHY.Location = new System.Drawing.Point(398, 2);
            this.labelPHY.Name = "labelPHY";
            this.labelPHY.Size = new System.Drawing.Size(45, 20);
            this.labelPHY.TabIndex = 0;
            this.labelPHY.Text = "PHY";
            this.labelPHY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolTipTBs
            // 
            this.toolTipTBs.AutomaticDelay = 200;
            this.toolTipTBs.ToolTipTitle = "MiniMAC TB Airframe Counts";
            // 
            // toolTipMSC
            // 
            this.toolTipMSC.AutomaticDelay = 200;
            this.toolTipMSC.ToolTipTitle = "Modulation Control";
            // 
            // bgWrkConstellation
            // 
            this.bgWrkConstellation.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWrkConstellation_DoWork);
            this.bgWrkConstellation.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWrkConstellation_RunWorkerCompleted);
            // 
            // tableLayoutPanelWholeForm
            // 
            this.tableLayoutPanelWholeForm.ColumnCount = 1;
            this.tableLayoutPanelWholeForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelWholeForm.Controls.Add(this.tableLayoutPanelLinkStatus, 0, 0);
            this.tableLayoutPanelWholeForm.Controls.Add(this.tableLayoutPanelGMAC, 0, 1);
            this.tableLayoutPanelWholeForm.Controls.Add(this.tableLayoutPanelPHY, 0, 2);
            this.tableLayoutPanelWholeForm.Controls.Add(this.tableLayoutPanelStatusBottom, 0, 4);
            this.tableLayoutPanelWholeForm.Controls.Add(this.tableLayoutPanelGraphic, 0, 3);
            this.tableLayoutPanelWholeForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelWholeForm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelWholeForm.Name = "tableLayoutPanelWholeForm";
            this.tableLayoutPanelWholeForm.RowCount = 5;
            this.tableLayoutPanelWholeForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanelWholeForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelWholeForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelWholeForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanelWholeForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanelWholeForm.Size = new System.Drawing.Size(849, 649);
            this.tableLayoutPanelWholeForm.TabIndex = 16;
            // 
            // tableLayoutPanelLinkStatus
            // 
            this.tableLayoutPanelLinkStatus.BackColor = System.Drawing.Color.LightGray;
            this.tableLayoutPanelLinkStatus.ColumnCount = 10;
            this.tableLayoutPanelLinkStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelLinkStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelLinkStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelLinkStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelLinkStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelLinkStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelLinkStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelLinkStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelLinkStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelLinkStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelLinkStatus.Controls.Add(this.panelLinkPllLock, 5, 0);
            this.tableLayoutPanelLinkStatus.Controls.Add(this.labelLinkPllLock, 4, 0);
            this.tableLayoutPanelLinkStatus.Controls.Add(this.panelLinkTxOn, 1, 0);
            this.tableLayoutPanelLinkStatus.Controls.Add(this.labelLinkTxOn, 0, 0);
            this.tableLayoutPanelLinkStatus.Controls.Add(this.panelLinkTimingLoop, 3, 0);
            this.tableLayoutPanelLinkStatus.Controls.Add(this.labelLinkTimingLoop, 2, 0);
            this.tableLayoutPanelLinkStatus.Controls.Add(this.labelLinkStatus, 9, 0);
            this.tableLayoutPanelLinkStatus.Controls.Add(this.labelRLMLinkStatus, 8, 0);
            this.tableLayoutPanelLinkStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLinkStatus.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelLinkStatus.Name = "tableLayoutPanelLinkStatus";
            this.tableLayoutPanelLinkStatus.RowCount = 1;
            this.tableLayoutPanelLinkStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLinkStatus.Size = new System.Drawing.Size(843, 26);
            this.tableLayoutPanelLinkStatus.TabIndex = 0;
            // 
            // panelLinkPllLock
            // 
            this.panelLinkPllLock.BackColor = System.Drawing.Color.Yellow;
            this.panelLinkPllLock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLinkPllLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLinkPllLock.Location = new System.Drawing.Point(397, 3);
            this.panelLinkPllLock.Name = "panelLinkPllLock";
            this.panelLinkPllLock.Size = new System.Drawing.Size(74, 20);
            this.panelLinkPllLock.TabIndex = 13;
            this.toolTipLinkStatus.SetToolTip(this.panelLinkPllLock, "Green: Phase-lock-loop is locked.");
            // 
            // labelLinkPllLock
            // 
            this.labelLinkPllLock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLinkPllLock.AutoSize = true;
            this.labelLinkPllLock.Location = new System.Drawing.Point(327, 6);
            this.labelLinkPllLock.Name = "labelLinkPllLock";
            this.labelLinkPllLock.Size = new System.Drawing.Size(56, 13);
            this.labelLinkPllLock.TabIndex = 12;
            this.labelLinkPllLock.Text = "PLL Lock:";
            this.labelLinkPllLock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLinkTxOn
            // 
            this.panelLinkTxOn.BackColor = System.Drawing.Color.Yellow;
            this.panelLinkTxOn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLinkTxOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLinkTxOn.Location = new System.Drawing.Point(81, 3);
            this.panelLinkTxOn.Name = "panelLinkTxOn";
            this.panelLinkTxOn.Size = new System.Drawing.Size(74, 20);
            this.panelLinkTxOn.TabIndex = 11;
            this.toolTipLinkStatus.SetToolTip(this.panelLinkTxOn, "Green: Both antenna transmitters are on.");
            // 
            // labelLinkTxOn
            // 
            this.labelLinkTxOn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLinkTxOn.AutoSize = true;
            this.labelLinkTxOn.Location = new System.Drawing.Point(19, 6);
            this.labelLinkTxOn.Name = "labelLinkTxOn";
            this.labelLinkTxOn.Size = new System.Drawing.Size(39, 13);
            this.labelLinkTxOn.TabIndex = 10;
            this.labelLinkTxOn.Text = "Tx On:";
            this.labelLinkTxOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLinkTimingLoop
            // 
            this.panelLinkTimingLoop.BackColor = System.Drawing.Color.Yellow;
            this.panelLinkTimingLoop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLinkTimingLoop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLinkTimingLoop.Location = new System.Drawing.Point(239, 3);
            this.panelLinkTimingLoop.Name = "panelLinkTimingLoop";
            this.panelLinkTimingLoop.Size = new System.Drawing.Size(74, 20);
            this.panelLinkTimingLoop.TabIndex = 5;
            this.toolTipLinkStatus.SetToolTip(this.panelLinkTimingLoop, "Green: The Timing Loop is operating properly.");
            // 
            // labelLinkTimingLoop
            // 
            this.labelLinkTimingLoop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLinkTimingLoop.AutoSize = true;
            this.labelLinkTimingLoop.Location = new System.Drawing.Point(163, 6);
            this.labelLinkTimingLoop.Name = "labelLinkTimingLoop";
            this.labelLinkTimingLoop.Size = new System.Drawing.Size(68, 13);
            this.labelLinkTimingLoop.TabIndex = 1;
            this.labelLinkTimingLoop.Text = "Timing Loop:";
            this.labelLinkTimingLoop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLinkStatus
            // 
            this.labelLinkStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLinkStatus.AutoSize = true;
            this.labelLinkStatus.Location = new System.Drawing.Point(755, 6);
            this.labelLinkStatus.Name = "labelLinkStatus";
            this.labelLinkStatus.Size = new System.Drawing.Size(43, 13);
            this.labelLinkStatus.TabIndex = 8;
            this.labelLinkStatus.Text = "------------";
            // 
            // labelRLMLinkStatus
            // 
            this.labelRLMLinkStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRLMLinkStatus.AutoSize = true;
            this.labelRLMLinkStatus.Location = new System.Drawing.Point(639, 6);
            this.labelRLMLinkStatus.Name = "labelRLMLinkStatus";
            this.labelRLMLinkStatus.Size = new System.Drawing.Size(63, 13);
            this.labelRLMLinkStatus.TabIndex = 9;
            this.labelRLMLinkStatus.Text = "Link Status:";
            // 
            // tableLayoutPanelGMAC
            // 
            this.tableLayoutPanelGMAC.ColumnCount = 2;
            this.tableLayoutPanelGMAC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGMAC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelGMAC.Controls.Add(this.groupBoxGMAC0, 0, 0);
            this.tableLayoutPanelGMAC.Controls.Add(this.groupBoxGMAC1, 1, 0);
            this.tableLayoutPanelGMAC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGMAC.Location = new System.Drawing.Point(3, 35);
            this.tableLayoutPanelGMAC.Name = "tableLayoutPanelGMAC";
            this.tableLayoutPanelGMAC.RowCount = 1;
            this.tableLayoutPanelGMAC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGMAC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.tableLayoutPanelGMAC.Size = new System.Drawing.Size(843, 231);
            this.tableLayoutPanelGMAC.TabIndex = 1;
            // 
            // tableLayoutPanelGraphic
            // 
            this.tableLayoutPanelGraphic.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelGraphic.ColumnCount = 2;
            this.tableLayoutPanelGraphic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.2586F));
            this.tableLayoutPanelGraphic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.7414F));
            this.tableLayoutPanelGraphic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelGraphic.Controls.Add(this.groupBoxSTO, 1, 0);
            this.tableLayoutPanelGraphic.Controls.Add(this.groupBoxXPI, 1, 2);
            this.tableLayoutPanelGraphic.Controls.Add(this.DesignArtNetworks, 0, 0);
            this.tableLayoutPanelGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGraphic.Location = new System.Drawing.Point(3, 509);
            this.tableLayoutPanelGraphic.Name = "tableLayoutPanelGraphic";
            this.tableLayoutPanelGraphic.RowCount = 4;
            this.tableLayoutPanelGraphic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelGraphic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelGraphic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelGraphic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelGraphic.Size = new System.Drawing.Size(843, 104);
            this.tableLayoutPanelGraphic.TabIndex = 12;
            // 
            // groupBoxSTO
            // 
            this.groupBoxSTO.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxSTO.Controls.Add(this.textBoxSTO2);
            this.groupBoxSTO.Controls.Add(this.textBoxSTO1);
            this.groupBoxSTO.Controls.Add(this.label1);
            this.groupBoxSTO.Controls.Add(this.label2);
            this.groupBoxSTO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSTO.Location = new System.Drawing.Point(628, 3);
            this.groupBoxSTO.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBoxSTO.Name = "groupBoxSTO";
            this.tableLayoutPanelGraphic.SetRowSpan(this.groupBoxSTO, 2);
            this.groupBoxSTO.Size = new System.Drawing.Size(212, 49);
            this.groupBoxSTO.TabIndex = 26;
            this.groupBoxSTO.TabStop = false;
            this.groupBoxSTO.Text = "STO ";
            // 
            // textBoxSTO2
            // 
            this.textBoxSTO2.Location = new System.Drawing.Point(138, 14);
            this.textBoxSTO2.Name = "textBoxSTO2";
            this.textBoxSTO2.ReadOnly = true;
            this.textBoxSTO2.Size = new System.Drawing.Size(63, 20);
            this.textBoxSTO2.TabIndex = 24;
            this.textBoxSTO2.TabStop = false;
            // 
            // textBoxSTO1
            // 
            this.textBoxSTO1.Location = new System.Drawing.Point(40, 14);
            this.textBoxSTO1.Name = "textBoxSTO1";
            this.textBoxSTO1.ReadOnly = true;
            this.textBoxSTO1.Size = new System.Drawing.Size(63, 20);
            this.textBoxSTO1.TabIndex = 23;
            this.textBoxSTO1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Ant 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Ant 0:";
            // 
            // groupBoxXPI
            // 
            this.groupBoxXPI.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxXPI.Controls.Add(this.textBoxXPIAnt1);
            this.groupBoxXPI.Controls.Add(this.textBoxXPIAnt0);
            this.groupBoxXPI.Controls.Add(this.label11);
            this.groupBoxXPI.Controls.Add(this.label10);
            this.groupBoxXPI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxXPI.Location = new System.Drawing.Point(628, 55);
            this.groupBoxXPI.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.groupBoxXPI.Name = "groupBoxXPI";
            this.tableLayoutPanelGraphic.SetRowSpan(this.groupBoxXPI, 2);
            this.groupBoxXPI.Size = new System.Drawing.Size(212, 49);
            this.groupBoxXPI.TabIndex = 25;
            this.groupBoxXPI.TabStop = false;
            this.groupBoxXPI.Text = "XPI";
            this.groupBoxXPI.Visible = false;
            // 
            // textBoxXPIAnt1
            // 
            this.textBoxXPIAnt1.Location = new System.Drawing.Point(136, 14);
            this.textBoxXPIAnt1.Name = "textBoxXPIAnt1";
            this.textBoxXPIAnt1.ReadOnly = true;
            this.textBoxXPIAnt1.Size = new System.Drawing.Size(69, 20);
            this.textBoxXPIAnt1.TabIndex = 20;
            this.textBoxXPIAnt1.TabStop = false;
            // 
            // textBoxXPIAnt0
            // 
            this.textBoxXPIAnt0.Location = new System.Drawing.Point(34, 14);
            this.textBoxXPIAnt0.Name = "textBoxXPIAnt0";
            this.textBoxXPIAnt0.ReadOnly = true;
            this.textBoxXPIAnt0.Size = new System.Drawing.Size(69, 20);
            this.textBoxXPIAnt0.TabIndex = 19;
            this.textBoxXPIAnt0.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(104, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Ant 1:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Ant 0:";
            // 
            // DesignArtNetworks
            // 
            this.DesignArtNetworks.Font = new System.Drawing.Font("Haettenschweiler", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DesignArtNetworks.Image = global::WindowsFormsApplication1.Properties.Resources.logo_to_paint_cropt;
            this.DesignArtNetworks.LinkColor = System.Drawing.Color.Transparent;
            this.DesignArtNetworks.Location = new System.Drawing.Point(0, 0);
            this.DesignArtNetworks.Margin = new System.Windows.Forms.Padding(0);
            this.DesignArtNetworks.Name = "DesignArtNetworks";
            this.tableLayoutPanelGraphic.SetRowSpan(this.DesignArtNetworks, 4);
            this.DesignArtNetworks.Size = new System.Drawing.Size(625, 104);
            this.DesignArtNetworks.TabIndex = 20;
            // 
            // toolTipLinkStatus
            // 
            this.toolTipLinkStatus.AutomaticDelay = 200;
            this.toolTipLinkStatus.ToolTipTitle = "Link Status";
            // 
            // spPerfChart0
            // 
            this.spPerfChart0.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.tableLayoutPanelGMACleft.SetColumnSpan(this.spPerfChart0, 3);
            this.spPerfChart0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spPerfChart0.DualGraph = false;
            this.spPerfChart0.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.spPerfChart0.ForeColor = System.Drawing.Color.Black;
            this.spPerfChart0.HideBorder = false;
            this.spPerfChart0.Location = new System.Drawing.Point(3, 3);
            this.spPerfChart0.Name = "spPerfChart0";
            this.spPerfChart0.OrderOfMagnitude = 0;
            this.spPerfChart0.PerfChartStyle.AntiAliasing = true;
            chartPen1.Color = System.Drawing.Color.Black;
            chartPen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            chartPen1.Width = 1F;
            this.spPerfChart0.PerfChartStyle.AvgLinePen = chartPen1;
            this.spPerfChart0.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.DimGray;
            this.spPerfChart0.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.Gainsboro;
            chartPen2.Color = System.Drawing.Color.Orange;
            chartPen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen2.Width = 2F;
            this.spPerfChart0.PerfChartStyle.ChartLinePen = chartPen2;
            chartPen3.Color = System.Drawing.Color.Gold;
            chartPen3.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen3.Width = 1F;
            this.spPerfChart0.PerfChartStyle.ChartLinePenB = chartPen3;
            chartPen4.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen4.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen4.Width = 1F;
            this.spPerfChart0.PerfChartStyle.HorizontalGridPen = chartPen4;
            this.spPerfChart0.PerfChartStyle.ShowAverageLine = false;
            this.spPerfChart0.PerfChartStyle.ShowHorizontalGridLines = true;
            this.spPerfChart0.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen5.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen5.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen5.Width = 1F;
            this.spPerfChart0.PerfChartStyle.VerticalGridPen = chartPen5;
            this.spPerfChart0.ScaleMode = SpPerfChart.ScaleMode.Magnitude;
            this.spPerfChart0.Size = new System.Drawing.Size(403, 170);
            this.spPerfChart0.TabIndex = 11;
            this.spPerfChart0.TimerInterval = 100;
            this.spPerfChart0.TimerMode = SpPerfChart.TimerMode.Disabled;
            // 
            // spPerfChart1
            // 
            this.tableLayoutPanelGMACright.SetColumnSpan(this.spPerfChart1, 3);
            this.spPerfChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spPerfChart1.DualGraph = false;
            this.spPerfChart1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.spPerfChart1.HideBorder = false;
            this.spPerfChart1.Location = new System.Drawing.Point(3, 3);
            this.spPerfChart1.Name = "spPerfChart1";
            this.spPerfChart1.OrderOfMagnitude = 0;
            this.spPerfChart1.PerfChartStyle.AntiAliasing = true;
            chartPen6.Color = System.Drawing.Color.Black;
            chartPen6.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            chartPen6.Width = 1F;
            this.spPerfChart1.PerfChartStyle.AvgLinePen = chartPen6;
            this.spPerfChart1.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.DimGray;
            this.spPerfChart1.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.Gainsboro;
            chartPen7.Color = System.Drawing.Color.Orange;
            chartPen7.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen7.Width = 2F;
            this.spPerfChart1.PerfChartStyle.ChartLinePen = chartPen7;
            chartPen8.Color = System.Drawing.Color.Gold;
            chartPen8.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen8.Width = 2F;
            this.spPerfChart1.PerfChartStyle.ChartLinePenB = chartPen8;
            chartPen9.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen9.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen9.Width = 1F;
            this.spPerfChart1.PerfChartStyle.HorizontalGridPen = chartPen9;
            this.spPerfChart1.PerfChartStyle.ShowAverageLine = false;
            this.spPerfChart1.PerfChartStyle.ShowHorizontalGridLines = true;
            this.spPerfChart1.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen10.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen10.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen10.Width = 1F;
            this.spPerfChart1.PerfChartStyle.VerticalGridPen = chartPen10;
            this.spPerfChart1.ScaleMode = SpPerfChart.ScaleMode.Magnitude;
            this.spPerfChart1.Size = new System.Drawing.Size(404, 170);
            this.spPerfChart1.TabIndex = 11;
            this.spPerfChart1.TimerInterval = 100;
            this.spPerfChart1.TimerMode = SpPerfChart.TimerMode.Disabled;
            // 
            // spPerfChartMCS
            // 
            this.spPerfChartMCS.AbsoluteScaleLabels = new string[] {
        "MCS 10",
        "MCS 9",
        "MCS 8",
        "MCS 7",
        "MCS 6",
        "MCS 5",
        "MCS 4",
        "MCS 3",
        "MCS 2",
        "MCS 1"};
            this.tableLayoutPanelMCS.SetColumnSpan(this.spPerfChartMCS, 3);
            this.spPerfChartMCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spPerfChartMCS.DualGraph = true;
            this.spPerfChartMCS.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spPerfChartMCS.HideBorder = false;
            this.spPerfChartMCS.Location = new System.Drawing.Point(3, 3);
            this.spPerfChartMCS.Name = "spPerfChartMCS";
            this.spPerfChartMCS.OrderOfMagnitude = 0;
            this.spPerfChartMCS.PerfChartStyle.AntiAliasing = true;
            chartPen11.Color = System.Drawing.Color.Black;
            chartPen11.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            chartPen11.Width = 2F;
            this.spPerfChartMCS.PerfChartStyle.AvgLinePen = chartPen11;
            this.spPerfChartMCS.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.DarkGray;
            this.spPerfChartMCS.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.Gainsboro;
            chartPen12.Color = System.Drawing.Color.Orange;
            chartPen12.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen12.Width = 2F;
            this.spPerfChartMCS.PerfChartStyle.ChartLinePen = chartPen12;
            chartPen13.Color = System.Drawing.Color.Red;
            chartPen13.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen13.Width = 2F;
            this.spPerfChartMCS.PerfChartStyle.ChartLinePenB = chartPen13;
            chartPen14.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen14.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen14.Width = 1F;
            this.spPerfChartMCS.PerfChartStyle.HorizontalGridPen = chartPen14;
            this.spPerfChartMCS.PerfChartStyle.ShowAverageLine = false;
            this.spPerfChartMCS.PerfChartStyle.ShowHorizontalGridLines = true;
            this.spPerfChartMCS.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen15.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen15.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen15.Width = 1F;
            this.spPerfChartMCS.PerfChartStyle.VerticalGridPen = chartPen15;
            this.spPerfChartMCS.ScaleMode = SpPerfChart.ScaleMode.Absolute;
            this.spPerfChartMCS.ShowAbsoluteScale = true;
            this.spPerfChartMCS.Size = new System.Drawing.Size(195, 130);
            this.spPerfChartMCS.TabIndex = 11;
            this.spPerfChartMCS.TimerInterval = 100;
            this.spPerfChartMCS.TimerMode = SpPerfChart.TimerMode.Disabled;
            // 
            // spPerfChartPER
            // 
            this.tableLayoutPanelPER.SetColumnSpan(this.spPerfChartPER, 3);
            this.spPerfChartPER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spPerfChartPER.DualGraph = true;
            this.spPerfChartPER.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.spPerfChartPER.HideBorder = false;
            this.spPerfChartPER.Location = new System.Drawing.Point(3, 3);
            this.spPerfChartPER.MinimumSize = new System.Drawing.Size(160, 130);
            this.spPerfChartPER.Name = "spPerfChartPER";
            this.spPerfChartPER.OrderOfMagnitude = 0;
            this.spPerfChartPER.PerfChartStyle.AntiAliasing = true;
            chartPen16.Color = System.Drawing.Color.Black;
            chartPen16.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            chartPen16.Width = 2F;
            this.spPerfChartPER.PerfChartStyle.AvgLinePen = chartPen16;
            this.spPerfChartPER.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.DimGray;
            this.spPerfChartPER.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.Gainsboro;
            chartPen17.Color = System.Drawing.Color.Orange;
            chartPen17.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen17.Width = 2F;
            this.spPerfChartPER.PerfChartStyle.ChartLinePen = chartPen17;
            chartPen18.Color = System.Drawing.Color.Red;
            chartPen18.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen18.Width = 2F;
            this.spPerfChartPER.PerfChartStyle.ChartLinePenB = chartPen18;
            chartPen19.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen19.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen19.Width = 1F;
            this.spPerfChartPER.PerfChartStyle.HorizontalGridPen = chartPen19;
            this.spPerfChartPER.PerfChartStyle.ShowAverageLine = false;
            this.spPerfChartPER.PerfChartStyle.ShowHorizontalGridLines = true;
            this.spPerfChartPER.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen20.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen20.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen20.Width = 1F;
            this.spPerfChartPER.PerfChartStyle.VerticalGridPen = chartPen20;
            this.spPerfChartPER.ScaleMode = SpPerfChart.ScaleMode.Absolute;
            this.spPerfChartPER.ShowAbsoluteScale = true;
            this.spPerfChartPER.Size = new System.Drawing.Size(192, 130);
            this.spPerfChartPER.TabIndex = 11;
            this.spPerfChartPER.TimerInterval = 100;
            this.spPerfChartPER.TimerMode = SpPerfChart.TimerMode.Disabled;
            // 
            // spPerfChartCINR
            // 
            this.spPerfChartCINR.AbsoluteScaleLabels = new string[] {
        "50",
        "40",
        "30",
        "20",
        "10"};
            this.tableLayoutPanelCINR.SetColumnSpan(this.spPerfChartCINR, 3);
            this.spPerfChartCINR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spPerfChartCINR.DualGraph = true;
            this.spPerfChartCINR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.spPerfChartCINR.HideBorder = false;
            this.spPerfChartCINR.Location = new System.Drawing.Point(3, 3);
            this.spPerfChartCINR.Name = "spPerfChartCINR";
            this.spPerfChartCINR.OrderOfMagnitude = 0;
            this.spPerfChartCINR.PerfChartStyle.AntiAliasing = true;
            chartPen21.Color = System.Drawing.Color.Black;
            chartPen21.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            chartPen21.Width = 2F;
            this.spPerfChartCINR.PerfChartStyle.AvgLinePen = chartPen21;
            this.spPerfChartCINR.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.DimGray;
            this.spPerfChartCINR.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.Gainsboro;
            chartPen22.Color = System.Drawing.Color.Orange;
            chartPen22.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen22.Width = 2F;
            this.spPerfChartCINR.PerfChartStyle.ChartLinePen = chartPen22;
            chartPen23.Color = System.Drawing.Color.Red;
            chartPen23.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen23.Width = 2F;
            this.spPerfChartCINR.PerfChartStyle.ChartLinePenB = chartPen23;
            chartPen24.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen24.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen24.Width = 1F;
            this.spPerfChartCINR.PerfChartStyle.HorizontalGridPen = chartPen24;
            this.spPerfChartCINR.PerfChartStyle.ShowAverageLine = false;
            this.spPerfChartCINR.PerfChartStyle.ShowHorizontalGridLines = true;
            this.spPerfChartCINR.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen25.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen25.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen25.Width = 1F;
            this.spPerfChartCINR.PerfChartStyle.VerticalGridPen = chartPen25;
            this.spPerfChartCINR.ScaleMode = SpPerfChart.ScaleMode.Absolute;
            this.spPerfChartCINR.ShowAbsoluteScale = true;
            this.spPerfChartCINR.Size = new System.Drawing.Size(192, 130);
            this.spPerfChartCINR.TabIndex = 11;
            this.spPerfChartCINR.TimerInterval = 100;
            this.spPerfChartCINR.TimerMode = SpPerfChart.TimerMode.Disabled;
            // 
            // spPerfChartRSSI
            // 
            this.tableLayoutPanelRSSI.SetColumnSpan(this.spPerfChartRSSI, 3);
            this.spPerfChartRSSI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spPerfChartRSSI.DualGraph = true;
            this.spPerfChartRSSI.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.spPerfChartRSSI.HideBorder = false;
            this.spPerfChartRSSI.Location = new System.Drawing.Point(3, 3);
            this.spPerfChartRSSI.Name = "spPerfChartRSSI";
            this.spPerfChartRSSI.OrderOfMagnitude = 0;
            this.spPerfChartRSSI.PerfChartStyle.AntiAliasing = true;
            chartPen26.Color = System.Drawing.Color.Black;
            chartPen26.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            chartPen26.Width = 1F;
            this.spPerfChartRSSI.PerfChartStyle.AvgLinePen = chartPen26;
            this.spPerfChartRSSI.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.DimGray;
            this.spPerfChartRSSI.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.Gainsboro;
            chartPen27.Color = System.Drawing.Color.Orange;
            chartPen27.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen27.Width = 2F;
            this.spPerfChartRSSI.PerfChartStyle.ChartLinePen = chartPen27;
            chartPen28.Color = System.Drawing.Color.Red;
            chartPen28.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen28.Width = 2F;
            this.spPerfChartRSSI.PerfChartStyle.ChartLinePenB = chartPen28;
            chartPen29.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen29.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen29.Width = 1F;
            this.spPerfChartRSSI.PerfChartStyle.HorizontalGridPen = chartPen29;
            this.spPerfChartRSSI.PerfChartStyle.ShowAverageLine = false;
            this.spPerfChartRSSI.PerfChartStyle.ShowHorizontalGridLines = true;
            this.spPerfChartRSSI.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen30.Color = System.Drawing.Color.DarkOliveGreen;
            chartPen30.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen30.Width = 1F;
            this.spPerfChartRSSI.PerfChartStyle.VerticalGridPen = chartPen30;
            this.spPerfChartRSSI.ScaleMode = SpPerfChart.ScaleMode.Relative;
            this.spPerfChartRSSI.Size = new System.Drawing.Size(192, 130);
            this.spPerfChartRSSI.TabIndex = 11;
            this.spPerfChartRSSI.TimerInterval = 100;
            this.spPerfChartRSSI.TimerMode = SpPerfChart.TimerMode.Disabled;
            // 
            // FormSystemStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 649);
            this.Controls.Add(this.tableLayoutPanelWholeForm);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSystemStatus";
            this.Text = "DAN PMC";
            this.groupBoxGMAC0.ResumeLayout(false);
            this.tableLayoutPanelGMACleft.ResumeLayout(false);
            this.tableLayoutPanelGMACleft.PerformLayout();
            this.groupBoxGMAC1.ResumeLayout(false);
            this.tableLayoutPanelGMACright.ResumeLayout(false);
            this.tableLayoutPanelGMACright.PerformLayout();
            this.tableLayoutPanelStatusBottom.ResumeLayout(false);
            this.tableLayoutPanelStatusBottom.PerformLayout();
            this.tableLayoutPanelPHY.ResumeLayout(false);
            this.tableLayoutPanelPHY.PerformLayout();
            this.groupBoxMCS.ResumeLayout(false);
            this.tableLayoutPanelMCS.ResumeLayout(false);
            this.tableLayoutPanelMCS.PerformLayout();
            this.groupBoxPER.ResumeLayout(false);
            this.groupBoxPER.PerformLayout();
            this.tableLayoutPanelPER.ResumeLayout(false);
            this.tableLayoutPanelPER.PerformLayout();
            this.groupBoxCINR.ResumeLayout(false);
            this.tableLayoutPanelCINR.ResumeLayout(false);
            this.tableLayoutPanelCINR.PerformLayout();
            this.groupBoxRSSI.ResumeLayout(false);
            this.tableLayoutPanelRSSI.ResumeLayout(false);
            this.tableLayoutPanelRSSI.PerformLayout();
            this.panelPhySectionSeparator.ResumeLayout(false);
            this.panelPhySectionSeparator.PerformLayout();
            this.tableLayoutPanelWholeForm.ResumeLayout(false);
            this.tableLayoutPanelWholeForm.PerformLayout();
            this.tableLayoutPanelLinkStatus.ResumeLayout(false);
            this.tableLayoutPanelLinkStatus.PerformLayout();
            this.tableLayoutPanelGMAC.ResumeLayout(false);
            this.tableLayoutPanelGMAC.PerformLayout();
            this.tableLayoutPanelGraphic.ResumeLayout(false);
            this.groupBoxSTO.ResumeLayout(false);
            this.groupBoxSTO.PerformLayout();
            this.groupBoxXPI.ResumeLayout(false);
            this.groupBoxXPI.PerformLayout();
            this.ResumeLayout(false);

        }

 

        #endregion

        private System.ComponentModel.BackgroundWorker bgWrkTimer;

        private System.Windows.Forms.GroupBox groupBoxGMAC0;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGMACleft;
        private System.Windows.Forms.ComboBox comboBoxGraph0a;
        private System.Windows.Forms.ComboBox comboBoxGraph0b;
        private System.Windows.Forms.Label labelGraph0Max;
        private System.Windows.Forms.Label labelGraph0Latest;
        private SpPerfChart.SpPerfChart spPerfChart0;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelStatusBottom;
        private System.Windows.Forms.Button buttonResetSOC;
        private System.Windows.Forms.Button buttonResetCounters;
        private System.Windows.Forms.Button buttonConstellation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGMACright;
        private System.Windows.Forms.GroupBox groupBoxGMAC1;
        private System.Windows.Forms.ComboBox comboBoxGraph1b;
        private System.Windows.Forms.ComboBox comboBoxGraph1a;
        private System.Windows.Forms.Label labelGraph1Max;
        private System.Windows.Forms.Label labelGraph1Latest;
        private SpPerfChart.SpPerfChart spPerfChart1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPHY;
        private System.Windows.Forms.GroupBox groupBoxRSSI;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRSSI;
        private SpPerfChart.SpPerfChart spPerfChartRSSI;
        private System.Windows.Forms.Label labelGraphRSSI0Current;
        private System.Windows.Forms.RadioButton radioButtonRSSI1;
        private System.Windows.Forms.RadioButton radioButtonRSSI2;
        private System.Windows.Forms.GroupBox groupBoxCINR;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCINR;
        private SpPerfChart.SpPerfChart spPerfChartCINR;
        private System.Windows.Forms.Label labelGraphCINR0Current;
        private System.Windows.Forms.RadioButton radioButtonCINR1;
        private System.Windows.Forms.RadioButton radioButtonCINR2;
        private System.Windows.Forms.GroupBox groupBoxPER;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPER;
        private SpPerfChart.SpPerfChart spPerfChartPER;
        private System.Windows.Forms.Label labelGraphPER0Current;
        private System.Windows.Forms.RadioButton radioButtonPER1;
        private System.Windows.Forms.RadioButton radioButtonPER2;
        private System.Windows.Forms.Panel panelPhySectionSeparator;
        private System.Windows.Forms.Label labelPHY;
        private System.Windows.Forms.Label labelGraphPER1Nack;
        private System.Windows.Forms.ToolTip toolTipTBs;
        private System.Windows.Forms.Label labelGraphPER0Nack;
        private System.Windows.Forms.GroupBox groupBoxMCS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMCS;
        private System.Windows.Forms.Label labelMcsManualSetting;
        private SpPerfChart.SpPerfChart spPerfChartMCS;
        private System.Windows.Forms.Label labelMcsLatest;
        private System.Windows.Forms.RadioButton radioButtonMCSAnt1;
        private System.Windows.Forms.RadioButton radioButtonMCSAnt2;
        private System.Windows.Forms.Label labelMcsAuto;
        private System.Windows.Forms.Button buttonProperties;
        private System.Windows.Forms.ToolTip toolTipMSC;
        private System.ComponentModel.BackgroundWorker bgWrkConstellation;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelWholeForm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLinkStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGMAC;
        private System.Windows.Forms.ToolTip toolTipLinkStatus;
        private System.Windows.Forms.Panel panelLinkTimingLoop;
        private System.Windows.Forms.Label labelLinkTimingLoop;
        private System.Windows.Forms.Label labelGraphRSSI1Current;
        private System.Windows.Forms.Label labelGraphCINR1Current;
        private System.Windows.Forms.Label labelGraphPER1Current;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGraphic;
        private GroupBox groupBoxSTO;
        private TextBox textBoxSTO2;
        private TextBox textBoxSTO1;
        private Label label1;
        private Label label2;
        private LinkLabel DesignArtNetworks;
        private CheckBox chkBxTimerEnabled;
        private GroupBox groupBoxXPI;
        private TextBox textBoxXPIAnt1;
        private TextBox textBoxXPIAnt0;
        private Label label11;
        private Label label10;
        private Label labelLinkStatus;
        private Label labelRLMLinkStatus;
        private Panel panelLinkPllLock;
        private Label labelLinkPllLock;
        private Panel panelLinkTxOn;
        private Label labelLinkTxOn;

    }
}

