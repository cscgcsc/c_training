using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager applicationManager;

        public HelperBase(ApplicationManager applicationManager)
        {
            driver = applicationManager.Driver;
            this.applicationManager = applicationManager;
        }

        protected void WaitForElementPresent(By element)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(element)) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }

        protected bool IsElementPresent(By element)
        {
            try
            {
                driver.FindElement(element);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected string CloseAlertAndGetItsText(bool acceptNextAlert)
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        protected void Type(By element, string value)
        {
            if(value != null)
            {
                driver.FindElement(element).Clear();
                driver.FindElement(element).SendKeys(value);
            }
        }

        protected void Select(By element, string value)
        {
            if (value != null)
            {
                new SelectElement(driver.FindElement(element)).SelectByText(value);
            }
        }

        protected int GetMonthNumber(string monthName)
        {
            if (string.IsNullOrEmpty(monthName))
            {
                return 0;
            }
            string[] monthNames = new System.Globalization.CultureInfo("en-US").DateTimeFormat.MonthNames;

            return Array.IndexOf(monthNames, monthName) + 1;
        }
    }
}
