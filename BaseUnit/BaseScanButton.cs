using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DJScan
{
    public partial class BaseScanButton : BaseScan
    {
        public delegate void OnImportEvent(object sender);
        public event OnImportEvent ImportComplete;

        /// <summary>
        /// 結束按鈕 委派
        /// </summary>
        public delegate void UnitFinish();
        public UnitFinish delUnitFinish;
        protected virtual void OnImportComplete(object sender)
        {
            if (ImportComplete != null)
            {
                ImportComplete(sender);
            }
        }

        public BaseScanButton(Form winForm) : base(winForm)
        {
            InitializeComponent();
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            Scan();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            DJScanCompletList = DJScan.BaseUnit.ImageTools.DJCommonUnit.OpenFileDialogImport(openFileDialog1, DJImgEncrypt, DJScanTitle, DJScanCompletList);
            ImportComplete.Invoke(sender);
        }

        private void buttonSelectScan_Click(object sender, EventArgs e)
        {
            this.selectScan();
        }

        private void BaseScanButton_Load(object sender, EventArgs e)
        {
            Form tempForm = new Form();
            //ScanInit(tempForm.Handle, tempForm, "dj");
        }

        private void buttonBarCodeOK_Click(object sender, EventArgs e)
        {
            if (delUnitFinish != null)
            {
                delUnitFinish.Invoke();
            }

        }

        public void EnableSelectScan(bool BtnVisable = true)
        {
            buttonSelectScan.Visible = BtnVisable;
        }
    }
}
