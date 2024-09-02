using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeBehind.DTO;

namespace TestCodeBehind.BuisnessLayer.Team
{
    public static class TeamProcessor
    {
        public static Dictionary<string, Tim> CollectRankedTeams(Dictionary<string, Group> groups)
        {
            var rankedTeams = new Dictionary<string, Tim>();

            foreach (var group in groups)
            {
                foreach (var team in group.Value.Teams)
                {
                    rankedTeams.Add($"{group.Key}-{team.ISOCode}", team);
                }
            }

            return rankedTeams;
        }

        public static List<Tim> GetQualifiedTeams(Dictionary<string, Tim> rankedTeams)
        {
            return rankedTeams.Values
                .OrderByDescending(t => t.Points)
                .ThenByDescending(t => t.PointDifference)
                .ThenByDescending(t => t.ScoredPoints)
                .ToList();
        }

        public static void SortTeamsByPerformance(Group group)
        {
            group.Teams = group.Teams
                .OrderByDescending(t => t.Points)
                .ThenByDescending(t => t.PointDifference)
                .ThenByDescending(t => t.ScoredPoints)
                .ToList();
        }
    }
}
