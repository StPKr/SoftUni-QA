namespace _03._Old_Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            string input = "";
            int counter = -1;
            while (input != book && input != "No More Books")
            {
                input = Console.ReadLine();
                counter++;
            }
            if (input == book)
            {
                Console.WriteLine($"You checked {counter} books and found it.");
            }
            else
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {counter} books.");
            }
        }
    }
}