int[] numbers = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();
int evenSum = 0;
int oddSum = 0;
foreach (int element in numbers){ 
    if (element %2 == 0)
    {
        evenSum += element;
    } else
    {
        oddSum += element;
    }
}
Console.WriteLine(evenSum - oddSum);