using System.Collections.Generic;
using System.Linq;

namespace TestApp;

public class Palindrome
{
    public static bool IsPalindrome(List<string> words)
    {
        return words
            .Select(s => s.ToLower())
            .All(word => word.SequenceEqual(word.Reverse()));
    }
}
