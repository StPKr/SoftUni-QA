/*List<int> integers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
bool check = true;
while (check && integers.Count > 1)
{
    for (int i = 0; i < integers.Count() - 1; i++)
    {
        if (integers[i] == integers[i + 1])
            {
            integers[i] *= 2;
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
Console.WriteLine(string.Join(" ", integers)); - каруцарски*/

List<int> integers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
for (int i = 0; i < integers.Count() - 1; i++)
{
    if (integers[i] == integers[i + 1])
    {
        integers[i] *= 2;
        integers.RemoveAt(i + 1);
        i = -1;
    }
}
Console.WriteLine(string.Join(" ", integers));