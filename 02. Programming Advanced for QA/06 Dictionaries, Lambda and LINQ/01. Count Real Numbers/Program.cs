int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

SortedDictionary<int, int> numberFrequency = new();

foreach (int number in numbers)
{
    if (numberFrequency.ContainsKey(number))
    {
        numberFrequency[number] = numberFrequency[number] + 1;
    }
    else
    {
        numberFrequency.Add(number, 1);
    }
}
foreach (KeyValuePair<int, int> pair in numberFrequency)
{
    Console.WriteLine($"{pair.Key} -> {pair.Value}");
}
