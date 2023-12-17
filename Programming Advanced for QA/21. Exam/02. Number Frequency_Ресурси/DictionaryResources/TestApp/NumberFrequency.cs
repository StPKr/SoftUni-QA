using System;
using System.Collections.Generic;

namespace TestApp;

public class NumberFrequency
{
    public static Dictionary<int, int> CountDigits(int number)
    {
        number = Math.Abs(number);
        
        Dictionary<int, int> digitFrequency = new();

        while (number > 0)
        {
            int digit = number % 10;
            digitFrequency.TryAdd(digit, 0);
            digitFrequency[digit]++;
            number /= 10;
        }

        return digitFrequency;
    }
}
