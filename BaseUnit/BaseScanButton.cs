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

        public BaseScanButton()
        {
            InitializeComponent();
        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            Scan();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            #region bak
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //if (DJScanCompletList == null) DJScanCompletList = new List<string>();
            //DJScanCompletList.Clear();
            //string ImportPath = Application.StartupPath + @"\temp\";
            //if (!System.IO.Directory.Exists(ImportPath))
            //{
            //    System.IO.Directory.CreateDirectory(ImportPath);
            //}

            //bool boolEven = false;
            //string LastFileName = "";

            //foreach (string item in openFileDialog1.FileNames)
            //{
            //string desFileName = ImportPath + DJScanTitle + DateTime.Now.ToString("_yyMMddHHmmssffff") + System.IO.Path.GetExtension(item);

            //if (boolEven)
            //{
            //    desFileName = ImportPath + DJScanTitle + LastFileName + "_B" + System.IO.Path.GetExtension(item);
            //}
            //else
            //{
            //    LastFileName = DateTime.Now.ToString("_yyMMddHHmmssffff");
            //    desFileName = ImportPath + DJScanTitle + LastFileName + "_A" + System.IO.Path.GetExtension(item);
            //    System.Threading.Thread.Sleep(1);
            //}

            //System.IO.File.Copy(item, desFileName, true);
            //DJScanCompletList.Add(desFileName);
            ////todo:匯入 若檔名重覆會overwrite,重新產生檔名?
            //boolEven = !boolEven;
            //}
            //}

            #endregion

            DJScanCompletList = DJScan.BaseUnit.ImageTools.DJCommonUnit.OpenFileDialogImport(openFileDialog1, DJImgEncrypt, DJScanTitle, DJScanCompletList);
            ImportComplete.Invoke(sender);
        }

        private void buttonSelectScan_Click(object sender, EventArgs e)
        {
            this.SelectSrc();
        }

        /// <summary>
        /// 直接Scan
        /// </summary>
        public void Scan()
        {
            startScan();
        }

        private void BaseScanButton_Load(object sender, EventArgs e)
        {
            Form tempForm = new Form();
            ScanInit(tempForm.Handle, tempForm, "dj");
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
