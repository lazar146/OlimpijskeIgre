using System.Text.Json;
using TestCodeBehind.BuisnessLayer;
using TestCodeBehind.BuisnessLayer.Team;

string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
string groupsFilePath = Path.Combine(baseDirectory, "groups.json");
string exhibitionsFilePath = Path.Combine(baseDirectory, "exibitions.json");

var allGroups = DataLoader.LoadAllGroups(groupsFilePath);
var allExhibitions = DataLoader.LoadAllExhibitions(exhibitionsFilePath);

foreach (var group in allGroups)
{
    MatchSimulator.SimulateGroupStage(group.Key, group.Value);
}

var rankedTeams = TeamProcessor.CollectRankedTeams(allGroups);
var qualifiedTeams = TeamProcessor.GetQualifiedTeams(rankedTeams);

Console.WriteLine("Seedings:");
TeamPrinter.PrintSeedings(qualifiedTeams);

var knockoutPairs = KnockoutStageOrganizer.CreateKnockoutPairs(qualifiedTeams);
MatchSimulator.SimulateKnockoutRounds(knockoutPairs);



