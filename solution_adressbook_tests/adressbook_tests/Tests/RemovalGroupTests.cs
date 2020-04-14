using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class RemovalGroupTests : AuthorizationTestBase
    {
        [Test]
        public void RemoveGroup()
        {
            applicationManager.GroupHelper.InitGroupsListAction();
            if (applicationManager.GroupHelper.IsGroupsListEmpty())
            {
                applicationManager.GroupHelper.Create(new Group("Test groupname"));
            }

            List<Group> oldGroupsList = applicationManager.GroupHelper.GetGroupsList();
            string deletedId = oldGroupsList[0].Id;
            oldGroupsList.RemoveAt(0);
            oldGroupsList.Sort();

            applicationManager.GroupHelper.Remove(0);
            List<Group> newGroupsList = applicationManager.GroupHelper.GetGroupsList();
            newGroupsList.Sort();

            Assert.AreEqual(oldGroupsList, newGroupsList);

            foreach (Group group in newGroupsList)
            {
                Assert.AreNotEqual(deletedId, group.Id);
            }
        }
    }
}
