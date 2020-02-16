using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class RemovalGroup : TestBase
    {
        [Test]
        public void TheDelGroupTest()
        {
            applicationManager.NavigationHelper.OpenURL();
            applicationManager.LoginHelper.Login(new User("admin", "secret"));
            applicationManager.GroupHelper.InitGroupAction();
            applicationManager.GroupHelper.SelectGroup(1);
            applicationManager.GroupHelper.RemoveGroup();
            applicationManager.NavigationHelper.GoToGroupPage();
            applicationManager.LoginHelper.Logout();
        }
    }
}
