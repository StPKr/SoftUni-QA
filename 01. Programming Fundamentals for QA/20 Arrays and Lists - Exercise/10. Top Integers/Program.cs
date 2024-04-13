List<int> integers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
List<int> topIntegers = new List<int>();
for (int i = 0; i < integers.Count - 1; i++)
{
    bool check = true;
    for (int j = i + 1; j < integers.Count; j++)
    {
        if (integers[i] <= integers[j])
        {
            check = false;
            break;
        }
    }
    if (check)
    {
        topIntegers.Add(integers[i]);
    }
}
topIntegers.Add(integers[integers.Count - 1]);
Console.WriteLine(string.Join(" ", topIntegers));