using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpPcap;

namespace WindowsFormsApplication1
{
    public partial class FormDiscover : Form
    {

        public FormDiscover()
        {
            InitializeComponent();
            this.textBoxAppVersion.Text = String.Format("Version {0}", Application.ProductVersion);
        }

        // Instantiate a SharpPcap object, to ensure the DLL is found.
        // If not found, throw System.IO.FileNotFoundException.
        // If found, but not running, (pcap.devices.Count returns zero), 
        // throws PcapNotRunningException.
        public void testDll()
        {
            // Make sure it is running (at least some network devices found)
            if (PcapConnection.pcap.devices.Count == 0)
            {
                throw new PcapNotRunningException();
            }
         }

        private void FormDiscover_Load(object sender, EventArgs e)
        {
            // The two attributes we expect to get out of this dialog:
            PcapConnection.pcap.device = null;
            PcapConnection.pcap.targetMAC = null;

            // Clear out development items:
            listViewNetworkAdapters.Items.Clear();
            foreach (ICaptureDevice dev in PcapConnection.pcap.devices)
            {
                this.listViewNetworkAdapters.Items.Add(new ListViewItem(PcapConnection.parseDeviceDescription(dev)));
            }
            if (PcapConnection.pcap.devices.Count == 1)
            {
                this.listViewNetworkAdapters.SelectedIndices.Add(0);
                PcapConnection.pcap.device = PcapConnection.pcap.devices[0];
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (PcapConnection.pcap.device == null)
            {
                // Was an adapter selected once, but failed?
                if (listViewNetworkAdapters.SelectedIndices.Count > 0)
                {
                    // Yes... reselect it and try again:
                    // (TODO: Don't bother setting to NULL on error!)
                    PcapConnection.pcap.device = PcapConnection.pcap.devices[listViewNetworkAdapters.SelectedIndices[0]];
                }
                else
                {
                    // For demo, will allow no pcap driver running
                    MessageBox.Show("Please select a network adapter.", "Multiple Adapters Present",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if (PcapConnection.pcap.targetMAC == null)
            {
                MessageBox.Show("Please select the target's MAC address.", "MAC Address",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            bool openedDevice = PcapConnection.pcap.connect();
            if (openedDevice)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
            else
            {
                string selectedMAC = this.comboBoxTargetMAC.Text;
                string selectedAdapter = this.listViewNetworkAdapters.SelectedItems[0].Text;

                MessageBox.Show("The DAN PTP device at " + selectedMAC + " did not respond on adapter " + selectedAdapter,
                    "DAN PTP - Communication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void listViewNetworkAdapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewNetworkAdapters.SelectedIndices.Count == 0)
            {
                // we know this has only been set, never 'connected' at this point in the code.
                // If it had been, we can call .stopDevice() instead, which sets the prop to null.
                PcapConnection.pcap.device = null; 
                return;
            }
            int itemIndex = listViewNetworkAdapters.SelectedIndices[0];
            if (itemIndex > PcapConnection.pcap.devices.Count)
            {
                itemIndex = 0;
            }
            PcapConnection.pcap.device = PcapConnection.pcap.devices[itemIndex];
        }

        private void comboBoxTargetMAC_SelectedIndexChanged(object sender, EventArgs e)
        {
            PcapConnection.pcap.targetMAC = comboBoxTargetMAC.Text;
        }

    }
}
