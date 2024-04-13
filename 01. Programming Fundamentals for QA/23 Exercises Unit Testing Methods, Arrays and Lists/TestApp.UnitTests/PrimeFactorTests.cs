using NUnit.Framework;

namespace TestApp.UnitTests;

public class PrimeFactorTests
{
    [Test]
    public void Test_FindLargestPrimeFactor_NumberLowerThanTwo()
    {
        // Arrange
        int n = -1;

        // Act & Assert
        Assert.That(() => PrimeFactor.FindLargestPrimeFactor(n), Throws.ArgumentException);
    }

    [Test]
    public void Test_FindLargestPrimeFactor_PrimeNumber()
    {
        int n = 11;

        long result = PrimeFactor.FindLargestPrimeFactor(n);

        Assert.That(result, Is.EqualTo(11));
    }

    [Test]
    public void Test_FindLargestPrimeFactor_LargeNumber()
    {
        int n = 150;

        long result = PrimeFactor.FindLargestPrimeFactor(n);

        Assert.That(result, Is.EqualTo(5));
    }
}
