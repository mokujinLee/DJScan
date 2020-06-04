using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace DJScan.BaseUnit.ImageTools
{
    public class DJCommonUnit
    {
        public static List<string> OpenFileDialogImport(System.Windows.Forms.OpenFileDialog ofd ,bool DJImgEncrypt, string DJScanTitle, List<string> DJScanCompletList)
        {           

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (DJScanCompletList == null) DJScanCompletList = new List<string>();
                string ImportPath = Application.StartupPath + @"\temp\";
                if (!System.IO.Directory.Exists(ImportPath))
                {
                    System.IO.Directory.CreateDirectory(ImportPath);
                }

                bool boolEven = false;
                string LastFileName = "";
                foreach (string item in ofd.FileNames)
                {
                    string desFileName;
                    if (boolEven)
                    {
                        desFileName = ImportPath + DJScanTitle + LastFileName + "_B" + System.IO.Path.GetExtension(item);
                    }
                    else
                    {
                        LastFileName = DateTime.Now.ToString("_yyMMddHHmmssffff");
                        System.Threading.Thread.Sleep(1);
                        desFileName = ImportPath + DJScanTitle + LastFileName + "_A" + System.IO.Path.GetExtension(item);
                    }

                    System.IO.File.Copy(item, desFileName, true);
                    System.Threading.Thread.Sleep(1);


                    if (DJImgEncrypt)
                    {
                        djFileAccess.djED.EncryptFile(desFileName, desFileName);
                    }

                    DJScanCompletList.Add(desFileName);

                    boolEven = !boolEven;
                }

                
            }
            return DJScanCompletList;
        }

    }
}
