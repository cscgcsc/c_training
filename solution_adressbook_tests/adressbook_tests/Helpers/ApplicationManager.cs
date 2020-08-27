using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{   
    public class ApplicationManager
    {
        public string baseURL;
        private static ThreadLocal<ApplicationManager> instance = new ThreadLocal<ApplicationManager>();

        public LoginHelper LoginHelper { get; set; }
        public GroupHelper GroupHelper { get; set; }
        public NavigationHelper NavigationHelper { get; set; }
        public ContactHelper ContactHelper { get; set; }

        private ApplicationManager()
        {
            Driver = Firefox();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            baseURL = "http://localhost";
            
            LoginHelper = new LoginHelper(this);
            GroupHelper = new GroupHelper(this);
            NavigationHelper = new NavigationHelper(this);
            ContactHelper = new ContactHelper(this);
        }

        public static ApplicationManager GetInstance()
        {
            if (!instance.IsValueCreated)
            {
                instance.Value = new ApplicationManager();
            }                      
            return instance.Value;
        }

        ~ApplicationManager()
        {
            try
            {
                Driver.Quit();
                Driver = null;
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public IWebDriver Driver { get; set; }

        public WebDriverWait Wait { get; set; }

        private FirefoxDriver Firefox()
        {
            FirefoxOptions options = new FirefoxOptions();
            //options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            options.BrowserExecutableLocation = @"C:\Program Files\Firefox Nightly\firefox.exe";
            //options.LogLevel = FirefoxDriverLogLevel.Trace;  

            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("network.proxy.allow_hijacking_localhost", true);
            options.Profile = profile;

            return new FirefoxDriver(options);
        }

        private ChromeDriver Chrome()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            //options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
            //options.AddArgument("--enable-logging");
            //options.AddArgument(@"--log-net-log=D:\qq\3.json");

            //options.AddArgument(@"user-data-dir=D:\q\");
            //options.AddArgument(@"download.default_directory=D:\q\");

            //options.AddArgument("--window-size=500,500");
            //options.PageLoadStrategy = PageLoadStrategy.Normal;
            //options.BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            //options.Proxy = GetProxy();

            return new ChromeDriver(options);
        }

        private InternetExplorerDriver InternetExplorer()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            //InternetExplorerDriverService IEDriverService = InternetExplorerDriverService.CreateDefaultService();
            //IEDriverService.LoggingLevel = InternetExplorerDriverLogLevel.Trace;
            //IEDriverService.LogFile = @"D:\q\111.log";

            return new InternetExplorerDriver(options);
        }
    }
}
