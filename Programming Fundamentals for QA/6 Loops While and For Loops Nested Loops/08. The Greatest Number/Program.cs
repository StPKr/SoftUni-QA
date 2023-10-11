namespace _08._The_Greatest_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int n = int.MinValue;
            while (command != "Stop")
            {
                int a = int.Parse(command);
                if (n < a)
                {
                    n = a;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(n);

        }
    }
}