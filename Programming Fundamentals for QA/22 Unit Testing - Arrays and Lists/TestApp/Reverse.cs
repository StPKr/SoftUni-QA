using System;

namespace TestApp;

public class Reverse
{
    public static string ReverseArray(int[] arr)
    {
        Array.Reverse(arr);
        return string.Join(" ", arr);
    }
}
