using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SauceDemo_MP.lib.tests
{
    [Binding]
    public class SD_SigninSteps
    {
        private SD_Website<ChromeDriver> SD_Website = new SD_Website<ChromeDriver>();


        [Given(@"I am on the sign in page")]
        public void GivenIAmOnTheSignInPage()
        {
            SD_Website.SD_SignInPage.NavigateToSignInPage();
        }

        [When(@"I enter a username (.*) and password (.*)")]
        public void WhenIEnterAUsernameAndPassword(string username, string password)
        {
            SD_Website.SD_SignInPage.EnterUsernameAndPassword(username, password);
        }

        [When(@"I enter an invalid username of ""(.*)"" and password ""(.*)""")]
        public void WhenIEnterAnInvalidUsernameOfAndPassword(string username, string password)
        {
            SD_Website.SD_SignInPage.EnterUsernameAndPassword(username, password);
        }

        [When(@"I enter a username ""(.*)"" and no password")]
        public void WhenIEnterAUsernameAndNoPassword(string username)
        {
            SD_Website.SD_SignInPage.EnterUsernameAndPassword(username, "");
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            SD_Website.SD_SignInPage.ClickLoginButton();
        }
        
        [Then(@"I should be redirected to the products page")]
        public void ThenIShouldBeRedirectedToTheProductsPage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
        }

        [When(@"I click the remove error message button")]
        public void WhenIClickTheRemoveErrorMessageButton()
        {
            SD_Website.SD_SignInPage.ClickErrorMessageButton();
        }

        [Then(@"I should receive an error containing ""(.*)""")]
        public void ThenIShouldReceiveAnErrorContaining(string error)
        {
            Assert.That(SD_Website.SD_SignInPage.RetrieveErrorMessage(), Does.Contain(error));
        }

        [Then(@"there should be no visible error message")]
        public void ThenThereShouldBeNoVisibleErrorMessage()
        {
            Assert.That(SD_Website.SD_SignInPage.RetrieveErrorMessage(), Is.EqualTo(""));
        }

        [AfterScenario]
        public void TearDown()
        {
            SD_Website.SeleniumDriver.Dispose();
            SD_Website.SeleniumDriver.Quit();
        }
    }
}
