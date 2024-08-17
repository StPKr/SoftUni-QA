using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject1.Pages;

namespace TestProject1.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;

        public LoginPage loginPage;

        public CreateIdeaPage createIdeaPage;

        public MyIdeasPage myIdeasPage;

        public IdeasReadPage ideasReadPage;

        public IdeasEditPage ideasEditPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profilempassword_manager_enabled", false); //removes the pop up "your password is not secure"
            chromeOptions.AddArgument("--disable-search-engine-choice-screen"); //removes the pop up "choose a serach engine" that pops up on each new instance of Chrome

            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            loginPage = new LoginPage(driver);
            createIdeaPage = new CreateIdeaPage(driver);
            myIdeasPage = new MyIdeasPage(driver);
            ideasReadPage = new IdeasReadPage(driver);
            ideasEditPage = new IdeasEditPage(driver);

            loginPage.OpenPage();
            loginPage.Login("testi@abv.bg", "123456");
        }

        [OneTimeTearDown]

        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public string GenerateRandomString(int length)
        {
            const string chars = "dsagjehgasdgjdsagdas";
            var random = new Random();

            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
