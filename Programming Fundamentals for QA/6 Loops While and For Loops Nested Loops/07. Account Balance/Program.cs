using System;

namespace _07._Account_Balance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double account = 0;
            string command = Console.ReadLine();
                      
            while (command != "NoMoreMoney")
            {
                double money = double.Parse(command);
                if (money < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                account += money;
                Console.WriteLine($"Increase: {money:f2}");
                command = Console.ReadLine();

            }
            Console.WriteLine($"Total: {account:f2}");
        }
    }
}