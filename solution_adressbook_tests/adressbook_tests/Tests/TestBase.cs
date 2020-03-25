using NUnit.Framework;

namespace WebAddressBookTests
{
    public class TestBase
    {
        protected ApplicationManager applicationManager;

        [SetUp]
        protected void SetupTest()
        {
            applicationManager = ApplicationManager.GetInstance();
            applicationManager.NavigationHelper.OpenURL();
        }
    }
}
