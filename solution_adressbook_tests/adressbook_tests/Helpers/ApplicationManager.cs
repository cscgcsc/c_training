using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{   
    public class ApplicationManager
    {
        public LoginHelper LoginHelper { get; set; }
        public GroupHelper GroupHelper { get; set; }
        public NavigationHelper NavigationHelper { get; set; }
        public ContactHelper ContactHelper { get; set; }
        private IWebDriver driver;
        private string baseURL;

        public ApplicationManager()
        {
            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("security.enterprise_roots.enabled", true);
            profile.SetPreference("network.proxy.allow_hijacking_localhost", true);
            FirefoxOptions options = new FirefoxOptions
            {
                Profile = profile
            };
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost";

            LoginHelper = new LoginHelper(driver);
            GroupHelper = new GroupHelper(driver);
            NavigationHelper = new NavigationHelper(driver, baseURL);
            ContactHelper = new ContactHelper(driver);
        }

        public void StopDriver()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
