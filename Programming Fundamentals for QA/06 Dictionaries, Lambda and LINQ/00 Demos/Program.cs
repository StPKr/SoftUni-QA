﻿List<string> exampleList = new();
Dictionary<string, string> phoneBook = new();
phoneBook.Add("Ivan Petrov", "+389 888 123 456");
phoneBook.Add("Jon Smith", "+44 20102 330");
//phoneBook.Add("Jon Smith", "+44 20102 112"); - unique keys only, erro if you try to add 


string value = phoneBook["Ivan Petrov"];
Console.WriteLine(value);

phoneBook["Ivan Petrov"] = "+49 1219 0302";
Console.WriteLine(phoneBook["Ivan Petrov"]);

var fruits = new SortedDictionary<string, double>();
fruits["kiwi"] = 4.50;
fruits["orange"] = 2.50;
fruits["banana"] = 2.20;

foreach (var item in fruits)
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}