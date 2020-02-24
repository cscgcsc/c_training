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
        public IWebDriver Driver { get; set; }
        public string baseURL;

        public ApplicationManager()
        {
            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("security.enterprise_roots.enabled", true);
            profile.SetPreference("network.proxy.allow_hijacking_localhost", true);
            FirefoxOptions options = new FirefoxOptions
            {
                Profile = profile
            };
            Driver = new FirefoxDriver(options);
            baseURL = "http://localhost";

            LoginHelper = new LoginHelper(this);
            GroupHelper = new GroupHelper(this);
            NavigationHelper = new NavigationHelper(this);
            ContactHelper = new ContactHelper(this);
        }

        public void StopDriver()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
