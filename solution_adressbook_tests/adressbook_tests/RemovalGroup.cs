using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class RemovalGroup : TestBase
    {
        [Test]
        public void TheDelGroupTest()
        {
            OpenURL();
            Login(new User("admin", "secret"));
            InitGroupAction();
            SelectGroup(1);
            RemoveGroup();
            GoToGroupPage();
            Logout();
        }
    }
}
