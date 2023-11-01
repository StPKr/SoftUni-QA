using NUnit.Framework;

namespace TestApp.UnitTests;

public class StringReverseTests
{
    // TODO: finish test
    [Test]
    public void Test_Reverse_WhenGivenEmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = "";
        // Act
        string actual = StringReverse.Reverse(input);

        // Assert
        Assert.AreEqual("", actual);
    }

    [Test]
    public void Test_Reverse_WhenGivenSingleCharacterString_ReturnsSameCharacter()
    {
        string input = "x";

        string result = StringReverse.Reverse(input);

        Assert.AreEqual("x", result);
        Assert.AreEqual(1, result.Length);
    }

    [Test]
    public void Test_Reverse_WhenGivenNormalString_ReturnsReversedString()
    {
        string input = "xyz";

        string result = StringReverse.Reverse(input);

        Assert.AreEqual("zyx", result);
        Assert.AreEqual(input.Length, result.Length);
    }
}
