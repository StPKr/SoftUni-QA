namespace _05._Sum_of_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int targetSum = int.Parse(Console.ReadLine());
            int currentSum = 0;

            while (currentSum < targetSum)
            {
                currentSum += int.Parse(Console.ReadLine());

            }
            Console.WriteLine(currentSum);
        }
    }
}