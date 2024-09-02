using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCodeBehind.DTO;

namespace TestCodeBehind.BuisnessLayer
{
    public static class DataLoader
    {
        public static Dictionary<string, Group> LoadAllGroups(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File with groups not found at: {filePath}");
            }

            var jsonContent = File.ReadAllText(filePath);
            var groupData = JsonConvert.DeserializeObject<Dictionary<string, List<Tim>>>(jsonContent);

            var groups = new Dictionary<string, Group>();
            foreach (var entry in groupData)
            {
                groups[entry.Key] = new Group { Teams = entry.Value };
            }

            return groups;
        }

        public static Dictionary<string, List<ExhibitionMatch>> LoadAllExhibitions(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File with exhibitions not found at: {filePath}");
            }

            var jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, List<ExhibitionMatch>>>(jsonContent);
        }

        public static void AssignExhibitionsToTeams(Dictionary<string, Group> groups, Dictionary<string, List<ExhibitionMatch>> exhibitions)
        {
            var allTeams = groups.SelectMany(g => g.Value.Teams).ToDictionary(t => t.ISOCode);

            foreach (var exhibitionEntry in exhibitions)
            {
                var teamISOCode = exhibitionEntry.Key;
                if (allTeams.TryGetValue(teamISOCode, out var team))
                {
                    team.ExhibitionMatches.AddRange(exhibitionEntry.Value);
                }
            }
        }
    }
}
