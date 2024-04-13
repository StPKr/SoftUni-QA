List<int> integers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
int maxSequence = 0;
int lastIndex = 0;
for (int i = 0; i < integers.Count(); i++)
{
    int currentSequence = 1;
    for (int j = i + 1; j < integers.Count(); j++)
    {
        if (integers[i] == integers[j])
        {
            currentSequence++;
        }
        else
        {
            break;
        }
        if (maxSequence < currentSequence)
        {
            maxSequence = currentSequence;
            lastIndex = j;
        }
    }
}
string result = "";
for (int k = lastIndex; k > lastIndex - maxSequence; k--)
{
    result += integers[k] + " ";
}
Console.WriteLine(result);