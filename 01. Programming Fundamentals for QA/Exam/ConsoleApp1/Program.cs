List<int> integers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    integers.Insert(0, integers[integers.Count - 1]);
    integers.RemoveAt(integers.Count - 1);

}
Console.WriteLine(string.Join(", ", integers));