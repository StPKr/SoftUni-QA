using System;

namespace _09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string assessment = Console.ReadLine();
            double nightPrice = 0;

            switch (type)
            {
                case "room for one person":
                    nightPrice = 118.00; break;
                case "apartment":
                    nightPrice = 155.00;
                    if (days < 10)
                    
                        nightPrice *= 0.7;
                    
                    else if (days >= 10 && days <= 15)
                    {
                        nightPrice *= 0.65;
                    } else if (days > 15)
                    {
                        nightPrice *= 0.5;
                    }break;
                case "president apartment":
                    nightPrice = 235.00;
                    if (days < 10)
                    {
                        nightPrice *= 0.9;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        nightPrice *= 0.85;
                    }
                    else if (days > 15)
                    {
                        nightPrice *= 0.8;
                    }break;
            }
            double totalStayPrice = (days - 1) * nightPrice;
            switch (assessment)
            {
                case "positive": totalStayPrice *= 1.25;break;
                case "negative": totalStayPrice *= 0.9; break;
            }
            Console.WriteLine($"{totalStayPrice:f2}");




            /*int duration = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string grade = Console.ReadLine();
            double nights = duration - 1;
            double price = 0;
            double discount = 0;
            if (type == "room for one person")
            {
                price = 118.00;
                discount = 0;
            }
            else if (type == "apartment")
            {
                price = 155.00;
                if (duration > 15)
                {
                    discount = 0.5;
                }
                else if (duration >= 10)
                {
                    discount = 0.35;
                }
                else if (duration < 10)
                {
                    discount = 0.3;
                }
            }
            else if (type == "president apartment")
            {
                price = 235.00;
                if (duration > 15)
                {
                    discount = 0.2;
                }
                else if (duration >= 10)
                {
                    discount = 0.15;
                }
                else if (duration < 10)
                {
                    discount = 0.1;
                }
            }
            double finPrice = nights * price;
            double finalPrice = finPrice - finPrice * discount;
            double extradiscount;
            double finalfinalPrice;
            if (duration < 1){
            if (grade == "positive")
            {
                extradiscount = 0.25;
                finalfinalPrice = finalPrice + finalPrice * extradiscount;
            }
            else
            {
                extradiscount = 0.1;
                finalfinalPrice = finalPrice - finalPrice * extradiscount;
            }
            Console.WriteLine($"{finalfinalPrice:f2}");*/
        }
    }
}