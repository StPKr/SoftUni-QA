namespace _06._Sequence_2k_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int a = 1;
            while ( a <= n )
            {
                Console.WriteLine(a);
                a = 2 * a + 1 ;
            }
        }
    }
}