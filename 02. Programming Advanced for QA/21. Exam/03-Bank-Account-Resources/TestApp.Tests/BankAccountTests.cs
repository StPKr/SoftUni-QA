using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Security.Cryptography.X509Certificates;

namespace TestApp.Tests;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void Test_Constructor_InitialBalanceIsSet()
    {
        double input = 200;

        BankAccount bankAccount = new BankAccount(input);

        Assert.AreEqual(input, bankAccount.Balance);

    }

    [Test]
    public void Test_Deposit_PositiveAmount_IncreasesBalance()
    {
        BankAccount bankAccount = new BankAccount(200);
        bankAccount.Deposit(50);

        Assert.AreEqual(250, bankAccount.Balance);
    }

    [Test]
    public void Test_Deposit_NegativeAmount_ThrowsArgumentException()
    {
        double input = 200;
        BankAccount bankAccount = new BankAccount(input);

        double deposit = -50;

        Assert.That(() => bankAccount.Deposit(deposit), Throws.ArgumentException);
    }

    [Test]
    public void Test_Withdraw_ValidAmount_DecreasesBalance()
    {
        double input = 200;
        BankAccount bankAccount = new BankAccount(input);

        double withdrawal = 50;
        bankAccount.Withdraw(withdrawal);

        double expected = 150;

        Assert.AreEqual(expected, bankAccount.Balance);
    }

    [Test]
    public void Test_Withdraw_NegativeAmount_ThrowsArgumentException()
    {
        double input = 200;
        BankAccount bankAccount = new BankAccount(input);

        double withdrawal = -50;

        Assert.That(() => bankAccount.Withdraw(withdrawal), Throws.ArgumentException);
    }

    [Test]
    public void Test_Withdraw_AmountGreaterThanBalance_ThrowsArgumentException()
    {
        double input = 200;
        BankAccount bankAccount = new BankAccount(input);

        double withdrawal = 250;

        Assert.That(() => bankAccount.Withdraw(withdrawal), Throws.ArgumentException);
    }
}
