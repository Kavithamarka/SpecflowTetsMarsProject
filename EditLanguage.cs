using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature3Steps : Utils.Start
    {
        [Given(@"I am under language tab under Profile page")]
        public void GivenIAmUnderLanguageTabUnderProfilePage()
        {
            //Click on Profile Page
            //Click on Profile Page
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

            //Click on Language tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")).Click();

        }
        
        [Given(@"I Clicked on edit on already entered language")]
        public void GivenIClickedOnEditOnAlreadyEnteredLanguage()
        {
            //Click on the Edit Button for the first row
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]")).Click();
        }
        
        [When(@"I could able change the level of language")]
        public void WhenICouldAbleChangeTheLevelOfLanguage()
        {
            IWebElement Lang = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[0];
            Lang.Click();
        }
        
        [When(@"click update button")]
        public void WhenClickUpdateButton()
        {
            Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
        }
        
        [Then(@"table is updated with change")]
        public void ThenTableIsUpdatedWithChange()
        {
            try
            {
                Thread.Sleep(2000);
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Language");
                String ExpectedValue = "Fluent";
               String ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[2]")).Text;
                if (ActualValue == ExpectedValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Language is level is updated successfully.");

                }


            }

            catch
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
        }
    }
}
