using System;

namespace _3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dep = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());
            double amount = dep + months * dep * interest / 100 / 12;

            Console.WriteLine(amount);
        }
    }
}