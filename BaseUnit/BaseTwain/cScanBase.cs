using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace DJScan
{
    interface iScan { }

    abstract public class ScanBase : UserControl
    {

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
        /// 多次掃描檔 List
        /// (不可為 static ，會造成 不同元件間 的掃描結果 混在一起)
        /// </summary>
        public List<string> DJScanCompletList;

        /// <summary>
        /// 單次掃描List
        /// </summary>
        public List<string> DJOneScanList;

        /// <summary>
        /// 圖檔是否加密
        /// </summary>
        public static bool DJImgEncrypt = true;

        //}

        /// <summary>
        /// 是否顯示 設定介面
        /// </summary>
        public bool ShowUi = false;

        #endregion


        Form ActiveForm;

        abstract public void Scan();
        abstract public void selectScan();
    }

}
