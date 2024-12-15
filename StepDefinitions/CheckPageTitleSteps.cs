using NorthStandard.Pages;
using NorthStandard.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace NorthStandard.StepDefinitions
{
    [Binding]
    public class CheckPageTitleSteps
    {
        private SeleniumHomePage _seleniumHomePage;

        [Given(@"I have set the driver")]
        public void GivenIHaveSetTheDriver()
        {
            _seleniumHomePage = new SeleniumHomePage(DriverManager.Driver);
        }

        [When("I navigate to the page url \"(.*)\"")]
        public void WhenINavigateToThePageUrl(string url)
        {
            _seleniumHomePage.NavigateToHomePage(url);
        }

        [Then("the page title should be \"(.*)\"")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            Utils.AssertTitle(expectedTitle);
        }
      

    }
}
