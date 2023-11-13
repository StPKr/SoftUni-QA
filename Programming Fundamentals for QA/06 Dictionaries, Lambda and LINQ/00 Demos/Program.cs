/*List<string> exampleList = new();
Dictionary<string, string> phoneBook = new();
phoneBook.Add("Ivan Petrov", "+389 888 123 456");
phoneBook.Add("Jon Smith", "+44 20102 330");
//phoneBook.Add("Jon Smith", "+44 20102 112"); - unique keys only, erro if you try to add 


string value = phoneBook["Ivan Petrov"];
Console.WriteLine(value);

phoneBook["Ivan Petrov"] = "+49 1219 0302";
Console.WriteLine(phoneBook["Ivan Petrov"]);

SortedDictionary<string, double> fruits = new SortedDictionary<string, double>()
{
    {"strawberry", 22.2 },
    {"cherry", 23.2 }
};
fruits["kiwi"] = 4.50;
fruits["orange"] = 2.50;
fruits["banana"] = 2.20;

foreach (var item in fruits) // instead of var we can use KeyValuePair<string, double>
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}*/

List<int> testListInts = new() { 1, 2, 3, 4, 5, 6 };
List<string> testListStrings = new() { "hello", "world", "Maybe?", "a" };

Console.WriteLine(testListInts.Min());
Console.WriteLine(testListStrings.Min());

Console.WriteLine(testListInts.Max());
Console.WriteLine(testListInts.Sum());
Console.WriteLine(testListInts.Average());

