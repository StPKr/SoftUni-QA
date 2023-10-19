List<int> list = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
list.RemoveAll(x => x < 0);
if(list.Count > 0)
{
    list.Reverse();
    Console.WriteLine(string.Join(" ", list));
}
else
{
    Console.WriteLine("empty");
}
