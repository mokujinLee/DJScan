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
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            djscan1.scan();
        }

        private void buttonSelectScan_Click(object sender, EventArgs e)
        {
            djscan1.SelectSrc();
        }
    }
}
