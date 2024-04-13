namespace _06._Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            int accumulatedSteps = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Going home")
                {
                    int stepsGoingHome = int.Parse(Console.ReadLine());
                    accumulatedSteps += stepsGoingHome;
                    if (accumulatedSteps >= goal)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine(accumulatedSteps - goal + " steps over the goal!");
                    } else
                    {
                        Console.WriteLine(goal - accumulatedSteps + " more steps to reach goal.");
                    }
                    break;
                }
                int steps = int.Parse(command);
                accumulatedSteps += steps;
                if (accumulatedSteps >= goal)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine(accumulatedSteps - goal + " steps over the goal!");
                    break;
                }

            }

            
        }
    }
}