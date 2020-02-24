using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class NavigationHelper : HelperBase
    {

        public NavigationHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public void OpenURL()
        {
            driver.Navigate().GoToUrl(applicationManager.baseURL + "/addressbook/index.php");
        }

        public void GoToHomePage()
        {
            By Element = By.LinkText("home");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        public void ReturnToHomePage()
        {
            By Element = By.LinkText("home page");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        public void GoToGroupPage()
        {
            By Element = By.LinkText("groups");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        public void ReturnToGroupPage()
        {
            By Element = By.LinkText("group page");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        public void GoToBirthdayPage()
        {
            By Element = By.LinkText("next birthdays");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        public void GoToNewGroupPage()
        {
            By Element = By.LinkText("add new");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }
    }
}
