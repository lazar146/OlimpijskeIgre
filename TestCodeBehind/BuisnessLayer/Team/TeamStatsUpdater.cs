using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeBehind.DTO;

namespace TestCodeBehind.BuisnessLayer.Team
{
    public static class TeamStatsUpdater
    {
        public static void UpdateTeamStats(Tim teamA, Tim teamB, MatchResult result)
        {
            if (result.Winner == teamA)
            {
                teamA.Points += 2;
                teamB.Points += 1;
            }
            else
            {
                teamB.Points += 2;
                teamA.Points += 1;
            }

            teamA.ScoredPoints += result.Score.Split(':')[0] == teamA.ISOCode
                ? int.Parse(result.Score.Split(':')[0])
                : int.Parse(result.Score.Split(':')[1]);

            teamB.ScoredPoints += result.Score.Split(':')[1] == teamB.ISOCode
                ? int.Parse(result.Score.Split(':')[1])
                : int.Parse(result.Score.Split(':')[0]);

            teamA.ConcededPoints += result.Score.Split(':')[1] == teamA.ISOCode
                ? int.Parse(result.Score.Split(':')[1])
                : int.Parse(result.Score.Split(':')[0]);

            teamB.ConcededPoints += result.Score.Split(':')[0] == teamB.ISOCode
                ? int.Parse(result.Score.Split(':')[0])
                : int.Parse(result.Score.Split(':')[1]);
        }
    }
}
