string command = Console.ReadLine();
while (command != "end")
{
    char[] list = command.ToCharArray();
    Array.Reverse(list);
    string reversed = new string(list);
    Console.WriteLine(command + " = " + reversed);
    command = Console.ReadLine();
}