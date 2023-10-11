using System;

namespace _05._Special_ns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string result = "";
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int l = 1; l <= 9; l++)
                        {
                            bool isSpecial = n % i == 0 && 
                                n % j == 0 &&  
                                n % k == 0 && 
                                n% l == 0;
                            if (isSpecial)
                            {
                                result += $"{i}{j}{k}{l} ";
                            }

                        }
                    }
                }
            }
            Console.WriteLine(result);

        }
    }
}