int[] array1 = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();
int[] array2 = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();
string commonElements = "";
for (int i = 0; i < array1.Length; i++)
{
    int element1 = array1[i];
    for (int j = 0; j < array2.Length; j++) { 
    int element2 = array2[i];

        if (element1 == element2)
        {
            commonElements += element1 + " ";
        }
    }
}
Console.WriteLine(commonElements);