using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class HelperBase
    {
        protected ApplicationManager app;
        protected IWebDriver driver;      
        protected WebDriverWait wait;

        public HelperBase(ApplicationManager app)
        {
            this.app = app;
            driver = app.Driver;
            wait = app.Wait;
        }

        protected bool IsElementPresent(By by)
        {
            return driver.FindElements(by).Count > 0;
        }

        protected bool IsElementPresent(By by, out IWebElement element)
        {
            ICollection<IWebElement> elements = driver.FindElements(by);
            if (elements.Count > 0)
            {
                element = elements.First();
                return true;
            }
            else
            {
                element = null;
                return false;
            }
        }

        protected bool IsElementPresentContext(By by, IWebElement context)
        {
            return context.FindElements(by).Count > 0;
        }

        protected bool IsElementPresentContext(By by, IWebElement context, out IWebElement element)
        {
            ICollection<IWebElement> elements = context.FindElements(by);
            if (elements.Count > 0)
            {
                element = elements.First();
                return true;
            }
            else
            {
                element = null;
                return false;
            }
        }

        protected bool IsDocumentReadyStateComplete()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string readyState = (string)js.ExecuteScript("return document.readyState");
            return readyState.Equals("complete");
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
            }
        }

        protected void Type(By by, string value)
        {
            if(value != null)
            {
                driver.FindElement(by).Clear();
                driver.FindElement(by).SendKeys(value);
            }
        }

        protected void Select(By by, string value)
        {
            if (value != null)
            {
                new SelectElement(driver.FindElement(by)).SelectByText(value);
            }
        }

        protected void Select(IWebElement element, string value)
        {
            if (value != null)
            {
                new SelectElement(element).SelectByText(value);
            }
        }

        protected void SelectByValue(By by, string value)
        {
            if (value != null)
            {
                new SelectElement(driver.FindElement(by)).SelectByValue(value);
            }
        }

        protected void SelectByValue(IWebElement element, string value)
        {
            if (value != null)
            {
                new SelectElement(element).SelectByValue(value);
            }
        }
    }
}
