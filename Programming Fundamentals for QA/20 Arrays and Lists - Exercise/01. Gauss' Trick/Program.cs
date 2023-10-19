List<int> integers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
List<int> sumArray = new List<int>();
int sum = 0;
for (int i = 0; i <= integers.Count()/2; i++)
{
    int reverseIndex = integers.Count() - 1 - i;
    if (integers.Count() % 2 == 0)
    {
    sum = integers[i] + integers[reverseIndex];
    }
    else
    {
        if (i == reverseIndex - 1)
        {
            sum = integers[i];
        }
        else
        {
            sum = integers[i] + integers[reverseIndex];
        }
    }
    sumArray.Add(sum);
}
Console.WriteLine(string.Join(" ", sumArray));