int number = Math.Abs(int.Parse(Console.ReadLine()));

int output = GetMultipleOfEvenAndOdds(number);

Console.WriteLine(output);
int GetMultipleOfEvenAndOdds(int number)
{
    int sumEven = GetSumOfEvenDigits(number);
    int sumOdd = GetSumOfOddDigits(number);

    int result = sumEven * sumOdd;
    return result;
}

int GetSumOfEvenDigits(int number)
{
    int sum = 0;
    while (number > 0)
    {
        int digit = number % 10;
        number /= 10;

        if (digit % 2 == 0)
        {
            sum += digit;
        }
    }
    return sum;
}

int GetSumOfOddDigits(int number)
{
    int sum = 0;
    while (number > 0)
    {
        int digit = number % 10;
        number /= 10;

        if (digit % 2 != 0)
        {
            sum += digit;
        }
    }
    return sum;
}