using OpenQA.Selenium;

namespace TestProject1.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public string URL = BaseUrl + "/Users/Login";

        public IWebElement EmailInput => driver.FindElement(By.XPath("//input[@name='Email']"));
        public IWebElement PasswordInput => driver.FindElement(By.XPath("//input[@name='Password']"));

        public IWebElement SignInButton => driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-lg btn-block']"));

        public void Login(string email, string password)
        {
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            SignInButton.Click();
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(URL); 
        }
    }
}
