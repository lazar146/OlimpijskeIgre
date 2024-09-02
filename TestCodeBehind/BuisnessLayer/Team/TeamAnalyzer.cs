using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeBehind.DTO;

namespace TestCodeBehind.BuisnessLayer.Team
{
    public static class TeamAnalyzer
    {
        public static double CalculateForm(Tim team)
        {
            double formScore = 0;
            foreach (var match in team.ExhibitionMatches)
            {
                if (match.Result == "win")
                {
                    formScore += 5;
                }
                else if (match.Result == "loss")
                {
                    formScore -= 3;
                }
            }
            return formScore;
        }
    }
}
