using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Text;

namespace Foody
{
    public class Tests
    {

        private readonly static string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85";
        private WebDriver driver;
        private Actions actions;
        private string? LastCreatedName;

        [OneTimeSetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profilempassword_manager_enabled", false);
            chromeOptions.AddArgument("--disable-search-engine-choice-screen");

            driver = new ChromeDriver(chromeOptions);
            actions = new Actions(driver);
            driver.Navigate().GoToUrl(BaseUrl);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl($"{BaseUrl}/User/Login");
            var loginForms = driver.FindElement(By.XPath("//form[@method='post']"));

            driver.FindElement(By.Id("username")).SendKeys("Testi");
            driver.FindElement(By.Id("password")).SendKeys("123456");

            driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']")).Click();
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test, Order(1)]
        public void AddFoodWithInvalidData()
        {
            driver.Navigate().GoToUrl($"{BaseUrl}/Food/Add");

            var nameInput = driver.FindElement(By.Id("name"));
            actions.ScrollToElement(nameInput).Perform();
            nameInput.Clear();
            nameInput.SendKeys("");

            var descriptionInput = driver.FindElement(By.Id("name"));
            actions.ScrollToElement(descriptionInput).Perform();
            descriptionInput.Clear();
            descriptionInput.SendKeys("");

            var submitButton = driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));
            actions.ScrollToElement(submitButton).Perform();
            submitButton.Click();

            var currentUrl = driver.Url;
            Assert.That(currentUrl, Is.EqualTo($"{BaseUrl}/Food/Add"), "The page should not navigate away");

            var mainErrorMessage = driver.FindElement(By.XPath("//li[normalize-space()='Unable to add this food revue!']")).Text;
            Assert.That(mainErrorMessage, Is.EqualTo("Unable to add this food revue!"), "Incorrect or missing main error message");

            var inputFieldErrors = driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"));
            var nameInputError = inputFieldErrors[0].Text;
            var descriptionInputError = inputFieldErrors[1].Text;

            Assert.That(nameInputError, Is.EqualTo("The Name field is required."), "Incorrect or missing name field error message");
            Assert.That(descriptionInputError, Is.EqualTo("The Description field is required."), "Incorrect or missing description field error message");
        }

        [Test, Order(2)]
        public void AddRandoFoodTest()
        {
            driver.Navigate().GoToUrl($"{BaseUrl}/Food/Add");

            var nameInput = driver.FindElement(By.Id("name"));
            actions.ScrollToElement(nameInput).Perform();
            nameInput.Clear();
            LastCreatedName = StringRandomiser(6);
            nameInput.SendKeys(LastCreatedName);

            var descriptionInput = driver.FindElement(By.Id("description"));
            actions.ScrollToElement(descriptionInput).Perform();
            descriptionInput.Clear();
            var newFoodDescription = StringRandomiser(15);
            descriptionInput.SendKeys(newFoodDescription);

            var submitButton = driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));
            actions.ScrollToElement(submitButton).Perform();
            submitButton.Click();

            var currentUrl = driver.Url;
            Assert.That(currentUrl, Is.EqualTo($"{BaseUrl}/"), "User was not redirected to the Home page");

            var foods = driver.FindElements(By.XPath("//h2[@class='display-4']"));
            var lastFoodName = foods.Last().Text;
            Assert.That(lastFoodName, Is.EqualTo(LastCreatedName), "The last added Food is missing");

        }

        [Test, Order(3)]
        public void EditLastAddedFoodTest()
        {
            driver.Navigate().GoToUrl(BaseUrl);

            var foods = driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']"));
            Assert.That(foods.Count(), Is.AtLeast(1), "There are no foods");
            var lastFoodItem = foods.Last();

            var lastFoodEditButton = lastFoodItem.FindElement(By.XPath(".//a[@class='btn btn-primary btn-xl rounded-pill mt-5' and text()='Edit']"));
            actions.ScrollToElement(lastFoodEditButton).Perform();
            lastFoodEditButton.Click();

            var nameInput = driver.FindElement(By.Id("name"));
            actions.ScrollToElement(nameInput).Perform();
            var oldFoodName = nameInput.GetAttribute("value");
            nameInput.Clear();
            LastCreatedName = StringRandomiser(6);
            nameInput.SendKeys(LastCreatedName);

            var submitButton = driver.FindElement(By.XPath("//button[@class='btn btn-primary btn-block fa-lg gradient-custom-2 mb-3']"));
            actions.ScrollToElement(submitButton).Perform();
            submitButton.Click();

            var currentUrl = driver.Url;
            Assert.That(currentUrl, Is.EqualTo($"{BaseUrl}/"), "User was not redirected to the Home page");

            var updatedFood = driver.FindElements(By.XPath("//h2[@class='display-4']")).Last();
            actions.ScrollToElement(updatedFood).Perform();
            var updatedFoodName = updatedFood.Text;
            Assert.That(updatedFoodName, Is.EqualTo(oldFoodName), "Update was successful");
            Console.WriteLine("Food name was not updated due to a missing functionality");

            LastCreatedName = oldFoodName;
        }

        [Test, Order(4)]
        public void SearchForFoodNameTest()
        {
            driver.Navigate().GoToUrl(BaseUrl);

            var searchField = driver.FindElement(By.XPath("//input[@placeholder='Search']"));
            actions.ScrollToElement(searchField).Perform();

            var searchInput = driver.FindElement(By.XPath("//input[@placeholder='Search']"));
            searchInput.SendKeys(LastCreatedName);
            var searchButton = driver.FindElement(By.XPath("//button[@type='submit']"));
            searchButton.Click();

            var foodList = driver.FindElements(By.CssSelector("div.row.gx-5.align-items-center"));
            var lastFoodName = foodList.Last().FindElement(By.CssSelector("h2.display-4")).Text;

            Assert.That(lastFoodName, Is.EqualTo(LastCreatedName), "No results found");

        }

        [Test, Order(5)]
        public void DeleteLastAddedFood()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var initialFoods = driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']"));
            var initialFoodsCount = initialFoods.Count();
            var lastInitialFoodsItem = initialFoods.Last();

            var lastFoodDeleteButton = lastInitialFoodsItem.FindElement(By.XPath(".//a[@class='btn btn-primary btn-xl rounded-pill mt-5' and text()='Delete']"));
            actions.ScrollToElement(lastFoodDeleteButton).Perform();
            lastFoodDeleteButton.Click();

            var noFoodsText = driver.FindElement(By.XPath("//h2[@class='display-4']")).Text;
            var updatedFoods = driver.FindElements(By.XPath("//div[@class='row gx-5 align-items-center']"));
            var updatedFoodsCount = 0;
            if (noFoodsText != "There are no foods :(")
            {
                updatedFoodsCount = updatedFoods.Count();
            }
            var lastUpdatedFoodsItem = updatedFoods.Last().Text;

            Assert.That(updatedFoodsCount, Is.EqualTo(initialFoodsCount - 1), "Deletion failed");
            Assert.That(lastUpdatedFoodsItem, Is.Not.EqualTo(LastCreatedName), "Deletion fialed");

        }

        [Test, Order(6)]
        public void SearchForDeletedFoodTest()
        {
            driver.Navigate().GoToUrl(BaseUrl);

            var searchField = driver.FindElement(By.XPath("//input[@placeholder='Search']"));
            actions.ScrollToElement(searchField).Perform();

            var searchInput = driver.FindElement(By.XPath("//input[@placeholder='Search']"));
            searchInput.SendKeys(LastCreatedName);
            var searchButton = driver.FindElement(By.XPath("//button[@type='submit']"));
            searchButton.Click();

            var noFoodsText = driver.FindElement(By.XPath("//h2[@class='display-4']")).Text;
            Assert.That(noFoodsText, Is.EqualTo("There are no foods :("));

            var addFoodButton = driver.FindElement(By.XPath("//a[@class='btn btn-primary btn-xl rounded-pill mt-5' and text()='Add food']"));
            Assert.That(addFoodButton.Displayed, Is.True, "Add Food Button is missing");

        }

        public static string StringRandomiser(int length)
        {
            char[] chars =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            if (length <= 0)
            {
                throw new ArgumentException("Length must be greater than zero.", nameof(length));
            }

            var random = new Random();
            var result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }
    }
}