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
            if(driver.Url == applicationManager.baseURL + "/addressbook/index.php")
            {
                return;
            }
            driver.Navigate().GoToUrl(applicationManager.baseURL + "/addressbook/index.php");
        }

        public void GoToHomePage()
        {
            if (driver.Url == applicationManager.baseURL + "/addressbook/index.php")
            {
                return;
            }
            By Element = By.LinkText("home");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        public void ReturnToHomePage()
        {
            if (driver.Url == applicationManager.baseURL + "/addressbook/index.php")
            {
                return;
            }
            By Element = By.LinkText("home page");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        public void GoToGroupPage()
        {
            if (driver.Url == applicationManager.baseURL + "/addressbook/group.php")
            {
                return;
            }
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
            if (driver.Url == applicationManager.baseURL + "/addressbook/birthdays.php")
            {
                return;
            }
            By Element = By.LinkText("next birthdays");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        public void GoToNewContactPage()
        {
            if (driver.Url == applicationManager.baseURL + "/addressbook/edit.php")
            {
                return;
            }
            By Element = By.LinkText("add new");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }
    }
}
