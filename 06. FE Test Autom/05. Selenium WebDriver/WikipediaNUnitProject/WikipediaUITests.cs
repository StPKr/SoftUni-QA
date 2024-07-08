using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WikipediaNUnitProject
{
    public class WikipediaUITests
    {
        private ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://wikipedia.org");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void CheckPageTitle()
        {

            Assert.That(driver.Title, Is.EqualTo("Wikipedia"));

        }

        [Test]
        public void CheckQualityAssurancePageTitle()
        {
            driver.FindElement(By.Id("searchInput")).SendKeys("Quality Assurance" + Keys.Enter);
            Assert.That(driver.Title, Is.EqualTo("Quality assurance - Wikipedia"));

        }

    }
}