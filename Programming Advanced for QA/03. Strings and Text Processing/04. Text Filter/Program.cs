string[] bannedWords = Console.ReadLine().Split(", ").ToArray();
string text = Console.ReadLine();
foreach (string word in bannedWords)
{
    string replacemeentPhrase = "";
        for (int i = 0; i < word.Length; i++)
    {
        replacemeentPhrase += "*";
    }
    text = text.Replace(word, replacemeentPhrase);
}
Console.WriteLine(text);
