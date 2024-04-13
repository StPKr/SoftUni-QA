List<int> integers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
string command = Console.ReadLine();
while (command != "end")
{
    string commandName = command.Split(" ")[0];

    switch (commandName)
    {
        case "Contains":
            int n = int.Parse(command.Split(" ")[1]);
            if (integers.Contains(n))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
            break;
        case "PrintEven":
            string placeholder = "";
            foreach (int a in integers)
            {
                if (a % 2 == 0)
                {
                    Console.Write(a + " ");
                }
            }
            Console.WriteLine();
            break;
        case "PrintOdd":
            foreach (int a in integers)
            {
                if (a % 2 != 0)
                {
                    Console.Write(a + " ");
                }
            }
            Console.WriteLine();
            break;
        case "GetSum":
            Console.WriteLine(integers.Sum());
            break;
        case "Filter":
            string condition = command.Split(" ")[1];
            int number = int.Parse(command.Split(" ")[2]);
            switch (condition)
            {
                case "<":
                    integers.RemoveAll(x => x >= number);
                    break;
                case ">":
                    integers.RemoveAll(x => x <= number);
                    break;
                case "<=":
                    integers.RemoveAll(x => x > number);
                    break;
                case ">=":
                    integers.RemoveAll(x => x < number);
                    break;
            }
            break;
    }
    command = Console.ReadLine();
}
Console.WriteLine(string.Join(" ", integers));
