using OpenQA.Selenium;
using SauceDemo_MP.lib.pages;
using SeleniumPOM.lib.driver_config;

namespace SauceDemo_MP
{
    public class SD_Website<T> where T : IWebDriver, new()
    {
        public IWebDriver SeleniumDriver { get; internal set; }
        public SD_SignInPage SD_SignInPage { get; set; }
        public SD_ProductsPage SD_ProductsPage { get; set; }
        public SD_ProductPage SD_ProductPage { get; set; }
        public SD_CartPage SD_CartPage { get; set; }
        public SD_CheckoutPage SD_CheckoutPage { get; set; }
        public SD_CheckoutTwoPage SD_CheckoutTwoPage { get; set; }

        public SD_Website(int pageLoadWaitInSecs = 5, int implicitWaitInSecs = 5)
        {
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadWaitInSecs, implicitWaitInSecs).Driver;
          
            SD_SignInPage = new SD_SignInPage(SeleniumDriver);
            SD_ProductsPage = new SD_ProductsPage(SeleniumDriver);
            SD_ProductPage = new SD_ProductPage(SeleniumDriver);
            SD_CartPage = new SD_CartPage(SeleniumDriver);
            SD_CheckoutPage = new SD_CheckoutPage(SeleniumDriver);
            SD_CheckoutTwoPage = new SD_CheckoutTwoPage(SeleniumDriver);
        }

        public void DeleteCookies()
        {
            SeleniumDriver.Manage().Cookies.DeleteAllCookies();
        }
    }
}