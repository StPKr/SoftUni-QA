using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class BalancedBracketsTests
{
    [Test]
    public void Test_IsBalanced_EmptyInput_ShouldReturnTrue()
    {
        string[] input = new string[] { };

        bool output = BalancedBrackets.IsBalanced(input);

        Assert.That(output, Is.True);
    }

    [Test]
    public void Test_IsBalanced_BalancedBrackets_ShouldReturnTrue()
    {
        string[] input = new string[] { "(", ")", "(", ")" };

        bool output = BalancedBrackets.IsBalanced(input);

        Assert.That(output, Is.True);
    }

    [Test]
    public void Test_IsBalanced_UnbalancedBrackets_ShouldReturnFalse()
    {
        string[] input = new string[] { "(", "(", ")" };

        bool output = BalancedBrackets.IsBalanced(input);

        Assert.That(output, Is.False);
    }

    [Test]
    public void Test_IsBalanced_MoreClosingBrackets_ShouldReturnFalse()
    {
        string[] input = new string[] { "(", ")", "(", ")", ")" };

        bool output = BalancedBrackets.IsBalanced(input);

        Assert.That(output, Is.False);
    }

    [Test]
    public void Test_IsBalanced_NoClosingBrackets_ShouldReturnFalse()
    {
        string[] input = new string[] { "(", "(" };

        bool output = BalancedBrackets.IsBalanced(input);

        Assert.That(output, Is.False);
    }
}
