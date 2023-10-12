int max1 = int.Parse(Console.ReadLine());
int max2  = int.Parse(Console.ReadLine());
int max3 = int.Parse(Console.ReadLine());
string output = "";
for (int i = 2; i <= max1; i+=2)
{
    for (int j = 1; j <= max2; j++)
    {
        for (int k = 2; k <= max3; k+=2)
        {
            if (j == 2 || j == 3 || j == 5 || j == 7)
            {
                output = $"{i}{j}{k}";
                Console.WriteLine(output);
            }
        }
    }
}
