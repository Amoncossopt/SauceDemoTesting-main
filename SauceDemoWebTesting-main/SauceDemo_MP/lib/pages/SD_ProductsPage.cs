using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo_MP.lib.pages
{
    public class SD_ProductsPage
    {
        private IWebDriver _seleniumDriver;
        private string _productsPageURL = "https://www.saucedemo.com/inventory.html";

        public SD_ProductsPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }

        private IWebElement cart => _seleniumDriver.FindElement(By.Id("shopping_cart_container"));
        private SelectElement filterOptions => new SelectElement(_seleniumDriver.FindElement(By.ClassName("product_sort_container")));
        private IReadOnlyCollection<IWebElement> productsPriceList => _seleniumDriver.FindElements(By.ClassName("inventory_item_price"));
        private IReadOnlyCollection<IWebElement> productsNameList => _seleniumDriver.FindElements(By.ClassName("inventory_item_name"));
        private IReadOnlyCollection<IWebElement> productsAddToCart => _seleniumDriver.FindElements(By.ClassName("btn_inventory"));
        private IWebElement burgerMenuButton => _seleniumDriver.FindElement(By.CssSelector(".bm-burger-button"));


        public void GoToProductsPage() => _seleniumDriver.Navigate().GoToUrl(_productsPageURL);

        public void GoToCheckout() => cart.Click();

        public void FilterProducts(string filterSpecifier) => filterOptions.SelectByValue(filterSpecifier);

        public void ClickProductName(string productName) => productsNameList.Where(item => item.Text.Contains(productName.Trim('\"'))).FirstOrDefault().FindElement(By.XPath("..")).Click();

        public IEnumerable<decimal> GetListOfProductsPrices() => productsPriceList.Select(e => decimal.Parse(e.Text, NumberStyles.Currency, new CultureInfo("en-US")));

        public IEnumerable<string> GetListOfProductsNames() => productsNameList.Select(element => element.Text).ToArray();

        public void AddItemToCart() => productsAddToCart.ToArray()[0].Click();

        public void RemoveItemFromCart() => productsAddToCart.ToArray()[0].Click();

        public int GetCartItemCount() => int.Parse(_seleniumDriver.FindElement(By.ClassName("shopping_cart_badge")).Text);

        public string GetRemoveButtonText() => _seleniumDriver.FindElement(By.ClassName("btn_inventory")).Text;

        public bool CheckProductsSortedAlphabetically(bool alphabetical)
        {
            IEnumerable<string> sortedArray;
            if(alphabetical) sortedArray = GetListOfProductsNames().OrderBy(element => element);
            else sortedArray = GetListOfProductsNames().OrderByDescending(element => element);

            return GetListOfProductsNames().SequenceEqual(sortedArray);
        }
    }
}
