using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23AndMe_SNP_Parsing.Models
{
    public class GenomeData
    {
        public GenomeData()
        {
            ChromData = new Dictionary<string, ChromosomeData>();
        }
        public Dictionary<string, ChromosomeData> ChromData { get; set; }

        public List<ChromosomeData> SortedChromData { get; set;}
    }
}
