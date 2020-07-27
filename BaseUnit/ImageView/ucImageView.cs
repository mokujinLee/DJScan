using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using djFileAccess;
using log4net;
using log4net.Config;
//using ScalePictureBoxLibrary;
namespace DJScan
{
    /// <summary>
    /// 使用方式：
    /// 1.將 pathList 傳入  reloadScanBar
    /// 2.AddImgDetail  : 加入 一 圖檔明細
    /// 3.AddImgPath   : 加入 一 圖檔路徑
    /// 4.直接對 imagePathList 對存取
    /// </summary>
    public partial class ucImageView : UserControl
    {

        protected static readonly ILog logger = LogManager.GetLogger(typeof(UserControl));
        ucImageView()
        {
            InitializeComponent();
            XmlConfigurator.Configure(new System.IO.FileInfo("./log4net.config"));
        }

        #region 參數
        //PictureBox pictureBoxDisplay;
        //System.Drawing.Image DisplayImage;

        enumIconType IconType;


        /// <summary>
        /// 顯示此list 到畫面上
        /// </summary>
        public List<string> imagePathList = new List<string>();

        /// <summary>
        /// imagePathList  圖檔的明細資料
        /// </summary>
        public List<BaseImg.ImageDetail> imgDetailList = new List<BaseImg.ImageDetail>();

        /// <summary>
        /// 檢視模式：不顯示刪除功能
        /// </summary>
        //public bool ReadOnlyMode = false;

        private bool ivReadOnly = false;
        public bool ReadOnlyMode
        {
            get
            {
                return ivReadOnly;
            }
            set
            {
                ivReadOnly = value;

                #region 唯讀模式 不可刪除
                if (value)
                {
                    foreach (var item in flowLayoutPanelImageIcon.Controls)
                    {
                        (item as Control).ContextMenuStrip = null;
                    }
                } 
                #endregion
            }
        }


        string LastFile = string.Empty;

        string CurrentPrintFile;

        /// <summary>
        /// 委派 點擊ImageIcon
        /// </summary>
        /// <param name="DownLoadFile"></param>
        public delegate void delIconMouseIn(System.Drawing.Image tempImage);
        public delIconMouseIn uivIconMouseIn;

        //public delegate void delIconMouseInGetImgDetail(BaseImg.ImageDetail imgDetail);
        //public delIconMouseIn uivIconMouseInGetImgDetail;

        public delegate void delIconMouseOut();
        public delIconMouseOut uivIconMouseOut;

        /// <summary>
        /// 加入img 委派
        /// </summary>
        public delegate void addImage();
        public addImage deladdImage;

        public delegate void _delAllIcon();
        public _delAllIcon delAllIcon;

        /// <summary>
        /// 載入圖檔 是否有加密
        /// </summary>
        public bool LoadImageDecrypt = false;

        /// <summary>
        /// 顯示的 圖檔明細
        /// </summary>
        public BaseImg.ImageDetail DisplayImgDetail;


        /// <summary>
        /// 是否 先載入 icon 縮圖
        /// 
        /// 大圖時影響速度
        /// </summary>
        public bool IconLoadImage = true;
        #endregion


        #region init

        public ucImageView(enumIconType _IconType = enumIconType.PictureBox)
        {
            InitializeComponent();
            //toolStripMenuItemDelOne.Click += new EventHandler(delImage);
            //ToolStripMenuItemDelAll.Click += new EventHandler(delImage);
            IconType = _IconType;
        }
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucImageView));

        #endregion


        #region 元件對外函式

        /// <summary>
        /// Icon 來源路徑 顯示 
        /// </summary>
        public bool boolShowIconPathHint { get; set; }

        /// <summary>
        /// 載入顯示列(載入string List, 連動picBox)
        /// 只能載入加密 圖檔
        /// </summary>
        public void reloadImageBarFrom(List<string> allImageList, bool AppendItem = false)
        {
            if (AppendItem)
            {
                if (imagePathList == null) imagePathList = new List<string>();
                imagePathList.AddRange(allImageList);

            }
            else
            {
                imagePathList = (allImageList);

            }
            reloadImageBar();
            //todo:防止連續執行

            if (deladdImage != null)
            {
                deladdImage.Invoke();
            }
        }

        public void AddImgDetail(BaseImg.ImageDetail id)
        {
            imgDetailList.Add(id);
            imagePathList.Add(id.Path);
            reloadImageBar(false);
            //todo:防止連續執行

            if (deladdImage != null)
            {
                deladdImage.Invoke();
            }
        }

        /// <summary>
        /// 加入  img path 顯示
        /// </summary>
        /// <param name="path"></param>
        public void AddImgPath(string path)
        {
            imagePathList.Add(path);
            reloadImageBar(false);
            //todo:防止連續執行

            if (deladdImage != null)
            {
                deladdImage.Invoke();
            }
        }

        public FlowDirection IconFlowDirection
        {
            get { return flowLayoutPanelImageIcon.FlowDirection; }
            set { flowLayoutPanelImageIcon.FlowDirection = value; }
        }

        public enum enumIconType { CheckBox, PictureBox, SuperPictureBox }
        #endregion

        #region 圖列點擊委派
        public delegate void dgImageChecked(CheckBox Sender);
        public dgImageChecked imageChecked;

        /// <summary>
        /// delegate InnerTarget PictureBox 滑鼠點選事件
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        public delegate void InnerTargetMouseClickEvent(MouseEventArgs e);
        /// <summary>
        /// InnerTarget PictureBox 滑鼠點選事件
        /// </summary>
        private event InnerTargetMouseClickEvent m_innertargetmouseclickevent = null;
        #endregion

        #region 載入顯示列

        /// <summary>
        /// 載入顯示列 from imageListPath
        /// </summary>
        public bool reloadImageBar(bool displayImg = true)
        {

            bool AllImgExist = true;
            if (imagePathList == null) return false;
            flowLayoutPanelImageIcon.Controls.Clear();
            foreach (var item in imagePathList)
            {
                if (item.Length > 0)
                {
                    addScanButton(item);
                }
                if (!File.Exists(item))
                {
                    AllImgExist = false;
                }

            }

            #region 顯示
            if ((displayImg) && (flowLayoutPanelImageIcon.Controls.Count > 0))
            {
                displayImage(flowLayoutPanelImageIcon.Controls[0]);
            }
            #endregion

            return AllImgExist;
        }

        #endregion

        #region 刪除圖示
        private void contextMenuStripDel_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStripDel.Tag = (sender as ContextMenuStrip).SourceControl.Text;
        }

        ///// <summary>
        ///// 刪除指定圖
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void delImage(object sender, EventArgs e)
        //{


        //}

        ///// <summary>
        ///// 元件內部刪除所有圖
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void delAllImage(object sender, EventArgs e)
        //{
        //    this.Controls.Clear();
        //}

        /// <summary>
        /// 清除顯示列
        /// </summary>
        public void clearBar()
        {
            flowLayoutPanelImageIcon.Controls.Clear();
            if (imagePathList != null)
            {
                imagePathList.Clear();
                imgDetailList.Clear();
            }

        }

        private void toolStripMenuItemDelOne_Click(object sender, EventArgs e)
        {
            string FileName = contextMenuStripDel.Tag.ToString();
            imagePathList.Remove(FileName);

            //if (File.Exists(FileName)) File.Delete(FileName);
            //todo:1.刪檔時因檢視中而被鎖住
            //2.分為刪檔和清除：刪檔、清除只清icon

            reloadImageBar();
        }

        private void ToolStripMenuItemDelAll_Click(object sender, EventArgs e)
        {
            clearBar();
            //todo:清除所有list檔案,清picbox
            reloadImageBar();
            if (delAllIcon != null)
            {
                delAllIcon.Invoke();
            }
        }

        #endregion

        #region 列印顯示列

        /// <summary>
        /// 列印顯示列所有圖
        /// </summary>
        public void PrintAllImage()
        {
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            foreach (Control item in this.Controls)
            {
                CurrentPrintFile = item.Text;
                if ((item as CheckBox).Checked)
                {
                    printDocument1.Print();
                }
            }
        }

        /// <summary>
        /// 列印指定List圖
        /// </summary>
        public void PrintListImage(List<string> PrintList)
        {
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            foreach (string item in PrintList)
            {
                CurrentPrintFile = item;
                printDocument1.Print();
            }
        }

        void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap myBitmap;
            myBitmap = new Bitmap(CurrentPrintFile);
            e.Graphics.DrawImage(myBitmap, 0, 0);
        }

        #endregion

        public void SelectAll()
        {
            bool SetStatus = true;
            if (Controls.Count > 0)
            {
                SetStatus = !(Controls[0] as CheckBox).Checked;
            }
            foreach (Control item in this.Controls)
            {

                (item as CheckBox).Checked = SetStatus;
            }
        }


        #region 目前使用中  1501021

        /// <summary>
        /// 新增CheckBox顯示圖示 到ListBar : from string
        /// addCheckBoxItem.Name = 圖檔路徑;
        /// addCheckBoxItem.Text = 載入狀態;        
        /// </summary>
        /// <param name="ImagePath"></param>
        private void addScanButton(string ImagePath)
        {
            if (File.Exists(ImagePath))
            {
                UpdateIcon(ImagePath);// 若用x64 complie 會有問題
            }
            else
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucImageView));
                CheckBox AddImgIcon = new CheckBox();
                AddImgIcon.Text = "unLoad";
                AddImgIcon.Name = ImagePath;
            }
        }

        private void InnerTargetMouseClick(MouseEventArgs e)
        {
            MessageBox.Show("Left");
        }


        /// <summary>
        /// 只更新  新加入的 圖示
        /// </summary>
        /// <param name="allImageList"></param>
        public void UpadatScanButton(string ImagePath)
        {
            Control[] ctl = flowLayoutPanelImageIcon.Controls.Find(ImagePath, true);
            if (ctl.Length > 0)
            {
                flowLayoutPanelImageIcon.Controls.Remove(ctl[0]);
                addScanButton(ImagePath);
            }

            if (flowLayoutPanelImageIcon.Controls.Count > 0)
            {
                displayImage(flowLayoutPanelImageIcon.Controls[0]);
            }

        }


        /// <summary>
        /// 更新  新加入的 圖示
        /// </summary>
        /// <param name="allImageList"></param>
        public void BarRefresh(List<string> ImageList)
        {
            foreach (string ImagePath in ImageList)
            {

                if (File.Exists(ImagePath))
                {
                    Control[] ctl = flowLayoutPanelImageIcon.Controls.Find(ImagePath, true);
                    if (ctl.Length > 0)
                    {
                        CheckBox addCheckBoxItem = (CheckBox)ctl[0];
                        #region Image Exist
                        if (addCheckBoxItem.Text == "unLoad")
                        {
                            UpdateIcon(ImagePath);
                        }

                        #endregion
                    }
                }
            }

            if (flowLayoutPanelImageIcon.Controls.Count > 0)
            {
                displayImage(flowLayoutPanelImageIcon.Controls[0]);
            }
        }

        /// <summary>
        /// 更新 icon, 
        /// 載入圖檔路徑,縮圖
        /// </summary>
        /// <param name="ImagePath"></param>
        /// <param name="LoadImage"></param>
        private void UpdateIcon(string ImagePath)
        {
            logger.Info(ImagePath + ":設定 右列圖示 ");

            try
            {
                logger.Info("BaseScan1.掃描 完成,載入 右方顯示列 ");
                #region 解密
                System.Threading.Thread.Sleep(10);//防止收到委派時，檔案還未被釋放
                System.Drawing.Image i1 = null;
                logger.Info(ImagePath + ":載入 右方顯示列 ");
                if (IconLoadImage)
                {
                    if (LoadImageDecrypt)
                    {
                        try
                        {
                            i1 = Image.FromStream(djED.DecryptMemoryStream(ImagePath));
                        }
                        catch (Exception)
                        {

                            i1 = ((System.Drawing.Image)(resources.GetObject("checkBoxEmpty.BackgroundImage")));
                        }

                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream();
                        using (FileStream file = new FileStream(ImagePath, FileMode.Open, FileAccess.Read))
                        {
                            byte[] bytes = new byte[file.Length];
                            file.Read(bytes, 0, (int)file.Length);
                            ms.Write(bytes, 0, (int)file.Length);
                        }
                        i1 = Image.FromStream(ms);

                    }
                }
                logger.Info(ImagePath + ":載入 右方顯示列 完成");
                #endregion

                #region ImgIcon屬性
                Control AddImgIcon;

                switch (IconType)
                {
                    case enumIconType.CheckBox:
                        CheckBox TmpChk = new CheckBox();
                        if (i1 == null)
                        {
                            TmpChk.BackColor = Color.Black;
                        }
                        else
                        {
                            TmpChk.Image = i1.GetThumbnailImage(52, 52, null, new IntPtr());
                        }

                        TmpChk.CheckedChanged += new EventHandler(checkBoxEmpty_CheckedChanged);
                        TmpChk.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
                        TmpChk.Size = new System.Drawing.Size(52, 52);
                        TmpChk.Font = new System.Drawing.Font("標楷體", 1f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                        AddImgIcon = TmpChk;
                        break;

                    case enumIconType.PictureBox:

                        PictureBox TmpPic = new PictureBox();
                        if (i1==null)
                        {
                            TmpPic.BackColor = Color.Black;
                        }
                        else
                        {
                            TmpPic.Image = i1.GetThumbnailImage(52, 52, null, new IntPtr());
                        }
                                                  
                        TmpPic.Size = new System.Drawing.Size(52, 52);
                        TmpPic.MouseHover += AddImgIcon_MouseHover;
                        TmpPic.MouseLeave += TmpPic_MouseLeave;
                        AddImgIcon = TmpPic;
                        break;

                    case enumIconType.SuperPictureBox:
                        PictureBox TmpSpb = new PictureBox();
                        AddImgIcon = TmpSpb;
                        break;

                    default:
                        Console.WriteLine(IconType);
                        AddImgIcon = new Control();
                        break;
                }

                AddImgIcon.Text = "";
                AddImgIcon.Name = ImagePath;
                AddImgIcon.MouseEnter += new EventHandler(ImgIcon_MouseEnter);
                AddImgIcon.MouseLeave += new EventHandler(checkBoxEmpty_MouseLeave);


                if (!ReadOnlyMode) AddImgIcon.ContextMenuStrip = contextMenuStripDel;
                flowLayoutPanelImageIcon.Controls.Add(AddImgIcon);
                #endregion
            }
            catch (Exception )
            {
                //Console.WriteLine(e.ToString());
                logger.Error(ImagePath + "載入 icon 失敗 ");
            }
            logger.Info(ImagePath + ":設定 右列圖示 完成");
        }

        private void TmpPic_MouseLeave(object sender, EventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.None;
        }

        private void AddImgIcon_MouseHover(object sender, EventArgs e)
        {
            (sender as PictureBox).BorderStyle = BorderStyle.Fixed3D;
        }


        private void flowLayoutPanel1_DoubleClick(object sender, EventArgs e)
        {
            reloadImageBar();

        }

        /// <summary>
        /// 顯示至 指定 pictureBox        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void displayImage(object sender)
        {
            if ((sender as Control).Text != "unLoad")
            {

                if (((sender as Control).Name.Length > 0) && (File.Exists((sender as Control).Name)))
                {

                    Image tempImage;
                    #region 加密
                    if (LoadImageDecrypt)
                    {
                        try
                        {
                            tempImage = Image.FromStream(djED.DecryptMemoryStream((sender as Control).Name));
                        }
                        catch (Exception)
                        {

                            tempImage = ((System.Drawing.Image)(resources.GetObject("checkBoxEmpty.BackgroundImage")));
                        }

                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream();
                        using (FileStream file = new FileStream((sender as Control).Name, FileMode.Open, FileAccess.Read))
                        {
                            byte[] bytes = new byte[file.Length];
                            file.Read(bytes, 0, (int)file.Length);
                            ms.Write(bytes, 0, (int)file.Length);
                        }
                        tempImage = Image.FromStream(ms);
                        //tempImage = Image.FromFile((sender as Control).Name);
                    }
                    #endregion


                    //Console.WriteLine(DisplayImgDetail.xywh);
                    //Console.WriteLine(DisplayImgDetail.Path);
                    //MessageBox.Show(DisplayImgDetail.xywh);
                    if (uivIconMouseIn != null)
                    {
                        DisplayImgDetail = GetImgDetail((sender as Control).Name);
                        uivIconMouseIn.Invoke(tempImage);
                    }

                }
            }

            if (boolShowIconPathHint)
            {
                toolTip1.SetToolTip((sender as Control), (sender as Control).Name);
            }

        }

        public BaseImg.ImageDetail GetImgDetail(string path)
        {
            BaseImg.ImageDetail imgD = new BaseImg.ImageDetail();
            foreach (var item in imgDetailList)
            {

                if (item.Path == path)
                {
                    imgD = item;
                }
            }

            return imgD;
        }

        private void ImgIcon_MouseEnter(object sender, EventArgs e)
        {
            displayImage(sender);
        }


        #endregion
        #region mouse event
        public InnerTargetMouseClickEvent _InnerTargetMouseClickEvent
        {
            set
            {
                m_innertargetmouseclickevent = value;
            }
            get
            {
                return m_innertargetmouseclickevent;
            }
        }

        #endregion
        private void checkBoxEmpty_CheckedChanged(object sender, EventArgs e)
        {
            if (imageChecked != null)
            {
                imageChecked.Invoke((CheckBox)sender);
            }
        }

        private void checkBoxEmpty_MouseLeave(object sender, EventArgs e)
        {
            if (uivIconMouseOut != null)
            {
                uivIconMouseOut.Invoke();
            }
        }
    }
}
