string values = Console.ReadLine();
List<int> list = values.Split(" ").Select(int.Parse).ToList();
string commands = Console.ReadLine();
List<string> elements = commands.Split(" ").ToList();
while (elements[0] != "end")
{
    switch (elements[0])
    {
        case "Delete":
            while (list.Contains(int.Parse(elements[1]))){ 
            foreach (int a in list)
            {
                if (a == int.Parse(elements[1]))
                {
                    list.Remove(a);
                }
            }
            }
            break;
        case "Insert":
            list.Insert(int.Parse(elements[1]), int.Parse(elements[2]));
            break;


    }
    commands = Console.ReadLine();
    elements = commands.Split(" ").ToList();
}
Console.WriteLine(string.Join(" ", list));