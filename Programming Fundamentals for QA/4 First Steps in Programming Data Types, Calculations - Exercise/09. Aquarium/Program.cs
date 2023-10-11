namespace _09._Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double len = double.Parse(Console.ReadLine());
            double wid = double.Parse(Console.ReadLine());
            double hei = double.Parse(Console.ReadLine());
            double perc = double.Parse(Console.ReadLine());
            double finsum = len * wid * hei * 0.001 * (1 - perc * 0.01);
            Console.WriteLine(finsum);
        }
    }
}