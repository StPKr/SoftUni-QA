using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class TriangleTests
{
    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size0()
    {
        int input = 0;

        string result = Triangle.PrintTriangle(input);

        Assert.AreEqual("", result);
    }

    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size3()
    {
        int input = 3;
        string expectedOutput = "1" + "" + Environment.NewLine +
            "1 2" + Environment.NewLine +
            "1 2 3" + Environment.NewLine +
            "1 2" + Environment.NewLine +
            "1";


        string result = Triangle.PrintTriangle(input);

        Assert.AreEqual(expectedOutput, result);
    }

    [Test]
    public void Test_Triangle_OutputMatchesExpected_Size5()
    {
        int input = 5;
        string expectedOutput = "1" + "" + Environment.NewLine +
            "1 2" + Environment.NewLine +
            "1 2 3" + Environment.NewLine +
            "1 2 3 4" + Environment.NewLine +
            "1 2 3 4 5" + Environment.NewLine +
            "1 2 3 4" + Environment.NewLine +
            "1 2 3" + Environment.NewLine +
            "1 2" + Environment.NewLine +
            "1";


        string result = Triangle.PrintTriangle(input);

        Assert.AreEqual(expectedOutput, result);
    }
}
