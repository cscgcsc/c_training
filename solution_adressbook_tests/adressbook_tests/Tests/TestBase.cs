using NUnit.Framework;

namespace WebAddressBookTests
{
    public class TestBase
    {
        protected ApplicationManager applicationManager;

        [SetUp]
        protected void SetupTest()
        {
            applicationManager = new ApplicationManager();
            applicationManager.NavigationHelper.OpenURL();
            applicationManager.LoginHelper.Login(new User("admin", "secret"));
        }

        [TearDown]
        protected void TeardownTest()
        {
            applicationManager.LoginHelper.Logout();
            applicationManager.StopDriver();
        }
    }
}
