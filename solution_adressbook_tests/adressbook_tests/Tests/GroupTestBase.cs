using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    public class GroupTestBase : AuthorizationTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (LONG_UI_CHECKS)
            {
                app.GroupHelper.InitGroupsListAction();
                List<Group> groupsListUI = app.GroupHelper.GetGroupsList();
                List<Group> groupsListDB = Group.GetAll();
                groupsListDB.Sort();
                groupsListUI.Sort();

                Assert.AreEqual(groupsListUI, groupsListDB);
            }
        }
    }
}
