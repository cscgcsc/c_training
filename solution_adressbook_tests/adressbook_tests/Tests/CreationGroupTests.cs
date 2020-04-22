using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class CreationGroupTests : AuthorizationTestBase
    {
        public static List<Group> RandomGroupDataProvider()
        {
            List<Group> groupDataList = new List<Group>();

            for(int i = 0; i<5; i++)
            {
                groupDataList.Add(new Group(GenerateRandomString(10))
                    {
                        Groupheader = GenerateRandomString(10),
                        Groupfooter = GenerateRandomString(10)
                    });
            }

            return groupDataList;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void CreateGroup(Group groupData)
        {
            applicationManager.GroupHelper.InitGroupsListAction();

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
