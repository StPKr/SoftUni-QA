using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class CsvParserTests
{
    [Test]
    public void Test_ParseCsv_EmptyInput_ReturnsEmptyArray()
    {
        string input = "";

        string[] result = CsvParser.ParseCsv(input);
        string[] expected = { };
        
        Assert.That(result, Is.EqualTo(expected)); // or Is.Empty
    }

    [Test]
    public void Test_ParseCsv_SingleField_ReturnsArrayWithOneElement()
    {
        string input = "hello";

        string[] result = CsvParser.ParseCsv(input);
        string[] expected = { "hello" };

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseCsv_MultipleFields_ReturnsArrayWithMultipleElements()
    {
        string input = "hello,how,are,you";

        string[] result = CsvParser.ParseCsv(input);
        string[] expected = { "hello", "how",  "are", "you" };

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseCsv_TrimsWhiteSpace_ReturnsCleanArray()
    {
        string input = "hello,    how,    are,  you";

        string[] result = CsvParser.ParseCsv(input);
        string[] expected = { "hello", "how", "are", "you" };

        Assert.That(result, Is.EqualTo(expected));
    }
}
