using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class FormTerminalOptions : Form
    {
        public static FormTerminalOptions TelnetOptioninstance = new FormTerminalOptions();

        public FormTerminalOptions()
            
        {
            InitializeComponent();
            
            //set button names 
            textBoxBTNName1.Text = Properties.Settings.Default.BTNName1;
            textBoxBTNName2.Text = Properties.Settings.Default.BTNName2;
            textBoxBTNName3.Text = Properties.Settings.Default.BTNName3;
            textBoxBTNName4.Text = Properties.Settings.Default.BTNName4;
            textBoxBTNName5.Text = Properties.Settings.Default.BTNName5;
            textBoxBTNName6.Text = Properties.Settings.Default.BTNName6;
            textBoxBTNName7.Text = Properties.Settings.Default.BTNName7;
            textBoxBTNName8.Text = Properties.Settings.Default.BTNName8;
            textBoxBTNName9.Text = Properties.Settings.Default.BTNName9;
            textBoxBTNName10.Text = Properties.Settings.Default.BTNName10;
            textBoxBTNName11.Text = Properties.Settings.Default.BTNName11;
            textBoxBTNName12.Text = Properties.Settings.Default.BTNName12;
            textBoxBTNName13.Text = Properties.Settings.Default.BTNName13;
            textBoxBTNName14.Text = Properties.Settings.Default.BTNName14;
            textBoxBTNName15.Text = Properties.Settings.Default.BTNName15;

            //set button command
            textBoxBTNString1.Text = Properties.Settings.Default.textBoxBTNString1;
            textBoxBTNString2.Text = Properties.Settings.Default.textBoxBTNString2;
            textBoxBTNString3.Text = Properties.Settings.Default.textBoxBTNString3;
            textBoxBTNString4.Text = Properties.Settings.Default.textBoxBTNString4;
            textBoxBTNString5.Text = Properties.Settings.Default.textBoxBTNString5;
            textBoxBTNString6.Text = Properties.Settings.Default.textBoxBTNString6;
            textBoxBTNString7.Text = Properties.Settings.Default.textBoxBTNString7;
            textBoxBTNString8.Text = Properties.Settings.Default.textBoxBTNString8;
            textBoxBTNString9.Text = Properties.Settings.Default.textBoxBTNString9;
            textBoxBTNString10.Text = Properties.Settings.Default.textBoxBTNString10;
            textBoxBTNString11.Text = Properties.Settings.Default.textBoxBTNString11;
            textBoxBTNString12.Text = Properties.Settings.Default.textBoxBTNString12;
            textBoxBTNString13.Text = Properties.Settings.Default.textBoxBTNString13;
            textBoxBTNString14.Text = Properties.Settings.Default.textBoxBTNString14;
            textBoxBTNString15.Text = Properties.Settings.Default.textBoxBTNString15;
        }

        private void buttonExitAndSave_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.BTNName1 = textBoxBTNName1.Text;
            Properties.Settings.Default.BTNName2 = textBoxBTNName2.Text;
            Properties.Settings.Default.BTNName3 = textBoxBTNName3.Text;
            Properties.Settings.Default.BTNName4 = textBoxBTNName4.Text;
            Properties.Settings.Default.BTNName5 = textBoxBTNName5.Text;
            Properties.Settings.Default.BTNName6 = textBoxBTNName6.Text;
            Properties.Settings.Default.BTNName7 = textBoxBTNName7.Text;
            Properties.Settings.Default.BTNName8 = textBoxBTNName8.Text;
            Properties.Settings.Default.BTNName9 = textBoxBTNName9.Text;
            Properties.Settings.Default.BTNName10 = textBoxBTNName10.Text;
            Properties.Settings.Default.BTNName11 = textBoxBTNName11.Text;
            Properties.Settings.Default.BTNName12 = textBoxBTNName12.Text;
            Properties.Settings.Default.BTNName13 = textBoxBTNName13.Text;
            Properties.Settings.Default.BTNName14 = textBoxBTNName14.Text;
            Properties.Settings.Default.BTNName15 = textBoxBTNName15.Text;

            //set button command
            Properties.Settings.Default.textBoxBTNString1 = textBoxBTNString1.Text;
            Properties.Settings.Default.textBoxBTNString2 = textBoxBTNString2.Text;
            Properties.Settings.Default.textBoxBTNString3 = textBoxBTNString3.Text;
            Properties.Settings.Default.textBoxBTNString4 = textBoxBTNString4.Text;
            Properties.Settings.Default.textBoxBTNString5 = textBoxBTNString5.Text;
            Properties.Settings.Default.textBoxBTNString6 = textBoxBTNString6.Text;
            Properties.Settings.Default.textBoxBTNString7 = textBoxBTNString7.Text;
            Properties.Settings.Default.textBoxBTNString8 = textBoxBTNString8.Text;
            Properties.Settings.Default.textBoxBTNString9 = textBoxBTNString9.Text;
            Properties.Settings.Default.textBoxBTNString10 = textBoxBTNString10.Text;
            Properties.Settings.Default.textBoxBTNString11 = textBoxBTNString11.Text;
            Properties.Settings.Default.textBoxBTNString12 = textBoxBTNString12.Text;
            Properties.Settings.Default.textBoxBTNString13 = textBoxBTNString13.Text;
            Properties.Settings.Default.textBoxBTNString14 = textBoxBTNString14.Text;
            Properties.Settings.Default.textBoxBTNString15 = textBoxBTNString15.Text;
            Properties.Settings.Default.Save();
            this.Hide();
        }

        private void buttonExitNoSave_Click(object sender, EventArgs e)
        {
            this.Hide();            
        }

        private void textBoxBTNString1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
