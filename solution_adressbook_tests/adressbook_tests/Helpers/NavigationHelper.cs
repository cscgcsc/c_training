using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(IWebDriver driver, string baseURL) : base(driver)
        {
            this.baseURL = baseURL;
        }
        public void OpenURL()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/index.php");
        }
        public void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void GoToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
    }
}
