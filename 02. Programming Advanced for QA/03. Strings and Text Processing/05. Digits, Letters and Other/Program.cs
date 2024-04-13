string test = Console.ReadLine();
string digits = "";
string letters = "";
string rest = "";
for (int i = 0; i < test.Length; i++)
{
    if (char.IsDigit(test[i]))
    {
        digits += test[i];
    } else if (char.IsLetter(test[i]))
    {
        letters += test[i];
    } else
    {
        rest += test[i];
    }
}
Console.WriteLine(digits);
Console.WriteLine(letters);
Console.WriteLine(rest);