using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DJScan
{
    public partial class BaseScanUI : UserControl
    {
        public BaseScanUI()
        {
            InitializeComponent();

            djscan1.scanInit(this.Handle, Form.ActiveForm, "dj");

            //djscan1.ScanComplete -= new djScan.BaseScan.OnScanCompleteEvent(ScanComplete);
            //djscan1.ScanComplete += new djScan.BaseScan.OnScanCompleteEvent(ScanComplete);
            //djscan1.SetCapture(null, pictureBoxCapture);
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            djscan1.scan();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in openFileDialog1.FileNames)
                {
                    
                    //Common.RunTimeProperty.iFaxSystemProperty.RequestScanList.Add(item);
                }
            }

            //djscan1.ucImageView1.reloadScanBar(Common.RunTimeProperty.iFaxSystemProperty.RequestScanList, ref djscan1.pictureBoxTopDisplay);            
        }

        private void buttonSelectScan_Click(object sender, EventArgs e)
        {
            djscan1.SelectSrc();
        }
    }
}
