List<int> list1 = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
List<int> list2 = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
int elem1 = list1[2];
int elem2 = list2[2];
Console.WriteLine(elem1);
Console.WriteLine(elem2);