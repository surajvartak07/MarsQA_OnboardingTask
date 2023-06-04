using MarsQA_1.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MarsQA_1.SpecflowPages.Pages
{
    public class Languages
    {
        //delete all existing languages to avoid inability to add or edit languages in future
        public void CleanLanguageTable(IWebDriver driver)
        {
            try
            {
                for (var i = 0; i < 4; i++) //Loop will run till there is any language left in the list
                {
                    IWebElement RemoveButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
                    RemoveButton.Click();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            };
        }
        //Add new language 
        public void AddLanguage(IWebDriver driver,String Language)
        {
            Thread.Sleep(3000);
            IWebElement AddLanguageButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            AddLanguageButton.Click();

            IWebElement LanguageName = driver.FindElement(By.Name("name"));
            LanguageName.SendKeys(Language); //passing Language as parameter so that AddLanguage method can be re-used for adding multiple languages

            IWebElement LanguageLevelDropdown = driver.FindElement(By.Name("level"));
            //LanguageLevelDropdown.Click();

            var SelectLevel = new SelectElement(LanguageLevelDropdown);
            SelectLevel.SelectByValue("Basic");

            IWebElement AddButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            AddButton.Click();

            Thread.Sleep(3000);



        }
        
        public string ValidateAddedLanguage(IWebDriver driver)
        {
            IWebElement Language = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            return Language.Text;
        }
        //Edit existing language
        public void EditLanguage(IWebDriver driver)
        {
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            editButton.Click();

            IWebElement LanguageName = driver.FindElement(By.Name("name"));
            LanguageName.Clear();
            LanguageName.SendKeys("MarathiEdited");

            IWebElement LanguageLevelDropdown = driver.FindElement(By.Name("level"));

            var SelectLevel = new SelectElement(LanguageLevelDropdown);
            SelectLevel.SelectByValue("Fluent");

            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();

            Thread.Sleep(3000);
        }

        public string ValidateEditedLanguage(IWebDriver driver)
        {
            IWebElement EditedLanguageName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            return EditedLanguageName.Text;
        }
        public void DeleteLanguage(IWebDriver driver)
        {
            IWebElement RemoveButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
            RemoveButton.Click();
        }
        //If remove button element is not found, it means no language exists in list, so we have deleted the language successfully 
        public bool ValidateLanguageIsDeleted(IWebDriver driver)
        {
            try
            {
                IWebElement removeButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]/i"));
                return false;
            }
            catch
            {
                return true;
            }

        }

        public void AddFourLanguages(IWebDriver driver)
        {
            AddLanguage(driver, "Hindi");
            AddLanguage(driver, "English");
            AddLanguage(driver, "Sanskrit");
            AddLanguage(driver, "Marathi");
        }
        //Add new button wont be available if four languages already exists, hence exception will occur during try block
        public bool ValidateMaxLanguageLimit(IWebDriver driver)
        { 

            try
            {
                AddLanguage(driver, "Latin");
                return false;
            }

            catch(Exception ex)
            {
                return true;
            }
           
        }


    }
}
