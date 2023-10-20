List<int> integers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
int[] commands = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
int bombNumber = commands[0];
int power = commands[1];
while (integers.Contains(bombNumber))
{
    int position = integers.IndexOf(bombNumber);
    int numbersToRemove = power * 2 + 1;
    int startIndex = position - power;

    if (startIndex < 0)
    {
        startIndex = 0;
    }
    integers.RemoveRange(startIndex, numbersToRemove);
    }
    //integers.RemoveRange(startIndex, endIndex);
}
int sum = integers.Sum();
Console.WriteLine(sum);