using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23AndMe_SNP_Parsing.FileIO
{
    public static class FileInput
    {
        public static string GetSNPFile()
        {
            // Configure open file dialog box 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Data doc"; // Default file name 
            dlg.DefaultExt = ".data"; // Default file extension 
            dlg.Filter = "data docs (.data)|*.data"; // Filter files by extension 

            // Show open file dialog box 
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                return filename;
            }
            return "";
        }
    }
}
