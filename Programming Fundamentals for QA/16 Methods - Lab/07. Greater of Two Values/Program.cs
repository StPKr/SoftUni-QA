namespace _07._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {

            static int FindGreaterNumber(int num1, int num2)
            {
                if (num1 > num2)
                {
                    return num1;
                }
                else
                {
                    return num2;
                }
            }

            static char FindGreaterChar(char ch1, char ch2)
            {
                if (ch1 > ch2)
                {
                    return ch1;
                }
                else
                {
                    return ch2;
                }
            }

            static string  FindGreaterString(string? str1, string? str2)
            {
                if (str1.CompareTo(str2) > 0)
                {
                    return str1;
                }
                else
                {
                    return str2;
                }
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

                Console.WriteLine(FindGreaterChar(ch1, ch2));
            }
            else if (valueType == "string")
            {
                string str1 = Console.ReadLine();
                string str2 = Console.ReadLine();

                Console.WriteLine(FindGreaterString(str1, str2));
            }

        }
              
    }
}