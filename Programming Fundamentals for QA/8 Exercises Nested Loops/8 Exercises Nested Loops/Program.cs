namespace _8_Exercises_Nested_Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int current = 1;
            bool isBigger = false;
            string printCurrentLine = "";
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (current > n)
                    {
                        isBigger = true;
                        break;
                    }
                    printCurrentLine += current + " ";
                    current++;
                }
                Console.WriteLine(printCurrentLine);
                printCurrentLine = "";
                if (isBigger)
                {
                    break;
                }
            }
        }
    }
}