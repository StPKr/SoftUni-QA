using System;

namespace TestApp;

public class CharacterRange
{
    public static string GetRange(char a, char b)
    {
        int chOne = Math.Min(a, b);
        int chTwo = Math.Max(a, b);

        string result = string.Empty;
        for (int i = chOne + 1; i < chTwo; i++)
        {
            result += $"{(char)i} ";
        }

        return result.Trim();
    }
}
