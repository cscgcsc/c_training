using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    public class ContactTestBase : AuthorizationTestBase
    {
        [TearDown]
        public void CompareContactsUI_DB()
        {
            if (LONG_UI_CHECKS)
            {
                app.ContactHelper.InitContactsListAction();
                List<Contact> contactsListUI = app.ContactHelper.GetContactsList();
                List<Contact> contactsListDB = Contact.GetAll();
                contactsListDB.Sort();
                contactsListUI.Sort();

                Assert.AreEqual(contactsListUI, contactsListDB);
            }
        }

        [TearDown]
        public void CompareBirthdaysUI_DB()
        {
            if (LONG_UI_CHECKS)
            {
                app.ContactHelper.InitBirthdaysListAction();              
                List<Contact> birthdaysListUI = app.ContactHelper.GetBirthdaysList();
                List<Contact> birthdaysListDB = Contact.GetBirthdays();

                foreach (Contact birthday in birthdaysListDB)
                {
                    birthday.Initial = birthday.GenerateInitial();
                    birthday.Lastname = "";
                }
                birthdaysListDB.Sort();
                birthdaysListUI.Sort();

                Assert.AreEqual(birthdaysListUI, birthdaysListDB);   
            }
        }
    }
}
