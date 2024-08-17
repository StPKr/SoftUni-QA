namespace TestProject1.Tests
{
    public class IdealCenterTests : BaseTest
    {

        public string lastCreatedIdeaTitle;
        public string lastCreatedIdeaDescription;

        [Test, Order(1)]
        public void CreateIdeaWithInvalidDataTest()
        {
            createIdeaPage.OpenPage();

            createIdeaPage.CreateIdea("", "", "");

            createIdeaPage.AssertErrorMessages();

        }

        [Test, Order(2)]
        public void CreateIdeaWithValidDataTest()
        {
            lastCreatedIdeaTitle = "Idea " + GenerateRandomString(5);
            lastCreatedIdeaDescription = "Description " + GenerateRandomString(5);
            createIdeaPage.OpenPage();

            createIdeaPage.CreateIdea(lastCreatedIdeaTitle, "", lastCreatedIdeaDescription);

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "URL is not correct!");

            Assert.That(myIdeasPage.DescriptionLastIdea.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription), "Descriptions don't match!");
        }

        [Test, Order(3)]
        public void ViewLastCreatedIdea()
        {
            myIdeasPage.OpenPage();

            myIdeasPage.ViewButtonLastIdfea.Click();

            Assert.That(ideasReadPage.IdeaTitle.Text.Trim(), Is.EqualTo(lastCreatedIdeaTitle), "Title mismatch!");
            Assert.That(ideasReadPage.IdeaDescription.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription), "Description mismatch!");

        }

        [Test, Order(4)]
        public void EditIdeaTitle()
        {
            myIdeasPage.OpenPage();

            myIdeasPage.EditButtonLastIdea.Click();

            string updatedTitle = "Changed Title: " + lastCreatedIdeaTitle;

            ideasEditPage.TitleInput.Clear();
            ideasEditPage.TitleInput.SendKeys(updatedTitle);
            ideasEditPage.EditButton.Click();

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "Not redirected!");

            myIdeasPage.ViewButtonLastIdfea.Click();

            Assert.That(ideasReadPage.IdeaTitle.Text.Trim(), Is.EqualTo(updatedTitle), "Title mismatch!");

        }

        [Test, Order(5)]
        public void EditIdeaDescription()
        {
            myIdeasPage.OpenPage();

            myIdeasPage.EditButtonLastIdea.Click();

            string updatedDescription = "Changed Description: " + lastCreatedIdeaDescription;

            ideasEditPage.DescriptionInput.Clear();
            ideasEditPage.DescriptionInput.SendKeys(updatedDescription);
            ideasEditPage.EditButton.Click();

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "Not redirected!");

            myIdeasPage.ViewButtonLastIdfea.Click();

            Assert.That(ideasReadPage.IdeaDescription.Text.Trim(), Is.EqualTo(updatedDescription), "Description mismatch!");

        }

        [Test, Order(6)]
        public void DeleteLastIdea()
        {
            myIdeasPage.OpenPage();

            myIdeasPage.DeleteButtonLastIdea.Click();

            bool isIdeaDeleted = myIdeasPage.IdeasCards.All(card => card.Text.Contains(lastCreatedIdeaDescription));

            Assert.IsFalse(isIdeaDeleted, "The idea was not deleted!");
        }
    }
}
