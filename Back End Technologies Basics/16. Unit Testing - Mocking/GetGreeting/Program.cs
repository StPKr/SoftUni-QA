namespace GetGreeting
{
    class Program
    {
        static void Main(string[] args)
        {
            GreetingProvider greetingProvider = new GreetingProvider();
            string greeting = greetingProvider.GetGreeting();
            Console.WriteLine(greeting);
        }
    }

}