using System;

namespace _03._New_Home
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());
            double bud = double.Parse(Console.ReadLine());
            double pr = 0.0;
            double disc = 0.0;
            double inc = 0.0;
            double fin = 0.0;
    if (type == "Roses")
            {
                pr = 5;
                if (count > 80)
                {
                    disc = 0.1;
                    fin = pr * count - pr * count * disc;
                }
                else
                {
                    fin = pr * count;
                }
            }
            else if (type == "Dahlias")
            {
                pr = 3.80;
                if (count > 90)
                {
                    disc = 0.15;
                    fin = pr * count - pr * count * disc;
                }
                else
                {
                    fin = pr * count;
                }
            }
            else if (type == "Tulips")
            {
                pr = 2.80;
                if (count > 80)
                {
                    disc = 0.15;
                    fin = pr * count - pr * count * disc;
                }
                else
                {
                    fin = pr * count;
                }
            }
            else if (type == "Narcissus")
            {
                pr = 3;
                if (count < 120)
                {
                    inc = 0.15;
                    fin = pr * count + pr * count * inc;
                }
                else
                {
                    fin = pr * count;
                }
            }
            else if (type == "Gladiolus")
            {
                pr = 2.50;
                if (count < 80)
                {
                    inc = 0.2;
                    fin = pr * count + pr * count * inc;
                }
                else
                {
                    fin = pr * count;
                }
            }
            if (bud >= fin)
            {
                Console.WriteLine($"Hey, you have a great garden with {count} {type} and {(bud - fin):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(fin - bud):f2} leva more.");
            }
        }
    }
}