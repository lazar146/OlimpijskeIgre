using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeBehind.DTO;

namespace TestCodeBehind.BuisnessLayer.Team
{
    public static class TeamPrinter
    {
        public static void PrintGroupStandings(string groupName, Group group)
        {
            Console.WriteLine($"Finals in group {groupName}:");
            var sortedTeams = group.Teams
                .OrderByDescending(t => t.Points)
                .ThenByDescending(t => t.PointDifference)
                .ThenByDescending(t => t.ScoredPoints)
                .ToList();

            int position = 1;
            foreach (var team in sortedTeams)
            {
                Console.WriteLine($"{position}. {team.ISOCode} {team.Points} / {team.ScoredPoints} / {team.ConcededPoints} / {team.PointDifference}");
                position++;
            }
        }

        public static void PrintSeedings(List<Tim> topTeams)
        {
            var pots = new Dictionary<string, List<Tim>>()
        {
            { "D", topTeams.Take(2).ToList() },
            { "E", topTeams.Skip(2).Take(2).ToList() },
            { "F", topTeams.Skip(4).Take(2).ToList() },
            { "G", topTeams.Skip(6).Take (2).ToList() }
        };

            Console.WriteLine("Seed D");
            foreach (var team in pots["D"]) Console.WriteLine($"    {team.ISOCode}");
            Console.WriteLine("Seed E");
            foreach (var team in pots["E"]) Console.WriteLine($"    {team.ISOCode}");
            Console.WriteLine("Seed F");
            foreach (var team in pots["F"]) Console.WriteLine($"    {team.ISOCode}");
            Console.WriteLine("Seed G");
            foreach (var team in pots["G"]) Console.WriteLine($"    {team.ISOCode}");
        }
    }
}
