namespace ConsoleAppMagic
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sum = Sum(10, 20);
            Console.WriteLine();
        }

        public static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}