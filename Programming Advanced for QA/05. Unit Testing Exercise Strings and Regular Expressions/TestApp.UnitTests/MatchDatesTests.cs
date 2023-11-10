using NUnit.Framework;

namespace TestApp.UnitTests;

public class MatchDatesTests
{
    // TODO: finish the test
    [Test]
    public void Test_Match_ValidDate_ReturnsExpectedResult()
    {
        // Arrange
        string expected = "Day: 31, Month: Dec, Year: 2022";

        // Act

        // Assert
        //Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish the test
    [Test]
    public void Test_Match_NoMatch_ReturnsEmptyString()
    {
        // Arrange
        string input = "Invalid date format";
        string expected = string.Empty;

        // Act

        // Assert
    }

    [Test]
    public void Test_Match_MultipleMatches_ReturnsFirstMatch()
    {
        // TODO: finish the test
    }

    [Test]
    public void Test_Match_EmptyString_ReturnsEmptyString()
    {
        // TODO: finish the test
    }

    [Test]
    public void Test_Match_NullInput_ThrowsArgumentException()
    {
        // TODO: finish the test
    }
}
