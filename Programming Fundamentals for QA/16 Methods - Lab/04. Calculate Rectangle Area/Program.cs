namespace _04._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static int Area(int w, int l)
            {
                return w * l;
            }
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int area = Area(width, length);
            Console.WriteLine(area);
        }
    }
}