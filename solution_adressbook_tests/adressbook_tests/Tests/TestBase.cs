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
        }

        [TearDown]
        private void TeardownTest()
        {
            applicationManager.StopDriver();
        }
    }
}
