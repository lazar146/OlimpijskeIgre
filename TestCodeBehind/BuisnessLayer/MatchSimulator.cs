using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeBehind.BuisnessLayer.Team;
using TestCodeBehind.DTO;

namespace TestCodeBehind.BuisnessLayer
{
    public static class MatchSimulator
    {
        public static void SimulateGroupStage(string groupName, Group group)
        {
            Console.WriteLine($"Group Stage - Round 1 for group {groupName}:");

            for (int i = 0; i < group.Teams.Count; i++)
            {
                for (int j = i + 1; j < group.Teams.Count; j++)
                {
                    var result = SimulateGame(group.Teams[i], group.Teams[j]);
                    Console.WriteLine($"{group.Teams[i].ISOCode} - {group.Teams[j].ISOCode} ({result.Score})");

                    TeamStatsUpdater.UpdateTeamStats(group.Teams[i], group.Teams[j], result);
                }
            }

            TeamProcessor.SortTeamsByPerformance(group);
            TeamPrinter.PrintGroupStandings(groupName, group);
        }

        public static MatchResult SimulateGame(Tim teamA, Tim teamB)
        {
            Random randomGenerator = new Random();
            int rankDifference = teamA.FIBARanking - teamB.FIBARanking;

            double formA = TeamAnalyzer.CalculateForm(teamA);
            double formB = TeamAnalyzer.CalculateForm(teamB);

            int scoreA = randomGenerator.Next(80, 100) + rankDifference / 10 + (int)formA;
            int scoreB = randomGenerator.Next(80, 100) - rankDifference / 10 + (int)formB;

            while (scoreA == scoreB)
            {
                scoreA += randomGenerator.Next(1, 5);
            }

            return scoreA > scoreB
                ? new MatchResult { Winner = teamA, Loser = teamB, Score = $"{scoreA}:{scoreB}" }
                : new MatchResult { Winner = teamB, Loser = teamA, Score = $"{scoreB}:{scoreA}" };
        }

        public static void SimulateKnockoutRounds(List<MatchResult> matches)
        {
            Console.WriteLine("Quarterfinals:");
            foreach (var match in matches)
            {
                Console.WriteLine($"{match.Winner.ISOCode} vs {match.Loser.ISOCode} ({match.Score})");
            }

            var semiFinals = KnockoutStageOrganizer.PrepareNextRound(matches);
            Console.WriteLine("Semifinals:");
            foreach (var match in semiFinals)
            {
                Console.WriteLine($"{match.Winner.ISOCode} vs {match.Loser.ISOCode} ({match.Score})");
            }

            var finals = KnockoutStageOrganizer.PrepareNextRound(semiFinals);
            Console.WriteLine("Finals:");
            foreach (var match in finals)
            {
                Console.WriteLine($"{match.Winner.ISOCode} vs {match.Loser.ISOCode} ({match.Score})");
            }

            var thirdPlace = new List<MatchResult>
            {
                new MatchResult
                {
                    Winner = semiFinals[1].Loser,
                    Loser = semiFinals[0].Loser,
                    Score = SimulateGame(semiFinals[1].Loser, semiFinals[0].Loser).Score
                }
            };
            Console.WriteLine("Match for Third Place:");
            foreach (var match in thirdPlace)
            {
                Console.WriteLine($"{match.Winner.ISOCode} vs {match.Loser.ISOCode} ({match.Score})");
            }
        }
    }
}
