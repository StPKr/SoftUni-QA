string resource = Console.ReadLine();
int quantity = int.Parse(Console.ReadLine());
Dictionary<string, int> list = new();
while (true)
{
    if (list.ContainsKey(resource))
    {
        list[resource] += quantity;
    }
    else
    {
        list[resource] = quantity;
    }
    resource = Console.ReadLine();
    if (resource == "stop")
    {
        break;
    }
    quantity = int.Parse(Console.ReadLine());
}
foreach (var kvp in list)
{
    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
}