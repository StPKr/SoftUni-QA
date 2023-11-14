string words = Console.ReadLine();
Dictionary<char, int> charCount = new();
for (int i = 0; i < words.Length; i++)
{
    char ch = words[i];
    if ( ch == ' ')
    {
        continue;
    }
     if (charCount.ContainsKey(ch))
    {
        charCount[ch] += 1;
    }
    else
    {
        charCount.Add(ch, 1);
    }
}
foreach (KeyValuePair<char, int> pair in charCount)
{
        Console.WriteLine($"{pair.Key} -> {pair.Value}");
}