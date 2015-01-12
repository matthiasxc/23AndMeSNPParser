using _23AndMe_SNP_Parsing.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23AndMe_SNP_Parsing.FileIO
{
    public class FileOutput
    {
        private string fileFolder {get; set;}
        public string InitialDirectory { get; set; }
        //public void SelectFileFolder()
        //{
        //    Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
        //    sfd.InitialDirectory = 
        //    //System.Windows. FormFolderBrowserDialog fbd = new FolderBrowserDialog();
        //    //DialogResult result = fbd.ShowDialog();

        //    //string[] files = Directory.GetFiles(fbd.SelectedPath);
        //}
        public bool WriteChromeFile(string fileName, string extension, List< SNPDetails> snpDetails)
        {
            try { 
                // if the file name is nothing, call it "unspecified"
                if(fileName == "")
                    fileName = "unspecified";

                // create the path
                string path = InitialDirectory + fileName + extension;
                // if the file exists, delete it
                if (File.Exists(path))
                    System.IO.File.Delete(path);

                // If it is a *.data file, use a tab delimitor, 
                // otherwise use a comma
                string delimitor = ",";
                if (extension == ".data")
                    delimitor = "\t";

                // Construct string
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("index" + delimitor + "snp" + delimitor + "chromosome" + delimitor + "chromosome_position");
                foreach (SNPDetails snpD in snpDetails)
                {
                    sb.AppendLine(snpD.Index + delimitor +
                                  snpD.SNP + delimitor +
                                  snpD.Chromosome + delimitor +
                                  snpD.ChromPosition);
                }
            
                using (FileStream fs = File.Create(path))
                {
                    Byte[] fileDetails = new UTF8Encoding(true).GetBytes(sb.ToString());
                    fs.Write(fileDetails, 0, fileDetails.Length);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
