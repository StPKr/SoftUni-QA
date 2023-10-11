namespace _04._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            static void Area(int width, int length)
            {
                int area = width * length;
                Console.WriteLine(area);
            }
            Area(width, length);
        }
    }
}