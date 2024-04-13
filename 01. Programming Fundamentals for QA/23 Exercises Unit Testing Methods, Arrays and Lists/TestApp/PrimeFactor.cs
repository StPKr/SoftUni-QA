using System;

namespace TestApp;

public class PrimeFactor
{
    public static long FindLargestPrimeFactor(long number)
    {
        if (number <= 1)
        {
            throw new ArgumentException("Input must be greater than 1.");
        }

        long largestFactor = 1;
        long divisor = 2;

        while (number > 1)
        {
            if (number % divisor == 0)
            {
                largestFactor = divisor;
                number /= divisor;
                continue;
            } 
            
            divisor++;
        }

        return largestFactor;
    }
}
