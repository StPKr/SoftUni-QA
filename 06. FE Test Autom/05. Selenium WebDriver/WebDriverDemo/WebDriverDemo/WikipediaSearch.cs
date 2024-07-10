using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Create a new instance of ChromeDriver
var driver = new ChromeDriver();

// Navigate to the Wikipedia homepage

driver.Navigate().GoToUrl("https://wikipedia.org");

// Print the title of the main page to the console
Console.WriteLine("Main page title: " + driver.Title);

// Find the search input element by its ID
var searchBox = driver.FindElement(By.Id("searchInput"));

// Click on the search box to focus it
searchBox.Click();

// Type "QA" into the search box and press Enter
searchBox.SendKeys("Quality Assurance" + Keys.Enter);

// Print the title of the QA search results page to the console
Console.WriteLine("Quality A page title: " + driver.Title);

// Close the browser and end the session
driver.Quit();


