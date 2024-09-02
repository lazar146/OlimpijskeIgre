using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCodeBehind.DTO
{

    public class Tim
    {
        public string TeamName { get; set; }
        public string ISOCode { get; set; }
        public int FIBARanking { get; set; }
        public int Points { get; set; } = 0;
        public int ScoredPoints { get; set; } = 0;
        public int ConcededPoints { get; set; } = 0;

        public int PointDifference => ScoredPoints - ConcededPoints;
        public List<ExhibitionMatch> ExhibitionMatches { get; set; }

        public Tim()
        {
            ExhibitionMatches = new List<ExhibitionMatch>();
        }

    }
}