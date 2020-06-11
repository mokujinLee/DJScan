using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using DJImageTools;
namespace DJScan
{
    /// <summary>
    /// 掃描後：左右兩區塊 可拉框選取
    /// 
    /// 目前不能用，匯入
    /// </summary>
    public partial class BaseScanUI4 : BaseScanUI3
    {
        djPictureBox CapturePictureBox = new djPictureBox();
        /// <summary>
        /// 結束按鈕 委派
        /// </summary>
        public delegate void UnitFinish();
        public UnitFinish delUnitFinish;
        public BaseScanUI4(Form winForm) : base(winForm)
        {
            InitializeComponent();
           
            CapturePictureBox.CapTitle = DJScanTitle;
            CapturePictureBox.SetCapture(pictureBoxTopDisplay, pictureBoxTo);



            //設定 抓取顯示 picbox
            //CapturePictureBox.SetCapture(pictureBoxAllSealArea, pictureBoxSelectedSeal, contextMenuStripPicBoxMenu);

            //設定 bar 的顯示委派 (指定 pic)
            //usm.ucImageView1.ClickImageIcon += new DJScan.ucImageView.delClickImageIcon(ImageBarClick);

            //設定 抓取後的委派 
            CapturePictureBox.CaptureFinish += new djPictureBox.dgCapture(addToPathList);

            //usm.delUnitFinish += new DJScan.ucSetManager.UnitFinish(unitFinish);
            //usm.delAutoSet += new DJScan.ucSetManager.AutoSet(AutoSet);
            //usm.buttonBarCodeOK.Visible = true;
            //SealList.Clear();
            //CapturePictureBox.CapTitle = eOpenGlobalVar.公用變數.開戶參數.eSN + "_Seal_";

        }
        private void buttonBarCodeOK_Click(object sender, EventArgs e)
        {
            delUnitFinish.Invoke();
        }



        /// <summary>
        /// 將 PicBox 的PathList 傳入  imv
        /// </summary>
        /// <param name="Path"></param>
        void addToPathList(BaseImg.ImageDetail imgd)
        {
            //ucImageView1.reloadImageBarFrom(CapturePictureBox.CapturePathList);

        }

        void ImageBarClick(System.Drawing.Image clickImage)
        {
            pictureBoxTopDisplay.Image = clickImage;
        }
    }
}
