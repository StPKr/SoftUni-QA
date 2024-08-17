using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Pages
{
    public class MyIdeasPage : BasePage
    {
        public MyIdeasPage(IWebDriver driver) : base(driver)
        {

        }

        public string Url = BaseUrl + "/Ideas/MyIdeas";

        public ReadOnlyCollection<IWebElement> IdeasCards => driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));

        public IWebElement ViewButtonLastIdfea => IdeasCards.Last().FindElement(By.XPath(".//a[contains(@href,'/Ideas/Read')]"));

        public IWebElement EditButtonLastIdea => IdeasCards.Last().FindElement(By.XPath(".//a[contains(@href,'/Ideas/Edit')]"));

        public IWebElement DeleteButtonLastIdea => IdeasCards.Last().FindElement(By.XPath(".//a[contains(@href,'/Ideas/Delete')]"));

        public IWebElement DescriptionLastIdea => IdeasCards.Last().FindElement(By.XPath(".//p[@class='card-text']"));
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
