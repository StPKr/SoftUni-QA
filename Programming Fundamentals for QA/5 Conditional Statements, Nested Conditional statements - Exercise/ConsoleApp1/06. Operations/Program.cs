using System.Security.Cryptography;
using System;

namespace _06._Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            string op = Console.ReadLine();
            switch (op)
            {
                case "+":
                    double sum = N1 + N2;
                    if (sum % 2 == 0)
                    {
                        Console.WriteLine($"{N1} + {N2} = {sum} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} + ${N2} = ${sum} - odd");
            }
                    break;
                case "-":
                    double diff = N1 - N2;
                    if (diff % 2 == 0)
                    {
                        Console.WriteLine($"{ N1} - ${ N2} = ${ diff} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} - {N2} = {diff} - odd");
            }
                    break;
                case "*":
                    double prod = N1 * N2;
                    if (prod % 2 == 0)
                    {
                        Console.WriteLine($"{N1} * {N2} = {prod} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} * {N2} = {prod} - odd");
            }
                    break;
                case "/":
                    if (N2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {N1} by zero");
            }
                    else
                    {
                        Console.WriteLine($"{N1} / {N2} = {(N1 / N2):f2}");
            }
                    break;
                case "%":
                    if (N2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {N1} by zero");
            }
                    else
                    {
                        Console.WriteLine($"{N1} % {N2} = {N1 % N2}");
            }
                    break;
            }
        }
    }
}