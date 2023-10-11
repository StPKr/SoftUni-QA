using System.Diagnostics.Metrics;

namespace _07._Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            double counter = 0;

            while (amount > 0)
            {
                if (amount >= 2)
                {
                    counter += Math.Floor(amount / 2);
                    amount = Math.Round((amount % 2),2);
                }
                else if (amount >= 1)
                {
                    counter += Math.Floor(amount / 1);
                    amount = Math.Round((amount % 1),2);
                }
                else if (amount >= 0.5)
                {
                    counter += Math.Floor(amount / 0.5);
                    amount = Math.Round((amount % 0.5),2);
                }
                else if (amount >= 0.2)
                {
                    counter += Math.Floor(amount / 0.2);
                    amount = Math.Round((amount % 0.2),2);
                }
                else if (amount >= 0.1)
                {
                    counter += Math.Floor(amount / 0.1);
                    amount = Math.Round((amount % 0.1),2);
                }
                else if (amount >= 0.05)
                {
                    counter += Math.Floor(amount / 0.05);
                    amount = Math.Round((amount % 0.05),2);
                }
                else if (amount >= 0.02)
                {
                    counter += Math.Floor(amount / 0.02);
                    amount = Math.Round((amount % 0.02),2);
                }
                else if (amount >= 0.01)
                {
                    counter += Math.Floor(amount / 0.01);
                    amount = Math.Round((amount % 0.01),2);
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(counter);
        }
    }
}