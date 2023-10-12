int n = int.Parse(Console.ReadLine());
string output = "";
for (int i = 1; i <=9; i++)
{
    for (int j = 1; j <= 9; j++)
    {
        for (int k = 1; k <= 9; k++)
        {
            if (n == i * j * k)
            {
                output += $"{i}{j}{k} ";
            }

        }
    }
}
Console.WriteLine(output);