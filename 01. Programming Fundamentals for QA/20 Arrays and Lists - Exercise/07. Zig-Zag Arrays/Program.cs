List<int> list1 = new List<int>();
List<int> list2 = new List<int>();
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    int[] pairs = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
    int firstNumber = pairs[0];
    int secondNumber = pairs[1];

    if (i % 2 == 0)
    {
        list1.Add(firstNumber);
        list2.Add(secondNumber);
    }
    else
    {
        list1.Add(secondNumber);
        list2.Add(firstNumber);
    }
}
Console.WriteLine(string.Join(" ", list1));
Console.WriteLine(string.Join(" ", list2));