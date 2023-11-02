using System;

namespace TestApp;

public class Average
{
    public static double CalculateAverage(int[] numbers)
    {
        if (numbers.Length == 0)
        {
            throw new ArgumentException("Input array cannot be empty.");
        }

        int sum = 0;

        foreach (int number in numbers)
        {
            sum += number;
        }

        return (double)sum / numbers.Length;
    }
}
