using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class SubstringExtractorTests
{
    [Test]
    public void Test_ExtractSubstringBetweenMarkers_SubstringFound_ReturnsExtractedSubstring()
    {
        string input = "aaa bbb ccc";
        string startMarker = "aaa";
        string endMarker = "ccc";

        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        Assert.That(result, Is.EqualTo(" bbb "));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartMarkerNotFound_ReturnsNotFoundMessage()
    {
        string input = "aaa bbb ccc";
        string startMarker = "ddd";
        string endMarker = "ccc";

        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        Assert.That(result, Is.EqualTo("Substring not found"));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_EndMarkerNotFound_ReturnsNotFoundMessage()
    {
        string input = "aaa bbb ccc";
        string startMarker = "aaa";
        string endMarker = "ddd";

        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        Assert.That(result, Is.EqualTo("Substring not found"));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartAndEndMarkersNotFound_ReturnsNotFoundMessage()
    {
        string input = "aaa bbb ccc";
        string startMarker = "ttt";
        string endMarker = "ddd";

        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        Assert.That(result, Is.EqualTo("Substring not found"));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_EmptyInput_ReturnsNotFoundMessage()
    {
        string input = "";
        string startMarker = "aaa";
        string endMarker = "ddd";

        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        Assert.That(result, Is.EqualTo("Substring not found"));
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartAndEndMarkersOverlapping_ReturnsNotFoundMessage()
    {
        string input = "eedd";
        string startMarker = "ee";
        string endMarker = "ed";

        string result = SubstringExtractor.ExtractSubstringBetweenMarkers(input, startMarker, endMarker);

        Assert.That(result, Is.EqualTo("Substring not found"));
    }
}
