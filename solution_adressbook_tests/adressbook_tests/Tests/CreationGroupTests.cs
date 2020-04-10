using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class CreationGroupTests : AuthorizationTestBase
    {

        [Test]
        public void CreateGroup()
        {
            applicationManager.NavigationHelper.GoToGroupPage();

            Group groupData = new Group("Test groupname")
            {
                Groupheader = "Test groupheader",
                Groupfooter = "Test groupfooter"
            };
            List<Group> oldGroupsList = applicationManager.GroupHelper.GetGroupsList();
            oldGroupsList.Add(groupData);
            oldGroupsList.Sort();

            applicationManager.GroupHelper.Create(groupData);            
            List<Group> newGroupsList = applicationManager.GroupHelper.GetGroupsList();
            newGroupsList.Sort();

            Assert.AreEqual(oldGroupsList, newGroupsList);
        }
    }
}
