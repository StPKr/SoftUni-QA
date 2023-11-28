using System.Diagnostics.CodeAnalysis;

int countTeams = int.Parse(Console.ReadLine());
Dictionary<string, Team> teams = new Dictionary<string, Team>();

for (int i = 1; i <= countTeams; i++)
{
    string teamData = Console.ReadLine();

    string creator = teamData.Split("-")[0];
    string teamName = teamData.Split("-")[1];

    Team team = new Team(teamName, creator);
    Console.WriteLine($"Team {teamName} has been created by {creator}!");
    teams.Add(teamName, team);
}

string command = Console.ReadLine();
while (command != "end of assignment")
{

    string memberJoin = command.Split("->")[0];
    string teamJoining = command.Split("->")[1];

    teams[teamJoining].Members.Add(memberJoin);

    command = Console.ReadLine();
}

foreach (var team in teams.Where(team => team.Value.Members.Count > 0)
    .OrderByDescending(team => team.Value.Members.Count)
    .ThenBy(team => team.Key))
{
    Console.WriteLine(team.Key);
    Console.WriteLine("- " + team.Value.Creator);
    foreach (string member in team.Value.Members.OrderBy(m => m))
    {
        Console.WriteLine("-- " + member);
    }
}
Console.WriteLine("Teams to disband: ");
foreach (var team in teams.Where(team => team.Value.Members.Count == 0))
{
    Console.WriteLine(team.Key);
}
