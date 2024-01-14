using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SauceDemo_MP.lib.steps
{
    [Binding]
    public class SD_CheckoutSteps
    {
        private SD_Website<ChromeDriver> SD_Website = new SD_Website<ChromeDriver>();

        [Given(@"I am on the checkout page")]
        public void GivenIAmOnTheCheckoutPage()
        {
            SD_Website.SD_CheckoutPage.OnTheCheckoutPage();
        }


        [When(@"I enter a (.*) and (.*)")]
        [When(@"I enter a ""(.*)"" and ""(.*)""")]
        public void WhenIEnterAAnd(string firstinput, string secondinput)
        {
            if (firstinput == "firstname")
            { SD_Website.SD_CheckoutPage.EnterFirstName(firstinput); }
            if (firstinput == "lastname")
            { SD_Website.SD_CheckoutPage.EnterLastName(firstinput); }
            if (secondinput == "lastname")
                { SD_Website.SD_CheckoutPage.EnterLastName(secondinput); }
            if (secondinput == "postcode")
            { SD_Website.SD_CheckoutPage.EnterPostCode(secondinput); }
        }


        [When(@"I press ""(.*)""")]
        public void WhenIPress(string button)
        {
            SD_Website.SD_CheckoutPage.PressButton(button);
        }

        [Then(@"I land on the Cart Page")]
        public void ThenILandOnTheCartPage()
        {
            Assert.That(SD_Website.SD_CheckoutPage.Subheader().Contains("Your Cart"));
        }

        [When(@"I fill in the firstname, secondname, postcode")]
        public void IFillInTheFirstnameSecondnamePostcode()
        {
            SD_Website.SD_CheckoutPage.EnterFirstName("Sam");
            SD_Website.SD_CheckoutPage.EnterLastName("Test");
            SD_Website.SD_CheckoutPage.EnterPostCode("12345");
        }


        [Then(@"I land on the Second Checkout Page")]
        public void ThenILandOnTheSecondCheckoutPage()
        {
            Assert.That(SD_Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-step-two.html"));
        }

        [Then(@"I should receive the error containing (.*)")]
        [Then(@"I should receive the error containing ""(.*)""")]
        public void ThenIShouldReceiveTheErrorContaining(string error)
        {
            Assert.That(SD_Website.SD_CheckoutPage.RetrieveErrorMessage(), Does.Contain(error));
        }


        [AfterScenario]
        public void TearDown()
        {
            SD_Website.SeleniumDriver.Dispose();
            SD_Website.SeleniumDriver.Quit();
        }
    }
}
