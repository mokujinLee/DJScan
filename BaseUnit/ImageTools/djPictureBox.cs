using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using DJScan;
using System.Collections.Generic;

namespace DJImageTools
{
    /// <summary>
    /// 1.包含 ImageDetail的 pic box 元件
    /// 2.框選功能
    /// 
    /// x.框選指定範圍後，會將框選圖加入list  
    /// (更改為，此元件  只記錄 一次完成的動作，所有list 集中到 list 管理元件 setManager 中)
    /// 
    /// 來源.sizeMode = zoom,否則比例會跑掉
    /// </summary>
    public partial class djPictureBox : System.Windows.Forms.PictureBox
    {
        #region init
        public djPictureBox()
        {
            InitializeComponent();
        }

        public djPictureBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region 截圖

        #region 截取參數
        /// <summary>
        /// 遊標是否超出圖檔範圍
        /// </summary>

        public string CaptureColor = "R";

        enum eMouseOverRange { inRange, outRange, unknow }
        eMouseOverRange emor = eMouseOverRange.unknow;

        /// <summary>
        /// 實際圖檔上被選取的範圍
        /// </summary>
        Bitmap SelectArea = null;
        Point ptMouseDown = new Point();

        /// <summary>
        /// 實際圖座落點
        /// </summary>
        Point RatioPtMouseDown;

        /// <summary>
        /// 畫面上繪出的紅框
        /// </summary>
        public Rectangle drawRect = new Rectangle();

        /// <summary>
        /// 拖曳時變動的框
        /// </summary>
        public Rectangle rectLog = new Rectangle();

        PictureBox CaptureImageFrom, CaptureImageTo;

        /// <summary>
        /// 抓取的 路徑清單
        /// </summary>
        public string CapturePath = "";

        /// <summary>
        /// 抓取 的檔案明細
        /// </summary>
        public BaseImg.ImageDetail CaptureDetail = new BaseImg.ImageDetail();

        float MinRatio;
        int offsetX, offsetY;

        /// <summary>
        /// 抓取框最小值
        /// </summary>
        public int CaptureMinimum = 90;
        public string CapTitle = "djCap_";
        List<int> CaptureMinimumList = new List<int>();

        /// <summary>
        /// 滑鼠是否拖曳
        /// 是:框在右下
        /// 否:框在左上
        /// </summary>
        bool isMouseDrag = false;
        #endregion

        #region 圖列點擊委派
        public delegate void dgCapture(BaseImg.ImageDetail ImagePath);
        public dgCapture CaptureFinish;
        #endregion

        #region 旋轉
        public static void autoRatioImage(Image bmPic, PictureBox tempPic)
        {
            Image bmPic2 = new Bitmap(bmPic);
            Point ptLoction = new Point(bmPic2.Size);

            if (ptLoction.X > tempPic.Size.Width || ptLoction.Y > tempPic.Size.Height)
            {
                //圖像框的停靠方式   
                //pcbPic.Dock = DockStyle.Fill;   
                //圖像充滿圖像框，並且圖像維持比例   
                tempPic.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                //圖像在圖像框置中   
                tempPic.SizeMode = PictureBoxSizeMode.CenterImage;
            }

            tempPic.Image = bmPic2;

        }

        public static void autoRatioImage(string imageName, PictureBox tempPic)
        {
            Bitmap bmPic = new Bitmap(imageName);
            Bitmap bmPic2 = new Bitmap(bmPic);
            Point ptLoction = new Point(bmPic2.Size);
            if (ptLoction.X > tempPic.Size.Width || ptLoction.Y > tempPic.Size.Height)
            {

                tempPic.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                //圖像在圖像框置中   
                tempPic.SizeMode = PictureBoxSizeMode.CenterImage;
            }

            tempPic.Image = bmPic2;
            bmPic.Dispose();
        }

        #endregion


        #region 畫面click

        /// <summary>
        /// 畫框
        /// </summary>
        /// 
        void drawRectInit(MouseEventArgs e)
        {
            #region 畫框

            #region new
            if (HitArea(ptMouseDown, drawRect))
            {
                rectLog = drawRect;
                emor = eMouseOverRange.inRange;
                RatioPtMouseDown = new Point((int)((ptMouseDown.X - offsetX) / MinRatio), (int)((ptMouseDown.Y - offsetY) / MinRatio));
            }
            else
            {
                drawRect = new Rectangle(ptMouseDown, new Size(0, 0));
                emor = eMouseOverRange.outRange;
                RatioPtMouseDown = new Point((int)((ptMouseDown.X - offsetX) / MinRatio), (int)((ptMouseDown.Y - offsetY) / MinRatio));
            }
            
            #endregion


            #region old
            //drawRect = new Rectangle(ptMouseDown, new Size(0, 0));
            //emor = eMouseOverRange.outRange;
            //RatioPtMouseDown = new Point((int)((ptMouseDown.X - offsetX) / MinRatio), (int)((ptMouseDown.Y - offsetY) / MinRatio));
            #endregion

            #endregion
        }

        /// <summary>
        /// 畫框在螢幕上
        /// </summary>
        /// <param name="e"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void drawRectTo(MouseEventArgs e, int x, int y)
        {
            switch (emor)//根據 滑鼠按鈕狀態畫不同框
            {
                case eMouseOverRange.outRange:// todo:160823,out,目前這段不夠精準
                    #region out
                    switch (e.Button)
                    {
                        case MouseButtons.Left: //拉框

                            isMouseDrag = ((x - ptMouseDown.X) > 0); //是否拖曳關鍵

                            if (isMouseDrag)
                            {
                                drawRect = new Rectangle(ptMouseDown, new Size(x - ptMouseDown.X, y - ptMouseDown.Y));
                            }
                            else
                            {
                                drawRect.X = rectLog.X + (x - ptMouseDown.X);
                                drawRect.Y = rectLog.Y + (y - ptMouseDown.Y);
                            }
                            break;

                        default: ///非拖曳：使用預設框 顯示方式：左上角
                            drawRect = new Rectangle(x - CaptureMinimum, y - CaptureMinimum, CaptureMinimum, CaptureMinimum);
                            //畫在遊標左上方                            
                            break;
                    }
                    #endregion
                    break;

                case eMouseOverRange.inRange://原有框location+
                    #region in

                    switch (e.Button)
                    {
                        case MouseButtons.Left: // ( 拉框大小 =滑鼠位置-點擊位置)

                            isMouseDrag = ((x - ptMouseDown.X) > 0); //是否拖曳關鍵

                            if (isMouseDrag)
                            {
                                drawRect = new Rectangle(ptMouseDown, new Size(x - ptMouseDown.X, y - ptMouseDown.Y));
                            }
                            else
                            {
                                drawRect.X = rectLog.X + (x - ptMouseDown.X);
                                drawRect.Y = rectLog.Y + (y - ptMouseDown.Y);
                            }
                            break;

                        default: ///非拖曳：使用預設框 顯示方式：左上角
                            drawRect = new Rectangle(x - CaptureMinimum, y - CaptureMinimum, CaptureMinimum, CaptureMinimum);
                            //畫在遊標左上方                            
                            break;
                    }


                    #endregion
                    break;

                case eMouseOverRange.unknow:
                    Console.WriteLine("un");
                    break;
                default:
                    break;
            }

        }

        private void pictureBoxTopDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            if (CaptureImageFrom.Image != null)
            {
                #region offset:偏移量、縮放比例

                float RatioW = (float)CaptureImageFrom.Width / (float)CaptureImageFrom.Image.Width;
                float RatioH = (float)CaptureImageFrom.Height / (float)CaptureImageFrom.Image.Height;
                MinRatio = Math.Min(RatioW, RatioH);


                offsetX = (int)(CaptureImageFrom.Image.Width * MinRatio) - CaptureImageFrom.Width;
                if (Math.Abs(offsetX) > 10)
                {
                    offsetX = Math.Abs(offsetX / 2);
                }
                else
                {
                    offsetX = 0;
                }

                offsetY = (int)(CaptureImageFrom.Image.Height * MinRatio) - CaptureImageFrom.Height;
                if (Math.Abs(offsetY) > 10)
                {
                    offsetY = Math.Abs(offsetY / 2);
                }
                else
                {
                    offsetY = 0;
                }

                #endregion

                switch (e.Button)
                {
                    case MouseButtons.Left:
                        ptMouseDown = e.Location;

                        #region 超出範圍

                        if ((sender as PictureBox).Image == null)
                        {
                            return;
                        }

                        if (((ptMouseDown.X - offsetX) < 0) || ((ptMouseDown.Y - offsetY)) < 0)//image 之外
                        {
                            return;
                        }
                        if ((ptMouseDown.X > (offsetX + (CaptureImageFrom.Image.Width * MinRatio)))
                            || (ptMouseDown.Y > (offsetY + (CaptureImageFrom.Image.Height * MinRatio))))//image 之外
                        {
                            return;
                        }

                        #endregion

                        #region 畫框
                        if (HitArea(ptMouseDown, drawRect))
                        {
                            rectLog = drawRect;
                            emor = eMouseOverRange.inRange;
                        }
                        else
                        {
                            drawRect = new Rectangle(ptMouseDown, new Size(0, 0));

                            emor = eMouseOverRange.outRange;
                            RatioPtMouseDown = new Point((int)((ptMouseDown.X - offsetX) / MinRatio), (int)((ptMouseDown.Y - offsetY) / MinRatio));
                        }
                        #endregion
                        break;
                    default:
                        break;
                }

                (sender as PictureBox).Refresh();

            }
            //isMouseDrag = false;
        }
        private void pictureBoxTopDisplay_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right) return;

            if ((sender as PictureBox) != null)
            {
                drawRectInit(e);
                drawRectTo(e, e.X, e.Y);
                (sender as PictureBox).Refresh();
            }


            //todo:支援反向拉框
        }
        private void pictureBoxTopDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            #region 框選暫存檔路徑
            if (!System.IO.Directory.Exists(Application.StartupPath + @"\temp\"))
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\temp\");
            }
            BaseImg.ImageDetail CaptureImg = new BaseImg.ImageDetail();
            CaptureImg.Path = Application.StartupPath + @"\temp\" + CapTitle + DateTime.Now.ToString("mmssfff") + ".jpg";
            CaptureImg.xywh = "1,2,3,4";
            CaptureImg.color = CaptureColor;
            #endregion
            //Console.WriteLine("---------------------------");
            //Console.WriteLine("Width:" + (int)(drawRect.Width / MinRatio));
            //Console.WriteLine("Height:" + (int)(drawRect.Height / MinRatio));
            //Console.WriteLine("x:" + (int)((drawRect.X - offsetX) / MinRatio));
            //Console.WriteLine("y:" + (int)((drawRect.Y - offsetY) / MinRatio));
            if ((sender as PictureBox) != null)
            {
                #region 最小範圍 限制
                if (drawRect.Width < CaptureMinimum) drawRect.Width = CaptureMinimum;
                if (drawRect.Height < CaptureMinimum) drawRect.Height = CaptureMinimum;
                #endregion
                if (isMouseDrag)
                {
                    SetSelectImageArea(
                        (int)(drawRect.Width / MinRatio),
                        (int)(drawRect.Height / MinRatio),
                    (int)((drawRect.X - offsetX) / MinRatio),
                    (int)((drawRect.Y - offsetY) / MinRatio),
                     CaptureImg.Path);

                    CaptureImg.xywh = ((drawRect.X - offsetX) / MinRatio).ToString()
                        + "," + ((drawRect.Y - offsetY) / MinRatio)
                        + "," + (int)(drawRect.Width / MinRatio)
                        + "," + (drawRect.Height / MinRatio);
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Width:" + (int)(drawRect.Width / MinRatio));
                    Console.WriteLine("Height:" + (int)(drawRect.Height / MinRatio));
                    Console.WriteLine("x:" + (int)((drawRect.X - offsetX) / MinRatio));
                    Console.WriteLine("y:" + (int)((drawRect.Y - offsetY) / MinRatio));
                    Console.WriteLine("isMouseDrag");

                }
                else
                {
                    SetSelectImageArea(
                      (int)(drawRect.Width / MinRatio),
                      (int)(drawRect.Height / MinRatio),
                  (int)((drawRect.X - offsetX) / MinRatio),
                  (int)((drawRect.Y - offsetY) / MinRatio),
                   CaptureImg.Path);
                    CaptureImg.xywh = ((drawRect.X - offsetX) / MinRatio).ToString()
                     + "," + ((drawRect.Y - offsetY) / MinRatio)
                     + "," + (int)(drawRect.Width / MinRatio)
                     + "," + (drawRect.Height / MinRatio);
                }

                (sender as PictureBox).Refresh();
            }

            if (CaptureFinish != null)
            {
                CapturePath =(CaptureImg.Path);
                CaptureDetail=(CaptureImg);
                CaptureFinish(CaptureImg);
            }

        }
        #endregion

        #region mouse
        private void CaptureImageFrom_MouseEnter(object sender, EventArgs e)
        {

        }

        private void CaptureImageFrom_MouseLeave(object sender, EventArgs e)
        {
            //隱藏框
        }

        /// <summary>
        /// 滾輪調整框選大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CaptureImageFrom_MouseWheel(object sender, MouseEventArgs e)
        {
            Console.WriteLine("0408");
            int MinIndex = CaptureMinimumList.IndexOf(CaptureMinimum);
            if (e.Delta > 0)
            {
                if (MinIndex == 0)
                {
                    MinIndex = 0;
                }
                else
                {
                    MinIndex -= 1;
                }

            }
            else
            {
                if (MinIndex == (CaptureMinimumList.Count - 1))
                {
                    MinIndex = CaptureMinimumList.Count - 1;
                }
                else
                {
                    MinIndex += 1;
                }

            }
            CaptureMinimum = CaptureMinimumList[MinIndex];
            drawRectInit(e);
            drawRectTo(e, e.X - this.Location.X - CaptureImageFrom.Location.X, e.Y - this.Location.Y - CaptureImageFrom.Location.Y);
            CaptureImageFrom.Refresh();
        }

        #endregion

        /// <summary>
        /// 指定欲顯示框選範圍的 picturebox
        /// </summary>
        /// <param name="ImageFrom"></param>
        /// <param name="ImageTo"></param>
        public void SetCapture(PictureBox ImageFrom, PictureBox ImageTo, ContextMenuStrip cm = null)
        {
            CaptureImageFrom = ImageFrom;
            CaptureImageTo = ImageTo;

            CaptureImageFrom.Paint += new System.Windows.Forms.PaintEventHandler(DrawCaptureArea);
            CaptureImageFrom.MouseDown += new System.Windows.Forms.MouseEventHandler(pictureBoxTopDisplay_MouseDown);
            CaptureImageFrom.MouseMove += new System.Windows.Forms.MouseEventHandler(pictureBoxTopDisplay_MouseMove);
            CaptureImageFrom.MouseUp += new System.Windows.Forms.MouseEventHandler(pictureBoxTopDisplay_MouseUp);
            CaptureImageFrom.ContextMenuStrip = cm;

            for (int i = 0; i < 10; i++)
            {
                CaptureMinimumList.Add(30 + (i * 20));
            }
            this.MouseWheel += new MouseEventHandler(CaptureImageFrom_MouseWheel);
        }

        /// <summary>
        /// 點擊區在area內
        /// </summary>
        /// <param name="hitLocation"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        bool HitArea(Point hitLocation, Rectangle area)
        {
            bool retValue = ((hitLocation.X >= area.Left) &&
                             (hitLocation.Y >= area.Top) &&
                             (hitLocation.X <= area.Right) &&
                             (hitLocation.Y <= area.Bottom));

            return retValue;
        }

        /// <summary>
        /// 顯示圖上畫紅框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawCaptureArea(object sender, PaintEventArgs e)
        {            
            Pen rPen = new Pen(Color.Red, 5);
            e.Graphics.DrawRectangle(rPen, drawRect);
        }

        #region 取得實際圖
        /// <summary>
        /// 讀取指定框選範圍
        /// </summary>
        /// <param name="AreaWidth"></param>
        /// <param name="AreaHeight"></param>
        /// <param name="DescX"></param>
        /// <param name="DescY"></param>
        /// <param name="SavePath"></param>
        public void SetSelectImageArea(int AreaWidth, int AreaHeight, int DescX, int DescY, string SavePath = @"\CaptureFile.jpg")
        {
            if ((AreaWidth > 0) && (AreaHeight > 0))
            {
                SelectArea = new Bitmap(AreaWidth, AreaHeight);
                Graphics g = Graphics.FromImage(SelectArea);
                g.DrawImage(CaptureImageFrom.Image,
                    new Rectangle(0, 0, AreaWidth, AreaHeight),
                    new Rectangle(DescX, DescY, AreaWidth, AreaHeight),
                    GraphicsUnit.Pixel);
                CaptureImageTo.Image = SelectArea;
                CaptureImageTo.Image.Save(SavePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }


        /// <summary>
        /// 取得實際框選區塊
        /// </summary>
        /// <returns></returns>
        public string GetLastRect()
        {
            if ((int)(drawRect.Width / MinRatio) < 0 || (int)(drawRect.Height / MinRatio) < 0 ||
                (int)((drawRect.X - offsetX) / MinRatio) < 0 || (int)((drawRect.Y - offsetY) / MinRatio) < 0)
            {
                return "";
            }
            else
            {
                return (int)(drawRect.Width / MinRatio) + "," + (int)(drawRect.Height / MinRatio) + "," +
                (int)((drawRect.X - offsetX) / MinRatio) + "," + (int)((drawRect.Y - offsetY) / MinRatio);
            }
        }

        #endregion

        #region other

        /// <summary>
        /// 判別 barcode 判定標籤是否存在
        /// </summary>
        /// <param name="AccCheck">附件偵測模式: 0:不偵測,1:偵測,2:debub show出附件大小</param>
        /// <param name="LabelPix">達到此範圍判定為附件,default 50 , 國庫目前實際值58,59</param>
        /// <param name="MaxPix">超出此範圍判定為非附件,default 65</param>
        /// <param name="Corner">偵測角落：LU,LD,RU,RD; default RD</param>
        /// <param name="wRange">偵測角落寬,default 150</param>
        /// <param name="hRange">偵測角落高,default 300</param>
        /// <returns></returns>
        public bool NeedBarcode(string AccCheck = "1", int LabelPix = 50, int MaxPix = 65, string Corner = "RD", int wRange = 150, int hRange = 300)
        {

            switch (AccCheck)
            {
                case "0":
                    return true;


                default:
                case "1":
                case "2":
                    #region 附件偵測模式

                    Bitmap img = (Bitmap)CaptureImageFrom.Image;
                    int w = img.Width;
                    int h = img.Height;
                    Bitmap bmp = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
                    BitmapData data = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);


                    int yMaxPixCount = 0;//雜訊點：y 軸顏色變動次數 
                    int yWhiteCount = 0;
                    int yBlackCount = 0;
                    bool ThisYBlack = false; //上一列是否有標籤
                    int xOKCount = 0;  //相同顏色y 軸 加總

                    #region Corner

                    int l, r, u, d;
                    switch (Corner)
                    {
                        case "LU":
                            l = 10;
                            r = wRange;

                            u = 10;
                            d = hRange;
                            break;

                        case "LD":
                            l = 10;
                            r = wRange;

                            u = h - hRange;
                            d = h - 10;
                            break;

                        case "RU":
                            l = w - wRange;
                            r = w - 10;

                            u = 10;
                            d = hRange;
                            break;

                        case "RD":
                        default:
                            l = w - wRange;
                            r = w - 10;

                            u = h - hRange;
                            d = h - 10;
                            break;
                    }
                    #endregion

                    int ThisPix;
                    for (int x = l; x < r; x++)
                    {
                        Color c = img.GetPixel(x, 0);
                        yMaxPixCount = 0;
                        int LastPix = (c.R + c.G + c.B);
                        for (int y = u; y < d; y++)
                        {
                            c = img.GetPixel(x, y);
                            ThisPix = (c.R + c.G + c.B);
                            if ((c.R < 200) || (c.G < 200) || (c.B < 200))
                            {//黑點
                                yBlackCount++;
                                yWhiteCount = 0;
                                if (yBlackCount > yMaxPixCount)
                                {
                                    yMaxPixCount = yBlackCount;//此列最大值
                                }
                                if (yMaxPixCount > MaxPix)
                                {
                                    if (AccCheck != "2")
                                    {
                                        yBlackCount = 0;
                                        break;
                                    }

                                }
                            }
                            else
                            {//白點大於三點，重置
                                yWhiteCount++;
                                if (yWhiteCount > 3)
                                {
                                    yBlackCount = 0;
                                }
                            }
                        }
                        ThisYBlack = (yMaxPixCount > LabelPix);

                        if (ThisYBlack)
                        {
                            xOKCount++;
                            if (xOKCount > MaxPix)
                            {
                                if (AccCheck != "2")
                                {
                                    break;
                                }

                            }
                        }

                    }

                    if (AccCheck == "2")
                    {
                        //MessageBox.Show(xOKCount.ToString());

                    }

                    if ((xOKCount > LabelPix) && (xOKCount < MaxPix - 1))
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    #endregion

            }
        }

        /// <summary>
        /// 區域二值化
        /// </summary>
        /// <param name="Brightness"></param>
        /// <param name="BinImageFileName"></param>
        public void SetAreaBin(double Brightness, string BinImageFileName)
        {
            CaptureImageTo.Image = Binarize.ToGray((Bitmap)CaptureImageTo.Image);//不作灰階
            Bitmap tempBmp = new Bitmap(CaptureImageTo.Image);
            CaptureImageTo.Image = Binarize.BitmapTo1Bpp(tempBmp, Brightness, BinImageFileName);//use this 不作二值化                
            CaptureImageTo.Refresh();
        }
        #endregion

        #endregion
    }
}
