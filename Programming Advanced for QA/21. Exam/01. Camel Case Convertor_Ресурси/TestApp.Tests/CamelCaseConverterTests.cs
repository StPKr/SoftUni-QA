using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class CamelCaseConverterTests
{
    [Test]
    public void Test_ConvertToCamelCase_EmptyString_ReturnsEmptyString()
    {
        string input = "";

        string result = CamelCaseConverter.ConvertToCamelCase(input);
        string expected = "";

        Assert.AreEqual(expected, result);  

    }

    [Test]
    public void Test_ConvertToCamelCase_SingleWord_ReturnsLowercaseWord()
    {
        string input = "TeSt";

        string result = CamelCaseConverter.ConvertToCamelCase(input);
        string expected = "test";

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ConvertToCamelCase_MultipleWords_ReturnsCamelCase()
    {
        string input = "test the program";

        string result = CamelCaseConverter.ConvertToCamelCase(input);
        string expected = "testTheProgram";

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Test_ConvertToCamelCase_MultipleWordsWithMixedCase_ReturnsCamelCase()
    {
        string input = "TeSt tHe Program";

        string result = CamelCaseConverter.ConvertToCamelCase(input);
        string expected = "testTheProgram";

        Assert.AreEqual(expected, result);
    }
}
