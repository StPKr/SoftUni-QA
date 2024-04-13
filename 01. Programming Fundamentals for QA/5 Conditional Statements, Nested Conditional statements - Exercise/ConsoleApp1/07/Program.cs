using System;

namespace _07_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mon = Console.ReadLine();
            double ni = double.Parse(Console.ReadLine());
            double studio = 0.0;
            double apart = 0.0;
            switch (mon)
            {
                case "May":
                case "October":
                    studio = 50;
                    apart = 65;
                    if (ni > 7 && ni <= 14)
                    {
                        studio *= 0.95;
                    }
                    else if (ni > 14)
                    {
                        studio *= 0.7;
                        apart *= 0.9;
                    }
                    break;
                case "June":
                case "September":
                    studio = 75.20;
                    apart = 68.70;
                    if (ni > 14)
                    {
                        studio *= 0.8;
                        apart *= 0.9;
                    }
                    break;
                case "July":
                case "August":
                    studio = 76;
                    apart = 77;
                    if (ni > 14)
                    {
                        apart *= 0.9;
                    }
                    break;
            }
            Console.WriteLine($"Apartment: {(apart * ni):f2} lv.");
            Console.WriteLine($"Studio: {(studio * ni):f2} lv.");
        }
    }
}