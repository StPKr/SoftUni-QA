string[] words = Console.ReadLine().Split(" ");

Dictionary<string, int> wordsCount = new();

foreach (string word in words)
{
    string caseInsensitiveWord = word.ToLower();

    if (wordsCount.ContainsKey(caseInsensitiveWord))
    {
        wordsCount[caseInsensitiveWord] += 1;
    }
    else
    {
        wordsCount.Add(caseInsensitiveWord, 1);
    }
}
foreach (KeyValuePair<string, int> pair in wordsCount)
{
    if (pair.Value % 2 != 0)
    {
        Console.Write($"{pair.Key} ");
    }
}