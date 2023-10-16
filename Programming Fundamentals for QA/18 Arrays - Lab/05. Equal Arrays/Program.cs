int[] array1 = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();
int[] array2 = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();
bool check = true;
for (int i = 0; i < array1.Length; i++)
{
    int element1 = array1[i];
    int element2 = array2[i];

    if (element1 != element2)
    {
        check = false;
        break;
    }
}
    
if (check)
    {
        Console.WriteLine("Arrays are identical.");
    }
    else
{
    Console.WriteLine("Arrays are not identical.");
}