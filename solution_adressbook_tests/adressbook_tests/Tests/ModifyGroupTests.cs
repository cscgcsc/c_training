using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ModifyGroupTests : GroupTestBase
    {
        [Test]
        public void ModifyGroup()
        {
            applicationManager.GroupHelper.InitGroupsListAction();
            List<Group> oldGroupsList = Group.GetAll();
            if (oldGroupsList.Count == 0)
            { 
                applicationManager.GroupHelper.Create(new Group("Test groupname"));
                oldGroupsList = Group.GetAll();
            }

            Group groupData = new Group("New groupname")
            {
                Groupheader = "New groupheader",
                Groupfooter = "New groupfooter"
            };
           
            oldGroupsList[0].Groupname = groupData.Groupname;
            string modifiedId = oldGroupsList[0].Id;

            applicationManager.GroupHelper.Modify(groupData, modifiedId);
            List<Group> newGroupsList = Group.GetAll();
            oldGroupsList.Sort();
            newGroupsList.Sort();

            Assert.AreEqual(oldGroupsList, newGroupsList);
            
            Group modifiedGroup = Group.GetGroupById(modifiedId);
            Assert.AreEqual(groupData.Groupname, modifiedGroup.Groupname);
            Assert.AreEqual(groupData.Groupheader, modifiedGroup.Groupheader);
            Assert.AreEqual(groupData.Groupfooter, modifiedGroup.Groupfooter);
        }

        //[Test]
        public void OldModifyGroup()
        {
            applicationManager.GroupHelper.InitGroupsListAction();
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

            foreach (Group newGroup in newGroupsList)
            {
                if (newGroup.Id == oldGroupsList[0].Id)
                {
                    Assert.AreEqual(oldGroupsList[0].Groupname, newGroup.Groupname);
                }
            }
        }
    }
}
