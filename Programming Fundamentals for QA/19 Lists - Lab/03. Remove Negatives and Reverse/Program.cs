List<int> list = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
List<int> newList = new List<int>();
foreach (int a  in list)
{
    if (a >= 0)
    {
        newList.Add(a);
    }
}
if(newList.Count > 0)
{
    newList.Reverse();
    Console.WriteLine(string.Join(" ", newList));
}
else
{
    Console.WriteLine("empty");
}
