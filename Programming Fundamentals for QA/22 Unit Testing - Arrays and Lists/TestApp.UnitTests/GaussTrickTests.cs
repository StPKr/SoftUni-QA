using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class GaussTrickTests
{
    [Test]
    public void Test_SumPairs_InputIsEmptyList_ShouldReturnEmptyList()
    {
        // Arrange
        List<int> emptyList = new();

        // Act
        List<int> result = GaussTrick.SumPairs(emptyList);

        // Assert
        CollectionAssert.AreEqual(emptyList, result);
    }

    // TODO: finish the test
    [Test]
    public void Test_SumPairs_InputHasSingleElement_ShouldReturnSameElement()
    {
        // Arrange
        List<int> list = new() { 5 };
        // Act
        List<int> result = GaussTrick.SumPairs(list);

        // Assert
        CollectionAssert.AreEqual(list, result);
    }

    // TODO: finish the test
    [Test]
    public void Test_SumPairs_InputHasEvenCountElements_ShouldReturnSumPairs()
    {
        // Arrange
        List<int> list = new() { 1, 2, 3, 4 };
        // Act
        List<int> result = GaussTrick.SumPairs(list);

        // Assert
        /*List<int> assertResult = new List<int>() { 5, 5 };
        CollectionAssert.AreEqual(result, assertResult); - alternative */

        CollectionAssert.AreEqual(result, new List<int>() { 5, 5 });

    }

    [Test]
    public void Test_SumPairs_InputHasOddCountElements_ShouldReturnWithMiddleElement()
    {
        // Arrange
        List<int> list = new() { 1, 2, 3, 4, 5 };
        // Act
        List<int> result = GaussTrick.SumPairs(list);

        // Assert
        CollectionAssert.AreEqual(result, new List<int>() { 6, 6, 3 });
    }

    [Test]
    public void Test_SumPairs_InputHasLargeEvenCountElements_ShouldReturnSumPairs()
    {
        // Arrange
        List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        // Act
        List<int> result = GaussTrick.SumPairs(list);

        // Assert
        CollectionAssert.AreEqual(result, new List<int>() { 11, 11, 11, 11, 11});
    }

    [Test]
    public void Test_SumPairs_InputHasLargeOddCountElements_ShouldReturnWithMiddleElement()
    {
        // Arrange
        List<int> list = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        // Act
        List<int> result = GaussTrick.SumPairs(list);

        // Assert
        CollectionAssert.AreEqual(result, new List<int>() { 12, 12, 12, 12, 12, 6 });
    }
}
