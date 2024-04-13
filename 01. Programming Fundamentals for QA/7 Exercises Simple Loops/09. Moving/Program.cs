using System.Drawing;

namespace _09._Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int freeSpace = width * length * height;
            while (freeSpace >= 0)
            {
                string command = Console.ReadLine();
                if (command == "Done")
                {
                    break;
                }
                freeSpace -= int.Parse(command);
            }
            if (freeSpace >= 0)
            {
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {-freeSpace} Cubic meters more.");

            }
        }
    }
}