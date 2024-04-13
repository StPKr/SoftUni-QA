List<int> integers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
while (integers.Count() > 1)
{
    List<int> outputList = new List<int>();
    for (int i = 0; i < integers.Count() - 1; i++)
    {

        outputList.Add(integers[i] + integers[i + 1]);
    }
    integers = outputList;
}
Console.WriteLine(string.Join("", integers));