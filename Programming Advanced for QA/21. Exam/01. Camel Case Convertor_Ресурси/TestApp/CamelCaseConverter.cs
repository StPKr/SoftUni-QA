using System.Linq;
using System.Text;

namespace TestApp;

public class CamelCaseConverter
{
    public static string ConvertToCamelCase(string input)
    {
        string[] words = input.Split(' ');

        StringBuilder sb = new(words[0].ToLower());

        for (int i = 1; i < words.Length; i++)
        {
            sb.Append(words[i].Substring(0, 1).ToUpper());
            sb.Append(words[i].Substring(1).ToLower());
        }

        return sb.ToString();
    }
}
