using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(IWebDriver driver) : base(driver)
        {
        }
        public void Login(User userData)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(userData.Login);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(userData.Password);
            driver.FindElement(By.Id("LoginForm")).Submit();
        }
        public void Logout()
        {
            By Element = By.XPath("//a[contains(text(),'Logout')]");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }
    }
}
