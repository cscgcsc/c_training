using NUnit.Framework;

namespace WebAddressBookTests
{
    public class AuthorizationTestBase : TestBase
    {
        [SetUp]
        protected void SetupAuthorizationTest()
        {
            applicationManager.LoginHelper.Login(new User("admin", "secret"));
        }
    }
}
