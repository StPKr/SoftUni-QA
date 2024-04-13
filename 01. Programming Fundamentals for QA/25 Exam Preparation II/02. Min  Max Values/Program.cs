int[] array = Console.ReadLine()
   .Split(" ")
   .Select(int.Parse)
   .ToArray();
int n = int.Parse(Console.ReadLine());

List<int> list = new List<int>();
for (int i = 0; i < n; i++)
{
    list.Add(array[i]);
}
list.Sort();
Console.WriteLine(list[n -1]);
Console.WriteLine(list[0]);