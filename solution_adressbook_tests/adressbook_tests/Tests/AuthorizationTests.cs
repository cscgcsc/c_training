using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    class AuthorizationTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            applicationManager.LoginHelper.Logout();
            User user = new User("admin", "secret");
            applicationManager.LoginHelper.Login(user);
            Assert.IsTrue(applicationManager.LoginHelper.IsLoggedIn(user));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            applicationManager.LoginHelper.Logout();
            applicationManager.LoginHelper.Login(new User("admin1", "secret1"));
            Assert.IsFalse(applicationManager.LoginHelper.IsLoggedIn());
        }  
    }
}
