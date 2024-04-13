string test = Console.ReadLine();
string phrase = Console.ReadLine();
while (phrase.Contains(test))
{
    int indexOfTest = phrase.IndexOf(test);
    phrase = phrase.Remove(indexOfTest, test.Length);

    // phrase = phrase.Replace(test, "");
}
Console.WriteLine(phrase);