namespace _07._Food_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double chi = double.Parse(Console.ReadLine());
            double fi = double.Parse(Console.ReadLine());
            double veg = double.Parse(Console.ReadLine());
            double finsum1 = chi * 10.35 + fi * 12.40 + veg * 8.15;
            double finsum = finsum1 + finsum1 * 0.2 + 2.50;
            Console.WriteLine(finsum);
        }
    }
}