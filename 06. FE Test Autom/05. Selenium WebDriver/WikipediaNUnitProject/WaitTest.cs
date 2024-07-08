using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikipediaNUnitProject
{
    public class WaitTest
    {
        private ChromeDriver driver;

        [SetUp] // executed before every test
        // [OneTimeSetUp] executed once before each test
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        // [OneTimeTearDown] same as above
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void WaitExample()
        {
            driver.Url = "https://www.uitestingplayground.com/ajax";

            driver.FindElement(By.Id("details-button")).Click(); // if page doesn't load directly
            driver.FindElement(By.Id("proceed-link")).Click(); // if page doesn't load directly

            driver.FindElement(By.Id("ajaxButton")).Click();


            string fieldText = driver.FindElement(By.ClassName("bg-success")).Text;

            Assert.That(fieldText, Is.EqualTo("Data loaded with AJAX get request."));
        }

        

    }
}
