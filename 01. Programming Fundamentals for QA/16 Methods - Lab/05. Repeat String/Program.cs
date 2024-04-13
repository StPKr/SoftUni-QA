namespace _05._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            static void Repeat(string text, int count)
            {
                string output = "";
                for (int i = 0; i < count; i++)
                {
                    output += text;
                }
                Console.WriteLine(output);
            }
            Repeat(text, count);
        }
    }
}