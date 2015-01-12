using _23AndMe_SNP_Parsing.FileIO;
using _23AndMe_SNP_Parsing.Models;
using _23AndMe_SNP_Parsing.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _23AndMe_SNP_Parsing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string targetFile = "";
        ReadSNPData parseUtility = new ReadSNPData();
        FileOutput fo = new FileOutput();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            targetFile = FileInput.GetSNPFile();
            
            // Get that initial directory
            string[] directoryParsing = targetFile.Split('\\');
            string directory ="";
            for (int i = 0; i < directoryParsing.Length - 1; i++)
            {
                directory += directoryParsing[i] + "\\"; 
            }
            fo.InitialDirectory = directory;
            parseUtility.ReadAllData(targetFile);

            Results.Text = parseUtility.ReportData();
        }

        private void ExportData_Click(object sender, RoutedEventArgs e)
        {
            foreach(ChromosomeData cd in parseUtility.FullData.SortedChromData)
            {
                fo.WriteChromeFile(cd.Chromosome, ".data", cd.SNPs);
            }
        }


    }
}
