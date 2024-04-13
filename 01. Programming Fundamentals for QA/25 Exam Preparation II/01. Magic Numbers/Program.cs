int n = int.Parse(Console.ReadLine());
bool isThereNoMatchingNumbers = true;
for (int i = 1; i <= n; i++)
{
    int currentNum = i;
    int digitSum = 0;
    bool isAllDigitsPrime = true;

    while (currentNum > 0)
    {
        int digit = currentNum % 10;
        currentNum = currentNum / 10;

        bool isDigitPrime = digit == 2 || digit == 3 || digit == 5 || digit == 7;
        if (isDigitPrime)
        {
            digitSum += digit;
        }
        else
        {
            isAllDigitsPrime = false;
            break;
        }
    }
    if (isAllDigitsPrime && digitSum %2 == 0)
    {
        Console.Write(i + " ");
        isThereNoMatchingNumbers = false;
    }
}
if (isThereNoMatchingNumbers)
{
    Console.WriteLine("no");
}
