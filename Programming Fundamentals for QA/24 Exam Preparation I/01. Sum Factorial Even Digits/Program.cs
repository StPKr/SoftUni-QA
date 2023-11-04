string input = Console.ReadLine();
int sum = 0;
for (int i = 0; i < input.Length; i++)
{
    int n = int.Parse(input[i].ToString());
    if (n % 2 == 0)
    {
        int placeholder = 1;
        for (int j = n; j > 0; j--)
        {
            placeholder *= j;
        }
        sum += placeholder;
    }
}
Console.WriteLine(sum);
