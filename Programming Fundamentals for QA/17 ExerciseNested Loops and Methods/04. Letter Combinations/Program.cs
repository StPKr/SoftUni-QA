char start = char.Parse(Console.ReadLine());
char end = char.Parse(Console.ReadLine());
char excluded  = char.Parse(Console.ReadLine());
string output = "";
for (char i = start; i <= end; i++)
{
    for (char j = start; j <= end; j++)
    {
        for (char k = start; k <= end; k++)
        {
           if (i != excluded &&  j != excluded &&  k != excluded){
            output += $"{i}{j}{k} ";
            }

        }
    }
}