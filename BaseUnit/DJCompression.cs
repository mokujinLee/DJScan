using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
//using SevenZip;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace DJScan.BaseUnit
{
    public class DJCompression
    {



        public static void Compress(string SourceFile, string _7zFile = "", string destDir = "")
        {

            //string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


            #region 64bit
            //        If Environment.Is64BitProcess Then
            //    SevenZip.SevenZipCompressor.SetLibraryPath("7zx64.dll")
            //Else
            //    SevenZip.SevenZipCompressor.SetLibraryPath("7z.dll")
            //End If 
            #endregion

            //string sevendllpath = "7z.dll";
            ////string sevendllpaht = assemblyFolder + "\\lib\\7z.dll";
            //SevenZipCompressor.SetLibraryPath(sevendllpath);

            //if (_7zFile.Length == 0)
            //{
            //    _7zFile = Path.GetFileNameWithoutExtension(SourceFile) + ".djz";
            //}
            //using (FileStream fs = new FileStream(_7zFile, FileMode.Create))
            //{
            //    SevenZipCompressor szc = new SevenZipCompressor
            //    {

            //        CompressionMethod = CompressionMethod.Deflate,
            //        CompressionLevel = CompressionLevel.Normal,
            //        CompressionMode = CompressionMode.Create,
            //        DirectoryStructure = true,
            //        PreserveDirectoryRoot = false,
            //        ArchiveFormat = OutArchiveFormat.Zip
            //    };
            //    Dictionary<string, string> filesDictionary = new Dictionary<string, string>();
            //    //replace root fullname
            //    filesDictionary.Add(Path.GetFileName(SourceFile), SourceFile);
            //    //filesDictionary.Add(@"點部落格文章\新文字文件.txt", @"D:\點部落格文章\新文字文件.txt");

            //    //do not use  CompressFiles
            //    Console.WriteLine(DateTime.Now);
            //    szc.CompressFileDictionary(filesDictionary, fs);
            //    Console.WriteLine(DateTime.Now);

            //}
        }

        private void VaryQualityLevel(string img)
        {
            // Get a bitmap.
            Bitmap bmp1 = new Bitmap(img);
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder myEncoder =
                System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one
            // EncoderParameter object in the array.
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(@"p:\TestPhotoQualityFifty.jpg", jpgEncoder, myEncoderParameters);

            myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(@"p:\TestPhotoQualityHundred.jpg", jpgEncoder, myEncoderParameters);

            // Save the bitmap as a JPG file with zero quality level compression.
            myEncoderParameter = new EncoderParameter(myEncoder, 0L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(@"p:\TestPhotoQualityZero.jpg", jpgEncoder, myEncoderParameters);

        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
