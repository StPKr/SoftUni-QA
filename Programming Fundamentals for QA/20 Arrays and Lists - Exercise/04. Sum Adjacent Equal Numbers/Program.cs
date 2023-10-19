List<int> integers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
bool check = true;
while (check && integers.Count > 1)
{
    for (int i = 0; i < integers.Count() - 1; i++)
    {
        if (integers[i] == integers[i + 1])
            {
                integers.Insert(i, integers[i] * 2);
                integers.RemoveAt(i + 1);
                integers.RemoveAt(i + 1);
            check = true;
            break;
            }
        else
        {
            check = false;
        }

    }
}
Console.WriteLine(string.Join(" ", integers));

/*List<int> test = new List<int>() { 1, 2, 3, 4 };
test.Insert(1, 5);
test.RemoveAt(2);
test.RemoveAt(2);
Console.WriteLine(string.Join(" ",test));*/