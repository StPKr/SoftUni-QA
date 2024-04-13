using System;

namespace _01._Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            double r = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double pr = 0.0;
            switch (type)
            {
                case "Premiere": pr = 12.00; break;
                case "Normal": pr = 7.50; break;
                case "Discount": pr = 5.00; break;
            }
            double sum = r * c * pr;
            Console.WriteLine($"{sum:f2} leva");
        }
    }
}