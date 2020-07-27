using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DJScan
{
    /// <summary>
    /// 基本掃描界面3
    /// 1.掃描後的ListBar
    /// 2.顯示ListBar的PictureBox
    /// 3.功能按鈕
    /// </summary>
    public partial class BaseScanUI3 : BaseScanUI2
    {

        public delegate void _delAllIcon();
        public _delAllIcon delAllIcon;

        //public bool ReadonlyMode = false;


        BaseScanUI3(Form winForm) : base(winForm) { }
        /// <summary>
        /// ID 是否自動旋轉
        /// </summary>
        public bool RotateID = false;

        public bool EnableImportBtn
        {
            get
            {
                return buttonImport.Visible;
            }
            set
            {
                buttonImport.Visible = value;
            }
        }

        /// <summary>
        /// BaseScanUI3 建構式
        /// </summary>
        /// <param name="FileMultiSelect">匯入可否多選</param>
        //public BaseScanUI3(bool FileMultiSelect = false)
        public BaseScanUI3(Form winForm, bool FileMultiSelect = false) : base(winForm)
        {
            InitializeComponent();
            if (FileMultiSelect)
            {
                openFileDialog1.Multiselect = true;
                buttonImport.Text = "匯入文件(多選)";
            }
            else
            {
                openFileDialog1.Multiselect = false;
                buttonImport.Text = "匯入文件";
            }

            ucImageView1.delAllIcon = new ucImageView._delAllIcon(delall);

            //ucImageView1.ReadOnlyMode = ReadonlyMode;
        }

        private void delall()
        {

            DJScanCompletList.Clear();
            ScanList.Clear();

            pictureBoxTopDisplay.Image = null;
            if (delAllIcon != null)
            {
                delAllIcon.Invoke();
            }
        }

        /// <summary>
        /// 結束按鈕 委派
        /// </summary>
        public delegate void UnitFinish();
        public UnitFinish delUnitFinish;

        public delegate void UnitCancel();
        public UnitCancel delUnitCancel;

        public void EnableButtonCancel(bool enable = true)
        {
            buttonCancel.Visible = enable;
        }

        void ScanComplete3(object sender)
        {

        }
        private void buttonScan_Click(object sender, EventArgs e)
        {
            logger.Info("BaseScan3.按下 掃描");
            Scan();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            DJScanCompletList = DJScan.BaseUnit.ImageTools.DJCommonUnit.OpenFileDialogImport(openFileDialog1, DJImgEncrypt, DJScanTitle, DJScanCompletList);
            ucImageView1.reloadImageBarFrom(DJScanCompletList, false);
            ScanList = DJScanCompletList;
        }

        public void ReloadFromList(List<string> ImgList)
        {
            logger.Info("BaseScan3.載入 圖檔路徑 清單");
            ucImageView1.reloadImageBarFrom(ImgList, false);
            DJScanCompletList = new List<string>();
            ScanList = new List<string>();
            foreach (var item in ImgList)
            {
                DJScanCompletList.Add(item);
                ScanList.Add(item);
            }
            //DJScanCompletList = ImgList;
            //ScanList = ImgList;
        }

        private void buttonSelectScan_Click(object sender, EventArgs e)
        {
            this.selectScan();
        }


        void ResetImgToAB(List<string> imgList)
        {
            string sideFileName;
            bool boolEven = false;
            string fileName = "";
            if (imgList.Count > 2)
            {
                for (int i = 0; i < imgList.Count; i++)
                {
                    #region add ab file end
                    if (boolEven)
                    {
                        sideFileName = "_B";
                    }
                    else
                    {
                        sideFileName = "_A";
                        fileName = System.IO.Path.GetFileNameWithoutExtension(imgList[i]);

                    }
                    imgList[i] = fileName + sideFileName+".jpg";

                    //imgList[i] = "3";

                    boolEven = !boolEven;
                    #endregion

                }
            }
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {

            List<string> aaa = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                aaa.Add(i.ToString());
            }
            ResetImgToAB(aaa);

            if (delUnitFinish != null)
            {
                delUnitFinish.Invoke();
            }
        }

        public void EnableSelectScan(bool BtnVisable = true)
        {
            buttonSelectScan.Visible = BtnVisable;
        }

        private void BaseScanUI3_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (delUnitCancel != null)
            {
                delUnitCancel.Invoke();
            }
        }
    }
}
