using System;
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
    public partial class BaseScan_bak : UserControl, IMessageFilter
    {
        protected static readonly ILog logger = LogManager.GetLogger(typeof(UserControl));
        public BaseScan_bak()
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

        #region Public 參數


        //public static class ScanSetting
        //{
        /// <summary>
        /// 掃描路徑
        /// </summary>
        public static string DJScanPath = Application.StartupPath + @"\temp\";
        /// <summary>
        /// 掃描檔頭
        /// </summary>
        public string DJScanTitle = "ESN";

        /// <summary>
        /// 掃描輸出檔案格式
        /// </summary>
        public string DJImageFormat = "jpg";

        public static Int64 DJJpgEncodeLevel = 100L;

        /// <summary>
        /// 單次掃描檔 List
        /// (不可為 static ，會造成 不同元件間 的掃描結果 混在一起)
        /// </summary>
        public List<string> DJScanCompletList;

        /// <summary>
        /// 圖檔是否加密
        /// </summary>
        public static bool DJImgEncrypt = true;

        //}

        /// <summary>
        /// 是否顯示 設定介面
        /// </summary>
        public bool ShowGUI = false;

        /// <summary>
        /// 掃描解析度
        /// </summary>
        public int DPI = 300;
        #endregion

        #region scan參數
        //PicForm newpic;
        private bool msgfilter;
        private Twain tw;
        //private int picnumber = 0;
        Form mainForm;
        #endregion

        #region public function


        /// <summary>
        /// 開始掃描
        /// </summary>
        public void Scan()
        {
            if (!msgfilter)
            {
                msgfilter = true;
                Application.AddMessageFilter(this);
            }
            tw.Acquire(ShowGUI, DPI);
        }


        /// <summary>
        /// 掃描初始化
        /// </summary>
        /// <param name="hwndp"></param>
        /// <param name="senderForm"></param>
        public void scanInit(IntPtr hwndp, Form senderForm)
        {
            tw = new Twain();
            tw.Init(hwndp);
            mainForm = senderForm;
            ScanComplete += new OnScanCompleteEvent(djScanComplete);
        }

        /// <summary>
        /// 掃描初始化
        /// </summary>
        /// <param name="hwndp"></param>
        /// <param name="senderForm"></param>
        /// <param name="twSuccess"></param>
        /// <returns></returns>
        public bool ScanInit(IntPtr hwndp, Form senderForm, string twSuccess)
        {
            bool tws = false;
            tw = new Twain();
            tws = tw.Init(hwndp, tws);
            mainForm = senderForm;
            ScanComplete += new OnScanCompleteEvent(djScanComplete);
            return tws;
        }

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

        /// <summary>
        /// 選描掃描來源
        /// </summary>
        public void SelectSrc()
        {
            tw.Select();
            //TwCapability capResx = new TwCapability(TwCap.IXResolution, 300,TwType.Fix32);
        }

        #endregion

        #region scan

        bool IMessageFilter.PreFilterMessage(ref Message m)
        {

            TwainCommand cmd = tw.PassMessage(ref m);
            if (cmd == TwainCommand.Not)
            {
                return false;
            }

            switch (cmd)
            {

                case TwainCommand.CloseRequest:
                    {
                        EndingScan();
                        tw.CloseSrc();
                        break;
                    }
                case TwainCommand.CloseOk:
                    {
                        EndingScan();
                        tw.CloseSrc();
                        break;
                    }
                case TwainCommand.DeviceEvent:
                    {
                        logger.Error("BaseScan.(DeviceEvent)裝置錯誤");
                        //Console.WriteLine("DeviceEvent");
                        break;
                    }
                case TwainCommand.Null:
                    {
                        //logger.Error("BaseScan.(null) 正常等待");
                        
                        break;
                    }
                case TwainCommand.Failure:
                    {
                        MessageBox.Show("設置錯誤");
                        logger.Error("BaseScan.設置錯誤");
                        EndingScan();
                        tw.CloseSrc();
                        break;
                    }
                case TwainCommand.TransferReady:
                    {
                        #region 立即存檔
                        logger.Info("BaseScan.1.已取得圖檔，存入指定路徑");
                        DJScanCompletList = tw.TransferePicturesSaveImmediate(DJScanPath, DJScanTitle);
                        EndingScan();
                        tw.CloseSrc();
                        #endregion

                        switch (DJImageFormat)
                        {
                            case "jpg":
                                logger.Info("BaseScan.2.jpg 轉換");
                                DJScanCompletList = DJImageProcess.TransBmpToJpg(DJScanCompletList, DJJpgEncodeLevel, DJImgEncrypt);
                                logger.Info("BaseScan.2.jpg 轉換 ok");
                                break;

                            default:
                                break;
                        }

                        logger.Info("BaseScan.3.21.送出完成委派");
                        OnScanComplete(this);
                        logger.Info("BaseScan.3.3.送完完成委派");
                        break;

                    }
                default:
                    Console.WriteLine(cmd.ToString());
                    break;
            }

            return true;
        }

        private void EndingScan()
        {
            if (msgfilter)
            {
                Application.RemoveMessageFilter(this);
                msgfilter = false;
                mainForm.Enabled = true;
                mainForm.Activate();
            }
            logger.Info("BaseScan.1.2.結束掃描");
        }


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
