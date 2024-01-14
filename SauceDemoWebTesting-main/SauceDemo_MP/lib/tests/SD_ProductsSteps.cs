using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SauceDemo_MP.lib.tests
{
    [Binding]
    public class SD_ProductsSteps
    {
        private SD_Website<ChromeDriver> SD_Website;

        [BeforeScenario]
        public void SetUp()
        {
            SD_Website = new SD_Website<ChromeDriver>();
        }

        [Given(@"I am on the products page")]
        public void GivenIAmOnTheProductsPage()
        {
            SD_Website.SD_ProductsPage.GoToProductsPage();
        }

        [When(@"I click to add an item to cart")]
        public void WhenIClickToAddAnItemToCart()
        {
            SD_Website.SD_ProductsPage.AddItemToCart();
        }

        [Then(@"the cart number increases by one")]
        public void ThenTheCartNumberIncreasesByOne()
        {
            Assert.That(SD_Website.SD_ProductsPage.GetCartItemCount(), Is.EqualTo(1));
        }

        [Then(@"the add to cart button on the added item changes text to remove")]
        public void ThenTheAddToCartButtonOnTheAddedItemChangesTextToRemove()
        {
            Assert.That(SD_Website.SD_ProductsPage.GetRemoveButtonText(), Is.EqualTo("REMOVE"));
        }

        [When(@"I select Price \(low to high\)")]
        public void WhenISelectPriceLowToHigh()
        {
            SD_Website.SD_ProductsPage.FilterProducts("lohi");
        }
        
        [Then(@"the products are ordered in ascending price order")]
        public void ThenTheProductsAreOrderedInAscendingPriceOrder()
        {
            Assert.That(SD_Website.SD_ProductsPage.GetListOfProductsPrices(), Is.Ordered.Ascending);
        }

        [When(@"I select Price \(high to low\)")]
        public void WhenISelectPriceHighToLow()
        {
            SD_Website.SD_ProductsPage.FilterProducts("hilo");
        }

        [Then(@"the products are ordered in descending price order")]
        public void ThenTheProductsAreOrderedInDescendingPriceOrder()
        {
            Assert.That(SD_Website.SD_ProductsPage.GetListOfProductsPrices(), Is.Ordered.Descending);
        }

        [When(@"I click to go to that item's page")]
        public void WhenIClickToGoToThatItemSPage()
        {
            SD_Website.SD_ProductsPage.ClickProductName("Sauce Labs Backpack");
        }

        [Then(@"I am only able to remove that item from cart")]
        public void ThenIAmOnlyAbleToRemoveThatItemFromCart()
        {
            Assert.That(SD_Website.SD_ProductPage.GetAddOrRemoveButtonText().ToLower(), Is.EqualTo("remove"));
        }

        [When(@"I click to remove that item from cart")]
        public void WhenIClickToRemoveThatItemFromCart()
        {
            SD_Website.SD_ProductsPage.RemoveItemFromCart();
        }


        [Then(@"the remove button on the removed item changes text to add to cart")]
        public void ThenTheRemoveButtonOnTheRemovedItemChangesTextToAddToCart()
        {
            Assert.That(SD_Website.SD_ProductsPage.GetRemoveButtonText(), Is.EqualTo("ADD TO CART"));
        }

        [When(@"I select Name \(A to Z\)")]
        public void WhenISelectNameAToZ()
        {
            SD_Website.SD_ProductsPage.FilterProducts("az");
        }

        [Then(@"the products are ordered in alphabetical order")]
        public void ThenTheProductsAreOrderedInAlphabeticalOrder()
        {
            Assert.That(SD_Website.SD_ProductsPage.CheckProductsSortedAlphabetically(true), Is.True);
        }

        [When(@"I select Name \(Z to A\)")]
        public void WhenISelectNameZToA()
        {
            SD_Website.SD_ProductsPage.FilterProducts("za");
        }

        [Then(@"the products are ordered in reverse alphabetical order")]
        public void ThenTheProductsAreOrderedInReverseAlphabeticalOrder()
        {
            Assert.That(SD_Website.SD_ProductsPage.CheckProductsSortedAlphabetically(false), Is.True);
        }






        [AfterScenario]
        public void TearDown()
        {
            SD_Website.SeleniumDriver.Dispose();
            SD_Website.SeleniumDriver.Quit();
        }
    }
}
