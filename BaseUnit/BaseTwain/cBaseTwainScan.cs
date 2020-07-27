using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using TwainDotNet;
using System.IO;
using TwainDotNet.WinFroms;
using System.Windows.Forms;
using DJScan;

namespace cBaseTwainScan
{
    using DJImageTools;
    using System.Drawing;
    using TwainDotNet.TwainNative;
    public class cBaseTwainScan : ScanBase
    {
        private static AreaSettings AreaSettings = new AreaSettings(Units.Centimeters, 0.1f, 5.7f, 0.1F + 2.6f, 5.7f + 2.6f);

        Twain _twain;
        ScanSettings _settings;
        Form ActiveForm;

        public delegate void OnScanCompleteEvent(object sender);
        public event OnScanCompleteEvent ScanComplete;



        public cBaseTwainScan(Form winForm)
        {
            ActiveForm = winForm;
            _twain = new Twain(new WinFormsWindowMessageHook(winForm));
            DJScanCompletList = new List<string>();
            DJOneScanList = new List<string>();
            _twain.TransferImage += delegate (Object sender, TransferImageEventArgs args)
            {
                if (args.Image != null)
                {
                    string img = DJScanPath + DateTime.Now.ToString(@"\" + DJScanTitle + "yyMMddHHmmssff") + ".jpg";
                    args.Image.Save(img, System.Drawing.Imaging.ImageFormat.Jpeg);
                    DJImageProcess.EncryptJpg(img, DJJpgEncodeLevel, DJImgEncrypt);
                    //DJScanCompletList.Add(img);
                    DJOneScanList.Add(img);
                }
            };
            _twain.ScanningComplete += delegate
            {
                ResetImgToAB(DJOneScanList);
                DJScanCompletList.AddRange(DJOneScanList);

                winForm.Enabled = true;
                winForm.Activate();
                ScanComplete(winForm);
                //ScanComplete.Invoke(winForm);      
                DJOneScanList.Clear();

            };
        }

        void ResetImgToAB(List<string> imgList)
        {
            string sideFileName;
            bool boolEven = false;
            string fileName = "";

            try
            {
                if (imgList.Count > 1)
                {
                    for (int i = 0; i < imgList.Count; i++)
                    {
                        #region add ab file end
                        if (boolEven)
                        {
                            sideFileName = "_B";
                        }
                        else
                        {
                            sideFileName = "_A";
                            fileName = System.IO.Path.GetFileNameWithoutExtension(imgList[i]);

                        }
                        string newFileName = Path.GetDirectoryName(imgList[i]) + @"\" + fileName + sideFileName + ".jpg";
                        System.IO.File.Move(imgList[i], newFileName);
                        imgList[i] = newFileName;
                        boolEven = !boolEven;
                        #endregion
                    }
                }
            }
            catch (Exception)
            {

                //throw;
            }

        }

        public override void Scan()
        {
            ActiveForm.Enabled = false;

            _settings = new ScanSettings();
            _settings.UseDocumentFeeder = false;
            _settings.ShowTwainUI = ShowUi;
            _settings.ShowProgressIndicatorUI = true;
            _settings.UseDuplex = true;
            _settings.Resolution = false ? ResolutionSettings.Fax : ResolutionSettings.ColourPhotocopier;
            _settings.Area = !false ? null : AreaSettings;
            _settings.ShouldTransferAllPages = true;

            _settings.Rotation = new RotationSettings()
            {
                AutomaticRotate = false,
                AutomaticBorderDetection = false
            };

            try
            {
                _twain.StartScanning(_settings);
            }
            catch (TwainException ex)
            {
                MessageBox.Show(ex.Message);
                ActiveForm.Enabled = true;
            }
        }

        public override void selectScan()
        {
            _twain.SelectSource();
        }
    }
}
