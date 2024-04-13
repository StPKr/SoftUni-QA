using System.Diagnostics.Metrics;

namespace _06._Cinema_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double counter = 0;
            int studentCounter = 0;
            int standardCounter = 0;
            int kidCounter = 0;
            double totalCounter = 0;
            int totalStudentCounter = 0;
            int totalStandardCounter = 0;
            int totalKidCounter = 0;
            string ticketType = "";
            while (true)
            {
                string title = Console.ReadLine();
                if (title == "Finish")
                {
                    break;
                }
                double totalTickets = double.Parse(Console.ReadLine());

                while (counter < totalTickets && ticketType != "End")
                {
                    ticketType = Console.ReadLine();


                    switch (ticketType)
                    {
                        case "student": studentCounter++; counter++; totalCounter++; break;
                        case "standard": standardCounter++; counter++; totalCounter++; break;
                        case "kid": kidCounter++; counter++; totalCounter++; break;
                    }
                }
                totalStudentCounter += studentCounter;
                totalStandardCounter += standardCounter;
                totalKidCounter += kidCounter;
                Console.WriteLine(title + " - " + Math.Round(counter / totalTickets * 100, 2).ToString("0.00") + "% full.");
                counter = 0;
                studentCounter = 0;
                standardCounter = 0;
                kidCounter = 0;
                ticketType = "";
            }
            Console.WriteLine("Total tickets: " + totalCounter);
            Console.WriteLine(Math.Round(totalStudentCounter / totalCounter * 100, 2).ToString("0.00") + "% student tickets.");
            Console.WriteLine(Math.Round(totalStandardCounter / totalCounter * 100, 2).ToString("0.00") + "% standard tickets.");
            Console.WriteLine(Math.Round(totalKidCounter / totalCounter * 100, 2).ToString("0.00") + "% kids tickets.");


        }
    }
}