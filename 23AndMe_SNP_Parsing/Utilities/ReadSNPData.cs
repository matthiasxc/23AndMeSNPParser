using _23AndMe_SNP_Parsing.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23AndMe_SNP_Parsing.Utilities
{
    public class ReadSNPData
    {
        public GenomeData FullData {get; set;}
        public ReadSNPData(){}

        public void ReadAllData(string fileName){
            FullData = new GenomeData();

            using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (StreamReader sr = new StreamReader(bs))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] items = line.Split('\t');
                            if (items.Length > 1 && items[0] != "index")
                            {
                                SNPDetails snp = new SNPDetails();
                                snp.Index = Convert.ToInt32(items[0]);
                                snp.SNP = items[1];
                                snp.Chromosome = items[2];
                                snp.ChromPosition = Convert.ToInt32(items[3]);

                                if (!FullData.ChromData.ContainsKey(snp.Chromosome))
                                    FullData.ChromData[snp.Chromosome] = new ChromosomeData(snp.Chromosome);
                                FullData.ChromData[snp.Chromosome].SNPs.Add(snp);
                            }
                        }
                    }
                }
            }

            // Sort the SNP data
            List<ChromosomeData> tempData = new List<ChromosomeData>();
            foreach (KeyValuePair<string, ChromosomeData> kvp in FullData.ChromData)
                tempData.Add(kvp.Value);

            var holder = from d in tempData orderby d.Chromosome select d;
            FullData.SortedChromData = holder.ToList();
        }

        public string ReportData()
        {
            if (FullData == null)
                return "No data available";
            else
            {
                string reportReturn = "";
                //Old and busted
                //foreach (KeyValuePair<string, ChromosomeData> kvp in FullData.ChromData)
                //{
                //    if (kvp.Value.SNPs != null)
                //    {
                //        reportReturn += kvp.Value.Chromosome + " - " + kvp.Value.SNPs.Count + " SNPs \n";
                //    }
                //}

                // New hawtness
                foreach (ChromosomeData cd in FullData.SortedChromData)
                    reportReturn += cd.Chromosome + " - " + cd.SNPs.Count.ToString("N0") +" SNPs \n";

                return reportReturn;
            }
        }
    }
}
