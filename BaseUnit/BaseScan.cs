﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TwainLib;
using DJImageTools;
using System.IO;
using djFileAccess;

using log4net;
using log4net.Config;

namespace DJScan
{
    /// <summary>
    /// 基本掃描功能(無介面)<br/><br/><br/><br/>
    /// 調用流程:<br/>
    /// 1.new BaseScan()<br/>
    /// 2.scanInit(IntPtr, Form) 掃描初始化  <br/>
    /// 3.startScan()
    /// </summary>
    public partial class BaseScan :  cBaseTwainScan.cBaseTwainScan
    {
        protected static readonly ILog logger = LogManager.GetLogger(typeof(UserControl));
        public BaseScan(Form winForm):base(winForm)
        {
            InitializeComponent();

            if (!System.IO.Directory.Exists(Application.StartupPath + @"\temp"))
            {
                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\temp");
            }

            XmlConfigurator.Configure(new System.IO.FileInfo("./log4net.config"));

            //logger.Debug("(Debug)除錯");
            //logger.Info("(Info)訊息");
            //logger.Warn("(Warn)警告");
            //logger.Error("(Error)錯誤");
            //logger.Fatal("(Fatal)嚴重錯誤");

        }


        #region public function



        /// <summary>
        /// ID 是否自動旋轉
        /// </summary>
        public bool IDRotate = true;
        /// <summary>
        /// 掃描完成
        /// </summary>
        /// <param name="sender"></param>
        private void djScanComplete(object sender)
        {

            #region ID 自動旋轉
            if (IDRotate)
            {
                int IDWidth = 361;
                int IDHeight = 254;

                foreach (var item in DJScanCompletList)
                {
                    Bitmap bitmap1;
                    if (DJImgEncrypt)
                    {
                        bitmap1 = (Bitmap)Bitmap.FromStream(djFileAccess.djED.DecryptMemoryStream(item));
                    }
                    else
                    {
                        bitmap1 = (Bitmap)Bitmap.FromFile(item);
                    }

                    #region ID 自動轉正 暫時關閉
                    //if (((bitmap1.Height > (IDHeight - 30)) && (bitmap1.Height < (IDHeight + 30))) &&
                    // ((bitmap1.Width > (IDWidth - 30)) && (bitmap1.Width < (IDWidth + 30))))
                    //{
                    //    bitmap1.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    //    bitmap1.Save(item);
                    //} 
                    #endregion
                }
            }
            #endregion

        }



        #endregion

        #region scan


        public delegate void OnScanCompleteEvent(object sender);
        [Description(@"ScanComplete 屬性的值變更時發生")]
        public event OnScanCompleteEvent ScanComplete;
        protected virtual void OnScanComplete(object sender)
        {
            if (ScanComplete != null)
            {
                ScanComplete(sender);
                logger.Info("BaseScan.3.22.送出完成委派");
            }
        }

        #endregion

        #region ext
        public void SmartImageType(string ImagePath, bool Encode = false)
        {


            Image i1;
            if (Encode)
            {
                i1 = Image.FromStream(djED.DecryptMemoryStream(ImagePath));
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

                //i1 = Image.FromFile(ImagePath);
            }

        }

        #endregion
    }
}
