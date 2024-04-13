int[] array = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();

if (array.Length > 0)
{
    int index1 = array.Length / 2 - 1;
    int index2 = array.Length / 2;

    double a = array[index1];
    double b = array[index2];
    double result = (a + b) / 2;
    Console.WriteLine(result.ToString("F2"));
}
else
{
    Console.WriteLine(0);
}
