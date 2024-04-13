using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class TextFilterTests
{
    // TODO: finish the test
    [Test]
    public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
    {
        // Arrange
        string text = "The quick brown fox jumps over the lazy dog";
        string[] banned = new string[] { "bear" };

        // Act
        string result = TextFilter.Filter(banned, text);
        // Assert
        Assert.That(result, Is.EqualTo(text));
    }

    [Test]
    public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
    {
        // Arrange
        string text = "The quick brown fox jumps over the lazy dog";
        string[] banned = new string[] { "quick" };
        string expected = "The ***** brown fox jumps over the lazy dog";

        // Act
        string result = TextFilter.Filter(banned, text);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
    {
        string text = "The quick brown fox jumps over the lazy dog";
        string[] banned = Array.Empty<string>();

        // Act
        string result = TextFilter.Filter(banned, text);
        // Assert
        Assert.That(result, Is.EqualTo(text));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
    {
        // Arrange
        string text = "The quick brown fox jumps over the lazy dog";
        string[] banned = new string[] { "quick brown", "dog" };
        string expected = "The *********** fox jumps over the lazy ***";

        // Act
        string result = TextFilter.Filter(banned, text);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
