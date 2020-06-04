using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace DJScan
{
    /// <summary>
    ///  Set控制元件 (SetList)
    /// 
    /// 1. item 加入 ucImageView
    /// 2.加入一式    
    /// 3.
    /// 
    /// 
    /// 使用方式不夠元件化
    /// 1.path 是用reloadImageBarFrom
    /// 2.detail 是用   ucSetManager1.SetListImgDetail.Add(djPictureBox1.CaptureDetailList);
    /// </summary>
    public partial class ucSetManager : BaseImg
    {
        #region init

        //全部  SealPathList
        public List<List<string>> SetListPath = new List<List<string>>();

        /// <summary>
        /// 包含位置的 ImgDetail List
        /// </summary>
        public List<List<ImageDetail>> SetListImgDetail = new List<List<ImageDetail>>();

        #region 按鈕 委派
        /// <summary>
        /// 結束按鈕 委派
        /// </summary>
        public delegate void UnitFinish();
        public UnitFinish delUnitFinish;

        /// <summary>
        /// 自動式憑 按鈕 委派
        /// </summary>
        public delegate void AutoSet();
        public AutoSet delAutoSet;

        /// <summary>
        /// 新增一式 按鈕 委派
        /// </summary>
        public delegate void delAddOneSet();
        public delAddOneSet _AddOneSet;
        #endregion

        /// <summary>
        /// 改變式數
        /// </summary>
        /// <param name="currentList"></param>
        public delegate void delChangeCurrentSet(List<string> currentList);
        public delChangeCurrentSet ChangeCurrentSet;

        public delegate void delIconMouseIn(Image img);
        public delIconMouseIn IconMouseIn;

        public delegate void delIconMouseOut();
        public delIconMouseOut IconMouseOut;


        /// <summary>
        /// 顯示的 圖檔明細
        /// </summary>
        public BaseImg.ImageDetail DisplayImgDetail;

        /// <summary>
        /// 畫面上顯示的 圖 list
        /// </summary>
        public List<ImageDetail> DisplayImgList;

        #endregion

        public ucSetManager()
        {
            InitializeComponent();
            ucImageView1.deladdImage += new ucImageView.addImage(addImg);

            ucImageView1.uivIconMouseIn += new ucImageView.delIconMouseIn(IcMouseIn);
            ucImageView1.uivIconMouseOut += new ucImageView.delIconMouseOut(IcMouseOut);

            #region 外部自訂元件
            flowLayoutPanelBtn.Visible = !(flowLayoutPanelBtn.Controls.Count == 0);
            flowLayoutPanelUserItem.Visible = !(flowLayoutPanelUserItem.Controls.Count == 0);
            #endregion
        }

        #region Icon 滑鼠 in/out

        private void IcMouseOut()
        {
            if (IconMouseOut != null)
            {
                IconMouseOut.Invoke();
            }
        }

        private void IcMouseIn(Image tempImage)
        {
            if (IconMouseIn != null)
            {
                if (ucImageView1.DisplayImgDetail != null)
                {
                    DisplayImgDetail = ucImageView1.DisplayImgDetail;
                }

                IconMouseIn.Invoke(tempImage);
            }
        }

        #endregion

        /// <summary>
        /// uiv 元件  是否自動縮放
        /// </summary>
        /// <param name="autoSize"></param>
        public void FlowLayoutPanelAutoSize(bool autoSize = false)
        {
            ucImageView1.flowLayoutPanelImageIcon.AutoSize = autoSize;
        }

        #region add
        /// <summary>
        /// 新增  圖檔時 ，新增 一式按鈕打開
        /// </summary>
        private void addImg()
        {
            buttonAddSet.Enabled = true;
        }

        private void buttonOneSet_Click(object sender, EventArgs e)
        {
            if (ucImageView1.imagePathList == null)
            {
                MessageBox.Show("未加入任何 項目");
                return;
            }

            if (ucImageView1.imagePathList.Count > 0)
            {
                AddOneSet(ucImageView1.imagePathList, ucImageView1.imgDetailList);
            }

            if (_AddOneSet != null)
            {
                _AddOneSet.Invoke();
            }

        }

        /// <summary>
        /// 儲存一式
        /// </summary>
        /// <param name="PathList"></param>
        /// <param name="imgDetailList"></param>
        void AddOneSet(List<string> PathList, List<ImageDetail> imgDetailList)
        {    //新增式號，抓章 (可重覆)                
            PathList = new List<string>(PathList.ToArray());
            imgDetailList = new List<ImageDetail>(imgDetailList.ToArray());

            if (SetListPath.Count <= ((int)numericUpDown1.Value - 1))
            {
                SetListImgDetail.Add(imgDetailList);
                SetListPath.Add(PathList);
            }
            else
            {
                //第一式
                SetListImgDetail[(int)numericUpDown1.Value - 1] = imgDetailList;
                SetListPath[(int)numericUpDown1.Value - 1] = PathList;
            }


            ucImageView1.clearBar();
            numericUpDown1.Maximum = SetListPath.Count + 1;
            numericUpDown1.Value = numericUpDown1.Maximum;
            labelMaxSealSet.Text = @" /" + numericUpDown1.Maximum.ToString();
            buttonAddSet.Enabled = false;
            toolStripMenuItemDelOneSet.Enabled = (SetListPath.Count > 0);
        }

        public void AddImgDetail(BaseImg.ImageDetail imd)
        {
            ucImageView1.AddImgDetail(imd);
        }

        public void AddImgPath(string imgp)
        {
            ucImageView1.AddImgPath(imgp);
        }

        #endregion

        /// <summary>
        /// 由 上面 數字按鈕 控制 丟入 uiv 的 圖檔list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ucImageView1.clearBar();
            List<string> CurrentPathList = new List<string>();
            if (SetListPath.Count >= (int)numericUpDown1.Value)
            {
                CurrentPathList = new List<string>(SetListPath[(int)numericUpDown1.Value - 1].ToArray());

                ucImageView1.reloadImageBarFrom(CurrentPathList, false);
                ucImageView1.imgDetailList = new List<ImageDetail>(SetListImgDetail[(int)numericUpDown1.Value - 1].ToArray()); ;
                if (ChangeCurrentSet != null)
                {
                    ChangeCurrentSet.Invoke(CurrentPathList);
                }
            }
            buttonAddSet.Enabled = false;
        }

        void EnableOkBtn()
        {
            buttonBarCodeOK.Visible = true;
        }

        private void buttonBarCodeOK_Click(object sender, EventArgs e)
        {
            if (ucImageView1.imagePathList == null) return;
            if (ucImageView1.imagePathList.Count > 0)
            {
                AddOneSet(ucImageView1.imagePathList, ucImageView1.imgDetailList);
            }
            if (delUnitFinish != null)
            {
                delUnitFinish.Invoke();
            }
        }

        private void buttonAutoSet_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(SetList.Count.ToString());
            if (delAutoSet != null)
            {
                delAutoSet.Invoke();
            }
        }

        private void toolStripMenuItemDelOneSet_Click(object sender, EventArgs e)
        {
            if ((numericUpDown1.Value - 1) > 0)
            {
                if (SetListPath.Count >= numericUpDown1.Value)
                {
                    SetListPath.RemoveAt(Convert.ToInt32(numericUpDown1.Value - 1));
                    SetListImgDetail.RemoveAt(Convert.ToInt32(numericUpDown1.Value - 1));
                    labelMaxSealSet.Text = @" /" + (numericUpDown1.Maximum - 1).ToString();
                }
                ucImageView1.clearBar();
                //ucImageView1.imagePathList.Clear();
                numericUpDown1.Maximum = numericUpDown1.Maximum - 1;
            }
        }

        private void 全部清除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SetListPath.Count > 0)
            {
                SetListPath.Clear();
                SetListImgDetail.Clear();
                labelMaxSealSet.Text = @" /1";
                ucImageView1.clearBar();
                //ucImageView1.imagePathList.Clear();
                numericUpDown1.Maximum = 1;
            }

        }
        //todo:匯入文件檔名若重覆，需從 djscan import 按鈕修正

        #region 加入 自訂元件 
        public void addUserItem(Control ct)
        {
            flowLayoutPanelUserItem.Controls.Add(ct);

            flowLayoutPanelUserItem.Visible = !(flowLayoutPanelUserItem.Controls.Count == 0);
        }

        public void addUserBtn(Button bt)
        {
            flowLayoutPanelUserItem.Controls.Add(bt);
            flowLayoutPanelBtn.Visible = !(flowLayoutPanelBtn.Controls.Count == 0);
        }
        #endregion

        private void contextMenuStripAddition_Opening(object sender, CancelEventArgs e)
        {
            if (IconMouseOut != null)
            {
                IconMouseOut.Invoke();
            }
        }
    }
}
