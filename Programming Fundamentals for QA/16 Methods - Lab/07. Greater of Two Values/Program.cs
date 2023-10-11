namespace _07._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {

            static int FindGreaterNumber(int num1, int num2)
            {
                throw new NotImplementedException();
            }
            string valueType = Console.ReadLine();

            if (valueType == "int")
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                Console.WriteLine(FindGreaterNumber(num1, num2));
            }
            else if (valueType == "char") 
            {
                char ch1 = char.Parse(Console.ReadLine());
                char ch2 = char.Parse(Console.ReadLine());
            }
            else if (valueType == "string")
            {
                string str1 = Console.ReadLine();
                string str2 = Console.ReadLine();
            }
        }

        
    }
}