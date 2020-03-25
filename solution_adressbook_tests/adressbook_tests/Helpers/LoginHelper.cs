using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;

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
                {
                    return;
                }                 
                Logout();               
            }

            Type(By.Name("user"), userData.Login);
            Type(By.Name("pass"), userData.Password);
            driver.FindElement(By.Id("LoginForm")).Submit();

            Thread.Sleep(1000);
        }

        public void Logout()
        {       
            By Element = By.XPath("//a[contains(text(),'Logout')]");           
            if (IsElementPresent(Element))
            {
                driver.FindElement(Element).Click();
            }
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
