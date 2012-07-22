namespace WindowsFormsApplication1
{
    partial class FormNodeProperties
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Profile");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Modulation");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("CINR Simulation");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("PHY Counters");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("PHY", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Memory Viewer");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Constellation");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Unit Control");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("PLL ");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("CDU");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Debug", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Administration Control");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNodeProperties));
            this.splitContainerNodeProperties = new System.Windows.Forms.SplitContainer();
            this.treeViewNodeProperties = new System.Windows.Forms.TreeView();
            this.tableLayoutPanelNodePropertiesBottom = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPropertiesCancel = new System.Windows.Forms.Button();
            this.buttonPropertiesOK = new System.Windows.Forms.Button();
            this.toolTipNodeProperties = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialogConstellationData = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogConstellationExecutable = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControlNodePropertyPages = new Dotnetrix.Samples.CSharp.TabControl();
            this.tabPage0 = new System.Windows.Forms.TabPage();
            this.groupBoxRX = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBoxTX = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage0_0 = new System.Windows.Forms.TabPage();
            this.buttonProfileChangeApply = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelExpectedTputMCS11 = new System.Windows.Forms.Label();
            this.textBoxPhyExpectedThroughputMCS11 = new System.Windows.Forms.TextBox();
            this.labelExpectedTputMCS10 = new System.Windows.Forms.Label();
            this.textBoxPhyExpectedThroughputMCS10 = new System.Windows.Forms.TextBox();
            this.labelExpectedTputMCS9 = new System.Windows.Forms.Label();
            this.textBoxPhyExpectedThroughputMCS9 = new System.Windows.Forms.TextBox();
            this.textBoxPhyExpectedThroughputMCS1 = new System.Windows.Forms.TextBox();
            this.labelExpectedTputMCS8 = new System.Windows.Forms.Label();
            this.textBoxPhyExpectedThroughputMCS2 = new System.Windows.Forms.TextBox();
            this.labelExpectedTputMCS7 = new System.Windows.Forms.Label();
            this.textBoxPhyExpectedThroughputMCS3 = new System.Windows.Forms.TextBox();
            this.labelExpectedTputMCS6 = new System.Windows.Forms.Label();
            this.textBoxPhyExpectedThroughputMCS4 = new System.Windows.Forms.TextBox();
            this.labelExpectedTputMCS5 = new System.Windows.Forms.Label();
            this.textBoxPhyExpectedThroughputMCS5 = new System.Windows.Forms.TextBox();
            this.labelExpectedTputMCS4 = new System.Windows.Forms.Label();
            this.textBoxPhyExpectedThroughputMCS6 = new System.Windows.Forms.TextBox();
            this.labelExpectedTputMCS3 = new System.Windows.Forms.Label();
            this.textBoxPhyExpectedThroughputMCS7 = new System.Windows.Forms.TextBox();
            this.labelExpectedTputMCS2 = new System.Windows.Forms.Label();
            this.textBoxPhyExpectedThroughputMCS8 = new System.Windows.Forms.TextBox();
            this.labelExpectedTputMCS1 = new System.Windows.Forms.Label();
            this.textBoxPhyRange = new System.Windows.Forms.TextBox();
            this.textBoxPhyDuplexMode = new System.Windows.Forms.TextBox();
            this.textBoxPhyBandwidth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxPhyProfile = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage0_1 = new System.Windows.Forms.TabPage();
            this.labelMCSSetSelect = new System.Windows.Forms.Label();
            this.comboBoxMCSSetSelect = new System.Windows.Forms.ComboBox();
            this.checkBoxMCSSet2 = new System.Windows.Forms.CheckBox();
            this.groupBoxManualAMC = new System.Windows.Forms.GroupBox();
            this.textBoxManualAmcMaxThru = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBoxManualMCS1 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBoxManualMCS0 = new System.Windows.Forms.ComboBox();
            this.checkBoxAMC = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage0_2 = new System.Windows.Forms.TabPage();
            this.groupBoxCinrSimulation = new System.Windows.Forms.GroupBox();
            this.textBoxSimCinr1 = new System.Windows.Forms.TextBox();
            this.textBoxSimCinr0 = new System.Windows.Forms.TextBox();
            this.buttonWriteCinrValues = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.checkBoxCinrSimulation = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tabPage0_3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.MCS9 = new System.Windows.Forms.Label();
            this.MCS8 = new System.Windows.Forms.Label();
            this.MCS7 = new System.Windows.Forms.Label();
            this.MCS6 = new System.Windows.Forms.Label();
            this.MCS5 = new System.Windows.Forms.Label();
            this.MCS4 = new System.Windows.Forms.Label();
            this.MCS3 = new System.Windows.Forms.Label();
            this.MCS2 = new System.Windows.Forms.Label();
            this.MCS1 = new System.Windows.Forms.Label();
            this.textBoxMCS8UpThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS8DownThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS7UpThreshold = new System.Windows.Forms.TextBox();
            this.labelMCSDescription = new System.Windows.Forms.Label();
            this.textBoxMCS6UpThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS5UpThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS7DownThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS4UpThreshold = new System.Windows.Forms.TextBox();
            this.labelMCSDown = new System.Windows.Forms.Label();
            this.textBoxMCS3UpThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS1DownThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS2UpThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS6DownThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS2DownThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS3DownThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS4DownThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS5DownThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS1UpThreshold = new System.Windows.Forms.TextBox();
            this.labelMCSUp = new System.Windows.Forms.Label();
            this.MCS10 = new System.Windows.Forms.Label();
            this.MCS11 = new System.Windows.Forms.Label();
            this.textBoxMCS9UpThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS9DownThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS10UpThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS10DownThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS11DownThreshold = new System.Windows.Forms.TextBox();
            this.textBoxMCS11UpThreshold = new System.Windows.Forms.TextBox();
            this.buttonMCSApplyChanges = new System.Windows.Forms.Button();
            this.buttonMCSRestoreToDefault = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.tabPage0_4 = new System.Windows.Forms.TabPage();
            this.label40 = new System.Windows.Forms.Label();
            this.tabPage0_5 = new System.Windows.Forms.TabPage();
            this.checkBox_Uncoded_BER_COUNTER_ENABLE = new System.Windows.Forms.CheckBox();
            this.checkBox_BER_COUNTER_ENABLE = new System.Windows.Forms.CheckBox();
            this.groupBoxPHYTBCounters = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelPHYCounters = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GeneralQOS = new System.Windows.Forms.GroupBox();
            this.ShaperMB = new System.Windows.Forms.TextBox();
            this.ShaperLimit = new System.Windows.Forms.Label();
            this.QOSMethodSelect = new System.Windows.Forms.ComboBox();
            this.QOSMethod = new System.Windows.Forms.Label();
            this.QOSTypeSelect = new System.Windows.Forms.ComboBox();
            this.QOSType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage1_0 = new System.Windows.Forms.TabPage();
            this.QOSL2 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.Priority3L = new System.Windows.Forms.TextBox();
            this.Priority3H = new System.Windows.Forms.TextBox();
            this.Priority3 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.Priority4L = new System.Windows.Forms.TextBox();
            this.Priority4H = new System.Windows.Forms.TextBox();
            this.Priority4 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.Priority2L = new System.Windows.Forms.TextBox();
            this.Priority2H = new System.Windows.Forms.TextBox();
            this.Priority2 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.Priority1L = new System.Windows.Forms.TextBox();
            this.Priority1H = new System.Windows.Forms.TextBox();
            this.Priority1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.QOSL3 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.Priority3LIP = new System.Windows.Forms.TextBox();
            this.Priority3HIP = new System.Windows.Forms.TextBox();
            this.Priority3IP = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.Priority4LIP = new System.Windows.Forms.TextBox();
            this.Priority4HIP = new System.Windows.Forms.TextBox();
            this.Priority4IP = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.Priority2LIP = new System.Windows.Forms.TextBox();
            this.Priority2HIP = new System.Windows.Forms.TextBox();
            this.Priority2IP = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.Priority1LIP = new System.Windows.Forms.TextBox();
            this.Priority1HIP = new System.Windows.Forms.TextBox();
            this.Priority1IP = new System.Windows.Forms.Label();
            this.tabPage1_1 = new System.Windows.Forms.TabPage();
            this.VLANConfiguration = new System.Windows.Forms.GroupBox();
            this.VLANMember = new System.Windows.Forms.GroupBox();
            this.removeVlanMember = new System.Windows.Forms.Button();
            this.VlanMemPortNum = new System.Windows.Forms.Label();
            this.EnterVlanMemVlanID = new System.Windows.Forms.RichTextBox();
            this.EnterVlanMemPortNum = new System.Windows.Forms.ComboBox();
            this.VlanMemVlanID = new System.Windows.Forms.Label();
            this.AddVlanMember = new System.Windows.Forms.Button();
            this.VLANPortSetting = new System.Windows.Forms.GroupBox();
            this.PortNumberSet = new System.Windows.Forms.Label();
            this.EnterVLANPPortSet = new System.Windows.Forms.RichTextBox();
            this.FilterUnttagedselect = new System.Windows.Forms.ComboBox();
            this.FilterUnttagedSet = new System.Windows.Forms.Label();
            this.EnterVLANIDPortSet = new System.Windows.Forms.RichTextBox();
            this.VLANPPortSet = new System.Windows.Forms.Label();
            this.PortNumPortSet = new System.Windows.Forms.ComboBox();
            this.VLANIDPortSet = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonMemoryWrite = new System.Windows.Forms.Button();
            this.textBoxMemoryValue = new System.Windows.Forms.TextBox();
            this.labelAddrContents = new System.Windows.Forms.Label();
            this.buttonMemoryRead = new System.Windows.Forms.Button();
            this.listViewMemory = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxMemoryAddr = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonConstellationApply = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxMatlabwithChannelEstimation = new System.Windows.Forms.CheckBox();
            this.buttonConstellationDataFolder = new System.Windows.Forms.Button();
            this.buttonConstellationExecutable = new System.Windows.Forms.Button();
            this.textBoxConstellationDataFolder = new System.Windows.Forms.TextBox();
            this.textBoxConstellationExecutable = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxEnablePersistence = new System.Windows.Forms.ComboBox();
            this.labelEnablePersistence = new System.Windows.Forms.Label();
            this.comboBoxPLLDebug = new System.Windows.Forms.ComboBox();
            this.labelPLLDebug = new System.Windows.Forms.Label();
            this.comboBoxConstellationFFT = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.textBoxConstellationUpdateInterval = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textBoxTransmittionMode = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.textBoxRunningProfile = new System.Windows.Forms.TextBox();
            this.labelRunningProfile = new System.Windows.Forms.Label();
            this.textBoxUnitType = new System.Windows.Forms.TextBox();
            this.textBoxCPLDVersion = new System.Windows.Forms.TextBox();
            this.textBoxSWVersion = new System.Windows.Forms.TextBox();
            this.textBoxuMONVersion = new System.Windows.Forms.TextBox();
            this.labelCPLDVERSION = new System.Windows.Forms.Label();
            this.labelUnitType = new System.Windows.Forms.Label();
            this.labelSWVersion = new System.Windows.Forms.Label();
            this.labeluMONVersion = new System.Windows.Forms.Label();
            this.labelUnitControl = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label1DebugUnit = new System.Windows.Forms.Label();
            this.label2DebugUnit = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.comboBoxSpectralInversion = new System.Windows.Forms.ComboBox();
            this.labelSpectralInversion = new System.Windows.Forms.Label();
            this.comboBoxPLLLoopBWB1 = new System.Windows.Forms.ComboBox();
            this.labelPLLloopBandWidthB1 = new System.Windows.Forms.Label();
            this.textBoxRXPRIHypothesis = new System.Windows.Forms.TextBox();
            this.labelRXPRIHypothesis = new System.Windows.Forms.Label();
            this.comboBoxDisablePLLDerotation = new System.Windows.Forms.ComboBox();
            this.labelDisablePLLDerotation = new System.Windows.Forms.Label();
            this.comboBoxChannelEstimationFactor = new System.Windows.Forms.ComboBox();
            this.comboBoxCINRFactor = new System.Windows.Forms.ComboBox();
            this.labelChannelEstimationfactor = new System.Windows.Forms.Label();
            this.labelCINRfactor = new System.Windows.Forms.Label();
            this.comboBoxPLLLoopBWB2 = new System.Windows.Forms.ComboBox();
            this.labelPLLloopBandWidthB2 = new System.Windows.Forms.Label();
            this.comboBoxPLLWorkingMode = new System.Windows.Forms.ComboBox();
            this.labelPLLWorkingMode = new System.Windows.Forms.Label();
            this.buttonDebugApply = new System.Windows.Forms.Button();
            this.label_PLLDebug = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.labelMemoryDumpDownloadFileName = new System.Windows.Forms.Label();
            this.textBoxMemoryDumpDownloadFileName = new System.Windows.Forms.TextBox();
            this.labellMemoryDumpDownloadSize = new System.Windows.Forms.Label();
            this.textBoxMemoryDumpDownloadSize = new System.Windows.Forms.TextBox();
            this.labelMemoryDumpDownloadAddress = new System.Windows.Forms.Label();
            this.textBoxMemoryDumpDownloadAddress = new System.Windows.Forms.TextBox();
            this.buttonDownloadMemory = new System.Windows.Forms.Button();
            this.buttonCDUDownloadResults = new System.Windows.Forms.Button();
            this.buttonCDURunScript = new System.Windows.Forms.Button();
            this.labelCDUScript = new System.Windows.Forms.Label();
            this.comboBoxChooseCDUScript = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.buttonPasswordApply = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.LAbelPassword = new System.Windows.Forms.Label();
            this.labelUserNAme = new System.Windows.Forms.Label();
            this.labelAdminControl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerNodeProperties)).BeginInit();
            this.splitContainerNodeProperties.Panel1.SuspendLayout();
            this.splitContainerNodeProperties.Panel2.SuspendLayout();
            this.splitContainerNodeProperties.SuspendLayout();
            this.tableLayoutPanelNodePropertiesBottom.SuspendLayout();
            this.tabControlNodePropertyPages.SuspendLayout();
            this.tabPage0.SuspendLayout();
            this.groupBoxRX.SuspendLayout();
            this.groupBoxTX.SuspendLayout();
            this.tabPage0_0.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage0_1.SuspendLayout();
            this.groupBoxManualAMC.SuspendLayout();
            this.tabPage0_2.SuspendLayout();
            this.groupBoxCinrSimulation.SuspendLayout();
            this.tabPage0_3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage0_4.SuspendLayout();
            this.tabPage0_5.SuspendLayout();
            this.groupBoxPHYTBCounters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.GeneralQOS.SuspendLayout();
            this.tabPage1_0.SuspendLayout();
            this.QOSL2.SuspendLayout();
            this.QOSL3.SuspendLayout();
            this.tabPage1_1.SuspendLayout();
            this.VLANConfiguration.SuspendLayout();
            this.VLANMember.SuspendLayout();
            this.VLANPortSetting.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerNodeProperties
            // 
            this.splitContainerNodeProperties.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainerNodeProperties.Location = new System.Drawing.Point(0, 0);
            this.splitContainerNodeProperties.Name = "splitContainerNodeProperties";
            // 
            // splitContainerNodeProperties.Panel1
            // 
            this.splitContainerNodeProperties.Panel1.Controls.Add(this.treeViewNodeProperties);
            // 
            // splitContainerNodeProperties.Panel2
            // 
            this.splitContainerNodeProperties.Panel2.Controls.Add(this.tabControlNodePropertyPages);
            this.splitContainerNodeProperties.Size = new System.Drawing.Size(492, 524);
            this.splitContainerNodeProperties.SplitterDistance = 134;
            this.splitContainerNodeProperties.TabIndex = 0;
            // 
            // treeViewNodeProperties
            // 
            this.treeViewNodeProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewNodeProperties.HideSelection = false;
            this.treeViewNodeProperties.Location = new System.Drawing.Point(0, 0);
            this.treeViewNodeProperties.Name = "treeViewNodeProperties";
            treeNode1.Name = "NodePhyProfile";
            treeNode1.Tag = "1";
            treeNode1.Text = "Profile";
            treeNode2.Name = "NodeModulation";
            treeNode2.Tag = "2";
            treeNode2.Text = "Modulation";
            treeNode3.Name = "NodeCinrSimulation";
            treeNode3.Tag = "3";
            treeNode3.Text = "CINR Simulation";
            treeNode4.Name = "NodePHYCounters";
            treeNode4.Tag = "6";
            treeNode4.Text = "PHY Counters";
            treeNode5.Name = "NodePHY";
            treeNode5.Tag = "0";
            treeNode5.Text = "PHY";
            treeNode6.Name = "NodeMemoryViewer";
            treeNode6.Tag = "10";
            treeNode6.Text = "Memory Viewer";
            treeNode7.Name = "NodeConstellation";
            treeNode7.Tag = "11";
            treeNode7.Text = "Constellation";
            treeNode8.Name = "UnitControl";
            treeNode8.Tag = "12";
            treeNode8.Text = "Unit Control";
            treeNode9.Name = "PLL";
            treeNode9.Tag = "14";
            treeNode9.Text = "PLL ";
            treeNode10.Name = "CDU";
            treeNode10.Tag = "15";
            treeNode10.Text = "CDU";
            treeNode11.Name = "Debug";
            treeNode11.Tag = "13";
            treeNode11.Text = "Debug";
            treeNode12.Name = "AdministrationControl";
            treeNode12.Tag = "16";
            treeNode12.Text = "Administration Control";
            this.treeViewNodeProperties.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode11,
            treeNode12});
            this.treeViewNodeProperties.Size = new System.Drawing.Size(134, 524);
            this.treeViewNodeProperties.TabIndex = 0;
            this.treeViewNodeProperties.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewNodeProperties_AfterSelect);
            // 
            // tableLayoutPanelNodePropertiesBottom
            // 
            this.tableLayoutPanelNodePropertiesBottom.AutoSize = true;
            this.tableLayoutPanelNodePropertiesBottom.ColumnCount = 5;
            this.tableLayoutPanelNodePropertiesBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelNodePropertiesBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelNodePropertiesBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelNodePropertiesBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelNodePropertiesBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanelNodePropertiesBottom.Controls.Add(this.buttonPropertiesCancel, 3, 0);
            this.tableLayoutPanelNodePropertiesBottom.Controls.Add(this.buttonPropertiesOK, 2, 0);
            this.tableLayoutPanelNodePropertiesBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanelNodePropertiesBottom.Location = new System.Drawing.Point(0, 612);
            this.tableLayoutPanelNodePropertiesBottom.Name = "tableLayoutPanelNodePropertiesBottom";
            this.tableLayoutPanelNodePropertiesBottom.RowCount = 1;
            this.tableLayoutPanelNodePropertiesBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelNodePropertiesBottom.Size = new System.Drawing.Size(492, 29);
            this.tableLayoutPanelNodePropertiesBottom.TabIndex = 1;
            // 
            // buttonPropertiesCancel
            // 
            this.buttonPropertiesCancel.Location = new System.Drawing.Point(371, 3);
            this.buttonPropertiesCancel.Name = "buttonPropertiesCancel";
            this.buttonPropertiesCancel.Size = new System.Drawing.Size(68, 23);
            this.buttonPropertiesCancel.TabIndex = 1;
            this.buttonPropertiesCancel.Text = "Cancel";
            this.buttonPropertiesCancel.UseVisualStyleBackColor = true;
            this.buttonPropertiesCancel.Click += new System.EventHandler(this.buttonPropertiesCancel_Click);
            // 
            // buttonPropertiesOK
            // 
            this.buttonPropertiesOK.Location = new System.Drawing.Point(284, 3);
            this.buttonPropertiesOK.Name = "buttonPropertiesOK";
            this.buttonPropertiesOK.Size = new System.Drawing.Size(68, 23);
            this.buttonPropertiesOK.TabIndex = 0;
            this.buttonPropertiesOK.Text = "OK";
            this.buttonPropertiesOK.UseVisualStyleBackColor = true;
            this.buttonPropertiesOK.Click += new System.EventHandler(this.buttonPropertiesOK_Click);
            // 
            // toolTipNodeProperties
            // 
            this.toolTipNodeProperties.ToolTipTitle = "Node Properties";
            // 
            // folderBrowserDialogConstellationData
            // 
            this.folderBrowserDialogConstellationData.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // openFileDialogConstellationExecutable
            // 
            this.openFileDialogConstellationExecutable.DefaultExt = "exe";
            this.openFileDialogConstellationExecutable.FileName = "logic.exe";
            this.openFileDialogConstellationExecutable.InitialDirectory = "C:\\PTP\\logic_007";
            // 
            // tabControlNodePropertyPages
            // 
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage0);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage0_0);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage0_1);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage0_2);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage0_3);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage0_4);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage0_5);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage1);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage1_0);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage1_1);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage2);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage3);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage4);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage5);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage6);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage7);
            this.tabControlNodePropertyPages.Controls.Add(this.tabPage8);
            this.tabControlNodePropertyPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlNodePropertyPages.Location = new System.Drawing.Point(0, 0);
            this.tabControlNodePropertyPages.Multiline = true;
            this.tabControlNodePropertyPages.Name = "tabControlNodePropertyPages";
            this.tabControlNodePropertyPages.SelectedIndex = 0;
            this.tabControlNodePropertyPages.Size = new System.Drawing.Size(354, 524);
            this.tabControlNodePropertyPages.TabIndex = 1;
            this.tabControlNodePropertyPages.TabStop = false;
            // 
            // tabPage0
            // 
            this.tabPage0.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage0.Controls.Add(this.groupBoxRX);
            this.tabPage0.Controls.Add(this.groupBoxTX);
            this.tabPage0.Controls.Add(this.label1);
            this.tabPage0.Location = new System.Drawing.Point(4, 77);
            this.tabPage0.Name = "tabPage0";
            this.tabPage0.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage0.Size = new System.Drawing.Size(346, 443);
            this.tabPage0.TabIndex = 0;
            this.tabPage0.Text = "tabPage0";
            // 
            // groupBoxRX
            // 
            this.groupBoxRX.Controls.Add(this.textBox4);
            this.groupBoxRX.Controls.Add(this.textBox5);
            this.groupBoxRX.Controls.Add(this.textBox6);
            this.groupBoxRX.Controls.Add(this.label13);
            this.groupBoxRX.Controls.Add(this.label14);
            this.groupBoxRX.Controls.Add(this.label15);
            this.groupBoxRX.Location = new System.Drawing.Point(7, 192);
            this.groupBoxRX.Name = "groupBoxRX";
            this.groupBoxRX.Size = new System.Drawing.Size(284, 112);
            this.groupBoxRX.TabIndex = 2;
            this.groupBoxRX.TabStop = false;
            this.groupBoxRX.Text = "RX";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(146, 72);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(93, 20);
            this.textBox4.TabIndex = 22;
            this.textBox4.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(146, 46);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(93, 20);
            this.textBox5.TabIndex = 21;
            this.textBox5.TabStop = false;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(146, 20);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(93, 20);
            this.textBox6.TabIndex = 20;
            this.textBox6.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Spectrum Inversion:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "RF Frequency (Ghz):";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "IF Frequency (Mhz):";
            // 
            // groupBoxTX
            // 
            this.groupBoxTX.Controls.Add(this.textBox1);
            this.groupBoxTX.Controls.Add(this.textBox2);
            this.groupBoxTX.Controls.Add(this.textBox3);
            this.groupBoxTX.Controls.Add(this.label10);
            this.groupBoxTX.Controls.Add(this.label11);
            this.groupBoxTX.Controls.Add(this.label12);
            this.groupBoxTX.Location = new System.Drawing.Point(6, 77);
            this.groupBoxTX.Name = "groupBoxTX";
            this.groupBoxTX.Size = new System.Drawing.Size(284, 112);
            this.groupBoxTX.TabIndex = 1;
            this.groupBoxTX.TabStop = false;
            this.groupBoxTX.Text = "TX";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(146, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(93, 20);
            this.textBox1.TabIndex = 22;
            this.textBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(146, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(93, 20);
            this.textBox2.TabIndex = 21;
            this.textBox2.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(146, 20);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(93, 20);
            this.textBox3.TabIndex = 20;
            this.textBox3.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "RF Tx Power (dbm):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "RF Frequency (Ghz):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "IF Frequency (Mhz):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "RF / IF";
            // 
            // tabPage0_0
            // 
            this.tabPage0_0.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage0_0.Controls.Add(this.buttonProfileChangeApply);
            this.tabPage0_0.Controls.Add(this.groupBox3);
            this.tabPage0_0.Controls.Add(this.textBoxPhyRange);
            this.tabPage0_0.Controls.Add(this.textBoxPhyDuplexMode);
            this.tabPage0_0.Controls.Add(this.textBoxPhyBandwidth);
            this.tabPage0_0.Controls.Add(this.label8);
            this.tabPage0_0.Controls.Add(this.label7);
            this.tabPage0_0.Controls.Add(this.label6);
            this.tabPage0_0.Controls.Add(this.comboBoxPhyProfile);
            this.tabPage0_0.Controls.Add(this.label4);
            this.tabPage0_0.Location = new System.Drawing.Point(4, 77);
            this.tabPage0_0.Name = "tabPage0_0";
            this.tabPage0_0.Size = new System.Drawing.Size(346, 443);
            this.tabPage0_0.TabIndex = 3;
            this.tabPage0_0.Text = "tabPage0_0";
            // 
            // buttonProfileChangeApply
            // 
            this.buttonProfileChangeApply.Enabled = false;
            this.buttonProfileChangeApply.Location = new System.Drawing.Point(217, 62);
            this.buttonProfileChangeApply.Name = "buttonProfileChangeApply";
            this.buttonProfileChangeApply.Size = new System.Drawing.Size(75, 23);
            this.buttonProfileChangeApply.TabIndex = 35;
            this.buttonProfileChangeApply.Text = "Apply";
            this.buttonProfileChangeApply.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelExpectedTputMCS11);
            this.groupBox3.Controls.Add(this.textBoxPhyExpectedThroughputMCS11);
            this.groupBox3.Controls.Add(this.labelExpectedTputMCS10);
            this.groupBox3.Controls.Add(this.textBoxPhyExpectedThroughputMCS10);
            this.groupBox3.Controls.Add(this.labelExpectedTputMCS9);
            this.groupBox3.Controls.Add(this.textBoxPhyExpectedThroughputMCS9);
            this.groupBox3.Controls.Add(this.textBoxPhyExpectedThroughputMCS1);
            this.groupBox3.Controls.Add(this.labelExpectedTputMCS8);
            this.groupBox3.Controls.Add(this.textBoxPhyExpectedThroughputMCS2);
            this.groupBox3.Controls.Add(this.labelExpectedTputMCS7);
            this.groupBox3.Controls.Add(this.textBoxPhyExpectedThroughputMCS3);
            this.groupBox3.Controls.Add(this.labelExpectedTputMCS6);
            this.groupBox3.Controls.Add(this.textBoxPhyExpectedThroughputMCS4);
            this.groupBox3.Controls.Add(this.labelExpectedTputMCS5);
            this.groupBox3.Controls.Add(this.textBoxPhyExpectedThroughputMCS5);
            this.groupBox3.Controls.Add(this.labelExpectedTputMCS4);
            this.groupBox3.Controls.Add(this.textBoxPhyExpectedThroughputMCS6);
            this.groupBox3.Controls.Add(this.labelExpectedTputMCS3);
            this.groupBox3.Controls.Add(this.textBoxPhyExpectedThroughputMCS7);
            this.groupBox3.Controls.Add(this.labelExpectedTputMCS2);
            this.groupBox3.Controls.Add(this.textBoxPhyExpectedThroughputMCS8);
            this.groupBox3.Controls.Add(this.labelExpectedTputMCS1);
            this.groupBox3.Location = new System.Drawing.Point(35, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 307);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Expected throughput  Results";
            // 
            // labelExpectedTputMCS11
            // 
            this.labelExpectedTputMCS11.AutoSize = true;
            this.labelExpectedTputMCS11.Location = new System.Drawing.Point(25, 287);
            this.labelExpectedTputMCS11.Name = "labelExpectedTputMCS11";
            this.labelExpectedTputMCS11.Size = new System.Drawing.Size(48, 13);
            this.labelExpectedTputMCS11.TabIndex = 39;
            this.labelExpectedTputMCS11.Text = "MCS11 :";
            this.labelExpectedTputMCS11.Visible = false;
            // 
            // textBoxPhyExpectedThroughputMCS11
            // 
            this.textBoxPhyExpectedThroughputMCS11.Location = new System.Drawing.Point(126, 284);
            this.textBoxPhyExpectedThroughputMCS11.Name = "textBoxPhyExpectedThroughputMCS11";
            this.textBoxPhyExpectedThroughputMCS11.ReadOnly = true;
            this.textBoxPhyExpectedThroughputMCS11.Size = new System.Drawing.Size(93, 20);
            this.textBoxPhyExpectedThroughputMCS11.TabIndex = 38;
            this.textBoxPhyExpectedThroughputMCS11.TabStop = false;
            this.textBoxPhyExpectedThroughputMCS11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPhyExpectedThroughputMCS11.Visible = false;
            // 
            // labelExpectedTputMCS10
            // 
            this.labelExpectedTputMCS10.AutoSize = true;
            this.labelExpectedTputMCS10.Location = new System.Drawing.Point(25, 261);
            this.labelExpectedTputMCS10.Name = "labelExpectedTputMCS10";
            this.labelExpectedTputMCS10.Size = new System.Drawing.Size(48, 13);
            this.labelExpectedTputMCS10.TabIndex = 37;
            this.labelExpectedTputMCS10.Text = "MCS10 :";
            // 
            // textBoxPhyExpectedThroughputMCS10
            // 
            this.textBoxPhyExpectedThroughputMCS10.Location = new System.Drawing.Point(126, 258);
            this.textBoxPhyExpectedThroughputMCS10.Name = "textBoxPhyExpectedThroughputMCS10";
            this.textBoxPhyExpectedThroughputMCS10.ReadOnly = true;
            this.textBoxPhyExpectedThroughputMCS10.Size = new System.Drawing.Size(93, 20);
            this.textBoxPhyExpectedThroughputMCS10.TabIndex = 36;
            this.textBoxPhyExpectedThroughputMCS10.TabStop = false;
            this.textBoxPhyExpectedThroughputMCS10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelExpectedTputMCS9
            // 
            this.labelExpectedTputMCS9.AutoSize = true;
            this.labelExpectedTputMCS9.Location = new System.Drawing.Point(25, 235);
            this.labelExpectedTputMCS9.Name = "labelExpectedTputMCS9";
            this.labelExpectedTputMCS9.Size = new System.Drawing.Size(42, 13);
            this.labelExpectedTputMCS9.TabIndex = 35;
            this.labelExpectedTputMCS9.Text = "MCS9 :";
            // 
            // textBoxPhyExpectedThroughputMCS9
            // 
            this.textBoxPhyExpectedThroughputMCS9.Location = new System.Drawing.Point(126, 232);
            this.textBoxPhyExpectedThroughputMCS9.Name = "textBoxPhyExpectedThroughputMCS9";
            this.textBoxPhyExpectedThroughputMCS9.ReadOnly = true;
            this.textBoxPhyExpectedThroughputMCS9.Size = new System.Drawing.Size(93, 20);
            this.textBoxPhyExpectedThroughputMCS9.TabIndex = 34;
            this.textBoxPhyExpectedThroughputMCS9.TabStop = false;
            this.textBoxPhyExpectedThroughputMCS9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPhyExpectedThroughputMCS1
            // 
            this.textBoxPhyExpectedThroughputMCS1.Location = new System.Drawing.Point(126, 24);
            this.textBoxPhyExpectedThroughputMCS1.Name = "textBoxPhyExpectedThroughputMCS1";
            this.textBoxPhyExpectedThroughputMCS1.ReadOnly = true;
            this.textBoxPhyExpectedThroughputMCS1.Size = new System.Drawing.Size(93, 20);
            this.textBoxPhyExpectedThroughputMCS1.TabIndex = 18;
            this.textBoxPhyExpectedThroughputMCS1.TabStop = false;
            this.textBoxPhyExpectedThroughputMCS1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelExpectedTputMCS8
            // 
            this.labelExpectedTputMCS8.AutoSize = true;
            this.labelExpectedTputMCS8.Location = new System.Drawing.Point(25, 209);
            this.labelExpectedTputMCS8.Name = "labelExpectedTputMCS8";
            this.labelExpectedTputMCS8.Size = new System.Drawing.Size(42, 13);
            this.labelExpectedTputMCS8.TabIndex = 33;
            this.labelExpectedTputMCS8.Text = "MCS8 :";
            // 
            // textBoxPhyExpectedThroughputMCS2
            // 
            this.textBoxPhyExpectedThroughputMCS2.Location = new System.Drawing.Point(126, 50);
            this.textBoxPhyExpectedThroughputMCS2.Name = "textBoxPhyExpectedThroughputMCS2";
            this.textBoxPhyExpectedThroughputMCS2.ReadOnly = true;
            this.textBoxPhyExpectedThroughputMCS2.Size = new System.Drawing.Size(93, 20);
            this.textBoxPhyExpectedThroughputMCS2.TabIndex = 19;
            this.textBoxPhyExpectedThroughputMCS2.TabStop = false;
            this.textBoxPhyExpectedThroughputMCS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelExpectedTputMCS7
            // 
            this.labelExpectedTputMCS7.AutoSize = true;
            this.labelExpectedTputMCS7.Location = new System.Drawing.Point(25, 183);
            this.labelExpectedTputMCS7.Name = "labelExpectedTputMCS7";
            this.labelExpectedTputMCS7.Size = new System.Drawing.Size(42, 13);
            this.labelExpectedTputMCS7.TabIndex = 32;
            this.labelExpectedTputMCS7.Text = "MCS7 :";
            // 
            // textBoxPhyExpectedThroughputMCS3
            // 
            this.textBoxPhyExpectedThroughputMCS3.Location = new System.Drawing.Point(126, 76);
            this.textBoxPhyExpectedThroughputMCS3.Name = "textBoxPhyExpectedThroughputMCS3";
            this.textBoxPhyExpectedThroughputMCS3.ReadOnly = true;
            this.textBoxPhyExpectedThroughputMCS3.Size = new System.Drawing.Size(93, 20);
            this.textBoxPhyExpectedThroughputMCS3.TabIndex = 20;
            this.textBoxPhyExpectedThroughputMCS3.TabStop = false;
            this.textBoxPhyExpectedThroughputMCS3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelExpectedTputMCS6
            // 
            this.labelExpectedTputMCS6.AutoSize = true;
            this.labelExpectedTputMCS6.Location = new System.Drawing.Point(25, 157);
            this.labelExpectedTputMCS6.Name = "labelExpectedTputMCS6";
            this.labelExpectedTputMCS6.Size = new System.Drawing.Size(42, 13);
            this.labelExpectedTputMCS6.TabIndex = 31;
            this.labelExpectedTputMCS6.Text = "MCS6 :";
            // 
            // textBoxPhyExpectedThroughputMCS4
            // 
            this.textBoxPhyExpectedThroughputMCS4.Location = new System.Drawing.Point(126, 102);
            this.textBoxPhyExpectedThroughputMCS4.Name = "textBoxPhyExpectedThroughputMCS4";
            this.textBoxPhyExpectedThroughputMCS4.ReadOnly = true;
            this.textBoxPhyExpectedThroughputMCS4.Size = new System.Drawing.Size(93, 20);
            this.textBoxPhyExpectedThroughputMCS4.TabIndex = 21;
            this.textBoxPhyExpectedThroughputMCS4.TabStop = false;
            this.textBoxPhyExpectedThroughputMCS4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelExpectedTputMCS5
            // 
            this.labelExpectedTputMCS5.AutoSize = true;
            this.labelExpectedTputMCS5.Location = new System.Drawing.Point(25, 131);
            this.labelExpectedTputMCS5.Name = "labelExpectedTputMCS5";
            this.labelExpectedTputMCS5.Size = new System.Drawing.Size(42, 13);
            this.labelExpectedTputMCS5.TabIndex = 30;
            this.labelExpectedTputMCS5.Text = "MCS5 :";
            // 
            // textBoxPhyExpectedThroughputMCS5
            // 
            this.textBoxPhyExpectedThroughputMCS5.Location = new System.Drawing.Point(126, 128);
            this.textBoxPhyExpectedThroughputMCS5.Name = "textBoxPhyExpectedThroughputMCS5";
            this.textBoxPhyExpectedThroughputMCS5.ReadOnly = true;
            this.textBoxPhyExpectedThroughputMCS5.Size = new System.Drawing.Size(93, 20);
            this.textBoxPhyExpectedThroughputMCS5.TabIndex = 22;
            this.textBoxPhyExpectedThroughputMCS5.TabStop = false;
            this.textBoxPhyExpectedThroughputMCS5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelExpectedTputMCS4
            // 
            this.labelExpectedTputMCS4.AutoSize = true;
            this.labelExpectedTputMCS4.Location = new System.Drawing.Point(25, 105);
            this.labelExpectedTputMCS4.Name = "labelExpectedTputMCS4";
            this.labelExpectedTputMCS4.Size = new System.Drawing.Size(42, 13);
            this.labelExpectedTputMCS4.TabIndex = 29;
            this.labelExpectedTputMCS4.Text = "MCS4 :";
            // 
            // textBoxPhyExpectedThroughputMCS6
            // 
            this.textBoxPhyExpectedThroughputMCS6.Location = new System.Drawing.Point(126, 154);
            this.textBoxPhyExpectedThroughputMCS6.Name = "textBoxPhyExpectedThroughputMCS6";
            this.textBoxPhyExpectedThroughputMCS6.ReadOnly = true;
            this.textBoxPhyExpectedThroughputMCS6.Size = new System.Drawing.Size(93, 20);
            this.textBoxPhyExpectedThroughputMCS6.TabIndex = 23;
            this.textBoxPhyExpectedThroughputMCS6.TabStop = false;
            this.textBoxPhyExpectedThroughputMCS6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelExpectedTputMCS3
            // 
            this.labelExpectedTputMCS3.AutoSize = true;
            this.labelExpectedTputMCS3.Location = new System.Drawing.Point(25, 79);
            this.labelExpectedTputMCS3.Name = "labelExpectedTputMCS3";
            this.labelExpectedTputMCS3.Size = new System.Drawing.Size(42, 13);
            this.labelExpectedTputMCS3.TabIndex = 28;
            this.labelExpectedTputMCS3.Text = "MCS3 :";
            // 
            // textBoxPhyExpectedThroughputMCS7
            // 
            this.textBoxPhyExpectedThroughputMCS7.Location = new System.Drawing.Point(126, 180);
            this.textBoxPhyExpectedThroughputMCS7.Name = "textBoxPhyExpectedThroughputMCS7";
            this.textBoxPhyExpectedThroughputMCS7.ReadOnly = true;
            this.textBoxPhyExpectedThroughputMCS7.Size = new System.Drawing.Size(93, 20);
            this.textBoxPhyExpectedThroughputMCS7.TabIndex = 24;
            this.textBoxPhyExpectedThroughputMCS7.TabStop = false;
            this.textBoxPhyExpectedThroughputMCS7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelExpectedTputMCS2
            // 
            this.labelExpectedTputMCS2.AutoSize = true;
            this.labelExpectedTputMCS2.Location = new System.Drawing.Point(25, 53);
            this.labelExpectedTputMCS2.Name = "labelExpectedTputMCS2";
            this.labelExpectedTputMCS2.Size = new System.Drawing.Size(42, 13);
            this.labelExpectedTputMCS2.TabIndex = 27;
            this.labelExpectedTputMCS2.Text = "MCS2 :";
            // 
            // textBoxPhyExpectedThroughputMCS8
            // 
            this.textBoxPhyExpectedThroughputMCS8.Location = new System.Drawing.Point(126, 206);
            this.textBoxPhyExpectedThroughputMCS8.Name = "textBoxPhyExpectedThroughputMCS8";
            this.textBoxPhyExpectedThroughputMCS8.ReadOnly = true;
            this.textBoxPhyExpectedThroughputMCS8.Size = new System.Drawing.Size(93, 20);
            this.textBoxPhyExpectedThroughputMCS8.TabIndex = 25;
            this.textBoxPhyExpectedThroughputMCS8.TabStop = false;
            this.textBoxPhyExpectedThroughputMCS8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelExpectedTputMCS1
            // 
            this.labelExpectedTputMCS1.AutoSize = true;
            this.labelExpectedTputMCS1.Location = new System.Drawing.Point(25, 27);
            this.labelExpectedTputMCS1.Name = "labelExpectedTputMCS1";
            this.labelExpectedTputMCS1.Size = new System.Drawing.Size(42, 13);
            this.labelExpectedTputMCS1.TabIndex = 26;
            this.labelExpectedTputMCS1.Text = "MCS1 :";
            // 
            // textBoxPhyRange
            // 
            this.textBoxPhyRange.Location = new System.Drawing.Point(161, 143);
            this.textBoxPhyRange.Name = "textBoxPhyRange";
            this.textBoxPhyRange.ReadOnly = true;
            this.textBoxPhyRange.Size = new System.Drawing.Size(93, 20);
            this.textBoxPhyRange.TabIndex = 16;
            this.textBoxPhyRange.TabStop = false;
            this.textBoxPhyRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPhyDuplexMode
            // 
            this.textBoxPhyDuplexMode.Location = new System.Drawing.Point(161, 117);
            this.textBoxPhyDuplexMode.Name = "textBoxPhyDuplexMode";
            this.textBoxPhyDuplexMode.ReadOnly = true;
            this.textBoxPhyDuplexMode.Size = new System.Drawing.Size(93, 20);
            this.textBoxPhyDuplexMode.TabIndex = 15;
            this.textBoxPhyDuplexMode.TabStop = false;
            this.textBoxPhyDuplexMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPhyBandwidth
            // 
            this.textBoxPhyBandwidth.Location = new System.Drawing.Point(161, 91);
            this.textBoxPhyBandwidth.Name = "textBoxPhyBandwidth";
            this.textBoxPhyBandwidth.ReadOnly = true;
            this.textBoxPhyBandwidth.Size = new System.Drawing.Size(93, 20);
            this.textBoxPhyBandwidth.TabIndex = 14;
            this.textBoxPhyBandwidth.TabStop = false;
            this.textBoxPhyBandwidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Range (Km):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Duplex Mode:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Bandwidth (MHz):";
            // 
            // comboBoxPhyProfile
            // 
            this.comboBoxPhyProfile.Enabled = false;
            this.comboBoxPhyProfile.FormattingEnabled = true;
            this.comboBoxPhyProfile.Location = new System.Drawing.Point(35, 64);
            this.comboBoxPhyProfile.Name = "comboBoxPhyProfile";
            this.comboBoxPhyProfile.Size = new System.Drawing.Size(175, 21);
            this.comboBoxPhyProfile.TabIndex = 10;
            this.comboBoxPhyProfile.Text = "comboBoxPhyProfile";
            this.toolTipNodeProperties.SetToolTip(this.comboBoxPhyProfile, "This control is currently disabled -\r\nthe profile selection is not sent to the EV" +
                    "B.");
            this.comboBoxPhyProfile.SelectedIndexChanged += new System.EventHandler(this.comboBoxPhyProfile_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(133, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "PHY Profile";
            // 
            // tabPage0_1
            // 
            this.tabPage0_1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage0_1.Controls.Add(this.labelMCSSetSelect);
            this.tabPage0_1.Controls.Add(this.comboBoxMCSSetSelect);
            this.tabPage0_1.Controls.Add(this.checkBoxMCSSet2);
            this.tabPage0_1.Controls.Add(this.groupBoxManualAMC);
            this.tabPage0_1.Controls.Add(this.checkBoxAMC);
            this.tabPage0_1.Controls.Add(this.label5);
            this.tabPage0_1.Location = new System.Drawing.Point(4, 77);
            this.tabPage0_1.Name = "tabPage0_1";
            this.tabPage0_1.Size = new System.Drawing.Size(346, 443);
            this.tabPage0_1.TabIndex = 4;
            this.tabPage0_1.Text = "tabPage0_1";
            // 
            // labelMCSSetSelect
            // 
            this.labelMCSSetSelect.AutoSize = true;
            this.labelMCSSetSelect.Location = new System.Drawing.Point(42, 258);
            this.labelMCSSetSelect.Name = "labelMCSSetSelect";
            this.labelMCSSetSelect.Size = new System.Drawing.Size(88, 13);
            this.labelMCSSetSelect.TabIndex = 32;
            this.labelMCSSetSelect.Text = "MCS Set Select: ";
            // 
            // comboBoxMCSSetSelect
            // 
            this.comboBoxMCSSetSelect.FormattingEnabled = true;
            this.comboBoxMCSSetSelect.Items.AddRange(new object[] {
            "MCS Set 1",
            "MCS Set 2",
            "MCS Set 3"});
            this.comboBoxMCSSetSelect.Location = new System.Drawing.Point(168, 255);
            this.comboBoxMCSSetSelect.Name = "comboBoxMCSSetSelect";
            this.comboBoxMCSSetSelect.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMCSSetSelect.TabIndex = 31;
            this.comboBoxMCSSetSelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxMCSSetSelect_SelectedIndexChanged);
            // 
            // checkBoxMCSSet2
            // 
            this.checkBoxMCSSet2.AutoSize = true;
            this.checkBoxMCSSet2.Checked = true;
            this.checkBoxMCSSet2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMCSSet2.Location = new System.Drawing.Point(24, 307);
            this.checkBoxMCSSet2.Name = "checkBoxMCSSet2";
            this.checkBoxMCSSet2.Size = new System.Drawing.Size(151, 17);
            this.checkBoxMCSSet2.TabIndex = 30;
            this.checkBoxMCSSet2.Text = "Use MCS set2 (New MCS)";
            this.checkBoxMCSSet2.UseVisualStyleBackColor = true;
            this.checkBoxMCSSet2.Visible = false;
            this.checkBoxMCSSet2.CheckedChanged += new System.EventHandler(this.checkBoxMCSSet2_CheckedChanged);
            // 
            // groupBoxManualAMC
            // 
            this.groupBoxManualAMC.Controls.Add(this.textBoxManualAmcMaxThru);
            this.groupBoxManualAMC.Controls.Add(this.label16);
            this.groupBoxManualAMC.Controls.Add(this.label21);
            this.groupBoxManualAMC.Controls.Add(this.comboBoxManualMCS1);
            this.groupBoxManualAMC.Controls.Add(this.label20);
            this.groupBoxManualAMC.Controls.Add(this.comboBoxManualMCS0);
            this.groupBoxManualAMC.Location = new System.Drawing.Point(24, 92);
            this.groupBoxManualAMC.Name = "groupBoxManualAMC";
            this.groupBoxManualAMC.Size = new System.Drawing.Size(303, 147);
            this.groupBoxManualAMC.TabIndex = 21;
            this.groupBoxManualAMC.TabStop = false;
            this.groupBoxManualAMC.Text = "Manual AMC";
            // 
            // textBoxManualAmcMaxThru
            // 
            this.textBoxManualAmcMaxThru.Location = new System.Drawing.Point(160, 117);
            this.textBoxManualAmcMaxThru.Name = "textBoxManualAmcMaxThru";
            this.textBoxManualAmcMaxThru.ReadOnly = true;
            this.textBoxManualAmcMaxThru.Size = new System.Drawing.Size(93, 20);
            this.textBoxManualAmcMaxThru.TabIndex = 22;
            this.textBoxManualAmcMaxThru.TabStop = false;
            this.textBoxManualAmcMaxThru.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(31, 120);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Max Throughput:";
            this.label16.Visible = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(18, 85);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(85, 13);
            this.label21.TabIndex = 8;
            this.label21.Text = "Antenna 1 MCS:";
            // 
            // comboBoxManualMCS1
            // 
            this.comboBoxManualMCS1.Enabled = false;
            this.comboBoxManualMCS1.FormattingEnabled = true;
            this.comboBoxManualMCS1.Location = new System.Drawing.Point(145, 79);
            this.comboBoxManualMCS1.Name = "comboBoxManualMCS1";
            this.comboBoxManualMCS1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxManualMCS1.TabIndex = 7;
            this.toolTipNodeProperties.SetToolTip(this.comboBoxManualMCS1, "Antenna 1 setting is currently ignored. ");
            this.comboBoxManualMCS1.SelectedIndexChanged += new System.EventHandler(this.comboBoxManualMCS1_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(17, 46);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Antenna 0 MCS:";
            // 
            // comboBoxManualMCS0
            // 
            this.comboBoxManualMCS0.FormattingEnabled = true;
            this.comboBoxManualMCS0.Location = new System.Drawing.Point(144, 40);
            this.comboBoxManualMCS0.Name = "comboBoxManualMCS0";
            this.comboBoxManualMCS0.Size = new System.Drawing.Size(121, 21);
            this.comboBoxManualMCS0.TabIndex = 5;
            this.comboBoxManualMCS0.SelectedIndexChanged += new System.EventHandler(this.comboBoxManualMCS0_SelectedIndexChanged);
            // 
            // checkBoxAMC
            // 
            this.checkBoxAMC.AutoSize = true;
            this.checkBoxAMC.Checked = true;
            this.checkBoxAMC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAMC.Location = new System.Drawing.Point(42, 57);
            this.checkBoxAMC.Name = "checkBoxAMC";
            this.checkBoxAMC.Size = new System.Drawing.Size(196, 17);
            this.checkBoxAMC.TabIndex = 3;
            this.checkBoxAMC.Text = "Automatic Modulation Control (AMC)";
            this.checkBoxAMC.UseVisualStyleBackColor = true;
            this.checkBoxAMC.CheckedChanged += new System.EventHandler(this.checkBoxAMC_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(109, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Modulation";
            // 
            // tabPage0_2
            // 
            this.tabPage0_2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage0_2.Controls.Add(this.groupBoxCinrSimulation);
            this.tabPage0_2.Controls.Add(this.checkBoxCinrSimulation);
            this.tabPage0_2.Controls.Add(this.label29);
            this.tabPage0_2.Location = new System.Drawing.Point(4, 77);
            this.tabPage0_2.Name = "tabPage0_2";
            this.tabPage0_2.Size = new System.Drawing.Size(346, 443);
            this.tabPage0_2.TabIndex = 7;
            this.tabPage0_2.Text = "tabPage0_2";
            // 
            // groupBoxCinrSimulation
            // 
            this.groupBoxCinrSimulation.Controls.Add(this.textBoxSimCinr1);
            this.groupBoxCinrSimulation.Controls.Add(this.textBoxSimCinr0);
            this.groupBoxCinrSimulation.Controls.Add(this.buttonWriteCinrValues);
            this.groupBoxCinrSimulation.Controls.Add(this.label32);
            this.groupBoxCinrSimulation.Controls.Add(this.label23);
            this.groupBoxCinrSimulation.Controls.Add(this.label24);
            this.groupBoxCinrSimulation.Location = new System.Drawing.Point(22, 110);
            this.groupBoxCinrSimulation.Name = "groupBoxCinrSimulation";
            this.groupBoxCinrSimulation.Size = new System.Drawing.Size(303, 189);
            this.groupBoxCinrSimulation.TabIndex = 24;
            this.groupBoxCinrSimulation.TabStop = false;
            this.groupBoxCinrSimulation.Text = "Simulation Values";
            // 
            // textBoxSimCinr1
            // 
            this.textBoxSimCinr1.Location = new System.Drawing.Point(125, 121);
            this.textBoxSimCinr1.Name = "textBoxSimCinr1";
            this.textBoxSimCinr1.Size = new System.Drawing.Size(100, 20);
            this.textBoxSimCinr1.TabIndex = 26;
            this.textBoxSimCinr1.TextChanged += new System.EventHandler(this.textBoxSimCinr1_TextChanged);
            // 
            // textBoxSimCinr0
            // 
            this.textBoxSimCinr0.Location = new System.Drawing.Point(125, 89);
            this.textBoxSimCinr0.Name = "textBoxSimCinr0";
            this.textBoxSimCinr0.Size = new System.Drawing.Size(100, 20);
            this.textBoxSimCinr0.TabIndex = 25;
            this.textBoxSimCinr0.TextChanged += new System.EventHandler(this.textBoxSimCinr0_TextChanged);
            // 
            // buttonWriteCinrValues
            // 
            this.buttonWriteCinrValues.Enabled = false;
            this.buttonWriteCinrValues.Location = new System.Drawing.Point(102, 160);
            this.buttonWriteCinrValues.Name = "buttonWriteCinrValues";
            this.buttonWriteCinrValues.Size = new System.Drawing.Size(75, 23);
            this.buttonWriteCinrValues.TabIndex = 24;
            this.buttonWriteCinrValues.Text = "Apply";
            this.buttonWriteCinrValues.UseVisualStyleBackColor = true;
            this.buttonWriteCinrValues.Click += new System.EventHandler(this.buttonWriteCinrValues_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(17, 30);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(208, 13);
            this.label32.TabIndex = 23;
            this.label32.Text = "Enter values in db (expected range 0 .. 70)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(18, 124);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 13);
            this.label23.TabIndex = 8;
            this.label23.Text = "Antenna 1 CINR:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(17, 85);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(88, 13);
            this.label24.TabIndex = 6;
            this.label24.Text = "Antenna 0 CINR:";
            // 
            // checkBoxCinrSimulation
            // 
            this.checkBoxCinrSimulation.AutoSize = true;
            this.checkBoxCinrSimulation.Location = new System.Drawing.Point(40, 75);
            this.checkBoxCinrSimulation.Name = "checkBoxCinrSimulation";
            this.checkBoxCinrSimulation.Size = new System.Drawing.Size(65, 17);
            this.checkBoxCinrSimulation.TabIndex = 23;
            this.checkBoxCinrSimulation.Text = "Enabled";
            this.checkBoxCinrSimulation.UseVisualStyleBackColor = true;
            this.checkBoxCinrSimulation.CheckedChanged += new System.EventHandler(this.checkBoxCinrSimulation_CheckedChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(109, 22);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(105, 16);
            this.label29.TabIndex = 22;
            this.label29.Text = "CINR Simulation";
            // 
            // tabPage0_3
            // 
            this.tabPage0_3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage0_3.Controls.Add(this.tableLayoutPanel2);
            this.tabPage0_3.Controls.Add(this.buttonMCSApplyChanges);
            this.tabPage0_3.Controls.Add(this.buttonMCSRestoreToDefault);
            this.tabPage0_3.Controls.Add(this.label39);
            this.tabPage0_3.Location = new System.Drawing.Point(4, 77);
            this.tabPage0_3.Name = "tabPage0_3";
            this.tabPage0_3.Size = new System.Drawing.Size(346, 443);
            this.tabPage0_3.TabIndex = 10;
            this.tabPage0_3.Text = "tabPage0_3";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.MCS9, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.MCS8, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.MCS7, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.MCS6, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.MCS5, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.MCS4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.MCS3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.MCS2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.MCS1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS8UpThreshold, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS8DownThreshold, 2, 8);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS7UpThreshold, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.labelMCSDescription, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS6UpThreshold, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS5UpThreshold, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS7DownThreshold, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS4UpThreshold, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.labelMCSDown, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS3UpThreshold, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS1DownThreshold, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS2UpThreshold, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS6DownThreshold, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS2DownThreshold, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS3DownThreshold, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS4DownThreshold, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS5DownThreshold, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS1UpThreshold, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelMCSUp, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.MCS10, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.MCS11, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS9UpThreshold, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS9DownThreshold, 2, 9);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS10UpThreshold, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS10DownThreshold, 2, 10);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS11DownThreshold, 2, 11);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMCS11UpThreshold, 1, 11);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 44);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 12;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(327, 371);
            this.tableLayoutPanel2.TabIndex = 28;
            // 
            // MCS9
            // 
            this.MCS9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MCS9.AutoSize = true;
            this.MCS9.Location = new System.Drawing.Point(36, 284);
            this.MCS9.Name = "MCS9";
            this.MCS9.Size = new System.Drawing.Size(36, 13);
            this.MCS9.TabIndex = 27;
            this.MCS9.Text = "MCS9";
            // 
            // MCS8
            // 
            this.MCS8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MCS8.AutoSize = true;
            this.MCS8.Location = new System.Drawing.Point(36, 255);
            this.MCS8.Name = "MCS8";
            this.MCS8.Size = new System.Drawing.Size(36, 13);
            this.MCS8.TabIndex = 10;
            this.MCS8.Text = "MCS8";
            // 
            // MCS7
            // 
            this.MCS7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MCS7.AutoSize = true;
            this.MCS7.Location = new System.Drawing.Point(36, 226);
            this.MCS7.Name = "MCS7";
            this.MCS7.Size = new System.Drawing.Size(36, 13);
            this.MCS7.TabIndex = 9;
            this.MCS7.Text = "MCS7";
            // 
            // MCS6
            // 
            this.MCS6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MCS6.AutoSize = true;
            this.MCS6.Location = new System.Drawing.Point(36, 197);
            this.MCS6.Name = "MCS6";
            this.MCS6.Size = new System.Drawing.Size(36, 13);
            this.MCS6.TabIndex = 8;
            this.MCS6.Text = "MCS6";
            // 
            // MCS5
            // 
            this.MCS5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MCS5.AutoSize = true;
            this.MCS5.Location = new System.Drawing.Point(36, 168);
            this.MCS5.Name = "MCS5";
            this.MCS5.Size = new System.Drawing.Size(36, 13);
            this.MCS5.TabIndex = 7;
            this.MCS5.Text = "MCS5";
            // 
            // MCS4
            // 
            this.MCS4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MCS4.AutoSize = true;
            this.MCS4.Location = new System.Drawing.Point(36, 139);
            this.MCS4.Name = "MCS4";
            this.MCS4.Size = new System.Drawing.Size(36, 13);
            this.MCS4.TabIndex = 6;
            this.MCS4.Text = "MCS4";
            // 
            // MCS3
            // 
            this.MCS3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MCS3.AutoSize = true;
            this.MCS3.Location = new System.Drawing.Point(36, 110);
            this.MCS3.Name = "MCS3";
            this.MCS3.Size = new System.Drawing.Size(36, 13);
            this.MCS3.TabIndex = 5;
            this.MCS3.Text = "MCS3";
            // 
            // MCS2
            // 
            this.MCS2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MCS2.AutoSize = true;
            this.MCS2.Location = new System.Drawing.Point(36, 81);
            this.MCS2.Name = "MCS2";
            this.MCS2.Size = new System.Drawing.Size(36, 13);
            this.MCS2.TabIndex = 4;
            this.MCS2.Text = "MCS2";
            // 
            // MCS1
            // 
            this.MCS1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MCS1.AutoSize = true;
            this.MCS1.Location = new System.Drawing.Point(36, 52);
            this.MCS1.Name = "MCS1";
            this.MCS1.Size = new System.Drawing.Size(36, 13);
            this.MCS1.TabIndex = 3;
            this.MCS1.Text = "MCS1";
            // 
            // textBoxMCS8UpThreshold
            // 
            this.textBoxMCS8UpThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS8UpThreshold.Enabled = false;
            this.textBoxMCS8UpThreshold.Location = new System.Drawing.Point(116, 251);
            this.textBoxMCS8UpThreshold.Name = "textBoxMCS8UpThreshold";
            this.textBoxMCS8UpThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS8UpThreshold.TabIndex = 25;
            this.textBoxMCS8UpThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS8UpThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // textBoxMCS8DownThreshold
            // 
            this.textBoxMCS8DownThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS8DownThreshold.Enabled = false;
            this.textBoxMCS8DownThreshold.Location = new System.Drawing.Point(225, 251);
            this.textBoxMCS8DownThreshold.Name = "textBoxMCS8DownThreshold";
            this.textBoxMCS8DownThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS8DownThreshold.TabIndex = 26;
            this.textBoxMCS8DownThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS8DownThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // textBoxMCS7UpThreshold
            // 
            this.textBoxMCS7UpThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS7UpThreshold.Enabled = false;
            this.textBoxMCS7UpThreshold.Location = new System.Drawing.Point(116, 222);
            this.textBoxMCS7UpThreshold.Name = "textBoxMCS7UpThreshold";
            this.textBoxMCS7UpThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS7UpThreshold.TabIndex = 23;
            this.textBoxMCS7UpThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS7UpThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // labelMCSDescription
            // 
            this.labelMCSDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMCSDescription.AutoSize = true;
            this.labelMCSDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMCSDescription.Location = new System.Drawing.Point(38, 15);
            this.labelMCSDescription.Name = "labelMCSDescription";
            this.labelMCSDescription.Size = new System.Drawing.Size(33, 13);
            this.labelMCSDescription.TabIndex = 0;
            this.labelMCSDescription.Text = "MCS";
            this.labelMCSDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMCS6UpThreshold
            // 
            this.textBoxMCS6UpThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS6UpThreshold.Enabled = false;
            this.textBoxMCS6UpThreshold.Location = new System.Drawing.Point(116, 193);
            this.textBoxMCS6UpThreshold.Name = "textBoxMCS6UpThreshold";
            this.textBoxMCS6UpThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS6UpThreshold.TabIndex = 21;
            this.textBoxMCS6UpThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS6UpThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // textBoxMCS5UpThreshold
            // 
            this.textBoxMCS5UpThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS5UpThreshold.Enabled = false;
            this.textBoxMCS5UpThreshold.Location = new System.Drawing.Point(116, 164);
            this.textBoxMCS5UpThreshold.Name = "textBoxMCS5UpThreshold";
            this.textBoxMCS5UpThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS5UpThreshold.TabIndex = 19;
            this.textBoxMCS5UpThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS5UpThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // textBoxMCS7DownThreshold
            // 
            this.textBoxMCS7DownThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS7DownThreshold.Enabled = false;
            this.textBoxMCS7DownThreshold.Location = new System.Drawing.Point(225, 222);
            this.textBoxMCS7DownThreshold.Name = "textBoxMCS7DownThreshold";
            this.textBoxMCS7DownThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS7DownThreshold.TabIndex = 24;
            this.textBoxMCS7DownThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS7DownThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // textBoxMCS4UpThreshold
            // 
            this.textBoxMCS4UpThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS4UpThreshold.Enabled = false;
            this.textBoxMCS4UpThreshold.Location = new System.Drawing.Point(116, 135);
            this.textBoxMCS4UpThreshold.Name = "textBoxMCS4UpThreshold";
            this.textBoxMCS4UpThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS4UpThreshold.TabIndex = 17;
            this.textBoxMCS4UpThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS4UpThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // labelMCSDown
            // 
            this.labelMCSDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMCSDown.AutoSize = true;
            this.labelMCSDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMCSDown.Location = new System.Drawing.Point(238, 9);
            this.labelMCSDown.Name = "labelMCSDown";
            this.labelMCSDown.Size = new System.Drawing.Size(69, 26);
            this.labelMCSDown.TabIndex = 2;
            this.labelMCSDown.Text = "MCS Down Threshold";
            this.labelMCSDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMCS3UpThreshold
            // 
            this.textBoxMCS3UpThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS3UpThreshold.Enabled = false;
            this.textBoxMCS3UpThreshold.Location = new System.Drawing.Point(116, 106);
            this.textBoxMCS3UpThreshold.Name = "textBoxMCS3UpThreshold";
            this.textBoxMCS3UpThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS3UpThreshold.TabIndex = 15;
            this.textBoxMCS3UpThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS3UpThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // textBoxMCS1DownThreshold
            // 
            this.textBoxMCS1DownThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS1DownThreshold.Enabled = false;
            this.textBoxMCS1DownThreshold.Location = new System.Drawing.Point(225, 48);
            this.textBoxMCS1DownThreshold.Name = "textBoxMCS1DownThreshold";
            this.textBoxMCS1DownThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS1DownThreshold.TabIndex = 12;
            this.textBoxMCS1DownThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS1DownThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // textBoxMCS2UpThreshold
            // 
            this.textBoxMCS2UpThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS2UpThreshold.Enabled = false;
            this.textBoxMCS2UpThreshold.Location = new System.Drawing.Point(116, 77);
            this.textBoxMCS2UpThreshold.Name = "textBoxMCS2UpThreshold";
            this.textBoxMCS2UpThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS2UpThreshold.TabIndex = 13;
            this.textBoxMCS2UpThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS2UpThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // textBoxMCS6DownThreshold
            // 
            this.textBoxMCS6DownThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS6DownThreshold.Enabled = false;
            this.textBoxMCS6DownThreshold.Location = new System.Drawing.Point(225, 193);
            this.textBoxMCS6DownThreshold.Name = "textBoxMCS6DownThreshold";
            this.textBoxMCS6DownThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS6DownThreshold.TabIndex = 22;
            this.textBoxMCS6DownThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS6DownThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // textBoxMCS2DownThreshold
            // 
            this.textBoxMCS2DownThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS2DownThreshold.Enabled = false;
            this.textBoxMCS2DownThreshold.Location = new System.Drawing.Point(225, 77);
            this.textBoxMCS2DownThreshold.Name = "textBoxMCS2DownThreshold";
            this.textBoxMCS2DownThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS2DownThreshold.TabIndex = 14;
            this.textBoxMCS2DownThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS2DownThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // textBoxMCS3DownThreshold
            // 
            this.textBoxMCS3DownThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS3DownThreshold.Enabled = false;
            this.textBoxMCS3DownThreshold.Location = new System.Drawing.Point(225, 106);
            this.textBoxMCS3DownThreshold.Name = "textBoxMCS3DownThreshold";
            this.textBoxMCS3DownThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS3DownThreshold.TabIndex = 16;
            this.textBoxMCS3DownThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS3DownThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // textBoxMCS4DownThreshold
            // 
            this.textBoxMCS4DownThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS4DownThreshold.Enabled = false;
            this.textBoxMCS4DownThreshold.Location = new System.Drawing.Point(225, 135);
            this.textBoxMCS4DownThreshold.Name = "textBoxMCS4DownThreshold";
            this.textBoxMCS4DownThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS4DownThreshold.TabIndex = 18;
            this.textBoxMCS4DownThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS4DownThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // textBoxMCS5DownThreshold
            // 
            this.textBoxMCS5DownThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS5DownThreshold.Enabled = false;
            this.textBoxMCS5DownThreshold.Location = new System.Drawing.Point(225, 164);
            this.textBoxMCS5DownThreshold.Name = "textBoxMCS5DownThreshold";
            this.textBoxMCS5DownThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS5DownThreshold.TabIndex = 20;
            this.textBoxMCS5DownThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS5DownThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // textBoxMCS1UpThreshold
            // 
            this.textBoxMCS1UpThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS1UpThreshold.Enabled = false;
            this.textBoxMCS1UpThreshold.Location = new System.Drawing.Point(116, 48);
            this.textBoxMCS1UpThreshold.Name = "textBoxMCS1UpThreshold";
            this.textBoxMCS1UpThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS1UpThreshold.TabIndex = 11;
            this.textBoxMCS1UpThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS1UpThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtType_KeyPress_number);
            // 
            // labelMCSUp
            // 
            this.labelMCSUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMCSUp.AutoSize = true;
            this.labelMCSUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMCSUp.Location = new System.Drawing.Point(132, 9);
            this.labelMCSUp.Name = "labelMCSUp";
            this.labelMCSUp.Size = new System.Drawing.Size(63, 26);
            this.labelMCSUp.TabIndex = 1;
            this.labelMCSUp.Text = "MCS Up Threshold";
            this.labelMCSUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MCS10
            // 
            this.MCS10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MCS10.AutoSize = true;
            this.MCS10.Location = new System.Drawing.Point(33, 313);
            this.MCS10.Name = "MCS10";
            this.MCS10.Size = new System.Drawing.Size(42, 13);
            this.MCS10.TabIndex = 28;
            this.MCS10.Text = "MCS10";
            // 
            // MCS11
            // 
            this.MCS11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MCS11.AutoSize = true;
            this.MCS11.Location = new System.Drawing.Point(33, 346);
            this.MCS11.Name = "MCS11";
            this.MCS11.Size = new System.Drawing.Size(42, 13);
            this.MCS11.TabIndex = 29;
            this.MCS11.Text = "MCS11";
            this.MCS11.Visible = false;
            // 
            // textBoxMCS9UpThreshold
            // 
            this.textBoxMCS9UpThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS9UpThreshold.Enabled = false;
            this.textBoxMCS9UpThreshold.Location = new System.Drawing.Point(116, 280);
            this.textBoxMCS9UpThreshold.Name = "textBoxMCS9UpThreshold";
            this.textBoxMCS9UpThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS9UpThreshold.TabIndex = 31;
            this.textBoxMCS9UpThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMCS9DownThreshold
            // 
            this.textBoxMCS9DownThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS9DownThreshold.Enabled = false;
            this.textBoxMCS9DownThreshold.Location = new System.Drawing.Point(225, 280);
            this.textBoxMCS9DownThreshold.Name = "textBoxMCS9DownThreshold";
            this.textBoxMCS9DownThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS9DownThreshold.TabIndex = 30;
            this.textBoxMCS9DownThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMCS10UpThreshold
            // 
            this.textBoxMCS10UpThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS10UpThreshold.Enabled = false;
            this.textBoxMCS10UpThreshold.Location = new System.Drawing.Point(116, 309);
            this.textBoxMCS10UpThreshold.Name = "textBoxMCS10UpThreshold";
            this.textBoxMCS10UpThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS10UpThreshold.TabIndex = 32;
            this.textBoxMCS10UpThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMCS10DownThreshold
            // 
            this.textBoxMCS10DownThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS10DownThreshold.Enabled = false;
            this.textBoxMCS10DownThreshold.Location = new System.Drawing.Point(225, 309);
            this.textBoxMCS10DownThreshold.Name = "textBoxMCS10DownThreshold";
            this.textBoxMCS10DownThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS10DownThreshold.TabIndex = 33;
            this.textBoxMCS10DownThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMCS11DownThreshold
            // 
            this.textBoxMCS11DownThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS11DownThreshold.Enabled = false;
            this.textBoxMCS11DownThreshold.Location = new System.Drawing.Point(225, 342);
            this.textBoxMCS11DownThreshold.Name = "textBoxMCS11DownThreshold";
            this.textBoxMCS11DownThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS11DownThreshold.TabIndex = 34;
            this.textBoxMCS11DownThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS11DownThreshold.Visible = false;
            // 
            // textBoxMCS11UpThreshold
            // 
            this.textBoxMCS11UpThreshold.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMCS11UpThreshold.Enabled = false;
            this.textBoxMCS11UpThreshold.Location = new System.Drawing.Point(116, 342);
            this.textBoxMCS11UpThreshold.Name = "textBoxMCS11UpThreshold";
            this.textBoxMCS11UpThreshold.Size = new System.Drawing.Size(95, 20);
            this.textBoxMCS11UpThreshold.TabIndex = 35;
            this.textBoxMCS11UpThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMCS11UpThreshold.Visible = false;
            // 
            // buttonMCSApplyChanges
            // 
            this.buttonMCSApplyChanges.Enabled = false;
            this.buttonMCSApplyChanges.Location = new System.Drawing.Point(167, 447);
            this.buttonMCSApplyChanges.Name = "buttonMCSApplyChanges";
            this.buttonMCSApplyChanges.Size = new System.Drawing.Size(150, 23);
            this.buttonMCSApplyChanges.TabIndex = 26;
            this.buttonMCSApplyChanges.Text = "Apply";
            this.buttonMCSApplyChanges.UseVisualStyleBackColor = true;
            // 
            // buttonMCSRestoreToDefault
            // 
            this.buttonMCSRestoreToDefault.Enabled = false;
            this.buttonMCSRestoreToDefault.Location = new System.Drawing.Point(13, 447);
            this.buttonMCSRestoreToDefault.Name = "buttonMCSRestoreToDefault";
            this.buttonMCSRestoreToDefault.Size = new System.Drawing.Size(150, 23);
            this.buttonMCSRestoreToDefault.TabIndex = 25;
            this.buttonMCSRestoreToDefault.Text = "Restore To Default";
            this.buttonMCSRestoreToDefault.UseVisualStyleBackColor = true;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(139, 24);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(37, 16);
            this.label39.TabIndex = 23;
            this.label39.Text = "MCS";
            // 
            // tabPage0_4
            // 
            this.tabPage0_4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage0_4.Controls.Add(this.label40);
            this.tabPage0_4.Location = new System.Drawing.Point(4, 77);
            this.tabPage0_4.Name = "tabPage0_4";
            this.tabPage0_4.Size = new System.Drawing.Size(346, 443);
            this.tabPage0_4.TabIndex = 9;
            this.tabPage0_4.Text = "tabPage0_4";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(109, 22);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(38, 16);
            this.label40.TabIndex = 23;
            this.label40.Text = "Sync";
            // 
            // tabPage0_5
            // 
            this.tabPage0_5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage0_5.Controls.Add(this.checkBox_Uncoded_BER_COUNTER_ENABLE);
            this.tabPage0_5.Controls.Add(this.checkBox_BER_COUNTER_ENABLE);
            this.tabPage0_5.Controls.Add(this.groupBoxPHYTBCounters);
            this.tabPage0_5.Controls.Add(this.labelPHYCounters);
            this.tabPage0_5.Location = new System.Drawing.Point(4, 77);
            this.tabPage0_5.Name = "tabPage0_5";
            this.tabPage0_5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage0_5.Size = new System.Drawing.Size(346, 443);
            this.tabPage0_5.TabIndex = 11;
            this.tabPage0_5.Text = "tabPage0_5";
            // 
            // checkBox_Uncoded_BER_COUNTER_ENABLE
            // 
            this.checkBox_Uncoded_BER_COUNTER_ENABLE.AutoSize = true;
            this.checkBox_Uncoded_BER_COUNTER_ENABLE.Location = new System.Drawing.Point(137, 508);
            this.checkBox_Uncoded_BER_COUNTER_ENABLE.Name = "checkBox_Uncoded_BER_COUNTER_ENABLE";
            this.checkBox_Uncoded_BER_COUNTER_ENABLE.Size = new System.Drawing.Size(171, 17);
            this.checkBox_Uncoded_BER_COUNTER_ENABLE.TabIndex = 7;
            this.checkBox_Uncoded_BER_COUNTER_ENABLE.Text = "Uncoded BER Counter Enable";
            this.checkBox_Uncoded_BER_COUNTER_ENABLE.UseVisualStyleBackColor = true;
            this.checkBox_Uncoded_BER_COUNTER_ENABLE.CheckedChanged += new System.EventHandler(this.checkBox_Uncoded_BER_COUNTER_ENABLE_CheckedChanged);
            // 
            // checkBox_BER_COUNTER_ENABLE
            // 
            this.checkBox_BER_COUNTER_ENABLE.AutoSize = true;
            this.checkBox_BER_COUNTER_ENABLE.Location = new System.Drawing.Point(6, 508);
            this.checkBox_BER_COUNTER_ENABLE.Name = "checkBox_BER_COUNTER_ENABLE";
            this.checkBox_BER_COUNTER_ENABLE.Size = new System.Drawing.Size(124, 17);
            this.checkBox_BER_COUNTER_ENABLE.TabIndex = 6;
            this.checkBox_BER_COUNTER_ENABLE.Text = "BER Counter Enable";
            this.checkBox_BER_COUNTER_ENABLE.UseVisualStyleBackColor = true;
            this.checkBox_BER_COUNTER_ENABLE.CheckedChanged += new System.EventHandler(this.checkBox_BER_COUNTER_ENABLE_CheckedChanged);
            // 
            // groupBoxPHYTBCounters
            // 
            this.groupBoxPHYTBCounters.Controls.Add(this.dataGridView1);
            this.groupBoxPHYTBCounters.Location = new System.Drawing.Point(6, 41);
            this.groupBoxPHYTBCounters.Name = "groupBoxPHYTBCounters";
            this.groupBoxPHYTBCounters.Size = new System.Drawing.Size(302, 461);
            this.groupBoxPHYTBCounters.TabIndex = 5;
            this.groupBoxPHYTBCounters.TabStop = false;
            this.groupBoxPHYTBCounters.Text = "TBs Counters";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnValue});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView1.Location = new System.Drawing.Point(6, 14);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(290, 444);
            this.dataGridView1.TabIndex = 10;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.Width = 60;
            // 
            // ColumnValue
            // 
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.Width = 59;
            // 
            // labelPHYCounters
            // 
            this.labelPHYCounters.AutoSize = true;
            this.labelPHYCounters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelPHYCounters.Location = new System.Drawing.Point(109, 22);
            this.labelPHYCounters.Name = "labelPHYCounters";
            this.labelPHYCounters.Size = new System.Drawing.Size(92, 16);
            this.labelPHYCounters.TabIndex = 0;
            this.labelPHYCounters.Text = "PHY Counters";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.GeneralQOS);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 77);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(346, 443);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            // 
            // GeneralQOS
            // 
            this.GeneralQOS.BackColor = System.Drawing.SystemColors.Control;
            this.GeneralQOS.Controls.Add(this.ShaperMB);
            this.GeneralQOS.Controls.Add(this.ShaperLimit);
            this.GeneralQOS.Controls.Add(this.QOSMethodSelect);
            this.GeneralQOS.Controls.Add(this.QOSMethod);
            this.GeneralQOS.Controls.Add(this.QOSTypeSelect);
            this.GeneralQOS.Controls.Add(this.QOSType);
            this.GeneralQOS.Location = new System.Drawing.Point(71, 77);
            this.GeneralQOS.Name = "GeneralQOS";
            this.GeneralQOS.Size = new System.Drawing.Size(192, 127);
            this.GeneralQOS.TabIndex = 1;
            this.GeneralQOS.TabStop = false;
            this.GeneralQOS.Text = "General";
            // 
            // ShaperMB
            // 
            this.ShaperMB.Enabled = false;
            this.ShaperMB.Location = new System.Drawing.Point(117, 83);
            this.ShaperMB.Name = "ShaperMB";
            this.ShaperMB.Size = new System.Drawing.Size(61, 20);
            this.ShaperMB.TabIndex = 20;
            // 
            // ShaperLimit
            // 
            this.ShaperLimit.AutoSize = true;
            this.ShaperLimit.Location = new System.Drawing.Point(5, 86);
            this.ShaperLimit.Name = "ShaperLimit";
            this.ShaperLimit.Size = new System.Drawing.Size(106, 13);
            this.ShaperLimit.TabIndex = 19;
            this.ShaperLimit.Text = "Shaper Limit (Mbps) :";
            // 
            // QOSMethodSelect
            // 
            this.QOSMethodSelect.Enabled = false;
            this.QOSMethodSelect.FormattingEnabled = true;
            this.QOSMethodSelect.Items.AddRange(new object[] {
            "Strict",
            "weighed RR",
            "Strict + WRR "});
            this.QOSMethodSelect.Location = new System.Drawing.Point(80, 52);
            this.QOSMethodSelect.Name = "QOSMethodSelect";
            this.QOSMethodSelect.Size = new System.Drawing.Size(98, 21);
            this.QOSMethodSelect.TabIndex = 18;
            this.QOSMethodSelect.Text = "weighed RR";
            // 
            // QOSMethod
            // 
            this.QOSMethod.AutoSize = true;
            this.QOSMethod.Location = new System.Drawing.Point(6, 55);
            this.QOSMethod.Name = "QOSMethod";
            this.QOSMethod.Size = new System.Drawing.Size(75, 13);
            this.QOSMethod.TabIndex = 17;
            this.QOSMethod.Text = "QOS Method :";
            // 
            // QOSTypeSelect
            // 
            this.QOSTypeSelect.Enabled = false;
            this.QOSTypeSelect.FormattingEnabled = true;
            this.QOSTypeSelect.Items.AddRange(new object[] {
            "None",
            "L2",
            "L3"});
            this.QOSTypeSelect.Location = new System.Drawing.Point(80, 22);
            this.QOSTypeSelect.Name = "QOSTypeSelect";
            this.QOSTypeSelect.Size = new System.Drawing.Size(98, 21);
            this.QOSTypeSelect.TabIndex = 16;
            this.QOSTypeSelect.Text = "None";
            // 
            // QOSType
            // 
            this.QOSType.AutoSize = true;
            this.QOSType.Location = new System.Drawing.Point(6, 25);
            this.QOSType.Name = "QOSType";
            this.QOSType.Size = new System.Drawing.Size(63, 13);
            this.QOSType.TabIndex = 15;
            this.QOSType.Text = "QOS Type :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(109, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Network Configuration";
            // 
            // tabPage1_0
            // 
            this.tabPage1_0.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1_0.Controls.Add(this.QOSL2);
            this.tabPage1_0.Controls.Add(this.label18);
            this.tabPage1_0.Controls.Add(this.QOSL3);
            this.tabPage1_0.Location = new System.Drawing.Point(4, 77);
            this.tabPage1_0.Name = "tabPage1_0";
            this.tabPage1_0.Size = new System.Drawing.Size(346, 443);
            this.tabPage1_0.TabIndex = 5;
            this.tabPage1_0.Text = "tabPage1_0";
            // 
            // QOSL2
            // 
            this.QOSL2.BackColor = System.Drawing.SystemColors.Control;
            this.QOSL2.Controls.Add(this.label30);
            this.QOSL2.Controls.Add(this.Priority3L);
            this.QOSL2.Controls.Add(this.Priority3H);
            this.QOSL2.Controls.Add(this.Priority3);
            this.QOSL2.Controls.Add(this.label28);
            this.QOSL2.Controls.Add(this.Priority4L);
            this.QOSL2.Controls.Add(this.Priority4H);
            this.QOSL2.Controls.Add(this.Priority4);
            this.QOSL2.Controls.Add(this.label26);
            this.QOSL2.Controls.Add(this.Priority2L);
            this.QOSL2.Controls.Add(this.Priority2H);
            this.QOSL2.Controls.Add(this.Priority2);
            this.QOSL2.Controls.Add(this.label25);
            this.QOSL2.Controls.Add(this.Priority1L);
            this.QOSL2.Controls.Add(this.Priority1H);
            this.QOSL2.Controls.Add(this.Priority1);
            this.QOSL2.Location = new System.Drawing.Point(92, 53);
            this.QOSL2.Name = "QOSL2";
            this.QOSL2.Size = new System.Drawing.Size(166, 130);
            this.QOSL2.TabIndex = 6;
            this.QOSL2.TabStop = false;
            this.QOSL2.Text = "QOS L2";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(102, 77);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(10, 13);
            this.label30.TabIndex = 31;
            this.label30.Text = ":";
            // 
            // Priority3L
            // 
            this.Priority3L.Enabled = false;
            this.Priority3L.Location = new System.Drawing.Point(118, 75);
            this.Priority3L.Name = "Priority3L";
            this.Priority3L.Size = new System.Drawing.Size(32, 20);
            this.Priority3L.TabIndex = 30;
            this.Priority3L.Text = "5";
            // 
            // Priority3H
            // 
            this.Priority3H.Location = new System.Drawing.Point(63, 75);
            this.Priority3H.Name = "Priority3H";
            this.Priority3H.ReadOnly = true;
            this.Priority3H.Size = new System.Drawing.Size(32, 20);
            this.Priority3H.TabIndex = 29;
            this.Priority3H.Text = "4";
            // 
            // Priority3
            // 
            this.Priority3.AutoSize = true;
            this.Priority3.Location = new System.Drawing.Point(7, 77);
            this.Priority3.Name = "Priority3";
            this.Priority3.Size = new System.Drawing.Size(50, 13);
            this.Priority3.TabIndex = 28;
            this.Priority3.Text = "Priority3 :";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(103, 106);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(10, 13);
            this.label28.TabIndex = 27;
            this.label28.Text = ":";
            // 
            // Priority4L
            // 
            this.Priority4L.Enabled = false;
            this.Priority4L.Location = new System.Drawing.Point(119, 104);
            this.Priority4L.Name = "Priority4L";
            this.Priority4L.Size = new System.Drawing.Size(32, 20);
            this.Priority4L.TabIndex = 26;
            this.Priority4L.Text = "7";
            // 
            // Priority4H
            // 
            this.Priority4H.Location = new System.Drawing.Point(64, 104);
            this.Priority4H.Name = "Priority4H";
            this.Priority4H.ReadOnly = true;
            this.Priority4H.Size = new System.Drawing.Size(32, 20);
            this.Priority4H.TabIndex = 25;
            this.Priority4H.Text = "6";
            // 
            // Priority4
            // 
            this.Priority4.AutoSize = true;
            this.Priority4.Location = new System.Drawing.Point(8, 106);
            this.Priority4.Name = "Priority4";
            this.Priority4.Size = new System.Drawing.Size(50, 13);
            this.Priority4.TabIndex = 24;
            this.Priority4.Text = "Priority4 :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(101, 46);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(10, 13);
            this.label26.TabIndex = 23;
            this.label26.Text = ":";
            // 
            // Priority2L
            // 
            this.Priority2L.Enabled = false;
            this.Priority2L.Location = new System.Drawing.Point(117, 44);
            this.Priority2L.Name = "Priority2L";
            this.Priority2L.Size = new System.Drawing.Size(32, 20);
            this.Priority2L.TabIndex = 22;
            this.Priority2L.Text = "3";
            // 
            // Priority2H
            // 
            this.Priority2H.Location = new System.Drawing.Point(62, 44);
            this.Priority2H.Name = "Priority2H";
            this.Priority2H.ReadOnly = true;
            this.Priority2H.Size = new System.Drawing.Size(32, 20);
            this.Priority2H.TabIndex = 21;
            this.Priority2H.Text = "2";
            // 
            // Priority2
            // 
            this.Priority2.AutoSize = true;
            this.Priority2.Location = new System.Drawing.Point(6, 46);
            this.Priority2.Name = "Priority2";
            this.Priority2.Size = new System.Drawing.Size(50, 13);
            this.Priority2.TabIndex = 20;
            this.Priority2.Text = "Priority2 :";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(101, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(10, 13);
            this.label25.TabIndex = 19;
            this.label25.Text = ":";
            // 
            // Priority1L
            // 
            this.Priority1L.Enabled = false;
            this.Priority1L.Location = new System.Drawing.Point(117, 15);
            this.Priority1L.Name = "Priority1L";
            this.Priority1L.Size = new System.Drawing.Size(32, 20);
            this.Priority1L.TabIndex = 18;
            this.Priority1L.Text = "1";
            // 
            // Priority1H
            // 
            this.Priority1H.Location = new System.Drawing.Point(62, 15);
            this.Priority1H.Name = "Priority1H";
            this.Priority1H.ReadOnly = true;
            this.Priority1H.Size = new System.Drawing.Size(32, 20);
            this.Priority1H.TabIndex = 17;
            this.Priority1H.Text = "0";
            // 
            // Priority1
            // 
            this.Priority1.AutoSize = true;
            this.Priority1.Location = new System.Drawing.Point(6, 17);
            this.Priority1.Name = "Priority1";
            this.Priority1.Size = new System.Drawing.Size(50, 13);
            this.Priority1.TabIndex = 16;
            this.Priority1.Text = "Priority1 :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(109, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(118, 16);
            this.label18.TabIndex = 5;
            this.label18.Text = "QOS Configuration";
            // 
            // QOSL3
            // 
            this.QOSL3.BackColor = System.Drawing.SystemColors.Control;
            this.QOSL3.Controls.Add(this.label27);
            this.QOSL3.Controls.Add(this.Priority3LIP);
            this.QOSL3.Controls.Add(this.Priority3HIP);
            this.QOSL3.Controls.Add(this.Priority3IP);
            this.QOSL3.Controls.Add(this.label31);
            this.QOSL3.Controls.Add(this.Priority4LIP);
            this.QOSL3.Controls.Add(this.Priority4HIP);
            this.QOSL3.Controls.Add(this.Priority4IP);
            this.QOSL3.Controls.Add(this.label33);
            this.QOSL3.Controls.Add(this.Priority2LIP);
            this.QOSL3.Controls.Add(this.Priority2HIP);
            this.QOSL3.Controls.Add(this.Priority2IP);
            this.QOSL3.Controls.Add(this.label35);
            this.QOSL3.Controls.Add(this.Priority1LIP);
            this.QOSL3.Controls.Add(this.Priority1HIP);
            this.QOSL3.Controls.Add(this.Priority1IP);
            this.QOSL3.Location = new System.Drawing.Point(92, 189);
            this.QOSL3.Name = "QOSL3";
            this.QOSL3.Size = new System.Drawing.Size(166, 130);
            this.QOSL3.TabIndex = 4;
            this.QOSL3.TabStop = false;
            this.QOSL3.Text = "QOS L3";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(101, 77);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(10, 13);
            this.label27.TabIndex = 47;
            this.label27.Text = ":";
            // 
            // Priority3LIP
            // 
            this.Priority3LIP.Enabled = false;
            this.Priority3LIP.Location = new System.Drawing.Point(117, 75);
            this.Priority3LIP.Name = "Priority3LIP";
            this.Priority3LIP.Size = new System.Drawing.Size(32, 20);
            this.Priority3LIP.TabIndex = 46;
            this.Priority3LIP.Text = "47";
            // 
            // Priority3HIP
            // 
            this.Priority3HIP.Location = new System.Drawing.Point(62, 75);
            this.Priority3HIP.Name = "Priority3HIP";
            this.Priority3HIP.ReadOnly = true;
            this.Priority3HIP.Size = new System.Drawing.Size(32, 20);
            this.Priority3HIP.TabIndex = 45;
            this.Priority3HIP.Text = "32";
            // 
            // Priority3IP
            // 
            this.Priority3IP.AutoSize = true;
            this.Priority3IP.Location = new System.Drawing.Point(6, 77);
            this.Priority3IP.Name = "Priority3IP";
            this.Priority3IP.Size = new System.Drawing.Size(50, 13);
            this.Priority3IP.TabIndex = 44;
            this.Priority3IP.Text = "Priority3 :";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(102, 106);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(10, 13);
            this.label31.TabIndex = 43;
            this.label31.Text = ":";
            // 
            // Priority4LIP
            // 
            this.Priority4LIP.Enabled = false;
            this.Priority4LIP.Location = new System.Drawing.Point(118, 104);
            this.Priority4LIP.Name = "Priority4LIP";
            this.Priority4LIP.Size = new System.Drawing.Size(32, 20);
            this.Priority4LIP.TabIndex = 42;
            this.Priority4LIP.Text = "63";
            // 
            // Priority4HIP
            // 
            this.Priority4HIP.Location = new System.Drawing.Point(63, 104);
            this.Priority4HIP.Name = "Priority4HIP";
            this.Priority4HIP.ReadOnly = true;
            this.Priority4HIP.Size = new System.Drawing.Size(32, 20);
            this.Priority4HIP.TabIndex = 41;
            this.Priority4HIP.Text = "48";
            // 
            // Priority4IP
            // 
            this.Priority4IP.AutoSize = true;
            this.Priority4IP.Location = new System.Drawing.Point(7, 106);
            this.Priority4IP.Name = "Priority4IP";
            this.Priority4IP.Size = new System.Drawing.Size(50, 13);
            this.Priority4IP.TabIndex = 40;
            this.Priority4IP.Text = "Priority4 :";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(100, 46);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(10, 13);
            this.label33.TabIndex = 39;
            this.label33.Text = ":";
            // 
            // Priority2LIP
            // 
            this.Priority2LIP.Enabled = false;
            this.Priority2LIP.Location = new System.Drawing.Point(116, 44);
            this.Priority2LIP.Name = "Priority2LIP";
            this.Priority2LIP.Size = new System.Drawing.Size(32, 20);
            this.Priority2LIP.TabIndex = 38;
            this.Priority2LIP.Text = "31";
            // 
            // Priority2HIP
            // 
            this.Priority2HIP.Location = new System.Drawing.Point(61, 44);
            this.Priority2HIP.Name = "Priority2HIP";
            this.Priority2HIP.ReadOnly = true;
            this.Priority2HIP.Size = new System.Drawing.Size(32, 20);
            this.Priority2HIP.TabIndex = 37;
            this.Priority2HIP.Text = "16";
            // 
            // Priority2IP
            // 
            this.Priority2IP.AutoSize = true;
            this.Priority2IP.Location = new System.Drawing.Point(5, 46);
            this.Priority2IP.Name = "Priority2IP";
            this.Priority2IP.Size = new System.Drawing.Size(50, 13);
            this.Priority2IP.TabIndex = 36;
            this.Priority2IP.Text = "Priority2 :";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(100, 17);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(10, 13);
            this.label35.TabIndex = 35;
            this.label35.Text = ":";
            // 
            // Priority1LIP
            // 
            this.Priority1LIP.Enabled = false;
            this.Priority1LIP.Location = new System.Drawing.Point(116, 15);
            this.Priority1LIP.Name = "Priority1LIP";
            this.Priority1LIP.Size = new System.Drawing.Size(32, 20);
            this.Priority1LIP.TabIndex = 34;
            this.Priority1LIP.Text = "15";
            // 
            // Priority1HIP
            // 
            this.Priority1HIP.Location = new System.Drawing.Point(61, 15);
            this.Priority1HIP.Name = "Priority1HIP";
            this.Priority1HIP.ReadOnly = true;
            this.Priority1HIP.Size = new System.Drawing.Size(32, 20);
            this.Priority1HIP.TabIndex = 33;
            this.Priority1HIP.Text = "0";
            // 
            // Priority1IP
            // 
            this.Priority1IP.AutoSize = true;
            this.Priority1IP.Location = new System.Drawing.Point(5, 17);
            this.Priority1IP.Name = "Priority1IP";
            this.Priority1IP.Size = new System.Drawing.Size(50, 13);
            this.Priority1IP.TabIndex = 32;
            this.Priority1IP.Text = "Priority1 :";
            // 
            // tabPage1_1
            // 
            this.tabPage1_1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1_1.Controls.Add(this.VLANConfiguration);
            this.tabPage1_1.Controls.Add(this.label19);
            this.tabPage1_1.Location = new System.Drawing.Point(4, 77);
            this.tabPage1_1.Name = "tabPage1_1";
            this.tabPage1_1.Size = new System.Drawing.Size(346, 443);
            this.tabPage1_1.TabIndex = 6;
            this.tabPage1_1.Text = "tabPage1_1";
            // 
            // VLANConfiguration
            // 
            this.VLANConfiguration.BackColor = System.Drawing.Color.Transparent;
            this.VLANConfiguration.Controls.Add(this.VLANMember);
            this.VLANConfiguration.Controls.Add(this.VLANPortSetting);
            this.VLANConfiguration.Location = new System.Drawing.Point(3, 121);
            this.VLANConfiguration.Name = "VLANConfiguration";
            this.VLANConfiguration.Size = new System.Drawing.Size(344, 217);
            this.VLANConfiguration.TabIndex = 7;
            this.VLANConfiguration.TabStop = false;
            this.VLANConfiguration.Text = "VLAN Configuration";
            // 
            // VLANMember
            // 
            this.VLANMember.Controls.Add(this.removeVlanMember);
            this.VLANMember.Controls.Add(this.VlanMemPortNum);
            this.VLANMember.Controls.Add(this.EnterVlanMemVlanID);
            this.VLANMember.Controls.Add(this.EnterVlanMemPortNum);
            this.VLANMember.Controls.Add(this.VlanMemVlanID);
            this.VLANMember.Controls.Add(this.AddVlanMember);
            this.VLANMember.Location = new System.Drawing.Point(4, 129);
            this.VLANMember.Name = "VLANMember";
            this.VLANMember.Size = new System.Drawing.Size(334, 82);
            this.VLANMember.TabIndex = 37;
            this.VLANMember.TabStop = false;
            this.VLANMember.Text = "VLAN Member";
            // 
            // removeVlanMember
            // 
            this.removeVlanMember.Enabled = false;
            this.removeVlanMember.Location = new System.Drawing.Point(172, 53);
            this.removeVlanMember.Name = "removeVlanMember";
            this.removeVlanMember.Size = new System.Drawing.Size(155, 23);
            this.removeVlanMember.TabIndex = 47;
            this.removeVlanMember.Text = "Remove Configuration";
            this.removeVlanMember.UseVisualStyleBackColor = true;
            // 
            // VlanMemPortNum
            // 
            this.VlanMemPortNum.AutoSize = true;
            this.VlanMemPortNum.Location = new System.Drawing.Point(8, 21);
            this.VlanMemPortNum.Name = "VlanMemPortNum";
            this.VlanMemPortNum.Size = new System.Drawing.Size(72, 13);
            this.VlanMemPortNum.TabIndex = 46;
            this.VlanMemPortNum.Text = "Port Number :";
            // 
            // EnterVlanMemVlanID
            // 
            this.EnterVlanMemVlanID.Enabled = false;
            this.EnterVlanMemVlanID.Location = new System.Drawing.Point(253, 18);
            this.EnterVlanMemVlanID.Name = "EnterVlanMemVlanID";
            this.EnterVlanMemVlanID.Size = new System.Drawing.Size(72, 20);
            this.EnterVlanMemVlanID.TabIndex = 45;
            this.EnterVlanMemVlanID.Text = "0";
            // 
            // EnterVlanMemPortNum
            // 
            this.EnterVlanMemPortNum.Enabled = false;
            this.EnterVlanMemPortNum.FormattingEnabled = true;
            this.EnterVlanMemPortNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.EnterVlanMemPortNum.Location = new System.Drawing.Point(84, 18);
            this.EnterVlanMemPortNum.Name = "EnterVlanMemPortNum";
            this.EnterVlanMemPortNum.Size = new System.Drawing.Size(72, 21);
            this.EnterVlanMemPortNum.TabIndex = 44;
            this.EnterVlanMemPortNum.Text = "0";
            // 
            // VlanMemVlanID
            // 
            this.VlanMemVlanID.AutoSize = true;
            this.VlanMemVlanID.Location = new System.Drawing.Point(162, 21);
            this.VlanMemVlanID.Name = "VlanMemVlanID";
            this.VlanMemVlanID.Size = new System.Drawing.Size(55, 13);
            this.VlanMemVlanID.TabIndex = 43;
            this.VlanMemVlanID.Text = "VLAN ID :";
            // 
            // AddVlanMember
            // 
            this.AddVlanMember.Enabled = false;
            this.AddVlanMember.Location = new System.Drawing.Point(11, 53);
            this.AddVlanMember.Name = "AddVlanMember";
            this.AddVlanMember.Size = new System.Drawing.Size(155, 23);
            this.AddVlanMember.TabIndex = 42;
            this.AddVlanMember.Text = "Add Configuration";
            this.AddVlanMember.UseVisualStyleBackColor = true;
            // 
            // VLANPortSetting
            // 
            this.VLANPortSetting.Controls.Add(this.PortNumberSet);
            this.VLANPortSetting.Controls.Add(this.EnterVLANPPortSet);
            this.VLANPortSetting.Controls.Add(this.FilterUnttagedselect);
            this.VLANPortSetting.Controls.Add(this.FilterUnttagedSet);
            this.VLANPortSetting.Controls.Add(this.EnterVLANIDPortSet);
            this.VLANPortSetting.Controls.Add(this.VLANPPortSet);
            this.VLANPortSetting.Controls.Add(this.PortNumPortSet);
            this.VLANPortSetting.Controls.Add(this.VLANIDPortSet);
            this.VLANPortSetting.Location = new System.Drawing.Point(4, 19);
            this.VLANPortSetting.Name = "VLANPortSetting";
            this.VLANPortSetting.Size = new System.Drawing.Size(334, 104);
            this.VLANPortSetting.TabIndex = 36;
            this.VLANPortSetting.TabStop = false;
            this.VLANPortSetting.Text = "Port Settings";
            // 
            // PortNumberSet
            // 
            this.PortNumberSet.AutoSize = true;
            this.PortNumberSet.Location = new System.Drawing.Point(8, 18);
            this.PortNumberSet.Name = "PortNumberSet";
            this.PortNumberSet.Size = new System.Drawing.Size(72, 13);
            this.PortNumberSet.TabIndex = 40;
            this.PortNumberSet.Text = "Port Number :";
            // 
            // EnterVLANPPortSet
            // 
            this.EnterVLANPPortSet.Enabled = false;
            this.EnterVLANPPortSet.Location = new System.Drawing.Point(253, 45);
            this.EnterVLANPPortSet.Name = "EnterVLANPPortSet";
            this.EnterVLANPPortSet.Size = new System.Drawing.Size(72, 20);
            this.EnterVLANPPortSet.TabIndex = 39;
            this.EnterVLANPPortSet.Text = "0";
            // 
            // FilterUnttagedselect
            // 
            this.FilterUnttagedselect.Enabled = false;
            this.FilterUnttagedselect.FormattingEnabled = true;
            this.FilterUnttagedselect.Items.AddRange(new object[] {
            "Disable",
            "Enable"});
            this.FilterUnttagedselect.Location = new System.Drawing.Point(253, 15);
            this.FilterUnttagedselect.Name = "FilterUnttagedselect";
            this.FilterUnttagedselect.Size = new System.Drawing.Size(72, 21);
            this.FilterUnttagedselect.TabIndex = 38;
            this.FilterUnttagedselect.Text = "Disable";
            // 
            // FilterUnttagedSet
            // 
            this.FilterUnttagedSet.AutoSize = true;
            this.FilterUnttagedSet.Location = new System.Drawing.Point(162, 18);
            this.FilterUnttagedSet.Name = "FilterUnttagedSet";
            this.FilterUnttagedSet.Size = new System.Drawing.Size(85, 13);
            this.FilterUnttagedSet.TabIndex = 37;
            this.FilterUnttagedSet.Text = "Filter Untagged :";
            // 
            // EnterVLANIDPortSet
            // 
            this.EnterVLANIDPortSet.Enabled = false;
            this.EnterVLANIDPortSet.Location = new System.Drawing.Point(84, 42);
            this.EnterVLANIDPortSet.Name = "EnterVLANIDPortSet";
            this.EnterVLANIDPortSet.Size = new System.Drawing.Size(72, 20);
            this.EnterVLANIDPortSet.TabIndex = 36;
            this.EnterVLANIDPortSet.Text = "0";
            // 
            // VLANPPortSet
            // 
            this.VLANPPortSet.AutoSize = true;
            this.VLANPPortSet.Location = new System.Drawing.Point(162, 48);
            this.VLANPPortSet.Name = "VLANPPortSet";
            this.VLANPPortSet.Size = new System.Drawing.Size(75, 13);
            this.VLANPPortSet.TabIndex = 34;
            this.VLANPPortSet.Text = "VLAN Priority :";
            // 
            // PortNumPortSet
            // 
            this.PortNumPortSet.Enabled = false;
            this.PortNumPortSet.FormattingEnabled = true;
            this.PortNumPortSet.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.PortNumPortSet.Location = new System.Drawing.Point(84, 15);
            this.PortNumPortSet.Name = "PortNumPortSet";
            this.PortNumPortSet.Size = new System.Drawing.Size(72, 21);
            this.PortNumPortSet.TabIndex = 35;
            this.PortNumPortSet.Text = "0";
            // 
            // VLANIDPortSet
            // 
            this.VLANIDPortSet.AutoSize = true;
            this.VLANIDPortSet.Location = new System.Drawing.Point(8, 45);
            this.VLANIDPortSet.Name = "VLANIDPortSet";
            this.VLANIDPortSet.Size = new System.Drawing.Size(55, 13);
            this.VLANIDPortSet.TabIndex = 33;
            this.VLANIDPortSet.Text = "VLAN ID :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(109, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(124, 16);
            this.label19.TabIndex = 6;
            this.label19.Text = "VLAN Configuration";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.buttonMemoryWrite);
            this.tabPage2.Controls.Add(this.textBoxMemoryValue);
            this.tabPage2.Controls.Add(this.labelAddrContents);
            this.tabPage2.Controls.Add(this.buttonMemoryRead);
            this.tabPage2.Controls.Add(this.listViewMemory);
            this.tabPage2.Controls.Add(this.textBoxMemoryAddr);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 77);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(346, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // buttonMemoryWrite
            // 
            this.buttonMemoryWrite.Enabled = false;
            this.buttonMemoryWrite.Location = new System.Drawing.Point(215, 86);
            this.buttonMemoryWrite.Name = "buttonMemoryWrite";
            this.buttonMemoryWrite.Size = new System.Drawing.Size(75, 23);
            this.buttonMemoryWrite.TabIndex = 7;
            this.buttonMemoryWrite.Text = "Write";
            this.buttonMemoryWrite.UseVisualStyleBackColor = true;
            this.buttonMemoryWrite.Click += new System.EventHandler(this.buttonMemoryWrite_Click);
            // 
            // textBoxMemoryValue
            // 
            this.textBoxMemoryValue.Location = new System.Drawing.Point(99, 90);
            this.textBoxMemoryValue.MaxLength = 8;
            this.textBoxMemoryValue.Name = "textBoxMemoryValue";
            this.textBoxMemoryValue.Size = new System.Drawing.Size(100, 20);
            this.textBoxMemoryValue.TabIndex = 6;
            this.textBoxMemoryValue.TextChanged += new System.EventHandler(this.textBoxMemoryValue_TextChanged);
            // 
            // labelAddrContents
            // 
            this.labelAddrContents.AutoSize = true;
            this.labelAddrContents.Location = new System.Drawing.Point(31, 92);
            this.labelAddrContents.Name = "labelAddrContents";
            this.labelAddrContents.Size = new System.Drawing.Size(52, 13);
            this.labelAddrContents.TabIndex = 5;
            this.labelAddrContents.Text = "Contents:";
            // 
            // buttonMemoryRead
            // 
            this.buttonMemoryRead.Enabled = false;
            this.buttonMemoryRead.Location = new System.Drawing.Point(215, 52);
            this.buttonMemoryRead.Name = "buttonMemoryRead";
            this.buttonMemoryRead.Size = new System.Drawing.Size(75, 23);
            this.buttonMemoryRead.TabIndex = 4;
            this.buttonMemoryRead.Text = "Read";
            this.buttonMemoryRead.UseVisualStyleBackColor = true;
            this.buttonMemoryRead.Click += new System.EventHandler(this.buttonMemoryRead_Click);
            // 
            // listViewMemory
            // 
            this.listViewMemory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewMemory.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewMemory.FullRowSelect = true;
            this.listViewMemory.GridLines = true;
            this.listViewMemory.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listViewMemory.Location = new System.Drawing.Point(3, 116);
            this.listViewMemory.Name = "listViewMemory";
            this.listViewMemory.Size = new System.Drawing.Size(344, 314);
            this.listViewMemory.TabIndex = 3;
            this.listViewMemory.UseCompatibleStateImageBehavior = false;
            this.listViewMemory.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Addr";
            this.columnHeader1.Width = 68;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "0";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 68;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "4";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 68;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "8";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 68;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "C";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 68;
            // 
            // textBoxMemoryAddr
            // 
            this.textBoxMemoryAddr.Location = new System.Drawing.Point(100, 54);
            this.textBoxMemoryAddr.MaxLength = 8;
            this.textBoxMemoryAddr.Name = "textBoxMemoryAddr";
            this.textBoxMemoryAddr.Size = new System.Drawing.Size(100, 20);
            this.textBoxMemoryAddr.TabIndex = 2;
            this.textBoxMemoryAddr.TextChanged += new System.EventHandler(this.textBoxMemoryAddr_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(26, 57);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Address:   0x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(109, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "EVB Memory";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.buttonConstellationApply);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Location = new System.Drawing.Point(4, 77);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(346, 443);
            this.tabPage3.TabIndex = 8;
            this.tabPage3.Text = "tabPage3";
            // 
            // buttonConstellationApply
            // 
            this.buttonConstellationApply.Enabled = false;
            this.buttonConstellationApply.Location = new System.Drawing.Point(135, 376);
            this.buttonConstellationApply.Name = "buttonConstellationApply";
            this.buttonConstellationApply.Size = new System.Drawing.Size(75, 23);
            this.buttonConstellationApply.TabIndex = 10;
            this.buttonConstellationApply.Text = "Apply";
            this.buttonConstellationApply.UseVisualStyleBackColor = true;
            this.buttonConstellationApply.Click += new System.EventHandler(this.buttonConstellationApply_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxMatlabwithChannelEstimation);
            this.groupBox2.Controls.Add(this.buttonConstellationDataFolder);
            this.groupBox2.Controls.Add(this.buttonConstellationExecutable);
            this.groupBox2.Controls.Add(this.textBoxConstellationDataFolder);
            this.groupBox2.Controls.Add(this.textBoxConstellationExecutable);
            this.groupBox2.Controls.Add(this.label38);
            this.groupBox2.Controls.Add(this.label37);
            this.groupBox2.Location = new System.Drawing.Point(23, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 135);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Location";
            // 
            // checkBoxMatlabwithChannelEstimation
            // 
            this.checkBoxMatlabwithChannelEstimation.AutoSize = true;
            this.checkBoxMatlabwithChannelEstimation.Checked = true;
            this.checkBoxMatlabwithChannelEstimation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMatlabwithChannelEstimation.Location = new System.Drawing.Point(11, 112);
            this.checkBoxMatlabwithChannelEstimation.Name = "checkBoxMatlabwithChannelEstimation";
            this.checkBoxMatlabwithChannelEstimation.Size = new System.Drawing.Size(118, 17);
            this.checkBoxMatlabwithChannelEstimation.TabIndex = 11;
            this.checkBoxMatlabwithChannelEstimation.Text = "New Matlab formet ";
            this.checkBoxMatlabwithChannelEstimation.UseVisualStyleBackColor = true;
            this.checkBoxMatlabwithChannelEstimation.CheckedChanged += new System.EventHandler(this.checkBoxMatlabwithChannelEstimation_CheckedChanged);
            // 
            // buttonConstellationDataFolder
            // 
            this.buttonConstellationDataFolder.Location = new System.Drawing.Point(276, 82);
            this.buttonConstellationDataFolder.Name = "buttonConstellationDataFolder";
            this.buttonConstellationDataFolder.Size = new System.Drawing.Size(25, 23);
            this.buttonConstellationDataFolder.TabIndex = 5;
            this.buttonConstellationDataFolder.Text = "...";
            this.buttonConstellationDataFolder.UseVisualStyleBackColor = true;
            this.buttonConstellationDataFolder.Click += new System.EventHandler(this.buttonConstellationDataFolder_Click);
            // 
            // buttonConstellationExecutable
            // 
            this.buttonConstellationExecutable.Location = new System.Drawing.Point(276, 41);
            this.buttonConstellationExecutable.Name = "buttonConstellationExecutable";
            this.buttonConstellationExecutable.Size = new System.Drawing.Size(25, 23);
            this.buttonConstellationExecutable.TabIndex = 4;
            this.buttonConstellationExecutable.Text = "...";
            this.buttonConstellationExecutable.UseVisualStyleBackColor = true;
            this.buttonConstellationExecutable.Click += new System.EventHandler(this.buttonConstellationExecutable_Click);
            // 
            // textBoxConstellationDataFolder
            // 
            this.textBoxConstellationDataFolder.Location = new System.Drawing.Point(14, 85);
            this.textBoxConstellationDataFolder.Name = "textBoxConstellationDataFolder";
            this.textBoxConstellationDataFolder.Size = new System.Drawing.Size(256, 20);
            this.textBoxConstellationDataFolder.TabIndex = 3;
            this.textBoxConstellationDataFolder.TextChanged += new System.EventHandler(this.textBoxConstellationDataFolder_TextChanged);
            // 
            // textBoxConstellationExecutable
            // 
            this.textBoxConstellationExecutable.Location = new System.Drawing.Point(11, 44);
            this.textBoxConstellationExecutable.Name = "textBoxConstellationExecutable";
            this.textBoxConstellationExecutable.Size = new System.Drawing.Size(259, 20);
            this.textBoxConstellationExecutable.TabIndex = 2;
            this.textBoxConstellationExecutable.TextChanged += new System.EventHandler(this.textBoxConstellationExecutable_TextChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 65);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(65, 13);
            this.label38.TabIndex = 1;
            this.label38.Text = "Data Folder:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(6, 27);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(63, 13);
            this.label37.TabIndex = 0;
            this.label37.Text = "Executable:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxEnablePersistence);
            this.groupBox1.Controls.Add(this.labelEnablePersistence);
            this.groupBox1.Controls.Add(this.comboBoxPLLDebug);
            this.groupBox1.Controls.Add(this.labelPLLDebug);
            this.groupBox1.Controls.Add(this.comboBoxConstellationFFT);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.textBoxConstellationUpdateInterval);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Location = new System.Drawing.Point(26, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 163);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operating Parameters";
            // 
            // comboBoxEnablePersistence
            // 
            this.comboBoxEnablePersistence.FormattingEnabled = true;
            this.comboBoxEnablePersistence.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.comboBoxEnablePersistence.Location = new System.Drawing.Point(176, 134);
            this.comboBoxEnablePersistence.Name = "comboBoxEnablePersistence";
            this.comboBoxEnablePersistence.Size = new System.Drawing.Size(100, 21);
            this.comboBoxEnablePersistence.TabIndex = 7;
            this.comboBoxEnablePersistence.Text = "No";
            this.comboBoxEnablePersistence.SelectedIndexChanged += new System.EventHandler(this.comboBoxEnablePersistence_SelectedIndexChanged);
            // 
            // labelEnablePersistence
            // 
            this.labelEnablePersistence.AutoSize = true;
            this.labelEnablePersistence.Location = new System.Drawing.Point(26, 137);
            this.labelEnablePersistence.Name = "labelEnablePersistence";
            this.labelEnablePersistence.Size = new System.Drawing.Size(98, 13);
            this.labelEnablePersistence.TabIndex = 6;
            this.labelEnablePersistence.Text = "Enable Persistence";
            // 
            // comboBoxPLLDebug
            // 
            this.comboBoxPLLDebug.FormattingEnabled = true;
            this.comboBoxPLLDebug.Items.AddRange(new object[] {
            "Post PLL",
            "Pre PLL"});
            this.comboBoxPLLDebug.Location = new System.Drawing.Point(176, 96);
            this.comboBoxPLLDebug.Name = "comboBoxPLLDebug";
            this.comboBoxPLLDebug.Size = new System.Drawing.Size(100, 21);
            this.comboBoxPLLDebug.TabIndex = 5;
            this.comboBoxPLLDebug.Text = "Post PLL";
            this.comboBoxPLLDebug.SelectedIndexChanged += new System.EventHandler(this.comboBoxPLLDebug_SelectedIndexChanged);
            // 
            // labelPLLDebug
            // 
            this.labelPLLDebug.AutoSize = true;
            this.labelPLLDebug.Location = new System.Drawing.Point(26, 99);
            this.labelPLLDebug.Name = "labelPLLDebug";
            this.labelPLLDebug.Size = new System.Drawing.Size(61, 13);
            this.labelPLLDebug.TabIndex = 4;
            this.labelPLLDebug.Text = "PLL Debug";
            // 
            // comboBoxConstellationFFT
            // 
            this.comboBoxConstellationFFT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConstellationFFT.Enabled = false;
            this.comboBoxConstellationFFT.FormattingEnabled = true;
            this.comboBoxConstellationFFT.Items.AddRange(new object[] {
            "256",
            "512"});
            this.comboBoxConstellationFFT.Location = new System.Drawing.Point(176, 58);
            this.comboBoxConstellationFFT.Name = "comboBoxConstellationFFT";
            this.comboBoxConstellationFFT.Size = new System.Drawing.Size(100, 21);
            this.comboBoxConstellationFFT.TabIndex = 3;
            this.comboBoxConstellationFFT.SelectedIndexChanged += new System.EventHandler(this.comboBoxConstellationFFT_SelectedIndexChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(26, 61);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(52, 13);
            this.label36.TabIndex = 2;
            this.label36.Text = "FFT Size:";
            // 
            // textBoxConstellationUpdateInterval
            // 
            this.textBoxConstellationUpdateInterval.Location = new System.Drawing.Point(176, 20);
            this.textBoxConstellationUpdateInterval.MaxLength = 3;
            this.textBoxConstellationUpdateInterval.Name = "textBoxConstellationUpdateInterval";
            this.textBoxConstellationUpdateInterval.Size = new System.Drawing.Size(100, 20);
            this.textBoxConstellationUpdateInterval.TabIndex = 1;
            this.textBoxConstellationUpdateInterval.Text = "4";
            this.textBoxConstellationUpdateInterval.TextChanged += new System.EventHandler(this.textBoxConstellationUpdateInterval_TextChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(26, 23);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(131, 13);
            this.label34.TabIndex = 0;
            this.label34.Text = "Update interval (seconds):";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(109, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 16);
            this.label22.TabIndex = 7;
            this.label22.Text = "Constellation";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.textBoxTransmittionMode);
            this.tabPage4.Controls.Add(this.label42);
            this.tabPage4.Controls.Add(this.textBoxRunningProfile);
            this.tabPage4.Controls.Add(this.labelRunningProfile);
            this.tabPage4.Controls.Add(this.textBoxUnitType);
            this.tabPage4.Controls.Add(this.textBoxCPLDVersion);
            this.tabPage4.Controls.Add(this.textBoxSWVersion);
            this.tabPage4.Controls.Add(this.textBoxuMONVersion);
            this.tabPage4.Controls.Add(this.labelCPLDVERSION);
            this.tabPage4.Controls.Add(this.labelUnitType);
            this.tabPage4.Controls.Add(this.labelSWVersion);
            this.tabPage4.Controls.Add(this.labeluMONVersion);
            this.tabPage4.Controls.Add(this.labelUnitControl);
            this.tabPage4.Location = new System.Drawing.Point(4, 77);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(346, 443);
            this.tabPage4.TabIndex = 12;
            this.tabPage4.Text = "tabPage4";
            // 
            // textBoxTransmittionMode
            // 
            this.textBoxTransmittionMode.Location = new System.Drawing.Point(199, 235);
            this.textBoxTransmittionMode.Name = "textBoxTransmittionMode";
            this.textBoxTransmittionMode.ReadOnly = true;
            this.textBoxTransmittionMode.Size = new System.Drawing.Size(93, 20);
            this.textBoxTransmittionMode.TabIndex = 30;
            this.textBoxTransmittionMode.TabStop = false;
            this.textBoxTransmittionMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(41, 238);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(100, 13);
            this.label42.TabIndex = 29;
            this.label42.Text = "Transmitting Mode :";
            // 
            // textBoxRunningProfile
            // 
            this.textBoxRunningProfile.Location = new System.Drawing.Point(199, 205);
            this.textBoxRunningProfile.Name = "textBoxRunningProfile";
            this.textBoxRunningProfile.ReadOnly = true;
            this.textBoxRunningProfile.Size = new System.Drawing.Size(93, 20);
            this.textBoxRunningProfile.TabIndex = 28;
            this.textBoxRunningProfile.TabStop = false;
            this.textBoxRunningProfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelRunningProfile
            // 
            this.labelRunningProfile.AutoSize = true;
            this.labelRunningProfile.Location = new System.Drawing.Point(41, 208);
            this.labelRunningProfile.Name = "labelRunningProfile";
            this.labelRunningProfile.Size = new System.Drawing.Size(85, 13);
            this.labelRunningProfile.TabIndex = 27;
            this.labelRunningProfile.Text = "Running Profile :";
            // 
            // textBoxUnitType
            // 
            this.textBoxUnitType.Location = new System.Drawing.Point(199, 175);
            this.textBoxUnitType.Name = "textBoxUnitType";
            this.textBoxUnitType.ReadOnly = true;
            this.textBoxUnitType.Size = new System.Drawing.Size(93, 20);
            this.textBoxUnitType.TabIndex = 26;
            this.textBoxUnitType.TabStop = false;
            this.textBoxUnitType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxCPLDVersion
            // 
            this.textBoxCPLDVersion.Location = new System.Drawing.Point(199, 145);
            this.textBoxCPLDVersion.Name = "textBoxCPLDVersion";
            this.textBoxCPLDVersion.ReadOnly = true;
            this.textBoxCPLDVersion.Size = new System.Drawing.Size(93, 20);
            this.textBoxCPLDVersion.TabIndex = 25;
            this.textBoxCPLDVersion.TabStop = false;
            this.textBoxCPLDVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSWVersion
            // 
            this.textBoxSWVersion.Location = new System.Drawing.Point(199, 115);
            this.textBoxSWVersion.Name = "textBoxSWVersion";
            this.textBoxSWVersion.ReadOnly = true;
            this.textBoxSWVersion.Size = new System.Drawing.Size(93, 20);
            this.textBoxSWVersion.TabIndex = 24;
            this.textBoxSWVersion.TabStop = false;
            this.textBoxSWVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxuMONVersion
            // 
            this.textBoxuMONVersion.Location = new System.Drawing.Point(199, 85);
            this.textBoxuMONVersion.Name = "textBoxuMONVersion";
            this.textBoxuMONVersion.ReadOnly = true;
            this.textBoxuMONVersion.Size = new System.Drawing.Size(93, 20);
            this.textBoxuMONVersion.TabIndex = 23;
            this.textBoxuMONVersion.TabStop = false;
            this.textBoxuMONVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCPLDVERSION
            // 
            this.labelCPLDVERSION.AutoSize = true;
            this.labelCPLDVERSION.Location = new System.Drawing.Point(41, 148);
            this.labelCPLDVERSION.Name = "labelCPLDVERSION";
            this.labelCPLDVERSION.Size = new System.Drawing.Size(79, 13);
            this.labelCPLDVERSION.TabIndex = 4;
            this.labelCPLDVERSION.Text = "CPLD Version :";
            // 
            // labelUnitType
            // 
            this.labelUnitType.AutoSize = true;
            this.labelUnitType.Location = new System.Drawing.Point(41, 178);
            this.labelUnitType.Name = "labelUnitType";
            this.labelUnitType.Size = new System.Drawing.Size(129, 13);
            this.labelUnitType.TabIndex = 3;
            this.labelUnitType.Text = "Unit Type (Master/Slave):";
            // 
            // labelSWVersion
            // 
            this.labelSWVersion.AutoSize = true;
            this.labelSWVersion.Location = new System.Drawing.Point(40, 118);
            this.labelSWVersion.Name = "labelSWVersion";
            this.labelSWVersion.Size = new System.Drawing.Size(69, 13);
            this.labelSWVersion.TabIndex = 2;
            this.labelSWVersion.Text = "SW Version :";
            // 
            // labeluMONVersion
            // 
            this.labeluMONVersion.AutoSize = true;
            this.labeluMONVersion.Location = new System.Drawing.Point(41, 88);
            this.labeluMONVersion.Name = "labeluMONVersion";
            this.labeluMONVersion.Size = new System.Drawing.Size(82, 13);
            this.labeluMONVersion.TabIndex = 1;
            this.labeluMONVersion.Text = "uMON Version :";
            // 
            // labelUnitControl
            // 
            this.labelUnitControl.AutoSize = true;
            this.labelUnitControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelUnitControl.Location = new System.Drawing.Point(109, 22);
            this.labelUnitControl.Name = "labelUnitControl";
            this.labelUnitControl.Size = new System.Drawing.Size(76, 16);
            this.labelUnitControl.TabIndex = 0;
            this.labelUnitControl.Text = "Unit Control";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage5.Controls.Add(this.label1DebugUnit);
            this.tabPage5.Controls.Add(this.label2DebugUnit);
            this.tabPage5.Location = new System.Drawing.Point(4, 77);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(346, 443);
            this.tabPage5.TabIndex = 13;
            this.tabPage5.Text = "tabPage5";
            // 
            // label1DebugUnit
            // 
            this.label1DebugUnit.AutoSize = true;
            this.label1DebugUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.label1DebugUnit.ForeColor = System.Drawing.Color.Red;
            this.label1DebugUnit.Location = new System.Drawing.Point(70, 63);
            this.label1DebugUnit.Name = "label1DebugUnit";
            this.label1DebugUnit.Size = new System.Drawing.Size(193, 31);
            this.label1DebugUnit.TabIndex = 1;
            this.label1DebugUnit.Text = "DEBUG UNIT";
            // 
            // label2DebugUnit
            // 
            this.label2DebugUnit.AutoSize = true;
            this.label2DebugUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2DebugUnit.Location = new System.Drawing.Point(34, 114);
            this.label2DebugUnit.Name = "label2DebugUnit";
            this.label2DebugUnit.Size = new System.Drawing.Size(270, 62);
            this.label2DebugUnit.TabIndex = 0;
            this.label2DebugUnit.Text = "Administrator level \r\npermission required";
            this.label2DebugUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage6.Controls.Add(this.comboBoxSpectralInversion);
            this.tabPage6.Controls.Add(this.labelSpectralInversion);
            this.tabPage6.Controls.Add(this.comboBoxPLLLoopBWB1);
            this.tabPage6.Controls.Add(this.labelPLLloopBandWidthB1);
            this.tabPage6.Controls.Add(this.textBoxRXPRIHypothesis);
            this.tabPage6.Controls.Add(this.labelRXPRIHypothesis);
            this.tabPage6.Controls.Add(this.comboBoxDisablePLLDerotation);
            this.tabPage6.Controls.Add(this.labelDisablePLLDerotation);
            this.tabPage6.Controls.Add(this.comboBoxChannelEstimationFactor);
            this.tabPage6.Controls.Add(this.comboBoxCINRFactor);
            this.tabPage6.Controls.Add(this.labelChannelEstimationfactor);
            this.tabPage6.Controls.Add(this.labelCINRfactor);
            this.tabPage6.Controls.Add(this.comboBoxPLLLoopBWB2);
            this.tabPage6.Controls.Add(this.labelPLLloopBandWidthB2);
            this.tabPage6.Controls.Add(this.comboBoxPLLWorkingMode);
            this.tabPage6.Controls.Add(this.labelPLLWorkingMode);
            this.tabPage6.Controls.Add(this.buttonDebugApply);
            this.tabPage6.Controls.Add(this.label_PLLDebug);
            this.tabPage6.Location = new System.Drawing.Point(4, 77);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(346, 443);
            this.tabPage6.TabIndex = 14;
            this.tabPage6.Text = "tabPage5_0";
            // 
            // comboBoxSpectralInversion
            // 
            this.comboBoxSpectralInversion.FormattingEnabled = true;
            this.comboBoxSpectralInversion.Items.AddRange(new object[] {
            "Disable",
            "Enable"});
            this.comboBoxSpectralInversion.Location = new System.Drawing.Point(164, 280);
            this.comboBoxSpectralInversion.Name = "comboBoxSpectralInversion";
            this.comboBoxSpectralInversion.Size = new System.Drawing.Size(158, 21);
            this.comboBoxSpectralInversion.TabIndex = 27;
            this.comboBoxSpectralInversion.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpectralInversion_SelectedIndexChanged);
            // 
            // labelSpectralInversion
            // 
            this.labelSpectralInversion.AutoSize = true;
            this.labelSpectralInversion.Location = new System.Drawing.Point(26, 283);
            this.labelSpectralInversion.Name = "labelSpectralInversion";
            this.labelSpectralInversion.Size = new System.Drawing.Size(101, 13);
            this.labelSpectralInversion.TabIndex = 26;
            this.labelSpectralInversion.Text = "Spectral Inversion : ";
            // 
            // comboBoxPLLLoopBWB1
            // 
            this.comboBoxPLLLoopBWB1.FormattingEnabled = true;
            this.comboBoxPLLLoopBWB1.Items.AddRange(new object[] {
            "BW=400 KHz",
            "BW=300 KHz",
            "BW=200 KHz",
            "BW=100 KHz"});
            this.comboBoxPLLLoopBWB1.Location = new System.Drawing.Point(164, 100);
            this.comboBoxPLLLoopBWB1.Name = "comboBoxPLLLoopBWB1";
            this.comboBoxPLLLoopBWB1.Size = new System.Drawing.Size(158, 21);
            this.comboBoxPLLLoopBWB1.TabIndex = 25;
            this.comboBoxPLLLoopBWB1.SelectedIndexChanged += new System.EventHandler(this.comboBoxPLLLoopBWB1_SelectedIndexChanged);
            this.comboBoxPLLLoopBWB1.TextUpdate += new System.EventHandler(this.comboBoxPLLLoopBWB1_SelectedIndexChanged);
            // 
            // labelPLLloopBandWidthB1
            // 
            this.labelPLLloopBandWidthB1.AutoSize = true;
            this.labelPLLloopBandWidthB1.Location = new System.Drawing.Point(26, 103);
            this.labelPLLloopBandWidthB1.Name = "labelPLLloopBandWidthB1";
            this.labelPLLloopBandWidthB1.Size = new System.Drawing.Size(130, 13);
            this.labelPLLloopBandWidthB1.TabIndex = 24;
            this.labelPLLloopBandWidthB1.Text = "PLL loop BandWidth B1 : ";
            // 
            // textBoxRXPRIHypothesis
            // 
            this.textBoxRXPRIHypothesis.Location = new System.Drawing.Point(164, 200);
            this.textBoxRXPRIHypothesis.Name = "textBoxRXPRIHypothesis";
            this.textBoxRXPRIHypothesis.ReadOnly = true;
            this.textBoxRXPRIHypothesis.Size = new System.Drawing.Size(158, 20);
            this.textBoxRXPRIHypothesis.TabIndex = 23;
            this.textBoxRXPRIHypothesis.TextChanged += new System.EventHandler(this.textBoxRXPRIHypothese_TextChanged);
            // 
            // labelRXPRIHypothesis
            // 
            this.labelRXPRIHypothesis.AutoSize = true;
            this.labelRXPRIHypothesis.Location = new System.Drawing.Point(26, 203);
            this.labelRXPRIHypothesis.Name = "labelRXPRIHypothesis";
            this.labelRXPRIHypothesis.Size = new System.Drawing.Size(105, 13);
            this.labelRXPRIHypothesis.TabIndex = 22;
            this.labelRXPRIHypothesis.Text = "RX PRI hypothesis : ";
            // 
            // comboBoxDisablePLLDerotation
            // 
            this.comboBoxDisablePLLDerotation.FormattingEnabled = true;
            this.comboBoxDisablePLLDerotation.Items.AddRange(new object[] {
            "Enable",
            "Disable"});
            this.comboBoxDisablePLLDerotation.Location = new System.Drawing.Point(164, 154);
            this.comboBoxDisablePLLDerotation.Name = "comboBoxDisablePLLDerotation";
            this.comboBoxDisablePLLDerotation.Size = new System.Drawing.Size(158, 21);
            this.comboBoxDisablePLLDerotation.TabIndex = 21;
            this.comboBoxDisablePLLDerotation.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisablePLLDerotation_SelectedIndexChanged);
            // 
            // labelDisablePLLDerotation
            // 
            this.labelDisablePLLDerotation.AutoSize = true;
            this.labelDisablePLLDerotation.Location = new System.Drawing.Point(26, 157);
            this.labelDisablePLLDerotation.Name = "labelDisablePLLDerotation";
            this.labelDisablePLLDerotation.Size = new System.Drawing.Size(76, 13);
            this.labelDisablePLLDerotation.TabIndex = 20;
            this.labelDisablePLLDerotation.Text = "PLL derotation";
            // 
            // comboBoxChannelEstimationFactor
            // 
            this.comboBoxChannelEstimationFactor.FormattingEnabled = true;
            this.comboBoxChannelEstimationFactor.Items.AddRange(new object[] {
            "5%",
            "10%",
            "15%",
            "20%",
            "25%",
            "30%",
            "35%",
            "40%",
            "45%",
            "50%",
            "55%",
            "60%",
            "65%",
            "70%",
            "75%",
            "80%",
            "85%",
            "90%",
            "95%",
            "100%"});
            this.comboBoxChannelEstimationFactor.Location = new System.Drawing.Point(164, 253);
            this.comboBoxChannelEstimationFactor.Name = "comboBoxChannelEstimationFactor";
            this.comboBoxChannelEstimationFactor.Size = new System.Drawing.Size(158, 21);
            this.comboBoxChannelEstimationFactor.TabIndex = 19;
            this.comboBoxChannelEstimationFactor.SelectedIndexChanged += new System.EventHandler(this.comboBoxChannelEstimationFactor_SelectedIndexChanged);
            // 
            // comboBoxCINRFactor
            // 
            this.comboBoxCINRFactor.FormattingEnabled = true;
            this.comboBoxCINRFactor.Items.AddRange(new object[] {
            "5%",
            "10%",
            "15%",
            "20%",
            "25%",
            "30%",
            "35%",
            "40%",
            "45%",
            "50%",
            "55%",
            "60%",
            "65%",
            "70%",
            "75%",
            "80%",
            "85%",
            "90%",
            "95%",
            "100%"});
            this.comboBoxCINRFactor.Location = new System.Drawing.Point(164, 226);
            this.comboBoxCINRFactor.Name = "comboBoxCINRFactor";
            this.comboBoxCINRFactor.Size = new System.Drawing.Size(158, 21);
            this.comboBoxCINRFactor.TabIndex = 18;
            this.comboBoxCINRFactor.SelectedIndexChanged += new System.EventHandler(this.comboBoxCINRFactor_SelectedIndexChanged);
            // 
            // labelChannelEstimationfactor
            // 
            this.labelChannelEstimationfactor.AutoSize = true;
            this.labelChannelEstimationfactor.Location = new System.Drawing.Point(26, 256);
            this.labelChannelEstimationfactor.Name = "labelChannelEstimationfactor";
            this.labelChannelEstimationfactor.Size = new System.Drawing.Size(135, 13);
            this.labelChannelEstimationfactor.TabIndex = 17;
            this.labelChannelEstimationfactor.Text = "Channel estimation factor : ";
            // 
            // labelCINRfactor
            // 
            this.labelCINRfactor.AutoSize = true;
            this.labelCINRfactor.Location = new System.Drawing.Point(26, 229);
            this.labelCINRfactor.Name = "labelCINRfactor";
            this.labelCINRfactor.Size = new System.Drawing.Size(72, 13);
            this.labelCINRfactor.TabIndex = 16;
            this.labelCINRfactor.Text = "CINR factor : ";
            // 
            // comboBoxPLLLoopBWB2
            // 
            this.comboBoxPLLLoopBWB2.FormattingEnabled = true;
            this.comboBoxPLLLoopBWB2.Items.AddRange(new object[] {
            "BW=400 KHz",
            "BW=300 KHz",
            "BW=200 KHz",
            "BW=100 KHz"});
            this.comboBoxPLLLoopBWB2.Location = new System.Drawing.Point(164, 127);
            this.comboBoxPLLLoopBWB2.Name = "comboBoxPLLLoopBWB2";
            this.comboBoxPLLLoopBWB2.Size = new System.Drawing.Size(158, 21);
            this.comboBoxPLLLoopBWB2.TabIndex = 15;
            this.comboBoxPLLLoopBWB2.SelectedIndexChanged += new System.EventHandler(this.comboBoxPLLLoopBWB2_SelectedIndexChanged);
            // 
            // labelPLLloopBandWidthB2
            // 
            this.labelPLLloopBandWidthB2.AutoSize = true;
            this.labelPLLloopBandWidthB2.Location = new System.Drawing.Point(26, 130);
            this.labelPLLloopBandWidthB2.Name = "labelPLLloopBandWidthB2";
            this.labelPLLloopBandWidthB2.Size = new System.Drawing.Size(130, 13);
            this.labelPLLloopBandWidthB2.TabIndex = 14;
            this.labelPLLloopBandWidthB2.Text = "PLL loop BandWidth B2 : ";
            // 
            // comboBoxPLLWorkingMode
            // 
            this.comboBoxPLLWorkingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPLLWorkingMode.FormattingEnabled = true;
            this.comboBoxPLLWorkingMode.Items.AddRange(new object[] {
            "PRI - Off, RESET  - On",
            "PRI - On,  RESET - Off",
            "PRI - Off, RESET - Off"});
            this.comboBoxPLLWorkingMode.Location = new System.Drawing.Point(164, 73);
            this.comboBoxPLLWorkingMode.Name = "comboBoxPLLWorkingMode";
            this.comboBoxPLLWorkingMode.Size = new System.Drawing.Size(158, 21);
            this.comboBoxPLLWorkingMode.TabIndex = 13;
            this.comboBoxPLLWorkingMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxPLLWorkingMode_SelectedIndexChanged);
            // 
            // labelPLLWorkingMode
            // 
            this.labelPLLWorkingMode.AutoSize = true;
            this.labelPLLWorkingMode.Location = new System.Drawing.Point(26, 76);
            this.labelPLLWorkingMode.Name = "labelPLLWorkingMode";
            this.labelPLLWorkingMode.Size = new System.Drawing.Size(113, 13);
            this.labelPLLWorkingMode.TabIndex = 12;
            this.labelPLLWorkingMode.Text = "PLL Working Modes : ";
            // 
            // buttonDebugApply
            // 
            this.buttonDebugApply.Enabled = false;
            this.buttonDebugApply.Location = new System.Drawing.Point(112, 356);
            this.buttonDebugApply.Name = "buttonDebugApply";
            this.buttonDebugApply.Size = new System.Drawing.Size(72, 23);
            this.buttonDebugApply.TabIndex = 11;
            this.buttonDebugApply.Text = "Apply";
            this.buttonDebugApply.UseVisualStyleBackColor = true;
            this.buttonDebugApply.Click += new System.EventHandler(this.buttonDebugApply_Click);
            // 
            // label_PLLDebug
            // 
            this.label_PLLDebug.AutoSize = true;
            this.label_PLLDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label_PLLDebug.Location = new System.Drawing.Point(109, 22);
            this.label_PLLDebug.Name = "label_PLLDebug";
            this.label_PLLDebug.Size = new System.Drawing.Size(49, 16);
            this.label_PLLDebug.TabIndex = 6;
            this.label_PLLDebug.Text = "Debug";
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage7.Controls.Add(this.labelMemoryDumpDownloadFileName);
            this.tabPage7.Controls.Add(this.textBoxMemoryDumpDownloadFileName);
            this.tabPage7.Controls.Add(this.labellMemoryDumpDownloadSize);
            this.tabPage7.Controls.Add(this.textBoxMemoryDumpDownloadSize);
            this.tabPage7.Controls.Add(this.labelMemoryDumpDownloadAddress);
            this.tabPage7.Controls.Add(this.textBoxMemoryDumpDownloadAddress);
            this.tabPage7.Controls.Add(this.buttonDownloadMemory);
            this.tabPage7.Controls.Add(this.buttonCDUDownloadResults);
            this.tabPage7.Controls.Add(this.buttonCDURunScript);
            this.tabPage7.Controls.Add(this.labelCDUScript);
            this.tabPage7.Controls.Add(this.comboBoxChooseCDUScript);
            this.tabPage7.Controls.Add(this.label9);
            this.tabPage7.Location = new System.Drawing.Point(4, 77);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(346, 443);
            this.tabPage7.TabIndex = 15;
            this.tabPage7.Text = "tabPage5_1";
            // 
            // labelMemoryDumpDownloadFileName
            // 
            this.labelMemoryDumpDownloadFileName.AutoSize = true;
            this.labelMemoryDumpDownloadFileName.Location = new System.Drawing.Point(62, 306);
            this.labelMemoryDumpDownloadFileName.Name = "labelMemoryDumpDownloadFileName";
            this.labelMemoryDumpDownloadFileName.Size = new System.Drawing.Size(111, 13);
            this.labelMemoryDumpDownloadFileName.TabIndex = 18;
            this.labelMemoryDumpDownloadFileName.Text = "Download File Name: ";
            // 
            // textBoxMemoryDumpDownloadFileName
            // 
            this.textBoxMemoryDumpDownloadFileName.Location = new System.Drawing.Point(179, 303);
            this.textBoxMemoryDumpDownloadFileName.Name = "textBoxMemoryDumpDownloadFileName";
            this.textBoxMemoryDumpDownloadFileName.Size = new System.Drawing.Size(100, 20);
            this.textBoxMemoryDumpDownloadFileName.TabIndex = 17;
            // 
            // labellMemoryDumpDownloadSize
            // 
            this.labellMemoryDumpDownloadSize.AutoSize = true;
            this.labellMemoryDumpDownloadSize.Location = new System.Drawing.Point(62, 280);
            this.labellMemoryDumpDownloadSize.Name = "labellMemoryDumpDownloadSize";
            this.labellMemoryDumpDownloadSize.Size = new System.Drawing.Size(84, 13);
            this.labellMemoryDumpDownloadSize.TabIndex = 16;
            this.labellMemoryDumpDownloadSize.Text = "Download Size: ";
            // 
            // textBoxMemoryDumpDownloadSize
            // 
            this.textBoxMemoryDumpDownloadSize.Location = new System.Drawing.Point(179, 277);
            this.textBoxMemoryDumpDownloadSize.Name = "textBoxMemoryDumpDownloadSize";
            this.textBoxMemoryDumpDownloadSize.Size = new System.Drawing.Size(100, 20);
            this.textBoxMemoryDumpDownloadSize.TabIndex = 15;
            // 
            // labelMemoryDumpDownloadAddress
            // 
            this.labelMemoryDumpDownloadAddress.AutoSize = true;
            this.labelMemoryDumpDownloadAddress.Location = new System.Drawing.Point(62, 254);
            this.labelMemoryDumpDownloadAddress.Name = "labelMemoryDumpDownloadAddress";
            this.labelMemoryDumpDownloadAddress.Size = new System.Drawing.Size(102, 13);
            this.labelMemoryDumpDownloadAddress.TabIndex = 14;
            this.labelMemoryDumpDownloadAddress.Text = "Download Address: ";
            // 
            // textBoxMemoryDumpDownloadAddress
            // 
            this.textBoxMemoryDumpDownloadAddress.Location = new System.Drawing.Point(179, 251);
            this.textBoxMemoryDumpDownloadAddress.Name = "textBoxMemoryDumpDownloadAddress";
            this.textBoxMemoryDumpDownloadAddress.Size = new System.Drawing.Size(100, 20);
            this.textBoxMemoryDumpDownloadAddress.TabIndex = 13;
            // 
            // buttonDownloadMemory
            // 
            this.buttonDownloadMemory.Location = new System.Drawing.Point(73, 210);
            this.buttonDownloadMemory.Name = "buttonDownloadMemory";
            this.buttonDownloadMemory.Size = new System.Drawing.Size(200, 23);
            this.buttonDownloadMemory.TabIndex = 12;
            this.buttonDownloadMemory.Text = "Download Memory";
            this.buttonDownloadMemory.UseVisualStyleBackColor = true;
            this.buttonDownloadMemory.Click += new System.EventHandler(this.buttonDownloadMemory_Click);
            // 
            // buttonCDUDownloadResults
            // 
            this.buttonCDUDownloadResults.Location = new System.Drawing.Point(72, 166);
            this.buttonCDUDownloadResults.Name = "buttonCDUDownloadResults";
            this.buttonCDUDownloadResults.Size = new System.Drawing.Size(200, 23);
            this.buttonCDUDownloadResults.TabIndex = 11;
            this.buttonCDUDownloadResults.Text = "Download CDU Results";
            this.buttonCDUDownloadResults.UseVisualStyleBackColor = true;
            this.buttonCDUDownloadResults.Click += new System.EventHandler(this.buttonCDUDownloadResults_Click);
            // 
            // buttonCDURunScript
            // 
            this.buttonCDURunScript.Location = new System.Drawing.Point(72, 123);
            this.buttonCDURunScript.Name = "buttonCDURunScript";
            this.buttonCDURunScript.Size = new System.Drawing.Size(200, 23);
            this.buttonCDURunScript.TabIndex = 10;
            this.buttonCDURunScript.Text = "Run CDU Script";
            this.buttonCDURunScript.UseVisualStyleBackColor = true;
            this.buttonCDURunScript.Click += new System.EventHandler(this.buttonCDURunScript_Click);
            // 
            // labelCDUScript
            // 
            this.labelCDUScript.AutoSize = true;
            this.labelCDUScript.ForeColor = System.Drawing.Color.Black;
            this.labelCDUScript.Location = new System.Drawing.Point(69, 78);
            this.labelCDUScript.Name = "labelCDUScript";
            this.labelCDUScript.Size = new System.Drawing.Size(66, 13);
            this.labelCDUScript.TabIndex = 9;
            this.labelCDUScript.Text = "CDU Script :";
            // 
            // comboBoxChooseCDUScript
            // 
            this.comboBoxChooseCDUScript.FormattingEnabled = true;
            this.comboBoxChooseCDUScript.Location = new System.Drawing.Point(151, 75);
            this.comboBoxChooseCDUScript.Name = "comboBoxChooseCDUScript";
            this.comboBoxChooseCDUScript.Size = new System.Drawing.Size(121, 21);
            this.comboBoxChooseCDUScript.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label9.Location = new System.Drawing.Point(109, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Debug - CDU";
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage8.Controls.Add(this.buttonPasswordApply);
            this.tabPage8.Controls.Add(this.textBoxPassword);
            this.tabPage8.Controls.Add(this.textBoxUserName);
            this.tabPage8.Controls.Add(this.LAbelPassword);
            this.tabPage8.Controls.Add(this.labelUserNAme);
            this.tabPage8.Controls.Add(this.labelAdminControl);
            this.tabPage8.Location = new System.Drawing.Point(4, 77);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(346, 443);
            this.tabPage8.TabIndex = 16;
            this.tabPage8.Text = "tabPage8";
            // 
            // buttonPasswordApply
            // 
            this.buttonPasswordApply.Enabled = false;
            this.buttonPasswordApply.Location = new System.Drawing.Point(78, 190);
            this.buttonPasswordApply.Name = "buttonPasswordApply";
            this.buttonPasswordApply.Size = new System.Drawing.Size(199, 23);
            this.buttonPasswordApply.TabIndex = 6;
            this.buttonPasswordApply.Text = "Apply";
            this.buttonPasswordApply.UseVisualStyleBackColor = true;
            this.buttonPasswordApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(177, 133);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(177, 97);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(100, 20);
            this.textBoxUserName.TabIndex = 4;
            this.textBoxUserName.Text = "User";
            this.textBoxUserName.TextChanged += new System.EventHandler(this.textBoxUserName_TextChanged);
            // 
            // LAbelPassword
            // 
            this.LAbelPassword.AutoSize = true;
            this.LAbelPassword.Location = new System.Drawing.Point(75, 136);
            this.LAbelPassword.Name = "LAbelPassword";
            this.LAbelPassword.Size = new System.Drawing.Size(62, 13);
            this.LAbelPassword.TabIndex = 3;
            this.LAbelPassword.Text = "Password : ";
            // 
            // labelUserNAme
            // 
            this.labelUserNAme.AutoSize = true;
            this.labelUserNAme.Location = new System.Drawing.Point(75, 100);
            this.labelUserNAme.Name = "labelUserNAme";
            this.labelUserNAme.Size = new System.Drawing.Size(69, 13);
            this.labelUserNAme.TabIndex = 2;
            this.labelUserNAme.Text = "User Name : ";
            // 
            // labelAdminControl
            // 
            this.labelAdminControl.AutoSize = true;
            this.labelAdminControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdminControl.Location = new System.Drawing.Point(109, 22);
            this.labelAdminControl.Name = "labelAdminControl";
            this.labelAdminControl.Size = new System.Drawing.Size(137, 16);
            this.labelAdminControl.TabIndex = 1;
            this.labelAdminControl.Text = "Administration Control";
            // 
            // FormNodeProperties
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(492, 641);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanelNodePropertiesBottom);
            this.Controls.Add(this.splitContainerNodeProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNodeProperties";
            this.Text = "PTP Node Properties";
            this.splitContainerNodeProperties.Panel1.ResumeLayout(false);
            this.splitContainerNodeProperties.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerNodeProperties)).EndInit();
            this.splitContainerNodeProperties.ResumeLayout(false);
            this.tableLayoutPanelNodePropertiesBottom.ResumeLayout(false);
            this.tabControlNodePropertyPages.ResumeLayout(false);
            this.tabPage0.ResumeLayout(false);
            this.tabPage0.PerformLayout();
            this.groupBoxRX.ResumeLayout(false);
            this.groupBoxRX.PerformLayout();
            this.groupBoxTX.ResumeLayout(false);
            this.groupBoxTX.PerformLayout();
            this.tabPage0_0.ResumeLayout(false);
            this.tabPage0_0.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage0_1.ResumeLayout(false);
            this.tabPage0_1.PerformLayout();
            this.groupBoxManualAMC.ResumeLayout(false);
            this.groupBoxManualAMC.PerformLayout();
            this.tabPage0_2.ResumeLayout(false);
            this.tabPage0_2.PerformLayout();
            this.groupBoxCinrSimulation.ResumeLayout(false);
            this.groupBoxCinrSimulation.PerformLayout();
            this.tabPage0_3.ResumeLayout(false);
            this.tabPage0_3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage0_4.ResumeLayout(false);
            this.tabPage0_4.PerformLayout();
            this.tabPage0_5.ResumeLayout(false);
            this.tabPage0_5.PerformLayout();
            this.groupBoxPHYTBCounters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.GeneralQOS.ResumeLayout(false);
            this.GeneralQOS.PerformLayout();
            this.tabPage1_0.ResumeLayout(false);
            this.tabPage1_0.PerformLayout();
            this.QOSL2.ResumeLayout(false);
            this.QOSL2.PerformLayout();
            this.QOSL3.ResumeLayout(false);
            this.QOSL3.PerformLayout();
            this.tabPage1_1.ResumeLayout(false);
            this.tabPage1_1.PerformLayout();
            this.VLANConfiguration.ResumeLayout(false);
            this.VLANMember.ResumeLayout(false);
            this.VLANMember.PerformLayout();
            this.VLANPortSetting.ResumeLayout(false);
            this.VLANPortSetting.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerNodeProperties;
        private System.Windows.Forms.TreeView treeViewNodeProperties;
        private Dotnetrix.Samples.CSharp.TabControl tabControlNodePropertyPages;
        private System.Windows.Forms.TabPage tabPage0;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelNodePropertiesBottom;
        private System.Windows.Forms.Button buttonPropertiesCancel;
        private System.Windows.Forms.Button buttonPropertiesOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage0_0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage0_1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTipNodeProperties;
        private System.Windows.Forms.TextBox textBoxPhyExpectedThroughputMCS1;
        private System.Windows.Forms.TextBox textBoxPhyRange;
        private System.Windows.Forms.TextBox textBoxPhyDuplexMode;
        private System.Windows.Forms.TextBox textBoxPhyBandwidth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxPhyProfile;
        private System.Windows.Forms.CheckBox checkBoxAMC;
        private System.Windows.Forms.GroupBox groupBoxRX;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBoxTX;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxMemoryAddr;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button buttonMemoryRead;
        private System.Windows.Forms.ListView listViewMemory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox GeneralQOS;
        private System.Windows.Forms.TextBox ShaperMB;
        private System.Windows.Forms.Label ShaperLimit;
        private System.Windows.Forms.ComboBox QOSMethodSelect;
        private System.Windows.Forms.Label QOSMethod;
        private System.Windows.Forms.ComboBox QOSTypeSelect;
        private System.Windows.Forms.Label QOSType;
        private System.Windows.Forms.TabPage tabPage1_0;
        private System.Windows.Forms.GroupBox QOSL2;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox Priority3L;
        private System.Windows.Forms.TextBox Priority3H;
        private System.Windows.Forms.Label Priority3;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox Priority4L;
        private System.Windows.Forms.TextBox Priority4H;
        private System.Windows.Forms.Label Priority4;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox Priority2L;
        private System.Windows.Forms.TextBox Priority2H;
        private System.Windows.Forms.Label Priority2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox Priority1L;
        private System.Windows.Forms.TextBox Priority1H;
        private System.Windows.Forms.Label Priority1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox QOSL3;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox Priority3LIP;
        private System.Windows.Forms.TextBox Priority3HIP;
        private System.Windows.Forms.Label Priority3IP;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox Priority4LIP;
        private System.Windows.Forms.TextBox Priority4HIP;
        private System.Windows.Forms.Label Priority4IP;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox Priority2LIP;
        private System.Windows.Forms.TextBox Priority2HIP;
        private System.Windows.Forms.Label Priority2IP;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox Priority1LIP;
        private System.Windows.Forms.TextBox Priority1HIP;
        private System.Windows.Forms.Label Priority1IP;
        private System.Windows.Forms.TabPage tabPage1_1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tabPage0_2;
        private System.Windows.Forms.GroupBox VLANConfiguration;
        private System.Windows.Forms.GroupBox VLANMember;
        private System.Windows.Forms.Button removeVlanMember;
        private System.Windows.Forms.Label VlanMemPortNum;
        private System.Windows.Forms.RichTextBox EnterVlanMemVlanID;
        private System.Windows.Forms.ComboBox EnterVlanMemPortNum;
        private System.Windows.Forms.Label VlanMemVlanID;
        private System.Windows.Forms.Button AddVlanMember;
        private System.Windows.Forms.GroupBox VLANPortSetting;
        private System.Windows.Forms.Label PortNumberSet;
        private System.Windows.Forms.RichTextBox EnterVLANPPortSet;
        private System.Windows.Forms.ComboBox FilterUnttagedselect;
        private System.Windows.Forms.Label FilterUnttagedSet;
        private System.Windows.Forms.RichTextBox EnterVLANIDPortSet;
        private System.Windows.Forms.Label VLANPPortSet;
        private System.Windows.Forms.ComboBox PortNumPortSet;
        private System.Windows.Forms.Label VLANIDPortSet;
        private System.Windows.Forms.GroupBox groupBoxManualAMC;
        private System.Windows.Forms.ComboBox comboBoxManualMCS0;
        private System.Windows.Forms.Button buttonMemoryWrite;
        private System.Windows.Forms.TextBox textBoxMemoryValue;
        private System.Windows.Forms.Label labelAddrContents;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBoxManualMCS1;
        private System.Windows.Forms.TextBox textBoxManualAmcMaxThru;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBoxCinrSimulation;
        private System.Windows.Forms.Button buttonWriteCinrValues;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox checkBoxCinrSimulation;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox textBoxSimCinr1;
        private System.Windows.Forms.TextBox textBoxSimCinr0;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonConstellationApply;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxConstellationDataFolder;
        private System.Windows.Forms.TextBox textBoxConstellationExecutable;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxConstellationFFT;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox textBoxConstellationUpdateInterval;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogConstellationData;
        private System.Windows.Forms.OpenFileDialog openFileDialogConstellationExecutable;
        private System.Windows.Forms.Button buttonConstellationDataFolder;
        private System.Windows.Forms.Button buttonConstellationExecutable;
        private System.Windows.Forms.TabPage tabPage0_4;
        private System.Windows.Forms.TabPage tabPage0_3;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox textBoxPhyExpectedThroughputMCS8;
        private System.Windows.Forms.TextBox textBoxPhyExpectedThroughputMCS7;
        private System.Windows.Forms.TextBox textBoxPhyExpectedThroughputMCS6;
        private System.Windows.Forms.TextBox textBoxPhyExpectedThroughputMCS5;
        private System.Windows.Forms.TextBox textBoxPhyExpectedThroughputMCS4;
        private System.Windows.Forms.TextBox textBoxPhyExpectedThroughputMCS3;
        private System.Windows.Forms.TextBox textBoxPhyExpectedThroughputMCS2;
        private System.Windows.Forms.Label labelExpectedTputMCS8;
        private System.Windows.Forms.Label labelExpectedTputMCS7;
        private System.Windows.Forms.Label labelExpectedTputMCS6;
        private System.Windows.Forms.Label labelExpectedTputMCS5;
        private System.Windows.Forms.Label labelExpectedTputMCS4;
        private System.Windows.Forms.Label labelExpectedTputMCS3;
        private System.Windows.Forms.Label labelExpectedTputMCS2;
        private System.Windows.Forms.Label labelExpectedTputMCS1;
        private System.Windows.Forms.Label labelMCSDescription;
        private System.Windows.Forms.Label labelMCSUp;
        private System.Windows.Forms.Label labelMCSDown;
        private System.Windows.Forms.Label MCS1;
        private System.Windows.Forms.Label MCS2;
        private System.Windows.Forms.Label MCS3;
        private System.Windows.Forms.Label MCS4;
        private System.Windows.Forms.Label MCS5;
        private System.Windows.Forms.Label MCS6;
        private System.Windows.Forms.Label MCS7;
        private System.Windows.Forms.Label MCS8;
        private System.Windows.Forms.TextBox textBoxMCS8DownThreshold;
        private System.Windows.Forms.TextBox textBoxMCS8UpThreshold;
        private System.Windows.Forms.TextBox textBoxMCS7DownThreshold;
        private System.Windows.Forms.TextBox textBoxMCS7UpThreshold;
        private System.Windows.Forms.TextBox textBoxMCS6DownThreshold;
        private System.Windows.Forms.TextBox textBoxMCS6UpThreshold;
        private System.Windows.Forms.TextBox textBoxMCS5DownThreshold;
        private System.Windows.Forms.TextBox textBoxMCS5UpThreshold;
        private System.Windows.Forms.TextBox textBoxMCS4DownThreshold;
        private System.Windows.Forms.TextBox textBoxMCS4UpThreshold;
        private System.Windows.Forms.TextBox textBoxMCS3DownThreshold;
        private System.Windows.Forms.TextBox textBoxMCS3UpThreshold;
        private System.Windows.Forms.TextBox textBoxMCS2DownThreshold;
        private System.Windows.Forms.TextBox textBoxMCS2UpThreshold;
        private System.Windows.Forms.TextBox textBoxMCS1DownThreshold;
        private System.Windows.Forms.TextBox textBoxMCS1UpThreshold;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonMCSApplyChanges;
        private System.Windows.Forms.Button buttonMCSRestoreToDefault;
        private System.Windows.Forms.Button buttonProfileChangeApply;
        private System.Windows.Forms.TabPage tabPage0_5;
        private System.Windows.Forms.Label labelPHYCounters;
        private System.Windows.Forms.GroupBox groupBoxPHYTBCounters;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label labelUnitType;
        private System.Windows.Forms.Label labelSWVersion;
        private System.Windows.Forms.Label labeluMONVersion;
        private System.Windows.Forms.Label labelUnitControl;
        private System.Windows.Forms.Label labelCPLDVERSION;
        private System.Windows.Forms.ComboBox comboBoxPLLDebug;
        private System.Windows.Forms.Label labelPLLDebug;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Label labelAdminControl;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label LAbelPassword;
        private System.Windows.Forms.Label labelUserNAme;
        private System.Windows.Forms.Label label1DebugUnit;
        private System.Windows.Forms.Label label2DebugUnit;
        private System.Windows.Forms.Label label_PLLDebug;
        private System.Windows.Forms.Button buttonPasswordApply;
        private System.Windows.Forms.Button buttonDebugApply;
        private System.Windows.Forms.TextBox textBoxRunningProfile;
        private System.Windows.Forms.Label labelRunningProfile;
        private System.Windows.Forms.TextBox textBoxUnitType;
        private System.Windows.Forms.TextBox textBoxCPLDVersion;
        private System.Windows.Forms.TextBox textBoxSWVersion;
        private System.Windows.Forms.TextBox textBoxuMONVersion;
        private System.Windows.Forms.CheckBox checkBox_BER_COUNTER_ENABLE;
        private System.Windows.Forms.CheckBox checkBoxMatlabwithChannelEstimation;
        private System.Windows.Forms.ComboBox comboBoxEnablePersistence;
        private System.Windows.Forms.Label labelEnablePersistence;
        private System.Windows.Forms.Label labelExpectedTputMCS11;
        private System.Windows.Forms.TextBox textBoxPhyExpectedThroughputMCS11;
        private System.Windows.Forms.Label labelExpectedTputMCS10;
        private System.Windows.Forms.TextBox textBoxPhyExpectedThroughputMCS10;
        private System.Windows.Forms.Label labelExpectedTputMCS9;
        private System.Windows.Forms.TextBox textBoxPhyExpectedThroughputMCS9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label MCS9;
        private System.Windows.Forms.Label MCS10;
        private System.Windows.Forms.Label MCS11;
        private System.Windows.Forms.TextBox textBoxMCS9UpThreshold;
        private System.Windows.Forms.TextBox textBoxMCS9DownThreshold;
        private System.Windows.Forms.TextBox textBoxMCS10UpThreshold;
        private System.Windows.Forms.TextBox textBoxMCS10DownThreshold;
        private System.Windows.Forms.TextBox textBoxMCS11DownThreshold;
        private System.Windows.Forms.TextBox textBoxMCS11UpThreshold;
        private System.Windows.Forms.CheckBox checkBoxMCSSet2;
        private System.Windows.Forms.TextBox textBoxTransmittionMode;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ComboBox comboBoxDisablePLLDerotation;
        private System.Windows.Forms.Label labelDisablePLLDerotation;
        private System.Windows.Forms.ComboBox comboBoxChannelEstimationFactor;
        private System.Windows.Forms.ComboBox comboBoxCINRFactor;
        private System.Windows.Forms.Label labelChannelEstimationfactor;
        private System.Windows.Forms.Label labelCINRfactor;
        private System.Windows.Forms.ComboBox comboBoxPLLLoopBWB2;
        private System.Windows.Forms.Label labelPLLloopBandWidthB2;
        private System.Windows.Forms.ComboBox comboBoxPLLWorkingMode;
        private System.Windows.Forms.Label labelPLLWorkingMode;
        private System.Windows.Forms.TextBox textBoxRXPRIHypothesis;
        private System.Windows.Forms.Label labelRXPRIHypothesis;
        private System.Windows.Forms.ComboBox comboBoxPLLLoopBWB1;
        private System.Windows.Forms.Label labelPLLloopBandWidthB1;
        private System.Windows.Forms.ComboBox comboBoxSpectralInversion;
        private System.Windows.Forms.Label labelSpectralInversion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonCDUDownloadResults;
        private System.Windows.Forms.Button buttonCDURunScript;
        private System.Windows.Forms.Label labelCDUScript;
        private System.Windows.Forms.ComboBox comboBoxChooseCDUScript;
        private System.Windows.Forms.CheckBox checkBox_Uncoded_BER_COUNTER_ENABLE;
        private System.Windows.Forms.Label labelMCSSetSelect;
        private System.Windows.Forms.ComboBox comboBoxMCSSetSelect;
        private System.Windows.Forms.Button buttonDownloadMemory;
        private System.Windows.Forms.Label labelMemoryDumpDownloadFileName;
        private System.Windows.Forms.TextBox textBoxMemoryDumpDownloadFileName;
        private System.Windows.Forms.Label labellMemoryDumpDownloadSize;
        private System.Windows.Forms.TextBox textBoxMemoryDumpDownloadSize;
        private System.Windows.Forms.Label labelMemoryDumpDownloadAddress;
        private System.Windows.Forms.TextBox textBoxMemoryDumpDownloadAddress;
    }
}