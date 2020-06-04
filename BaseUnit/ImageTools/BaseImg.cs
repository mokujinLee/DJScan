using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace DJScan
{
    public class BaseImg : UserControl
    {
        /// <summary>
        /// 影像 明細
        /// 
        /// 1.路徑
        /// 2.位置
        /// 3.顏色
        /// </summary>
        public class ImageDetail
        {
            public string Path;
            public string xywh;
            public string color="R";
            public System.Drawing.Image humbnailImage;
        }
    }
}
