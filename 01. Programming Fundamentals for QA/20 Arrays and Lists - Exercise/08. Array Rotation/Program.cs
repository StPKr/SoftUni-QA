List<int> integers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
int rotations = int.Parse(Console.ReadLine());
for (int i = 0; i < rotations; i++)
{
    int firstElement = integers[0];
    integers.RemoveAt(0);
    integers.Add(firstElement);
}
Console.WriteLine(string.Join(" ", integers));