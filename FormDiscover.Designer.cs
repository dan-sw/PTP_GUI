namespace WindowsFormsApplication1
{
    partial class FormDiscover
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "192.168.1.55",
            "Simulated network adapter"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "0.0.0.0",
            "(if you see this, you didn\'t run pcap)"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDiscover));
            this.comboBoxTargetMAC = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxAppTitle = new System.Windows.Forms.TextBox();
            this.textBoxAppVersion = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.listViewNetworkAdapters = new System.Windows.Forms.ListView();
            this.columnHeaderIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // comboBoxTargetMAC
            // 
            this.comboBoxTargetMAC.FormattingEnabled = true;
            this.comboBoxTargetMAC.Items.AddRange(new object[] {
            "02-DE-AD-BE-EF-05",
            "00-11-22-33-00-05",
            "00-55-7b-b5-7d-05"});
            this.comboBoxTargetMAC.Location = new System.Drawing.Point(147, 333);
            this.comboBoxTargetMAC.Name = "comboBoxTargetMAC";
            this.comboBoxTargetMAC.Size = new System.Drawing.Size(192, 21);
            this.comboBoxTargetMAC.TabIndex = 1;
            this.comboBoxTargetMAC.Text = "Select Target MAC";
            this.comboBoxTargetMAC.SelectedIndexChanged += new System.EventHandler(this.comboBoxTargetMAC_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 192);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(492, 28);
            this.textBox1.TabIndex = 2;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Select a local network adapter and the MAC address \r\nof the target.   Click \'Conn" +
                "ect\' when ready.";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxAppTitle
            // 
            this.textBoxAppTitle.BackColor = System.Drawing.Color.White;
            this.textBoxAppTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAppTitle.Enabled = false;
            this.textBoxAppTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAppTitle.Location = new System.Drawing.Point(12, 125);
            this.textBoxAppTitle.Multiline = true;
            this.textBoxAppTitle.Name = "textBoxAppTitle";
            this.textBoxAppTitle.ReadOnly = true;
            this.textBoxAppTitle.Size = new System.Drawing.Size(492, 28);
            this.textBoxAppTitle.TabIndex = 3;
            this.textBoxAppTitle.TabStop = false;
            this.textBoxAppTitle.Text = "PTP Node Configuration and Monitor\r\n";
            this.textBoxAppTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxAppVersion
            // 
            this.textBoxAppVersion.BackColor = System.Drawing.Color.White;
            this.textBoxAppVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAppVersion.Enabled = false;
            this.textBoxAppVersion.Location = new System.Drawing.Point(12, 156);
            this.textBoxAppVersion.Multiline = true;
            this.textBoxAppVersion.Name = "textBoxAppVersion";
            this.textBoxAppVersion.ReadOnly = true;
            this.textBoxAppVersion.Size = new System.Drawing.Size(492, 18);
            this.textBoxAppVersion.TabIndex = 4;
            this.textBoxAppVersion.TabStop = false;
            this.textBoxAppVersion.Text = "Version from Assembly";
            this.textBoxAppVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(16, 370);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(488, 16);
            this.textBox2.TabIndex = 6;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Copyright 2011, Design Art Networks.";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(376, 328);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(86, 28);
            this.buttonConnect.TabIndex = 7;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // listViewNetworkAdapters
            // 
            this.listViewNetworkAdapters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIP,
            this.columnHeaderName});
            this.listViewNetworkAdapters.FullRowSelect = true;
            this.listViewNetworkAdapters.GridLines = true;
            this.listViewNetworkAdapters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewNetworkAdapters.HideSelection = false;
            this.listViewNetworkAdapters.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listViewNetworkAdapters.LabelWrap = false;
            this.listViewNetworkAdapters.Location = new System.Drawing.Point(12, 231);
            this.listViewNetworkAdapters.MultiSelect = false;
            this.listViewNetworkAdapters.Name = "listViewNetworkAdapters";
            this.listViewNetworkAdapters.Size = new System.Drawing.Size(492, 91);
            this.listViewNetworkAdapters.TabIndex = 8;
            this.listViewNetworkAdapters.UseCompatibleStateImageBehavior = false;
            this.listViewNetworkAdapters.View = System.Windows.Forms.View.Details;
            this.listViewNetworkAdapters.SelectedIndexChanged += new System.EventHandler(this.listViewNetworkAdapters_SelectedIndexChanged);
            // 
            // columnHeaderIP
            // 
            this.columnHeaderIP.Text = "IP Address";
            this.columnHeaderIP.Width = 110;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 400;
            // 
            // FormDiscover
            // 
            this.AcceptButton = this.buttonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.DAN_logo_to_paint;
            this.ClientSize = new System.Drawing.Size(516, 398);
            this.Controls.Add(this.listViewNetworkAdapters);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBoxAppVersion);
            this.Controls.Add(this.textBoxAppTitle);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBoxTargetMAC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDiscover";
            this.Text = "DAN PMC";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormDiscover_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTargetMAC;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxAppTitle;
        private System.Windows.Forms.TextBox textBoxAppVersion;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ListView listViewNetworkAdapters;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderIP;
    }
}