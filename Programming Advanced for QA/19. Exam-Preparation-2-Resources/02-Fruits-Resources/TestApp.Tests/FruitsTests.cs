using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class FruitsTests
{
    [Test]
    public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
    {
        Dictionary<string, int> fruits = new Dictionary<string, int>()
        {
            ["lemon"] = 10,
            ["orange"] = 20
        };

        //Dictionary<string, int> fruits = new Dictionary<string, int>();
        //fruits["lemon"] = 10;
        //fruits["orange"] = 20; - another way to delare a dictionary

        string currentFruits = "lemon";

        int result = Fruits.GetFruitQuantity(fruits,currentFruits);

        Assert.That(result, Is.EqualTo(10));
    }

    [Test]
    public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
    {
        Dictionary<string, int> fruits = new Dictionary<string, int>()
        {
            ["lemon"] = 10,
            ["orange"] = 20
        };


        string currentFruits = "kiwi";

        int result = Fruits.GetFruitQuantity(fruits, currentFruits);

        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
    {
        Dictionary<string, int> fruits = new Dictionary<string, int>();
        
        string currentFruits = "kiwi";

        int result = Fruits.GetFruitQuantity(fruits, currentFruits);

        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
    {
        Dictionary<string, int> fruits = null;

        string currentFruits = "kiwi";

        int result = Fruits.GetFruitQuantity(fruits, currentFruits);

        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
    {
        Dictionary<string, int> fruits = new Dictionary<string, int>()
        {
            ["lemon"] = 10,
            ["orange"] = 20
        };


        string currentFruits = null;

        int result = Fruits.GetFruitQuantity(fruits, currentFruits);

        Assert.That(result, Is.EqualTo(0));
    }
}
