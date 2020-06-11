using System.Windows.Forms;

namespace DJScan
{
    /// <summary>
    /// 基本掃描界面，掃描後的ListBar，顯示ListBar的PictureBox
    /// 可(需)自訂和 功能按鈕
    /// </summary>
    public partial class BaseScanUI2 : BaseScanUI1
    {
        public BaseScanUI2(Form winForm) : base(winForm)
        {
            InitializeComponent();
            //this.ScanComplete += new OnScanCompleteEvent(ScanComplete2);
            ucImageView1.uivIconMouseIn += new DJScan.ucImageView.delIconMouseIn(ImageBarClick);

            ucImageView1.delAllIcon = new ucImageView._delAllIcon(delall);
        }

        private void delall()
        {
            pictureBoxTopDisplay.Image = null;
            //if (delAllIcon != null)
            //{
            //    delAllIcon.Invoke();
            //}
        }


        void ScanComplete2(object sender)
        {
            
        }

        void ImageBarClick(System.Drawing.Image clickImage)
        {
            pictureBoxTopDisplay.Image = clickImage;
        }
    }
}
