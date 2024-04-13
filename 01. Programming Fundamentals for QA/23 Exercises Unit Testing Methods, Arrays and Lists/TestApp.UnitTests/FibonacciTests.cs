using NUnit.Framework;

namespace TestApp.UnitTests;

public class FibonacciTests
{
    [Test]
    public void Test_CalculateFibonacci_NegativeInput()
    {
        // Arrange
        int n = -1;

        // Act & Assert
        Assert.That(() => Fibonacci.CalculateFibonacci(n), Throws.ArgumentException);
    }

    [Test]
    public void Test_CalculateFibonacci_ZeroInput()
    {
        // Arrange
        int n = 0;

        int result = Fibonacci.CalculateFibonacci(n);

        Assert.That(result, Is.Zero);
        
    }

    [Test]
    public void Test_CalculateFibonacci_PositiveInput()
    {
        int n = 8;

        int result = Fibonacci.CalculateFibonacci(n);

        Assert.That(result, Is.EqualTo(21));
    }
}