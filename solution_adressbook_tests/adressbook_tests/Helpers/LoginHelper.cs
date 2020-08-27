using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public void Login(User userData)
        {
            if(IsLoggedIn())
            {
                if (IsLoggedIn(userData))
                    return;
                
                Logout();               
            }

            Type(By.XPath("//input[@name='user']"), userData.Login);
            Type(By.XPath("//input[@name='pass']"), userData.Password);
            IWebElement element = driver.FindElement(By.XPath("//form[@id='LoginForm']//input[@type='submit']"));
            element.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(element));
        }

        public void Logout()
        {                
            if (IsElementPresent(By.XPath("//a[contains(text(),'Logout')]"), out IWebElement element))
                element.Click();

        }

        public bool IsLoggedIn(User userData)
        {
            return IsElementPresent(By.XPath("//form[@name='logout']"))
                && IsElementPresent(By.XPath("//form[@name='logout']/b[contains(text(),'(" + userData.Login + ")')]"));           
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.XPath("//form[@name='logout']"));       
        }
    }
}
