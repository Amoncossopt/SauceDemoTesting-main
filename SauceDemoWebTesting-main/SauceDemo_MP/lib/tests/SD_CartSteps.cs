using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using System.Threading;

namespace SauceDemo_MP.lib.tests
{
    [Binding]
    public class SD_CartSteps
    {
        private SD_Website<ChromeDriver> SD_Website = new SD_Website<ChromeDriver>();
        private string _productName;

        [BeforeScenario]
        public void SetUp()
        {
            SD_Website = new SD_Website<ChromeDriver>();
        }

        [Given(@"I click the ""(.*)"" add to cart button")]
        public void GivenIClickTheAddToCartButton(string productName)
        {
            SD_Website.SD_ProductsPage.GoToProductsPage();
            SD_Website.SD_ProductsPage.AddItemToCart();
        }

        [Given(@"I go to the cart page")]
        public void GivenIGoToTheCartPage()
        {
            SD_Website.SD_ProductPage.GoToCartPage();
        }
        
        [When(@"I click the checkout button")]
        public void WhenIClickTheCheckoutButton()
        {
            SD_Website.SD_CartPage.ClickCheckoutButton();
        }

        [When(@"I click remove for the product ""(.*)""")]
        public void WhenIClickRemoveForTheProduct(string productName)
        {
            _productName = productName;
            SD_Website.SD_CartPage.ClickProductRemove(productName);
        }

        [When(@"I click the continue shopping button")]
        public void WhenIClickTheContinueShoppingButton()
        {
            SD_Website.SD_CartPage.ClickContinueShoppingButton();
        }

        [Then(@"I should land on the products page")]
        public void ThenIShouldLandOnTheProductsPage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
        }


        [Then(@"I should no longer see that item in my cart")]
        public void ThenIShouldNoLongerSeeThatItemInMyCart()
        {
            Assert.That(SD_Website.SD_CartPage.GetCardItemByName(_productName), Is.Null);
        }

        [Then(@"I should be on the checkout page")]
        public void ThenIShouldBeOnTheCheckoutPage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-step-one.html"));
        }

        [AfterScenario]
        public void TearDown()
        {
            SD_Website.SeleniumDriver.Dispose();
            SD_Website.SeleniumDriver.Quit();
        }
    }
}
