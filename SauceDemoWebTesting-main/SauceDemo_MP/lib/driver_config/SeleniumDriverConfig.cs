using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM.lib.driver_config
{
    public class SeleniumDriverConfig<T> where T : IWebDriver, new()
    {
        public T Driver { get; set; }

        public SeleniumDriverConfig(int pageLoadInSecs, int implicitWaitInSecs)
        {
            DriverSetUp(pageLoadInSecs, implicitWaitInSecs);
        }

        public void DriverSetUp(int pageLoadInSecs, int implicitWaitInSecs)
        {
            SetDriver();
            SetDriverConfiguration(pageLoadInSecs, implicitWaitInSecs);
        }

        public void SetDriver()
        {
            Driver = new T();
        }

        public void SetDriverConfiguration(int pageLoadInSecs, int implicitWaitInSecs)
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSecs);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSecs);
        }

    }
}
