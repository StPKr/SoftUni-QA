using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class NumberFrequencyTests
{
    [Test]
    public void Test_CountDigits_ZeroNumber_ReturnsEmptyDictionary()
    {
        int input = 0;

        Dictionary<int, int> result = NumberFrequency.CountDigits(input);
        

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_CountDigits_SingleDigitNumber_ReturnsDictionaryWithSingleEntry()
    {
        int input = 5;

        Dictionary<int, int> result = NumberFrequency.CountDigits(input);
        Dictionary<int, int> expected = new Dictionary<int, int>()
        {
            [5] = 1
        };

        Assert.AreEqual(result, expected);
    }

    [Test]
    public void Test_CountDigits_MultipleDigitNumber_ReturnsDictionaryWithDigitFrequencies()
    {
        int input = 553535211;

        Dictionary<int, int> result = NumberFrequency.CountDigits(input);
        Dictionary<int, int> expected = new Dictionary<int, int>()
        {
            [5] = 4,
            [3] = 2,
            [2] = 1,
            [1] = 2
        };

        Assert.AreEqual(result, expected);
    }

    [Test]
    public void Test_CountDigits_NegativeNumber_ReturnsDictionaryWithDigitFrequencies()
    {
        int input = -453535211;

        Dictionary<int, int> result = NumberFrequency.CountDigits(input);
        Dictionary<int, int> expected = new Dictionary<int, int>()
        {
            [4] = 1,
            [5] = 3,
            [3] = 2,
            [2] = 1,
            [1] = 2
        };

        Assert.AreEqual(result, expected);
    }
}
