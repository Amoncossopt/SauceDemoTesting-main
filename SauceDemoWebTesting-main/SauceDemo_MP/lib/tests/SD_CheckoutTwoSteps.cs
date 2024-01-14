using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SauceDemo_MP.lib.tests
{
    [Binding]
    public class SD_CheckoutTwoSteps
    {
        private SD_Website<ChromeDriver> SD_Website;

        [BeforeScenario]
        public void SetUp()
        {
            SD_Website = new SD_Website<ChromeDriver>();
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            SD_Website.SD_SignInPage.NavigateToSignInPage();
            SD_Website.SD_SignInPage.EnterUsernameAndPassword("standard_user", "secret_sauce");
            SD_Website.SD_SignInPage.ClickLoginButton();
        }

        [Given(@"I am on the checkout two page")]
        [When(@"I go to the checkout two page")]
        public void IGoToTheCheckoutTwoPage()
        {
            SD_Website.SD_CheckoutTwoPage.OnTheCheckoutTwoPage();
        }

        [Given(@"I have an item in my basket")]
        public void GivenIHaveAnItemInMyBasket()
        {
            SD_Website.SD_ProductsPage.AddItemToCart();
        }


        [When(@"I press on the Item")]
        public void WhenIPressOnTheItem()
        {
            SD_Website.SD_CheckoutTwoPage.ClickOnItem();
        }


        [Then(@"I land on the Products Page")]
        public void ThenILandOnTheProductsPage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
        }
        
        [Then(@"I land on the Checkout Complete Page")]
        public void ThenILandOnTheCheckoutCompletePage()
        { 
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-complete.html"));
        }


        [AfterScenario]
        public void TearDown()
        {
            SD_Website.SeleniumDriver.Dispose();
            SD_Website.SeleniumDriver.Quit();
        }
    }
}
