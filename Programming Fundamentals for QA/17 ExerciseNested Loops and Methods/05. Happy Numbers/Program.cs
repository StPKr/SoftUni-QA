int n = int.Parse(Console.ReadLine());
string output = "";
for (int i = 1; i <= n; i++)
{
    for (int j = 0; j <= n; j++)
    {
        for (int k = 0; k <= n; k++)
        {
            for (int l = 0; l <= n; l++)
            {
                if (i + j == k + l && i + j == n)
                {
                    output += $"{i}{j}{k}{l} "; 
                }
            }
        }
    }
}
Console.WriteLine(output);