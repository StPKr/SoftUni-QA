using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Reflection.Metadata;
using static System.Net.WebRequestMethods;

namespace WebDriverWikiTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create new Chrome browser
            WebDriver driver = new ChromeDriver();

            // Navigate to Wikipedia page
            driver.Url = "https://www.wikipedia.org/";

            // create new Firefox browser
            // WebDriver driver = new FirefoxDriver();

            //var searchInput = driver.FindElement(By.Id("searchInput"));

            //searchInput.Click();

            //searchInput.SendKeys("Quality Assurance" + Keys.Enter);

            var cookies = driver.Manage().Cookies.AllCookies;

            foreach(var cookie in cookies)
            {
                Console.WriteLine("Name: " + cookie.Name);
                Console.WriteLine("Value: " + cookie.Value);
                Console.WriteLine("Domain: " + cookie.Domain);
                Console.WriteLine("Path: " + cookie.Path);
                Console.WriteLine("Expiry: " + cookie.Expiry);
                Console.WriteLine("Secure: " + cookie.Secure);
                Console.WriteLine("IsHttpOnly: " + cookie.IsHttpOnly);
                Console.WriteLine("==================================");
            }

            driver.FindElement(By.Id("searchInput")).SendKeys("Quality Assurance" + Keys.Enter);

            var currentPageTitle = driver.Title;

            Console.WriteLine("Current page title is: " + currentPageTitle);

            if (currentPageTitle == "Quality assurance - Wikipedia")
            {
                Console.WriteLine("*** TEST PASS ***");
            } else
            {
                Console.WriteLine("*** TEST FAIL ***");
            }

            // Clear browser
            driver.Quit();
        }
    }
}
