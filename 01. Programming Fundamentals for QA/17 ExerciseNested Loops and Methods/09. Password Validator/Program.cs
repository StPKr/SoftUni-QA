string password = Console.ReadLine();
bool isValidLength = password.Length >= 6 && password.Length <= 10;
bool isValidCounter = CheckContent(password);
bool isValidDigit = CheckDigitsCounter(password);
if (isValidLength && isValidCounter && isValidDigit)
{
    Console.WriteLine("Password is valid");
}
else
{
    if (!isValidLength)
    {
        Console.WriteLine("Password must be between 6 and 10 characters");

    }
    if (!isValidCounter)
    {
        Console.WriteLine("Password must consist only of letters and digits");

    }
    if (!isValidDigit)
    {
        Console.WriteLine("Password must have at least 2 digits");

    }
}

static bool CheckContent(string password)
{
    for (int i = 0; i < password.Length; i++)
    {
        char symbol = password[i];
        if (char.IsLetterOrDigit(symbol) == false)
        {
            return false;
        }
    } 
    return true;
}

static bool CheckDigitsCounter(string password)
{
    int counter = 0;
    for (int i = 0; i < password.Length; i++)
    {
        char symbol = password[i];
        if (char.IsDigit(symbol) == true) 
        {
            counter++;
        }
    }
    return counter >= 2;
}