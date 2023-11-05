using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace TestApp.Tests;

public class LongestIncreasingSubsequenceTests
{
    [Test]
    public void Test_GetLis_NullArray_ThrowsArgumentNullException()
    {
        int[] arr = null;

        Assert.That(() => LongestIncreasingSubsequence.GetLis(arr), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_GetLis_EmptyArray_ReturnsEmptyString()
    {
        int[] arr = Array.Empty<int>();

        string output = LongestIncreasingSubsequence.GetLis(arr);

        Assert.That(output, Is.Empty);
    }

    [Test]
    public void Test_GetLis_SingleElementArray_ReturnsElement()
    {
        // TODO: implement the test
    }

    [Test]
    public void Test_GetLis_UnsortedArray_ReturnsLongestIncreasingSubsequence()
    {
        // TODO: implement the test
    }

    [Test]
    public void Test_GetLis_SortedArray_ReturnsItself()
    {
        // TODO: implement the test
    }
}
