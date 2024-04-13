namespace _16_Methods___Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void SignCheck(int a)
            {
                if (a > 0)
                {
                    Console.WriteLine($"The number {a} is positive.");
                } 
                else if (a < 0)
                {
                    Console.WriteLine($"The number {a} is negative.");

                } else
                {
                    Console.WriteLine($"The number {a} is zero.");

                }
                
            }
            int a = int.Parse(Console.ReadLine() );
            SignCheck(a);

        }
    }
}