Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

string input = Console.ReadLine();

while (input != "End")
{

    string[] inputArray = input.Split(" -> ");
    string company = inputArray[0];
    string employeeID = inputArray[1];

    if (!companies.ContainsKey(company))
    {
        companies.Add(company, new List<string>());
    }
    if (!companies[company].Contains(employeeID))
    {
        companies[company].Add(employeeID);
    }

    input = Console.ReadLine();
}

foreach (KeyValuePair<string, List<string>> currentCompany in companies)
{
    Console.WriteLine(currentCompany.Key);

    foreach (string currentEmployeeId in currentCompany.Value)
    {
        Console.WriteLine($"-- {currentEmployeeId}");
    }
}