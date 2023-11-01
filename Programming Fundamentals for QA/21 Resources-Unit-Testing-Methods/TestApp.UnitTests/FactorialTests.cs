using NUnit.Framework;
using System;
using System.Xml.XPath;

namespace TestApp.UnitTests;

public class FactorialTests
{
    [Test]
    public void CalculateFactorial_InputZero_ReturnsOne()
    {
        int input = 0;

        int result = Factorial.CalculateFactorial(input);

        Assert.AreEqual(1, result);
    }

    [Test]
    public void CalculateFactorial_InputPositiveNumber_ReturnsCorrectFactorial()
    {
        int input = 3;

        int result = Factorial.CalculateFactorial(input);

        Assert.AreEqual(6, result);
    }

    [Test]
    public void CalculateFactorial_InputNegativeNumber_ThrowsException()
    {
        int input = -2;

        Assert.Throws<ArgumentOutOfRangeException>(() => { Factorial.CalculateFactorial(input); });
    }
}
