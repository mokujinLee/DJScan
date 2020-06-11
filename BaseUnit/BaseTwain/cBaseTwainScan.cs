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

    using TwainDotNet.TwainNative;
    public class cBaseTwainScan: ScanBase
    {
        private static AreaSettings AreaSettings = new AreaSettings(Units.Centimeters, 0.1f, 5.7f, 0.1F + 2.6f, 5.7f + 2.6f);

        Twain _twain;
        ScanSettings _settings;

        Form ActiveForm;

        public cBaseTwainScan(Form winForm)
        {
            ActiveForm = winForm;
            _twain = new Twain(new WinFormsWindowMessageHook(winForm));
            _twain.TransferImage += delegate (Object sender, TransferImageEventArgs args)
            {
                if (args.Image != null)
                {
                    //pictureBox1.Image = args.Image;
                    //widthLabel.Text = "Width: " + pictureBox1.Image.Width;
                    //heightLabel.Text = "Height: " + pictureBox1.Image.Height;

                    args.Image.Save(DateTime.Now.ToString("yyMMddHHmmssff") + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                }
            };
            _twain.ScanningComplete += delegate
            {
                winForm.Enabled = true;
            };
        }


        public override void Scan()
        {
            ActiveForm.Enabled = false;

            _settings = new ScanSettings();
            _settings.UseDocumentFeeder = false;
            _settings.ShowTwainUI = ShowUi;
            _settings.ShowProgressIndicatorUI = false;
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
