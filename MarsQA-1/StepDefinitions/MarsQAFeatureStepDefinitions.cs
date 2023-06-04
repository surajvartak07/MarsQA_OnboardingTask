using MarsQA_1.SpecflowPages.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MarsQA_1.StepDefinitions
{
    [Binding]
    public class MarsQAFeatureStepDefinitions : CommonDriver
    {
        Languages languagesObj = new Languages();

        [Given(@"User is logged into MarsQA application")]
        public void GivenUserIsLoggedIntoMarsQAApplication()
        {
            driver = new ChromeDriver();

            LoginMars loginObj = new LoginMars();
            loginObj.Login(driver);
        }

        [When(@"User adds new language")]
        public void WhenUserAddsNewLanguage()
        {
            languagesObj.CleanLanguageTable(driver);
            languagesObj.AddLanguage(driver,"Marathi");
        }

        [Then(@"Newly added language is displayed in the languages list on user profile")]
        public void ThenNewlyAddedLanguageIsDisplayedInTheLanguagesListOnUserProfile()
        {
            string addedLanguage = languagesObj.ValidateAddedLanguage(driver);
            Assert.That(addedLanguage == "Marathi", "Marathi language could not be added");
            driver.Quit();
            driver.Dispose();
        }

        [When(@"User edits newly added language")]
        public void WhenUserEditsNewlyAddedLanguage()
        {
            languagesObj.EditLanguage(driver);
        }

        [Then(@"Language is edited successfully")]
        public void ThenLanguageIsEditedSuccessfully()
        {
            string editedLanguage = languagesObj.ValidateEditedLanguage(driver);
            Assert.That(editedLanguage == "MarathiEdited", "Language could not be edited");
            driver.Quit();
            driver.Dispose();
        }
        [When(@"User delets newly added language")]
        public void WhenUserDeletsNewlyAddedLanguage()
        {
            languagesObj.DeleteLanguage(driver);
        }
        [Then(@"Language is deleted successfully")]
        public void ThenLanguageIsDeletedSuccessfully()
        {
            bool del = languagesObj.ValidateLanguageIsDeleted(driver);
            Assert.That(del = true, "Language cloul not be deleted");
            driver.Quit();
            driver.Dispose();
        }

        [When(@"User adds four languages")]
        public void WhenUserAddsFourLanguages()
        {
            languagesObj.AddFourLanguages(driver);
        }

        [Then(@"Add new Language button is not visible so user is not able to add fifth language")]
        public void ThenAddNewLanguageButtonIsNotVisibleSoUserIsNotAbleToAddFifthLanguage()
        {
            bool limit = languagesObj.ValidateMaxLanguageLimit(driver);
            Assert.That(limit = true);
            driver.Quit();
            driver.Dispose();
        }



    }
}
