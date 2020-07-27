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
    /// BaseScan + 
    /// </summary>
    public partial class BaseScanSetUI : BaseScanButton
    {
        public string OptionSelect = "";

        /// <summary>
        /// 載入 清單
        /// </summary>
        /// <param name="FileName"></param>
        public void LoadComboList(string FileName)
        {
            if (!System.IO.File.Exists(FileName)) return;

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(FileName, System.Text.Encoding.Default);
            while ((line = file.ReadLine()) != null)
            {
                comboBoxOption.Items.Add(line);
            }
            file.Close();
            if (comboBoxOption.Items.Count > 0)
            {
                comboBoxOption.Visible = true;
                comboBoxOption.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// BaseScanSetUI init
        /// </summary>
        /// <param name="SealSetMode">True :顯示自動分配按鈕</param>
        //public BaseScanSetUI(bool SealSetMode = false)
        public BaseScanSetUI(Form winForm) : base(winForm)
        {
            InitializeComponent();
            this.ScanComplete += new DJScan.BaseScan.OnScanCompleteEvent(SetScanComplete);
            ImportComplete += BaseScanSetUI_ImportComplete;
            ucSetManager1.ucImageView1.uivIconMouseIn += new DJScan.ucImageView.delIconMouseIn(displayImage);
            ucSetManager1.ChangeCurrentSet += new ucSetManager.delChangeCurrentSet(chgCurrentSet);
            SetImgEncrypt(true);

        }

        private void chgCurrentSet(List<string> currentList)
        {
            DJScanCompletList = currentList;
        }

        /// <summary>
        /// 設定圖檔是否加解密
        /// </summary>
        public void SetImgEncrypt(bool ImgEncrypt)
        {
            BaseScan.DJImgEncrypt = ImgEncrypt;
            ucSetManager1.ucImageView1.LoadImageDecrypt = BaseScan.DJImgEncrypt;

        }

        /// <summary>
        /// 結束按鈕 委派
        /// </summary>
        public delegate void UnitFinish();
        public UnitFinish delUnitFinish;


        private void BaseScanSetUI_ImportComplete(object sender)
        {
            ucSetManager1.ucImageView1.reloadImageBarFrom(DJScanCompletList, false);
        }

        private void displayImage(Image tempImage)
        {
            pictureBox1.Image = tempImage;
        }

        void SetScanComplete(object sender)
        {
            ucSetManager1.ucImageView1.reloadImageBarFrom(DJScanCompletList, true);
        }

        private void buttonBarCodeOK_Click(object sender, EventArgs e)
        {
            delUnitFinish.Invoke();
        }

        private void comboBoxOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            OptionSelect = (sender as ComboBox).Text;
        }
    }
}
