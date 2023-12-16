using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class GradesTests
{
    [Test]
    public void Test_GetBestStudents_ReturnsBestThreeStudents()
    {
        Dictionary<string, int> gradesDict = new()
        {
            ["Gosho"] = 5,
            ["Ivan"] = 3,
            ["Petkan"] = 4,
            ["Stoian"] = 6,
            ["Pesho"] = 2
        };

        string results = Grades.GetBestStudents(gradesDict);
        string expected = $"Stoian with average grade 6.00" +
            $"{Environment.NewLine}Gosho with average grade 5.00" +
            $"{Environment.NewLine}Petkan with average grade 4.00";

        Assert.That(results, Is.EqualTo(expected));

    }

    [Test]
    public void Test_GetBestStudents_EmptyGrades_ReturnsEmptyString()
    {
        Dictionary<string, int> gradesDict = new()
        {

        };

        string results = Grades.GetBestStudents(gradesDict);
        string expected = "";

        Assert.That(results, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_LessThanThreeStudents_ReturnsAllStudents()
    {
        Dictionary<string, int> gradesDict = new()
        {
            ["Gosho"] = 5,
            ["Ivan"] = 3,

        };

        string results = Grades.GetBestStudents(gradesDict);
        string expected = $"Gosho with average grade 5.00" +
            $"{Environment.NewLine}Ivan with average grade 3.00";

        Assert.That(results, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetBestStudents_SameGrade_ReturnsInAlphabeticalOrder()
    {
        Dictionary<string, int> gradesDict = new()
        {
            ["Gosho"] = 5,
            ["Ivan"] = 5,
            ["Petkan"] = 5,
            ["Stoian"] = 5,
            ["Pesho"] = 5

        };

        string results = Grades.GetBestStudents(gradesDict);
        string expected = $"Gosho with average grade 5.00" +
            $"{Environment.NewLine}Ivan with average grade 5.00" +
            $"{Environment.NewLine}Pesho with average grade 5.00";

        Assert.That(results, Is.EqualTo(expected));
    }
}
