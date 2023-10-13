int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());

static string SignChecker(int a, int b, int c)
{
    if (a == 0 || b == 0 || c == 0)
    {
        return "zero";
    }
    else if (((a > 0) && (b > 0) && (c > 0))
        || ((a < 0) && (b > 0) && (c < 0))
        || ((a < 0) && (b < 0) && (c > 0))
        || ((a > 0) && (b < 0) && (c < 0)))
    {
        return "positive";
    }
    else
    {
        return "negative";
    }
}
Console.WriteLine(SignChecker(a, b, c));