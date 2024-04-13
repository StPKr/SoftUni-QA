namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bud = double.Parse(Console.ReadLine());
            string sez = Console.ReadLine();
            string dest = "";
            string pl = "";
            if (bud <= 100)
            {
                dest = "Bulgaria";
                switch (sez)
                {
                    case "summer": bud *= 0.3; pl = "Camp"; break;
                    case "winter": bud *= 0.7; pl = "Hotel"; break;
                }
            }
            else if (100 < bud && bud <= 1000)
            {
                dest = "Balkans";
                switch (sez)
                {
                    case "summer": bud *= 0.4; pl = "Camp"; break;
                    case "winter": bud *= 0.8; pl = "Hotel"; break;
                }
            }
            else
            {
                dest = "Europe";
                bud *= 0.9;
                pl = "Hotel";
            }
            Console.WriteLine("Somewhere in " + dest);
            Console.WriteLine($"{pl} - {bud:f2}");
        }
    }
}