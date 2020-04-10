using NUnit.Framework;
using System.Collections.Generic;

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

            List<Group> oldGroupsList = applicationManager.GroupHelper.GetGroupsList();
            oldGroupsList[0].Groupname = groupData.Groupname;
            oldGroupsList.Sort();

            applicationManager.GroupHelper.Modify(groupData, 0);
            List<Group> newGroupsList = applicationManager.GroupHelper.GetGroupsList();
            newGroupsList.Sort();

            Assert.AreEqual(oldGroupsList, newGroupsList);           
        }
    }
}
