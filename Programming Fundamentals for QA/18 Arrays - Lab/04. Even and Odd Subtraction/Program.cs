int[] numbers = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();
int evenSum = 0;
int oddSum = 0;
for (int i = 0; i < numbers.Length; i++)
{
    int element = numbers[i];
    if (element %2 == 0)
    {
        evenSum += element;
    } else
    {
        oddSum += element;
    }
}
Console.WriteLine(evenSum - oddSum);