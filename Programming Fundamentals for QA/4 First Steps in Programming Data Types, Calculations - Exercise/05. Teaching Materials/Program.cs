namespace _05._Teaching_Materials
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pen =double.Parse(Console.ReadLine());
            double mark = double.Parse(Console.ReadLine());
            double litre = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());
            double finsum1 = pen * 5.80 + mark * 7.20 + litre * 1.20;
            double finsum = finsum1 - finsum1 * discount / 100;
            Console.WriteLine(finsum);
        }
    }
}