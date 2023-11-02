using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp;

public class MaxNumber
{
    public static int FindMax(List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0)
        {
            throw new ArgumentException("Input list is empty or null.");
        }

        return numbers.Max();
    }
}
