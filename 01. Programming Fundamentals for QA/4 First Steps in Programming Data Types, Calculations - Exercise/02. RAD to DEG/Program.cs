namespace _02._RAD_to_DEG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double rad = double.Parse(Console.ReadLine());
            double degree = rad * 180 / Math.PI;
            Console.WriteLine(degree);
        }
    }
}