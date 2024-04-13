using System;

using BoxData;

double l = double.Parse(Console.ReadLine()!);
double w = double.Parse(Console.ReadLine()!);
double h = double.Parse(Console.ReadLine()!);

try
{
    Console.WriteLine(new Box(l, w, h));
}
catch (ArgumentException e)
{
    Console.WriteLine(e.Message);
}
