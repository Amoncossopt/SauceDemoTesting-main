using OpenQA.Selenium;
using SeleniumPOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo_MP
{
    public class SD_CheckoutTwoPage
    {
        private IWebDriver _seleniumDriver;
        private string checkoutTwoUrl = "https://www.saucedemo.com/checkout-step-two.html";
        private IWebElement _item => _seleniumDriver.FindElement(By.ClassName("inventory_item_name"));
        private IWebElement _finish => _seleniumDriver.FindElement(By.ClassName("cart_button"));
        private IWebElement _cancel => _seleniumDriver.FindElement(By.ClassName("cart_cancel_link"));


        public SD_CheckoutTwoPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }

        public void OnTheCheckoutTwoPage()
        {
            _seleniumDriver.Navigate().GoToUrl(checkoutTwoUrl);
        }

        public void ClickOnItem()
        {
            _item.Click();
        }

        public void PressButton(string button)
        {
            if (button == "Finish")
            {
                _finish.Click();
            }
            if (button == "Cancel")
            {
                _cancel.Click();
            }
        }
    }
}
