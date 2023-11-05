using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class CharacterRangeTests
{
    [Test]
    public void Test_GetRange_WithAAndBInOrder_ReturnsEmptyString()
    {
        char first = 'A';
        char second = 'B';

        string result = CharacterRange.GetRange(first, second);

        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void Test_GetRange_WithBAndAInOrder_ReturnsEmptyString()
    {
        char first = 'B';
        char second = 'A';

        string result = CharacterRange.GetRange(first, second);

        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void Test_GetRange_WithAAndCInOrder_ReturnsB()
    {
        char first = 'A';
        char second = 'C';

        string result = CharacterRange.GetRange(first, second);

        Assert.That(result, Is.EqualTo("B"));
    }

    [Test]
    public void Test_GetRange_WithDAndGInOrder_Returns_E_F()
    {
        char first = 'D';
        char second = 'G';

        string result = CharacterRange.GetRange(first, second);

        Assert.That(result, Is.EqualTo("E F"));
    }

    [Test]
    public void Test_GetRange_WithXAndZInOrder_Returns_Y()
    {
        char first = 'X';
        char second = 'Z';

        string result = CharacterRange.GetRange(first, second);
        
        Assert.That(result, Is.EqualTo("Y"));
    }
}
