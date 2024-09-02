using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeBehind.DTO;

namespace TestCodeBehind.BuisnessLayer
{
    public static class KnockoutStageOrganizer
    {
        public static List<MatchResult> CreateKnockoutPairs(List<Tim> qualifiedTeams)
        {
            var knockoutPairs = new List<MatchResult>();
            for (int i = 0; i < qualifiedTeams.Count / 2; i++)
            {
                knockoutPairs.Add(new MatchResult
                {
                    Winner = qualifiedTeams[i],
                    Loser = qualifiedTeams[qualifiedTeams.Count - 1 - i],
                    Score = MatchSimulator.SimulateGame(qualifiedTeams[i], qualifiedTeams[qualifiedTeams.Count - 1 - i]).Score
                });
            }

            return knockoutPairs;
        }

        public static List<MatchResult> PrepareNextRound(List<MatchResult> previousRoundWinners)
        {
            var nextRound = new List<MatchResult>();
            for (int i = 0; i < previousRoundWinners.Count / 2; i++)
            {
                nextRound.Add(new MatchResult
                {
                    Winner = previousRoundWinners[i].Winner,
                    Loser = previousRoundWinners[previousRoundWinners.Count - 1 - i].Winner,
                    Score = MatchSimulator.SimulateGame(previousRoundWinners[i].Winner, previousRoundWinners[previousRoundWinners.Count - 1 - i].Winner).Score
                });
            }

            return nextRound;
        }
    }
}
