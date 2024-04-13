namespace TestApp;

public class BankAccount
{
    public BankAccount(double initialBalance)
    {
        this.Balance = initialBalance;
    }
    
    public double Balance { get; private set; }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be greater than zero.");
        }
        
        this.Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0 || amount > this.Balance)
        {
            throw new ArgumentException("Invalid withdrawal amount.");
        }

        this.Balance -= amount;
    }
}
