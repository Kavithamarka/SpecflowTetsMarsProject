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
    public class SpecFlowFeature2Steps : Utils.Start

    {
        [Given(@"Clicked on the Profile Page and then Language tab")]
        public void GivenClickedOnTheProfilePageAndThenLanguageTab()
        {
           
            Thread.Sleep(1000);            
          
            //Click on Profile Page
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

            //Click on Language tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")).Click();

            //Click on addlanguage button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();
        }


        [When(@"I press add new language and enter (.*) and (.*)")]
        public void WhenIPressAddNewLanguageAndEnterTeluguAnd(string language, string level)
        {
            //language entered from scenario outline
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys(language);

            //language level chosen from dropdown list
            IWebElement Level = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option"))[2];
            Level.Click();
            

        }

        [When(@"press add button")]
        public void WhenPressAddButton()
        {
            //pressing on add Button
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();

        }

        [Then(@"all the languages are displayed on my listings")]
        public void ThenAllTheLanguagesAreDisplayedOnMyListings()
        {

            string[] a = new string[3];
            a[0] = "English";
            a[1] = "Hindi";
            a[2] = "Telugu";

            for (int i = 0; i <= 2; i++)
            {
                try
                {
                    //Start the Reports

                    CommonMethods.ExtentReports();
                    Thread.Sleep(1000);
                    CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                    Thread.Sleep(1000);
                    string ExpectedValue = "a[i]";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                        // SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                    }

                    else
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                }

                catch (Exception e)
                {
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
                }

                Driver.Close();
            


            }
        }



    }
}
    

