using System;
using System.Linq;

namespace TestApp;

public class Fake
{
    public static char[] RemoveStringNumbers(char[]? arr)
    {
        if (arr is null)
        {
            throw new ArgumentException("Array can't be null.");
        }

        return arr.Where(c => !char.IsDigit(c)).ToArray();
    }
}
