using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SauceDemo_MP.lib.tests
{
    [Binding]
    public class SD_ProductSteps
    {
        private SD_Website<ChromeDriver> SD_Website = new SD_Website<ChromeDriver>();

        private int _itemsInCart;

        [Given(@"I click the (.*) product button")]
        public void GivenIClickTheProductButton(string productName)
        {
            SD_Website.SD_ProductsPage.ClickProductName(productName);
        }

        [Given(@"I have signed in as ""(.*)"" with the password ""(.*)""")]
        public void GivenIHaveSignedInAsWithThePassword(string username, string password)
        {
            SD_Website.SD_SignInPage.NavigateToSignInPage();
            SD_Website.SD_SignInPage.EnterUsernameAndPassword(username, password);
            SD_Website.SD_SignInPage.ClickLoginButton();
        }

        [Given(@"There are no items in my cart")]
        public void GivenThereAreNoItemsInMyCart()
        {
            _itemsInCart = 0;
            Assert.That(SD_Website.SD_ProductPage.GetNumberofItemsInCart(), Is.EqualTo(0));
        }

        [Given(@"There are ""(.*)"" items in my cart")]
        public void GivenThereAreItemsInMyCart(int numberOfItemsInCart)
        {
            _itemsInCart = numberOfItemsInCart;
            Assert.That(SD_Website.SD_ProductPage.GetNumberofItemsInCart(), Is.EqualTo(numberOfItemsInCart));
        }

        [Given(@"I click the add to cart button")]
        [When(@"I click the add to cart button")]
        public void IClickTheAddToCartButton()
        {
            SD_Website.SD_ProductPage.AddOrRemoveButtonClick();
        }

        [When(@"I click the remove button")]
        public void WhenIClickTheRemoveButton()
        {
            SD_Website.SD_ProductPage.AddOrRemoveButtonClick();
        }

        [When(@"I click the back button")]
        public void WhenIClickTheBackButton()
        {
            SD_Website.SD_ProductPage.GoBackToProductsList();
        }

        [Then(@"the cart number size decreases by one")]
        public void ThenTheCartNumberSizeDecreasesByOne()
        {
            Assert.That(SD_Website.SD_ProductPage.GetNumberofItemsInCart(), Is.EqualTo(_itemsInCart - 1));
        }

        [Then(@"the remove button changes to add to cart")]
        public void ThenTheRemoveButtonChangesToAddToCart()
        {
            Assert.That(SD_Website.SD_ProductPage.GetAddOrRemoveButtonText().ToLower(), Is.EqualTo("add to cart"));
        }

        [Then(@"I should be on the products page")]
        public void ThenIShouldBeOnTheProductsPage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
        }

        [Then(@"the cart number size increases by one")]
        public void ThenTheCartNumberSizeIncreasesByOne()
        {
            Assert.That(SD_Website.SD_ProductPage.GetNumberofItemsInCart(), Is.EqualTo(_itemsInCart + 1));
        }
        
        [Then(@"the add to cart button changes to remove")]
        public void ThenTheAddToCartButtonChangesToRemove()
        {
            Assert.That(SD_Website.SD_ProductPage.GetAddOrRemoveButtonText().ToLower(), Is.EqualTo("remove"));
        }

        [AfterScenario]
        public void TearDown()
        {
            SD_Website.SeleniumDriver.Dispose();
            SD_Website.SeleniumDriver.Quit();
        }
    }
}
