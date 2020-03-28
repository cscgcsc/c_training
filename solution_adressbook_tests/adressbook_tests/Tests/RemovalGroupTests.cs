using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class RemovalGroupTests : AuthorizationTestBase
    {
        [Test]
        public void RemoveGroup()
        {
            applicationManager.NavigationHelper.GoToGroupPage();
            if (applicationManager.GroupHelper.IsGroupsListEmpty())
            {
                applicationManager.GroupHelper.Create(new Group("Test groupname"));
            }

            applicationManager.GroupHelper.Remove(1);
        }
    }
}
