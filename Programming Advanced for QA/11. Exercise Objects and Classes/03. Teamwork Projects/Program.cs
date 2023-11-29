int countTeams = int.Parse(Console.ReadLine());
Dictionary<string, Team> teams = new Dictionary<string, Team>();
List<string> creators = new List<string>();

for (int i = 1; i <= countTeams; i++)
{
    string teamData = Console.ReadLine();

    string creator = teamData.Split("-")[0];
    string teamName = teamData.Split("-")[1];
    if (teams.ContainsKey(teamName))
    {
        Console.WriteLine($"Team {teamName} was already created!");
    }
    else if (creators.Contains(creator))
    {
        Console.WriteLine($"{creator} cannot create another team!");
    }
    else
    {
        Team team = new Team(teamName, creator);
        Console.WriteLine($"Team {teamName} has been created by {creator}!");
        teams.Add(teamName, team);
        creators.Add(creator);
    }
    
}

string command = Console.ReadLine();
while (command != "end of assignment")
{

    string memberJoin = command.Split("->")[0];
    string teamJoining = command.Split("->")[1];

    if (!teams.ContainsKey(teamJoining))
    {
        Console.WriteLine($"Team {teamJoining} does not exist!");
    }
    else if (creators.Contains(memberJoin) || teams[teamJoining].Creator == memberJoin || teams[teamJoining].Members.Contains(memberJoin))
    {
        Console.WriteLine($"Member {memberJoin} cannot join team {teamJoining}!");
    }
    else
    {
        teams[teamJoining].Members.Add(memberJoin);
    }
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
foreach (var team in teams.Where(team => team.Value.Members.Count == 0).OrderBy(team => team.Key))
{
    Console.WriteLine(team.Key);
}
