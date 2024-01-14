using OpenQA.Selenium;
using SeleniumPOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo_MP
{
    public class SD_CheckoutPage
    {
        private IWebDriver _seleniumDriver;

        private string checkoutUrl = "https://www.saucedemo.com/checkout-step-one.html";

     
        private IWebElement _continue => _seleniumDriver.FindElement(By.ClassName("cart_button"));
     
        private IWebElement _cancel => _seleniumDriver.FindElement(By.ClassName("cart_cancel_link"));
        private IWebElement _firstName => _seleniumDriver.FindElement(By.Id("first-name"));
        private IWebElement _lastName => _seleniumDriver.FindElement(By.Id("last-name"));
        private IWebElement _postCode => _seleniumDriver.FindElement(By.Id("postal-code"));

        public string RetrieveErrorMessage() => _seleniumDriver.FindElement(By.CssSelector("*[data-test=\"error\"]")).Text;

        public SD_CheckoutPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }
        public void OnTheCheckoutPage()
        {
            _seleniumDriver.Navigate().GoToUrl(checkoutUrl);
        }

        public void PressButton(string button)
        {
            if (button == "Continue" || button == "Finish")
            {
                _continue.Click();
            }
            if (button == "Cancel")
            {
                _cancel.Click();
            }
        }

        public void EnterFirstName(string name)
        {
            _firstName.SendKeys(name);
        }

        public void EnterLastName(string name)
        {
            _lastName.SendKeys(name);
        }
        public void EnterPostCode(string postcode)
        {
            _postCode.SendKeys(postcode);
        }
        public string EmptyFieldsAlert()
        {
            return RetrieveErrorMessage();
        }
    }
}
