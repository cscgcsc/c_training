using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class RemovalGroupTests : GroupTestBase
    {       
        [Test]
        public void RemoveGroup()
        {
            app.GroupHelper.InitGroupsListAction();
            List<Group> oldGroupsList = Group.GetAll();
            if (oldGroupsList.Count == 0)
            {
                app.GroupHelper.Create(new Group("Test groupname"));
                oldGroupsList = Group.GetAll();
            }
          
            string deletedId = oldGroupsList[0].Id;
            oldGroupsList.RemoveAt(0);
            
            app.GroupHelper.Remove(deletedId);           
            List<Group> newGroupsList = Group.GetAll();
            oldGroupsList.Sort();
            newGroupsList.Sort();

            Assert.AreEqual(oldGroupsList, newGroupsList);
            Assert.IsTrue(Group.GetGroupById(deletedId) == null);
        }

        //[Test]
        public void OldRemoveGroup()
        {
            app.GroupHelper.InitGroupsListAction();
            if (app.GroupHelper.IsGroupsListEmpty())
                app.GroupHelper.Create(new Group("Test groupname"));

            List<Group> oldGroupsList = app.GroupHelper.GetGroupsList();
            string deletedId = oldGroupsList[0].Id;
            oldGroupsList.RemoveAt(0);
            oldGroupsList.Sort();

            app.GroupHelper.Remove(0);
            List<Group> newGroupsList = app.GroupHelper.GetGroupsList();
            newGroupsList.Sort();

            Assert.AreEqual(oldGroupsList, newGroupsList);

            foreach (Group group in newGroupsList)
            {
                Assert.AreNotEqual(group.Id, deletedId);
            }
        }
    }
}
