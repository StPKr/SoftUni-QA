namespace _03._Sum_of_Prime_and_Non_Prime_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int primeSum = 0;
            int nonPrimeSum = 0;
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "stop")
                {
                    break;
                }
                int a = int.Parse(command);
                if (a < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }
                int divisors = 0;
                for (int i = 1; i <= a; i++)
                {
                    if (a % i == 0) { 
                        divisors++; 
                    }
                }
                if (divisors == 2)
                {
                    primeSum += a;
                } else
                {
                    nonPrimeSum += a;
                }

            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");


        }
    }
}