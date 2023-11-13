using System.IO.Pipes;
using System.Security.AccessControl;

string[] numbers = Console.ReadLine().Split(" ");

Dictionary<string, int> numberFrequency = new();

foreach (string number in numbers)
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
foreach (KeyValuePair<string, int> pair in numberFrequency)
{
    Console.WriteLine($"{pair.Key} -> {pair.Value}");
}
