using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TwainLib
{
    public enum TwainCommand
    {
        Not = -1,
        Null = 0,
        TransferReady = 1,
        CloseRequest = 2,
        CloseOk = 3,
        DeviceEvent = 4,
        Failure = 5
    }

    public class Twain
    {
        #region init
        private const short CountryUSA = 1;
        private const short LanguageUSA = 13;


        public Twain()
        {
            appid = new TwIdentity();
            appid.Id = IntPtr.Zero;
            appid.Version.MajorNum = 1;
            appid.Version.MinorNum = 1;
            appid.Version.Language = LanguageUSA;
            appid.Version.Country = CountryUSA;
            appid.Version.Info = "Hack 1";
            appid.ProtocolMajor = TwProtocol.Major;
            appid.ProtocolMinor = TwProtocol.Minor;
            appid.SupportedGroups = (int)(TwDG.Image | TwDG.Control);
            appid.Manufacturer = "NETMaster";
            appid.ProductFamily = "Freeware";
            appid.ProductName = "Hack";

            srcds = new TwIdentity();
            srcds.Id = IntPtr.Zero;

            evtmsg.EventPtr = Marshal.AllocHGlobal(Marshal.SizeOf(winmsg));
        }

        ~Twain()
        {
            Marshal.FreeHGlobal(evtmsg.EventPtr);
        }


        public bool Init(IntPtr hwndp, bool TWSuccess)
        {

            Finish();
            TwRC rc = DSMparent(appid, IntPtr.Zero, TwDG.Control, TwDAT.Parent, TwMSG.OpenDSM, ref hwndp);
            if (rc == TwRC.Success)
            {
                rc = DSMident(appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.GetDefault, srcds);
                if (rc == TwRC.Success)
                {
                    hwnd = hwndp;
                    TWSuccess = true;
                    return true;
                }
                else
                {
                    rc = DSMparent(appid, IntPtr.Zero, TwDG.Control, TwDAT.Parent, TwMSG.CloseDSM, ref hwndp);
                    TWSuccess = false;
                    return true;
                }
            }
            return false;
        }

        public void Init(IntPtr hwndp)
        {
            Finish();
            TwRC rc = DSMparent(appid, IntPtr.Zero, TwDG.Control, TwDAT.Parent, TwMSG.OpenDSM, ref hwndp);
            if (rc == TwRC.Success)
            {
                rc = DSMident(appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.GetDefault, srcds);
                if (rc == TwRC.Success)
                    hwnd = hwndp;
                else
                    rc = DSMparent(appid, IntPtr.Zero, TwDG.Control, TwDAT.Parent, TwMSG.CloseDSM, ref hwndp);
            }
        }
        #endregion

        /// <summary>
        /// 選擇Scanner
        /// </summary>
        public void Select()
        {
            TwRC rc;
            CloseSrc();
            if (appid.Id == IntPtr.Zero)
            {
                Init(hwnd);
                if (appid.Id == IntPtr.Zero)
                    return;
            }
            rc = DSMident(appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.UserSelect, srcds);
        }

        #region Scan
        TwRC rc;

        public void AcquireSource()
        {
            TwRC rc;
            CloseSrc();
            if (appid.Id == IntPtr.Zero)
            {
                Init(hwnd);
                if (appid.Id == IntPtr.Zero)
                    return;
            }
            rc = DSMident(appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.OpenDS, srcds);
            if (rc != TwRC.Success)
                return;

            TwCapability cap = new TwCapability(TwCap.XferCount, 1);
            rc = DScap(appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, cap);
            if (rc != TwRC.Success)
            {
                CloseSrc();
                return;
            }

            TwUserInterface guif = new TwUserInterface();
            guif.ShowUI = 1;
            guif.ModalUI = 1;
            guif.ParentHand = hwnd;
            rc = DSuserif(appid, srcds, TwDG.Control, TwDAT.UserInterface, TwMSG.EnableDS, guif);
            if (rc != TwRC.Success)
            {
                CloseSrc();
                return;
            }
        }


        /// <summary>
        /// 獲得掃描 結果
        /// </summary>
        public void Acquire(bool ShowGUI, int DPI)
        {
            #region INIT
            CloseSrc();
            if (appid.Id == IntPtr.Zero)
            {
                Init(hwnd);
                if (appid.Id == IntPtr.Zero)
                    return;
            }
            rc = DSMident(appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.OpenDS, srcds);
            if (rc != TwRC.Success)
                return;
            #endregion

            #region GUI
            TwUserInterface guif = new TwUserInterface();


            if (ShowGUI)
            {
                guif.ShowUI = 1;
                guif.ModalUI = 1;
                guif.ParentHand = hwnd;
            }
            else
            {
                guif.ShowUI = 0;
                guif.ModalUI = 0;
                guif.ParentHand = IntPtr.Zero;
            }

            #endregion

            #region DPI
            //TwCapability capUnit = new TwCapability(TwCap.IUnits, 0);
            //rc = DScap(appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, capUnit);
            //TwCapability capX = new TwCapability(TwCap.IXResolution, (short)DPI);
            //rc = DScap(appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, capX);
            //if (rc != TwRC.Success)
            //{
            //    CloseSrc();
            //    return;
            //}

            //TwCapability capY = new TwCapability(TwCap.IYResolution, (short)DPI);
            //rc = DScap(appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, capY);
            //if (rc != TwRC.Success)
            //{
            //    CloseSrc();
            //    return;
            //}
            #endregion

            #region 單/雙面
            //TwCapability capDuplex = new TwCapability(TwCap.CAP_DUPLEXENABLED, 1, true);//雙面
            ////TwCapability capDuplex = new TwCapability(TwCap.CAP_DUPLEXENABLED, 0, true);//單面
            //rc = DScap(appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, capDuplex);
            //if (rc != TwRC.Success)
            //{
            //    CloseSrc();
            //    return;
            //}
            #endregion

            #region 邊界 (無作用)



            ////TwCapability cap = new TwCapability(TwCap.ICAP_AUTOMATICBORDERDETECTION, 1, true);
            //TwCapability cap = new TwCapability(TwCap.ICAP_AUTOMATICBORDERDETECTION, (short)1);
            //rc = DScap(appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, cap);

            //if (rc != TwRC.Success)
            //{
            //    CloseSrc();
            //    return;
            //}
            #endregion

            #region 連續掃描 (未測試)

            #region 多張設定

            // 1 = only 1 image if we're not using the user interface
            // -1 = scan all images if we're not using the user interface

            //TwCapability cap = new TwCapability(TwCap.XferCount, -1);//單張
            //TwCapability cap = new TwCapability(TwCap.XferCount, 2);//多張
            //TwCapability xfrecount = new TwCapability(TwCap.XferCount, 1);//多張
            //rc = DScap(appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, xfrecount);
            //if (rc != TwRC.Success)
            //{
            //    CloseSrc();
            //    return;
            //} 
            #endregion

            #region MyRegion
            //TwCapability cap = new TwCapability(TwCap.XferCount, -1);//連掃
            //TwCapability cap = new TwCapability(TwCap.XferCount, 1);//一張
            //rc = DScap(appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, cap);
            //if (rc != TwRC.Success)
            //{
            //    CloseSrc();
            //    return;
            //} 
            #endregion

            #endregion

            #region 色彩 PixelType  無作用

            // Set the scan type
            // 0 = BW | 1 = Gray | 4 = Colour
            //short PixelType = 4;//無作用 0,1,2,3,8,16,-1
            //TwCapability ptCap = new TwCapability(TwCap.IPixelType, PixelType);
            ////TwCapability ptCap = new TwCapability(TwCap.IPixelType, 4, TwType.Int16);//err
            ////TwCapability ptCap = new TwCapability(TwCap.IPixelType, 4, TwType.Int16);//err

            //rc = DScap(appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, ptCap);
            //if (rc != TwRC.Success)
            //{
            //    CloseSrc();
            //    return;
            //}

            #region color IBitDepth

            #region test result
            //pt:8>3,16,24  not work

            //pt:1>1,8,16,24,32  not work
            //pt:-1>16  not work
            //pt:2>8,16,24  not work
            //pt:3>8,16,24  not work
            //pt:4> 8,16,24,32  not work 

            #endregion

            //short BitDepth = 24;
            ////b/w:1
            ////gray:8
            ////c:24

            //// set pixel bit depth to 1 bit (b/w)
            //TwCapability bdCap = new TwCapability(TwCap.IBitDepth, BitDepth);
            ////TwCapability bdCap = new TwCapability(TwCap.IBitDepth, (short)16, TwType.UInt16);//err不可用
            //rc = DScap(appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, bdCap);
            //if (rc != TwRC.Success)
            //{
            //    CloseSrc();
            //    return;
            //}
            #endregion


            #region 亮度.ok
            //TwCapability capBrightness = new TwCapability(TwCap.ICAP_BRIGHTNESS, 100);
            //rc = DScap(appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, capBrightness);
            //if (rc != TwRC.Success)
            //{
            //    CloseSrc();
            //    return;
            //}
            #endregion

            #region 對比.ok
            //// Set the gamma (doesn't work for BW)
            //TwCapability capGamma = new TwCapability(TwCap.ICAP_GAMMA, 2, TwType.Fix32);

            //TwCapability capGamma = new TwCapability(TwCap.ICAP_GAMMA, 1);
            //rc = DScap(appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, capGamma);
            //if (rc != TwRC.Success)
            //{
            //    CloseSrc();
            //    return;
            //} 
            #endregion

  
            #endregion

            #region ds 沒有紙
            rc = DSuserif(appid, srcds, TwDG.Control, TwDAT.UserInterface, TwMSG.EnableDS, guif);
            if (rc != TwRC.Success)
            {
                CloseSrc();
                return;
            }
            #endregion
        }

        #endregion

        #region 結束
        public ArrayList TransferPictures()
        {
            ArrayList pics = new ArrayList();
            if (srcds.Id == IntPtr.Zero)
                return pics;

            TwRC rc;
            IntPtr hbitmap = IntPtr.Zero;
            TwPendingXfers pxfr = new TwPendingXfers();

            do
            {
                pxfr.Count = 0;
                hbitmap = IntPtr.Zero;

                TwImageInfo iinf = new TwImageInfo();
                rc = DSiinf(appid, srcds, TwDG.Image, TwDAT.ImageInfo, TwMSG.Get, iinf);
                if (rc != TwRC.Success)
                {
                    CloseSrc();
                    return pics;
                }

                rc = DSixfer(appid, srcds, TwDG.Image, TwDAT.ImageNativeXfer, TwMSG.Get, ref hbitmap);
                if (rc != TwRC.XferDone)
                {
                    CloseSrc();
                    return pics;
                }

                rc = DSpxfer(appid, srcds, TwDG.Control, TwDAT.PendingXfers, TwMSG.EndXfer, pxfr);
                if (rc != TwRC.Success)
                {
                    CloseSrc();
                    return pics;
                }

                pics.Add(hbitmap);
            }
            while (pxfr.Count != 0);

            rc = DSpxfer(appid, srcds, TwDG.Control, TwDAT.PendingXfers, TwMSG.Reset, pxfr);
            return pics;
        }

        public System.Collections.Generic.List<string> TransferePicturesSaveImmediate(string ScanPath, string ScanTitle)
        {
            System.Collections.Generic.List<string> pics = new System.Collections.Generic.List<string>();
            if (srcds.Id == IntPtr.Zero)
                return pics;

            TwRC rc;
            IntPtr hbitmap = IntPtr.Zero;
            TwPendingXfers pxfr = new TwPendingXfers();
            bool boolEven = false;
            string LastFileName = "";

            #region do while
            do
            {
                pxfr.Count = 0;
                hbitmap = IntPtr.Zero;

                TwImageInfo iinf = new TwImageInfo();
                rc = DSiinf(appid, srcds, TwDG.Image, TwDAT.ImageInfo, TwMSG.Get, iinf);
                if (rc != TwRC.Success)
                {
                    CloseSrc();
                    return pics;
                }

                rc = DSixfer(appid, srcds, TwDG.Image, TwDAT.ImageNativeXfer, TwMSG.Get, ref hbitmap);
                if (rc != TwRC.XferDone)
                {
                    CloseSrc();
                    return pics;
                }

                rc = DSpxfer(appid, srcds, TwDG.Control, TwDAT.PendingXfers, TwMSG.EndXfer, pxfr);
                if (rc != TwRC.Success)
                {
                    CloseSrc();
                    return pics;
                }

                #region add ab file end
                string desFileName;
                if (boolEven)
                {
                    desFileName = ScanPath + ScanTitle + LastFileName + "_B";
                }
                else
                {
                    LastFileName = DateTime.Now.ToString("_yyMMddHHmmssffff");
                    System.Threading.Thread.Sleep(1);
                    desFileName = ScanPath + ScanTitle + LastFileName + "_A";
                }
                boolEven = !boolEven;
                #endregion

                DJScan.PicForm newpic = new DJScan.PicForm(hbitmap);
                newpic.Text = desFileName;
                pics.Add(desFileName + ".bmp");
                newpic.Show();
                newpic.saveImg();
                newpic.Close();
            }
            while (pxfr.Count != 0);
            #endregion



            rc = DSpxfer(appid, srcds, TwDG.Control, TwDAT.PendingXfers, TwMSG.Reset, pxfr);
            return pics;
        }

        public TwainCommand PassMessage(ref Message m)
        {
            if (srcds.Id == IntPtr.Zero)
                return TwainCommand.Not;

            int pos = GetMessagePos();

            winmsg.hwnd = m.HWnd;
            winmsg.message = m.Msg;
            winmsg.wParam = m.WParam;
            winmsg.lParam = m.LParam;
            winmsg.time = GetMessageTime();
            winmsg.x = (short)pos;
            winmsg.y = (short)(pos >> 16);

            Marshal.StructureToPtr(winmsg, evtmsg.EventPtr, false);
            evtmsg.Message = 0;
            TwRC rc = DSevent(appid, srcds, TwDG.Control, TwDAT.Event, TwMSG.ProcessEvent, ref evtmsg);
            if (rc == TwRC.NotDSEvent)
                return TwainCommand.Not;
            if (evtmsg.Message == (short)TwMSG.XFerReady)
                return TwainCommand.TransferReady;
            if (evtmsg.Message == (short)TwMSG.CloseDSReq)
                return TwainCommand.CloseRequest;
            if (evtmsg.Message == (short)TwMSG.CloseDSOK)
                return TwainCommand.CloseOk;
            if (evtmsg.Message == (short)TwMSG.DeviceEvent)
                return TwainCommand.DeviceEvent;
            if (rc == TwRC.Failure)
                return TwainCommand.Failure;
            return TwainCommand.Null;
        }

        public void CloseSrc()
        {
            TwRC rc;
            if (srcds.Id != IntPtr.Zero)
            {
                TwUserInterface guif = new TwUserInterface();
                rc = DSuserif(appid, srcds, TwDG.Control, TwDAT.UserInterface, TwMSG.DisableDS, guif);
                rc = DSMident(appid, IntPtr.Zero, TwDG.Control, TwDAT.Identity, TwMSG.CloseDS, srcds);
            }
        }

        public void Finish()
        {
            TwRC rc;
            CloseSrc();
            if (appid.Id != IntPtr.Zero)
                rc = DSMparent(appid, IntPtr.Zero, TwDG.Control, TwDAT.Parent, TwMSG.CloseDSM, ref hwnd);
            appid.Id = IntPtr.Zero;
        }
        #endregion

        #region MyRegion
        private IntPtr hwnd;
        private TwIdentity appid;
        private TwIdentity srcds;
        private TwEvent evtmsg;
        private WINMSG winmsg;


        #region DSM entry point DAT_ variants

        // ------ DSM entry point DAT_ variants:
        [DllImport("twain_32.dll", EntryPoint = "#1")]
        private static extern TwRC DSMparent([In, Out] TwIdentity origin, IntPtr zeroptr, TwDG dg, TwDAT dat, TwMSG msg, ref IntPtr refptr);

        [DllImport("twain_32.dll", EntryPoint = "#1")]
        private static extern TwRC DSMident([In, Out] TwIdentity origin, IntPtr zeroptr, TwDG dg, TwDAT dat, TwMSG msg, [In, Out] TwIdentity idds);

        [DllImport("twain_32.dll", EntryPoint = "#1")]
        private static extern TwRC DSMstatus([In, Out] TwIdentity origin, IntPtr zeroptr, TwDG dg, TwDAT dat, TwMSG msg, [In, Out] TwStatus dsmstat);


        // ------ DSM entry point DAT_ variants to DS:
        [DllImport("twain_32.dll", EntryPoint = "#1")]
        private static extern TwRC DSuserif([In, Out] TwIdentity origin, [In, Out] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, TwUserInterface guif);

        [DllImport("twain_32.dll", EntryPoint = "#1")]
        private static extern TwRC DSevent([In, Out] TwIdentity origin, [In, Out] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, ref TwEvent evt);

        [DllImport("twain_32.dll", EntryPoint = "#1")]
        private static extern TwRC DSstatus([In, Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, [In, Out] TwStatus dsmstat);

        [DllImport("twain_32.dll", EntryPoint = "#1")]
        private static extern TwRC DScap([In, Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, [In, Out] TwCapability capa);

        [DllImport("twain_32.dll", EntryPoint = "#1")]
        private static extern TwRC DSiinf([In, Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, [In, Out] TwImageInfo imginf);

        [DllImport("twain_32.dll", EntryPoint = "#1")]
        private static extern TwRC DSixfer([In, Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, ref IntPtr hbitmap);

        [DllImport("twain_32.dll", EntryPoint = "#1")]
        private static extern TwRC DSpxfer([In, Out] TwIdentity origin, [In] TwIdentity dest, TwDG dg, TwDAT dat, TwMSG msg, [In, Out] TwPendingXfers pxfr);


        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalAlloc(int flags, int size);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalLock(IntPtr handle);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern bool GlobalUnlock(IntPtr handle);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GlobalFree(IntPtr handle);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern int GetMessagePos();
        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern int GetMessageTime();


        [DllImport("gdi32.dll", ExactSpelling = true)]
        private static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr CreateDC(string szdriver, string szdevice, string szoutput, IntPtr devmode);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        private static extern bool DeleteDC(IntPtr hdc);


        #endregion

        public static int ScreenBitDepth
        {
            get
            {
                IntPtr screenDC = CreateDC("DISPLAY", null, null, IntPtr.Zero);
                //int bitDepth = GetDeviceCaps(screenDC, 12);
                int bitDepth = GetDeviceCaps(screenDC, 24);
                //bitDepth *= GetDeviceCaps(screenDC, 14);
                DeleteDC(screenDC);
                return bitDepth;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        internal struct WINMSG
        {
            public IntPtr hwnd;
            public int message;
            public IntPtr wParam;
            public IntPtr lParam;
            public int time;
            public int x;
            public int y;
        }

        #endregion


    } // class Twain
}
