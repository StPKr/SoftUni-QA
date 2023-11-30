using System.Xml.Linq;

List<string> strings = Console.ReadLine().Split().ToList();
int sum = 0;
foreach (string s in strings)

{
    try
    {
        int num = int.Parse(s);
        sum += num;
    }
    catch (FormatException)
    {
        Console.WriteLine($"The element '{s}' is in wrong format!");
    }
    catch (OverflowException)
    {
        Console.WriteLine($"The element '{s}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"Element '{s}' processed - current sum: {sum}");
    }
}

Console.WriteLine($"The total sum of all integers is: {sum}");
