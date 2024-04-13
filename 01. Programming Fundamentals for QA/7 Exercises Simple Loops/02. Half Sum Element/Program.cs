namespace _02._Half_Sum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;
            for (int i = 1; i <= n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                sum += a;

                if (a > max)
                {
                    max = a;
                }
            }
                int sumWithoutMaxNumber = sum - max;
                if (max == sumWithoutMaxNumber)
                {
                    Console.WriteLine("Yes");
                    Console.WriteLine("Sum = " + max);
                } else
                {
                    int diff = Math.Abs(max - sumWithoutMaxNumber);
                    Console.WriteLine("No");
                    Console.WriteLine("Diff = " + diff);
                }
                    
                
            
        }
    }
}