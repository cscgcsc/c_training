using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBookAutoItTests
{
    [TestFixture]
    public class CreationGroupTests : TestBase
    {
        [Test]
        public void CreateGroup()
        {
            applicationManager.GroupHelper.InitGroupsAction();
            
            List<Group> oldGroupsList = applicationManager.GroupHelper.GetGroupsList();          
            Group group = new Group()
            {
                Groupname = "Qwerty"
            };
            
            applicationManager.GroupHelper.Create(group);
            List<Group> newGroupsList = applicationManager.GroupHelper.GetGroupsList();
            oldGroupsList.Add(group);
            oldGroupsList.Sort();
            newGroupsList.Sort();
            Assert.AreEqual(oldGroupsList, newGroupsList);
            
            applicationManager.GroupHelper.CompleteGroupsAction();
        }
    }
}
