List<int> list = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
list.Sort((a,b) => b - a);
Console.WriteLine(string.Join(" ", list));