using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class ContactTestBase : AuthorizationTestBase
    {
        [TearDown]
        public void CompareContactsUI_DB()
        {
            if (LONG_UI_CHECKS)
            {
                applicationManager.ContactHelper.InitContactsListAction();
                List<Contact> contactsListUI = applicationManager.ContactHelper.GetContactsList();
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
                applicationManager.ContactHelper.InitBirthdaysListAction();              
                List<Contact> birthdaysListUI = applicationManager.ContactHelper.GetBirthdaysList();
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
