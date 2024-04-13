using System;

namespace _04._Fishing_Boat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bud = double.Parse(Console.ReadLine());
            string sea = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());
            double pr = 0.0;
            double disc = 0.0;
            double abon = 0.0;
            if (sea == "Spring")
            {
                pr = 3000;
            }
            else if (sea == "Summer" || sea == "Autumn")
            {
                pr = 4200;
            }
            else if (sea == "Winter")
            {
                pr = 2600;
            }
            if (count <= 6)
            {
                disc = 0.1;
            }
            else if (count > 6 && count <= 11)
            {
                disc = 0.15
            }
            else if (count > 11)
            {
                disc = 0.25;
            }
            if (count % 2 == 0 && sea != "Autumn")
            {
                abon = 0.05;
            }
            else
            {
                abon = 0;
            }
            double fin1 = pr - (pr * disc);
            double fin = fin1 - fin1 * abon;
            if (bud >= fin)
            {
                Console.WriteLine($"Yes! You have {(bud - fin):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(fin - bud):f2} leva.");
            }
        }
    } 
}