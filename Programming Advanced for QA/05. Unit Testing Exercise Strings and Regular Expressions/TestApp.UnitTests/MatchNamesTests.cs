using NUnit.Framework;

namespace TestApp.UnitTests;

public class MatchNamesTests
{
    [Test]
    public void Test_Match_ValidNames_ReturnsMatchedNames()
    {
        // Arrange
        string names = "John Smith and Alice Johnson";
        string expected = "John Smith Alice Johnson";

        // Act
        string result = MatchNames.Match(names);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Match_NoValidNames_ReturnsEmptyString()
    {
        // TODO: finish the test
    }

    [Test]
    public void Test_Match_EmptyInput_ReturnsEmptyString()
    {
        // TODO: finish the test
    }
}
