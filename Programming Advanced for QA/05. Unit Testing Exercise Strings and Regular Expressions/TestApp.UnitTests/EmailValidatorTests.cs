using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailValidatorTests
{
    // TODO: finish the test
    [TestCase("petar_petrov92@abv.bg")]
    [TestCase("aaaabbbccc_7_1@dir.bg")]
    [TestCase("stiga.mi.pisa@gmail.com")]
    public void Test_ValidEmails_ReturnsTrue(string email)
    {
        // Arrange

        // Act
        bool result = EmailValidator.IsValidEmail(email);

        // Assert
        Assert.That(result, Is.True);
    }

    // TODO: finish the test
    [TestCase("v@nk@tA@abv.bg")]
    [TestCase("50%otgovaryam@gmail")]
    [TestCase("da/ne%net.bg")]
    public void Test_InvalidEmails_ReturnsFalse(string email)
    {
        // Arrange

        // Act
        bool result = EmailValidator.IsValidEmail(email);

        // Assert
        Assert.That(result, Is.False);
    }
}
