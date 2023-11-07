string[] inputArray = Console.ReadLine().Split(" ").ToArray();
string commonElements = "";
for (int i = 0; i < inputArray.Length; i++)
{
    for (int j = 0; j < inputArray[i].Length; j++)
        commonElements += inputArray[i];
}
Console.WriteLine(commonElements);