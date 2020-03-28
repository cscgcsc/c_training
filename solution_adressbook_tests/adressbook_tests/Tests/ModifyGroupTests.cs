using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ModifyGroupTests : AuthorizationTestBase
    {
        [Test]
        public void ModifyGroup()
        {
            applicationManager.NavigationHelper.GoToGroupPage();
            if (applicationManager.GroupHelper.IsGroupsListEmpty())
            {
                applicationManager.GroupHelper.Create(new Group("Test groupname"));
            }

            Group groupData = new Group("New groupname")
            {
                Groupheader = "New groupheader",
                Groupfooter = "New groupfooter"
            };
            applicationManager.GroupHelper.Modify(groupData, 1);
        }
    }
}
