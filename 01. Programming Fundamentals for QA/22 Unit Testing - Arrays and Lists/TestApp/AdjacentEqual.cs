using System;
using System.Collections.Generic;

namespace TestApp;

public class AdjacentEqual
{
    public static string Sum(List<int>? numbers)
    {
        if (numbers is null)
        {
            throw new ArgumentException(nameof(numbers));
        }

        for (int i = 0; i < numbers.Count - 1; i++)
        {
            if (numbers[i] != numbers[i + 1])
            {
                continue;
            }

            numbers[i] += numbers[i + 1];
            numbers.RemoveAt(i + 1);
            i = -1;
        }

        return string.Join(" ", numbers);
    }
}
