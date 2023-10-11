using System.Reflection;

namespace _08._Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int size = width * length;
            while (size >= 0)
            {
                string command = Console.ReadLine();
                if (command == "STOP")
                {
                    break;

                }
                size -= int.Parse(command);
            }
            if (size >= 0)
            {
                Console.WriteLine($"{size} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {-size} pieces more.");

            }
        }


    }
}
