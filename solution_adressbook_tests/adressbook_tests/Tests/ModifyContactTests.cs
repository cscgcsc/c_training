using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ModifyContactTests : AuthorizationTestBase
    {
        [Test]
        public void ModifyContactFromHomePage()
        {
            applicationManager.ContactHelper.InitContactsListAction();
            if (applicationManager.ContactHelper.IsContactsListEmpty())
            {
                applicationManager.ContactHelper.Create(applicationManager.ContactHelper.GetDefaultContactData());
            }

            Contact contactData = new Contact("Petr", "Petrov")
            {
                Middlename = "Petrovich",
                Birthday = "25",
                Birthmonth = "May",
                Birthyear = "1985"
            };

            List<Contact> oldContactsList = applicationManager.ContactHelper.GetContactsList();
            oldContactsList[0].Firstname = contactData.Firstname;
            oldContactsList[0].Lastname = contactData.Lastname;
            oldContactsList.Sort();

            applicationManager.ContactHelper.Modify(contactData, 0);
            List<Contact> newContactsList = applicationManager.ContactHelper.GetContactsList();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList, newContactsList);

            foreach (Contact newContact in newContactsList)
            {
                if(newContact.Id == oldContactsList[0].Id)
                {
                    Assert.AreEqual(newContact.Firstname, oldContactsList[0].Firstname);
                    Assert.AreEqual(newContact.Lastname, oldContactsList[0].Lastname);
                }                   
            }
        }

        [Test]
        public void ModifyContactFromBirthdayPage()
        {
            applicationManager.ContactHelper.InitBirthdaysListAction();
            if (applicationManager.ContactHelper.IsBirthdaysListEmpty())
            {
                applicationManager.ContactHelper.Create(applicationManager.ContactHelper.GetDefaultContactData());
            }

            Contact contactData = new Contact("Maksim", "Maksimov")
            {
                Middlename = "Maksimovich",
                Birthday = "1",
                Birthmonth = "January",
                Birthyear = "1900"                                   
            };

            List<Contact> oldBirthdaysList = applicationManager.ContactHelper.GetBirthdaysList();
            oldBirthdaysList[0].Firstname = contactData.Firstname;
            oldBirthdaysList[0].Lastname = contactData.Middlename + " " + contactData.Lastname;
            oldBirthdaysList.Sort();

            applicationManager.ContactHelper.Modify(contactData, 0);
            List<Contact> newBirthdaysList = applicationManager.ContactHelper.GetBirthdaysList();
            newBirthdaysList.Sort();
                             
            Assert.AreEqual(oldBirthdaysList, newBirthdaysList);

            foreach (Contact newContact in newBirthdaysList)
            {
                if (newContact.Id == oldBirthdaysList[0].Id)
                {
                    Assert.AreEqual(newContact.Firstname, oldBirthdaysList[0].Firstname);
                    Assert.AreEqual(newContact.Lastname, oldBirthdaysList[0].Lastname);
                }
            }        
        }
    }
}
