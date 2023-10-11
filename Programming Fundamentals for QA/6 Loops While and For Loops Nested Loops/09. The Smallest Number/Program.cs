namespace _09._The_Smallest_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int n = int.MaxValue;
            while (command != "Stop")
            {
                int a = int.Parse(command);
                if (n > a)
                {
                    n = a;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(n);
        }
    }
}