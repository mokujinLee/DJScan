using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DJScan
{
    /// <summary>
    /// 基本掃描界面，只有掃描後的ListBar
    /// 可(需)自訂PictureBox 和 功能按鈕
    /// </summary>
    public partial class BaseScanUI1 : BaseScan
    {
        /// <summary>
        /// 基本 掃描元件 對外的 掃描結果List
        /// </summary>
        public List<string> ScanList;

        public BaseScanUI1(Form winForm) : base(winForm)
        {
            InitializeComponent();
            Form tempfomr = new Form();
            //ScanInit(tempfomr.Handle, tempfomr, "dj");
            ScanComplete += new OnScanCompleteEvent(scanCompleteByPath);


        }

        /// <summary>
        /// 設定圖檔是否加解密
        /// </summary>
        public void SetImgEncrypt(bool ImgEncrypt)
        {
            DJImgEncrypt = ImgEncrypt;
            ucImageView1.LoadImageDecrypt = DJImgEncrypt;
        }

        /// <summary>
        /// 以路徑存放掃描圖檔
        /// </summary>
        /// <param name="sender"></param>
        void scanCompleteByPath(object sender)
        {
            logger.Info("BaseScan1.掃描 完成,載入 右方顯示列 ");
            ucImageView1.reloadImageBarFrom(DJScanCompletList, true);
            ScanList = ucImageView1.imagePathList;
            logger.Info("BaseScan1.載入 右方顯示列 完成");

        }

        /// <summary>
        /// 直接scan,  直接繼承不用寫?
        /// </summary>
        //public void Scan()
        //{
        //    Scan();
        //}

        private void BaseScanUI1_Load(object sender, EventArgs e)
        {

        }
    }
}
