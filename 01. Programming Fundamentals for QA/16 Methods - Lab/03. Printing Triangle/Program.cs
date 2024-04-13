namespace _03._Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            static void PrintLine(int start, int end)
            {
                for (int i = start; i <= end; i++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            static void PrintTriangle (int num)
            {
                for (int currentLine = 1; currentLine <= num; currentLine++)
                {
                    PrintLine(1, currentLine);
                }
                for (int currentLine = num - 1; currentLine >= 1; currentLine--)
                {
                    PrintLine(1, currentLine);
                }
            }
            int number = int.Parse(Console.ReadLine());
            PrintTriangle(number);
            /* 
             int a = int.Parse(Console.ReadLine());
             static void Figure(int a)
            {
                
                for (int i = 1;  i <= a; i++)
                {
                    string b = "";
                    for (int j = 1; j <= i; j++)
                    {
                        b += j.ToString() + " ";
                        
                    }
                    Console.WriteLine(b);
                }
                for (int k = a - 1; k >= 1; k--)
                {
                    string c = "";
                    for (int h = 1; h <= k; h++)
                    {
                        c += h.ToString() + " ";
                    }
                    Console.WriteLine(c);
                }
            }
            Figure(a); */
        }
    }
}