namespace _05._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());
            int spendCounter = 0;
            int daysCounter = 0;
            while (true)
            {
                string command = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                daysCounter++;
                if (command == "spend")
                {
                    availableMoney -= money;
                    spendCounter++;
                }
                else if (command == "save")
                {
                    availableMoney += money;
                    spendCounter = 0;
                }
                if (spendCounter >= 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine($"{daysCounter}");
                    break;
                } else if (availableMoney <= 0)
                {
                    availableMoney = 0;
                } else if (availableMoney >= neededMoney)
                {
                    Console.WriteLine($"You saved the money for {daysCounter} days.");
                    break;
                }
            }

            
            


        }
    }
}