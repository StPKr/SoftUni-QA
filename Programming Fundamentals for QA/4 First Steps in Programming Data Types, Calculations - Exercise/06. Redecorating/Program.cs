namespace _06._Redecorating
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double nai = double.Parse(Console.ReadLine());
            double boq = double.Parse(Console.ReadLine());
            double razr = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double finsum1 = (nai + 2) * 1.50 + (boq + 0.1 * boq) * 14.50 + razr * 5 + 0.4;
            double finsum = finsum1 * 0.3 * h + finsum1;
            Console.WriteLine(finsum);
        }
    }
}