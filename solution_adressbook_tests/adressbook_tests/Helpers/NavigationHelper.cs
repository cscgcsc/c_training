using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class NavigationHelper : HelperBase
    {

        private string startURL;

        public NavigationHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public void OpenURL()
        {
            if(driver.Url == app.baseURL + "/addressbook/index.php")
                return;

            driver.Navigate().GoToUrl(app.baseURL + "/addressbook/index.php");
        }

        public void GoToHomePage()
        {
            if (driver.Url == app.baseURL + "/addressbook/index.php")
                return;

            driver.FindElement(By.XPath("//div[@id='nav']//a[contains(@href, './')]")).Click();
            WaitHomePageIsLoaded();
        }

        public void ReturnToHomePage()
        {
            driver.FindElement(By.XPath("//div[contains(@class, 'msgbox')]//a[contains(@href, 'index.php')]")).Click();
            WaitHomePageIsLoaded();
        }

        public void GoToGroupPage()
        {
            if (driver.Url == app.baseURL + "/addressbook/group.php")
                return;

            driver.FindElement(By.XPath("//div[@id='nav']//a[contains(@href, 'group.php')]")).Click();
            WaitGroupPageIsLoaded();
        }

        public void ReturnToGroupPage()
        {
            driver.FindElement(By.XPath("//div[contains(@class, 'msgbox')]//a[contains(@href, 'group.php')]")).Click();
            WaitGroupPageIsLoaded();
        }

        public void GoToBirthdayPage()
        {
            if (driver.Url == app.baseURL + "/addressbook/birthdays.php")
                return;

            driver.FindElement(By.XPath("//div[@id='nav']//a[contains(@href, 'birthdays.php')]")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//table[@id='birthdays']")));
        }

        public void GoToNewContactPage()
        {
            if (driver.Url == app.baseURL + "/addressbook/edit.php")
                return;

            driver.FindElement(By.XPath("//div[@id='nav']//a[contains(@href, 'edit.php')]")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//form[contains(@action, 'edit.php')]")));
        }

        public void ReturnToStartPage()
        {
            if(startURL == null)
                GoToHomePage();
            else
                driver.Navigate().GoToUrl(startURL);         
        }

        public void SetStartPage()
        {
            startURL = driver.Url;
        }

        private void WaitHomePageIsLoaded()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//table[@id='maintable']")));
        }

        private void WaitGroupPageIsLoaded()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//form[contains(@action, 'group.php')]")));
        }
    }
}
