int a = int.Parse(Console.ReadLine());
int b =  int.Parse(Console.ReadLine());
Console.WriteLine(FactorialDivision(a, b));
static double FactorialDivision(int a, int b)
{
    double factorialA = 1;
    double factorialB = 1;
    for (int i = 1; i <= a; i++)
    {
        factorialA *= i; 
    }
    for (int j = 1; j <= b; j++)
    {
        factorialB *= j;
    }
    return factorialA / factorialB;
}