using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace DJScan
{
    static class Binarize
    {

        #region 參數
        /// <summary>
        /// 二值圖輸出路徑
        /// </summary>
        static public string BinImageOutPath = "";
        #endregion
        /// <summary>
        /// 轉灰階
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap ToGray(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    Color newColor = Color.FromArgb(gray, gray, gray);
                    bmp.SetPixel(i, j, newColor);
                }
            }

            return bmp;
        }

        /// <summary>
        /// 二值化
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Bitmap ConvertToBpp(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    Color newColor = ((color.R + color.G + color.B) / 3) > 10 ? Color.White : Color.Black;   //<-----这句White Black互调就是黑白相反的
                    bmp.SetPixel(i, j, newColor);
                }
            }
            //string imageName = @"e:\" + DateTime.Now.ToString("hhmmssfff") + "_B.jpg";
            //bmp.Save(imageName);
            return bmp;
        }


        /// <summary>
        /// 二值化.2
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap BitmapTo1Bpp(Bitmap img, double Brightness, string BinImageFileName)
        {
            int w = img.Width;
            int h = img.Height;
            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format1bppIndexed);


            BitmapData data = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);
            for (int y = 0; y < h; y++)
            {
                byte[] scan = new byte[(w + 7) / 8];
                for (int x = 0; x < w; x++)
                {
                    Color c = img.GetPixel(x, y);
                    if (c.GetBrightness() >= Brightness)
                        scan[x / 8] |= (byte)(0x80 >> (x % 8));
                }
                Marshal.Copy(scan, 0, (IntPtr)((int)data.Scan0 + data.Stride * y), scan.Length);
            }

            if (BinImageOutPath.Length > 0)
            {
                string imageName = BinImageOutPath + @"\" + BinImageFileName + DateTime.Now.ToString("_mmssfff") + ".jpg";
                //System.Windows.Forms.MessageBox.Show(imageName);
                try
                {
                    //bmp.Save(imageName);
                }
                catch (Exception)
                {
                    //Console.WriteLine("bin 存檔失敗");

                }

            }

            bmp.UnlockBits(data);
            return bmp;
            //return img;
        }

        /// <summary>
        /// 判別是否為barcode
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        static public bool isBarcode(Bitmap img)
        {


            //空白行不計算
            //黑行過80% 非bar
            //黑行異動?

            int w = img.Width;
            int h = img.Height;
            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format1bppIndexed);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);
            //Console.WriteLine(w.ToString());
            //Console.WriteLine(h.ToString());



            int ySamePixCount = 0;//雜訊點：y 軸顏色變動次數 
            int isBlack; //是否為空白行
            int xOKCount = 0;  //相同顏色y 軸 加總


            int ThisPix;
            for (int x = 0; x < w; x++)
            {
                Color c = img.GetPixel(x, 0);
                isBlack = 0;
                ySamePixCount = 0;
                int LastPix = (c.R + c.G + c.B);
                for (int y = 1; y < h; y++)
                {
                    c = img.GetPixel(x, y);
                    ThisPix = (c.R + c.G + c.B);
                    if (LastPix != ThisPix)
                    {
                        ySamePixCount++;

                    }
                    else
                    {
                        if (ThisPix == 0)
                        {
                            isBlack++;
                        }
                    }

                    LastPix = ThisPix;
                }
                //Console.Write(ySamePixCount + ",");
                if ((ySamePixCount < 25) && (isBlack > (h * 0.6)))//1.雜訊點容許範圍:default 5 ; 2.是黑行 
                {
                    xOKCount++;

                }
            }
            //Console.WriteLine();
            //Console.WriteLine("x:" + xOKCount);
            //bmp.UnlockBits(data);

            if ((xOKCount > 50) && (xOKCount < (w * 0.7)))//黑行大於50 、黑行小於圖的70%
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 判別 barcode 判定標籤是否存在
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        static public bool NeedBarcode(Bitmap img)
        {

            int w = img.Width;
            int h = img.Height;
            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format1bppIndexed);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);


            int ySamePixCount = 0;//雜訊點：y 軸顏色變動次數 
            bool LastBlack = false; //上一列是否有標籤
            bool ThisBlack = false; //上一列是否有標籤
            int xOKCount = 0;  //相同顏色y 軸 加總


            int ThisPix;
            for (int x = w-300; x < w; x++)
            {
                Color c = img.GetPixel(x, 0);
                ySamePixCount = 0;
                int LastPix = (c.R + c.G + c.B);
                for (int y = 1; y < 600; y++)
                {
                    c = img.GetPixel(x, y);
                    ThisPix = (c.R + c.G + c.B);            
                    if ((LastPix == ThisPix) && (ThisPix < 90))
                    {
                           ySamePixCount++;
                        if (ySamePixCount > 100)
                        {
                            break;
                        }
                     
                    }
                    else
                    {
                        ySamePixCount = 0;
                    }
                    LastPix = ThisPix;
                }           
                ThisBlack = (ySamePixCount > 30);

                if (LastBlack && ThisBlack)
                {
                    xOKCount++;
                    if (xOKCount > 100)
                    {
                        break;                      
                    }
                }
                else
                {
                    xOKCount = 0;
                }
                LastBlack = (ySamePixCount > 30);
            }

            if (xOKCount > 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}