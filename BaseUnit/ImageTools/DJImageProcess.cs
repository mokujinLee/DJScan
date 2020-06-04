using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using djFileAccess;
namespace DJImageTools
{
    public static class DJImageProcess
    {

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }


        /// <summary>
        /// 批次  bmp 轉  jpg
        /// </summary>
        /// <param name="BmpList"></param>
        /// <param name="EncodeLavel"></param>
        /// <returns></returns>
        public static List<string> TransBmpToJpg(List<string> BmpList, Int64 EncodeLavel, bool DJImgEncrypt = true)
        {
            Bitmap myBitmap;
            ImageCodecInfo myImageCodecInfo;
            Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            List<string> JpgList = new List<string>();

            foreach (var item in BmpList)
            {
                string JpgFile = Path.ChangeExtension(item, "jpg");
                myBitmap = new Bitmap(item);
                myImageCodecInfo = GetEncoderInfo("image/jpeg");
                myEncoder = Encoder.Quality;
                myEncoderParameters = new EncoderParameters(1);
                myEncoderParameter = new EncoderParameter(myEncoder, EncodeLavel);
                myEncoderParameters.Param[0] = myEncoderParameter;
                myBitmap.Save(JpgFile, myImageCodecInfo, myEncoderParameters);
                if (DJImgEncrypt)
                {
                    djFileAccess.djED.EncryptFile(JpgFile, JpgFile);                    
                }
                JpgList.Add(JpgFile);
                myBitmap.Dispose();
            }

            foreach (var item in BmpList)
            {
                File.Delete(item);
            }
            return JpgList;
        }

    }
}
