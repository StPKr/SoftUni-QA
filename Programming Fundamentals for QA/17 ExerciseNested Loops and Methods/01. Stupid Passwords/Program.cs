int n = int.Parse(Console.ReadLine());
string output = "";
for  (int i = 2; i <= n; i += 2)
{
    for (int j = 1; j <= n; j += 2)
    {
        output += $"{i}{j}{i * j} ";
    }
}
Console.WriteLine(output);

