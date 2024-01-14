using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SauceDemo_MP.lib.tests
{
    //[Binding]
    //public class SharedSteps
    //{
    //    private SD_Website<ChromeDriver> SD_Website;

    //    [BeforeScenario]
    //    public void SetUp()
    //    {
    //        SD_Website = new SD_Website<ChromeDriver>();
    //    }

    //    [Given(@"I have signed in as ""(.*)"" with the password ""(.*)""")]
    //    public void GivenIHaveSignedInAsWithThePassword(string username, string password)
    //    {
    //        SD_Website.SD_SignInPage.NavigateToSignInPage();
    //        SD_Website.SD_SignInPage.EnterUsernameAndPassword(username, password);
    //        SD_Website.SD_SignInPage.ClickLoginButton();
    //    }

    //    [Then(@"I should receive an error containing ""(.*)""")]
    //    public void ThenIShouldReceiveAnErrorContaining(string error)
    //    {
    //        Assert.That(SD_Website.SD_SignInPage.RetrieveErrorMessage(), Does.Contain(error));
    //    }

    //    [AfterScenario]
    //    public void TearDown()
    //    {
    //        SD_Website.SeleniumDriver.Dispose();
    //        SD_Website.SeleniumDriver.Quit();
    //    }
    //}
}
