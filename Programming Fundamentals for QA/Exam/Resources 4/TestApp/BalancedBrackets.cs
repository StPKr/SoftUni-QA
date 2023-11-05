namespace TestApp;

public class BalancedBrackets
{
    public static bool IsBalanced(string[] input)
    {
        int balance = 0;

        foreach (string symbol in input)
        {
            if (symbol == "(")
            {
                balance++;
            }
            else if (symbol == ")")
            {
                balance--;
            }

            if (balance < 0)
            {
                return false;
            }
        }

        return balance == 0;
    }
}
