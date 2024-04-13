int[] array = Console.ReadLine()
  .Split(" ")
  .Select(int.Parse)
  .ToArray();
int n = int.Parse(Console.ReadLine());
int firstElement = array.Length - 1;
int lastElement = array.Length - n;
List<double> list = new List<double>();
for (int i = firstElement; i >= lastElement; i--)
{
    list.Add(array[i]);
}
double sum = list.Sum() / n;
Console.WriteLine(sum.ToString("F2"));