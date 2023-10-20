List<int> integers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
List<int> sumArray = new List<int>();
int sum = 0;
for (int i = 0; i < integers.Count() / 2; i++)
{
    int reverseIndex = integers.Count() - 1 - i;
    sum = integers[i] + integers[reverseIndex];
    sumArray.Add(sum);
}
if (integers.Count() % 2 != 0)
{
    int lastElement = integers[integers.Count() / 2];
    sumArray.Add(lastElement);
}
Console.WriteLine(string.Join(" ", sumArray));