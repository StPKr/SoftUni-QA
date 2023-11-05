int n = int.Parse(Console.ReadLine());
double sum = 0;
for (int i = 0; i < n; i++)
{
    double grade = double.Parse(Console.ReadLine());
    sum += grade;
}
double average = sum / n;
Console.WriteLine(average.ToString("F2"));