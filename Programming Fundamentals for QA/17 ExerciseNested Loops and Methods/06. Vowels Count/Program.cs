static int VowelsCount(string text)
{
    int count = 0;
    for (int i = 0; i < text.Length; i++)
    {
        char c = text[i];
        if (c == 'A' || c == 'a' ||
            c == 'E' || c == 'e' ||
            c == 'O' || c == 'o' ||
            c == 'U' || c == 'u' ||
            c == 'I' || c == 'i') 
        { 
            count++;
        }
    }
    return(count);
}
string text = Console.ReadLine();
Console.WriteLine(VowelsCount(text));