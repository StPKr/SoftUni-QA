namespace _04._Mandatory_Literature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int pph = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int finsum = pages / pph / days;
            Console.WriteLine(finsum);
        }
    }
}