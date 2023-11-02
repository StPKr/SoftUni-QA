using System;
using System.Collections.Generic;

namespace TestApp;

public class NumberProcessor
{
    public static List<double> ProcessNumbers(List<int> numbers)
    {
        List<double> result = new();

        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                result.Add(Math.Pow(number, 2));
            }
            else
            {
                if (number < 0)
                {
                    throw new ArgumentException("Cannot calculate square root of negative number.");
                }

                result.Add(Math.Sqrt(number));
            }
        }

        return result;
    }
}
