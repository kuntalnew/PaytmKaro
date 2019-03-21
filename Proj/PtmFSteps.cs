using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Proj
{
    [Binding]
    public class PtmFSteps
    {
        private static IWebDriver driver = new ChromeDriver();

        IList<string> listOfServices = new List<string>();
        IList<string> newListOfServices = new List<string>();
        string amount = "199";


        [Given]
        public void Given_I_am_on_the_home_page_of_Paytm()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://paytm.com/");
        }

        [Given]
        public void Given_I_select_the_option_Mobile()
        {
            driver.FindElement(By.XPath("//img[@alt='Mobile ']")).Click();
        }

        [Given]
        public void Given_I_enter_valid_prepaid_mobile_number_and_amount()
        {
            driver.FindElement(By.XPath("//input[@type='tel']")).SendKeys("9003184354");
            //driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("199");
            driver.FindElement(By.XPath("//*[@id='app']/div/div[4]/div[1]/div[1]/div/div[2]/div[2]/ul/li[4]/div[1]/div/input")).SendKeys(amount.ToString());
        }

        [When]
        public void When_if_I_click_on_the_button_Proceed_to_recharge()
        {
            driver.FindElement(By.XPath("//button[text()='Proceed to Recharge']")).Click();
        }

        [Then]
        public void Then_the_number_of_services_can_be_verified()
        {
            listOfServices.Add("Mobile");
            listOfServices.Add("Electricity");
            listOfServices.Add("Gold");
            listOfServices.Add("Fees");
            listOfServices.Add("Landline");
            listOfServices.Add("Broadband");
            listOfServices.Add("DTH");
            listOfServices.Add("CableTv");
            listOfServices.Add("Metro");
            listOfServices.Add("Forex");
            listOfServices.Add("Donation");

            IList<IWebElement> paytmServices = driver.FindElements(By.XPath("//div[@id='app']/div/div[3]/div/div[1]/div/a"));
            Console.WriteLine("size of paytmservices= {0}", paytmServices.Count);
            foreach (IWebElement service in paytmServices)
            {

                for (int i = 0; i < listOfServices.Count; i++)
                {
                    if (service.Text.Equals(listOfServices[i]))
                    {
                        Console.WriteLine(service.Text);
                        Console.WriteLine(listOfServices[i]);
                        newListOfServices.Add(service.Text);
                        break;
                    }

                }
            }
            Assert.AreEqual(listOfServices.Count, newListOfServices.Count);

        }

        [Then]
        public void Then_the_url_should_be_https_paytm_com_recharge()
        {
            Assert.AreEqual("https://paytm.com/recharge", driver.Url);
        }

        [Then]
        public void Then_the_button_Proceed_to_Pay_the_amount_is_displayed_and_the_url_is_displayed_as_https_paytm_com_coupons()
        {
            string buttonText = driver.FindElement(By.XPath("//button[contains(text(), 'Proceed to pay')]")).Text;
            Assert.AreEqual("Proceed to pay Rs. " + amount.ToString(), driver.FindElement(By.XPath("//button[contains(text(), 'Proceed to pay')]")).Text.Trim('0').Trim('.'));
            Assert.AreEqual("https://paytm.com/recharge", driver.Url);
            driver.Dispose();
        }

    }
}