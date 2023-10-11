namespace _06._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Power(a, b);
            static void Power (int x, int y)
            {
                double output = Math.Pow(x, y);
                Console.WriteLine(output);
            }
            
        }
    }
}