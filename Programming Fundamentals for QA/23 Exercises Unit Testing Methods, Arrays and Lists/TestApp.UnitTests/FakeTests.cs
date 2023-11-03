using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class FakeTests
{
    // TODO: finish test
    [Test]
    public void Test_RemoveStringNumbers_NullInput_ThrowsException()
    {
        // Arrange
        char[]? input = null;

        // Act + Assert
        Assert.That(() => Fake.RemoveStringNumbers(input), Throws.ArgumentException);
    }

    [Test]
    public void Test_RemoveStringNumbers_RemovesDigitsFromCharArray()
    {
        char[] input = new char[] { 'a', 'b', '3', 'c' };

        char[] result = Fake.RemoveStringNumbers(input);

        Assert.That(result, Is.EqualTo(new[] { 'a', 'b', 'c' }));
    }

    [Test]
    public void Test_RemoveStringNumbers_NoDigitsInInput_ReturnsSameArray()
    {
        char[] input = new char[] { 'a', 'b', 'c' };

        char[] result = Fake.RemoveStringNumbers(input);

        Assert.That(result, Is.EqualTo(new[] { 'a', 'b', 'c' }));
    }

    [Test]
    public void Test_RemoveStringNumbers_EmptyArray_ReturnsEmptyArray()
    {
        char[] input = new char[] { };

        char[] result = Fake.RemoveStringNumbers(input);

        Assert.That(result, Is.EqualTo(new char[] { }));
    }
}
