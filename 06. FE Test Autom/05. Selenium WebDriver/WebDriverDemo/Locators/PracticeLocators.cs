using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Locators
{
    public class PracticeLocators
    {
        private IWebDriver driver;
        private string baseUrl = "file:///C:/path/to/your/files/Locators.html";

        [OneTimeSetUp]
        public void Setup()
        {    
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseUrl);
            
        }

        [Test]
        public void BasicLocators()
        {
            
            driver.FindElement(By.Id("lname"));
            driver.FindElement(By.Name("newsletter"));
            driver.FindElement(By.TagName("a"));
            driver.FindElement(By.ClassName("information"));
            
        }

        [Test]
        public void TextLinkLocators()
        {
            driver.FindElement(By.LinkText("Softuni Official Page"));
            driver.FindElement(By.PartialLinkText("Official Page"));
        }

        [Test]
        public void CssSelectors()
        {
            driver.FindElement(By.CssSelector("#fname"));
            driver.FindElement(By.CssSelector("input[name='fname']"));
            driver.FindElement(By.CssSelector("input[class*='button']"));
            driver.FindElement(By.CssSelector("div.additional-info > p > input[type='text']"));
            driver.FindElement(By.CssSelector("form div.additional-info input[type='text']"));
        }

        [Test]
        public void XPath()
        {
            driver.FindElement(By.XPath("/html/body/form/input[1]"));
            driver.FindElement(By.XPath("//input[@value='m']"));
            driver.FindElement(By.XPath("//input[@name='lname']")); 
            driver.FindElement(By.XPath("//input[@type='checkbox']"));
            driver.FindElement(By.XPath("//input[@class='button']")); 
            driver.FindElement(By.XPath("//div[@class='additional-info']//input[@type='text']")); 


        }
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();

        }
    }
}