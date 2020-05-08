using NUnit.Framework;
using System.Collections.Generic;

namespace AddressBookAutoItTests
{
    [TestFixture]
    public class RemovalGroupTests : TestBase
    {
        [Test]
        public void RemoveGroup()
        {
            applicationManager.GroupHelper.InitGroupsAction();
                                           
            if (applicationManager.GroupHelper.IsGroupSingle())
            {
                applicationManager.GroupHelper.Create(new Group() { Groupname = "Test groupname" });
            }  
            
            List<Group> oldGroupsList = applicationManager.GroupHelper.GetGroupsList(); 
            applicationManager.GroupHelper.RemoveTreeNodes(oldGroupsList, "#0|#1");
            applicationManager.GroupHelper.Remove("#0|#1");         
            List<Group> newGroupsList = applicationManager.GroupHelper.GetGroupsList();            
            Assert.AreEqual(oldGroupsList, newGroupsList);

            applicationManager.GroupHelper.CompleteGroupsAction();
        }
    }
}
