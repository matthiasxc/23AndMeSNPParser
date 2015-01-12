using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23AndMe_SNP_Parsing.Models
{
    public class ChromosomeData
    {
        public ChromosomeData(string chrom)
        {
            Chromosome = chrom;
            SNPs = new List<SNPDetails>();
        }
        public string Chromosome { get; set;}
        public List<SNPDetails> SNPs { get; set; }
    }
}
