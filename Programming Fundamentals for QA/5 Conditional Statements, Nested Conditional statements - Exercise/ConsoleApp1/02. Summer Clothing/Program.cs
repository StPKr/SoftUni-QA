using System;

namespace _02._Summer_Clothing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double deg = double.Parse(Console.ReadLine());
            string time = Console.ReadLine();
            string outfit = "";
            string shoes = "";
            if (deg >= 10 && deg <= 18)
            {
                switch (time)
                {
                    case "Morning":
                        outfit = "Sweatshirt";
                        shoes = "Sneakers"; break;
                    case "Afternoon":
                        outfit = "Shirt";
                        shoes = "Moccasins"; break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins"; break;
                }
            }
            else if (deg > 18 && deg <= 24)
            {
                switch (time)
                {
                    case "Morning":
                        outfit = "Shirt";
                        shoes = "Moccasins"; break;
                    case "Afternoon":
                        outfit = "T-Shirt";
                        shoes = "Sandals"; break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins"; break;
                }
            }
            else
            {
                switch (time)
                {
                    case "Morning":
                        outfit = "T-Shirt";
                        shoes = "Sandals"; break;
                    case "Afternoon":
                        outfit = "Swim Suit";
                        shoes = "Barefoot"; break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins"; break;
                }
            }
            Console.WriteLine($"It's {deg} degrees, get your {outfit} and {shoes}.");
}
    }
    }
