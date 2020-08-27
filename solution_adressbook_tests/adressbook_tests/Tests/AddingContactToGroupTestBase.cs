using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    public class AddingContactToGroupTestBase : AuthorizationTestBase
    {
        [TearDown]
        public void CompareGroupsFilterUI_DB()
        {
            if (LONG_UI_CHECKS)
            {
                app.ContactHelper.InitContactsListAction();

                //none
                List<Contact> contactsListDB = Group.GetContactsNotInGroups();
                app.ContactHelper.SelectGroupFilter("[none]");
                List<Contact> contactsListUI = app.ContactHelper.GetContactsList();
                contactsListDB.Sort();
                contactsListUI.Sort();
                Assert.AreEqual(contactsListUI, contactsListDB);

                List<Group> groupsListDB = Group.GetAll();
                foreach (Group group in groupsListDB)
                {
                    contactsListDB = Group.GetContactsInGroup(group.Id);
                    app.ContactHelper.SelectGroupFilter(group.Id);
                    contactsListUI = app.ContactHelper.GetContactsList();
                    contactsListDB.Sort();
                    contactsListUI.Sort();

                    Assert.AreEqual(contactsListUI, contactsListDB);
                }
            }
        }
    }
}
