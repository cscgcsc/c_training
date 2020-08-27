using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    class AuthorizationTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.LoginHelper.Logout();
            User user = new User("admin", "secret");
            app.LoginHelper.Login(user);
            Assert.IsTrue(app.LoginHelper.IsLoggedIn(user));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            app.LoginHelper.Logout();
            app.LoginHelper.Login(new User("admin1", "secret1"));
            Assert.IsFalse(app.LoginHelper.IsLoggedIn());
        }  
    }
}
