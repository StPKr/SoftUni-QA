using System.Text.RegularExpressions;

string input = Console.ReadLine();
string pattern = @"\b(?<day>\d{2})(?<sep>[\.\-\/])(?<month>[A-Z][a-z]{2})\k<sep>(?<year>\d{4})\b";
Regex regex = new Regex(pattern);

MatchCollection matches = regex.Matches(input);

foreach (Match match in matches)
{
    Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
}