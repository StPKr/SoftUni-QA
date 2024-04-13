List<int> integers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
string command = Console.ReadLine();
while (command != "end")
{
    string[] commandParts = command.Split(" ");
    string commandName = commandParts[0];
    int element = int.Parse(commandParts[1]);
    // int element = int.Parse(command.Split(" ")[1]; - оптимален начин;
    switch (commandName)
        // if (command.StartsWith("Add")) - оптимален начин;
    {
        case "Add":
            integers.Add(element);
            break;
        case "Remove":
            integers.Remove(element);
            break;
        case "RemoveAt":
            integers.RemoveAt(element);
            break;
        case "Insert":
            int element2 = int.Parse(commandParts[2]);
            integers.Insert(element2, element);
            break;
    }
    command = Console.ReadLine();
}
Console.WriteLine(string.Join(" ", integers));