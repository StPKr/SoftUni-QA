using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class PatternTests
{
    // TODO: finish test
    [Test]
    public void Test_SortInPattern_NullInput_ThrowsException()
    {
        // Arrange
        int[]? inputArray = null;

        // Act + Assert
        Assert.That(() => Pattern.SortInPattern(inputArray), Throws.ArgumentException);
    }

    [Test]
    public void Test_SortInPattern_SortsIntArrayInPattern_SortsCorrectly()
    {
        // Arrange
        int[] numbers = new int[] { 1, 2, 3 };

        // Act

        int[] result = Pattern.SortInPattern(numbers);
        // Assert
        Assert.That(result, Is.EqualTo(new[] {1,3,2}));
    }

    [Test]
    public void Test_SortInPattern_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] numbers = new int[] {};

        // Act

        int[] result = Pattern.SortInPattern(numbers);
        // Assert
        Assert.That(result, Is.EqualTo(new int[] { }));
    }

    [Test]
    public void Test_SortInPattern_SingleElementArray_ReturnsSameArray()
    {
        // Arrange
        int[] numbers = new int[] { 3 };

        // Act

        int[] result = Pattern.SortInPattern(numbers);
        // Assert
        Assert.That(result, Is.EqualTo(new[] { 3 }));
    }
}
