using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ModifyContactTests : ContactTestBase
    {        
        [Test]
        public void ModifyContactHome()
        {
            applicationManager.ContactHelper.InitContactsListAction();
            List<Contact> oldContactsList = Contact.GetAll();
            if (oldContactsList.Count == 0)
            {
                applicationManager.ContactHelper.Create(applicationManager.ContactHelper.GetDefaultContactData());
                oldContactsList = Contact.GetAll();
            }

            Contact contactData = new Contact("Petr", "Petrov")
            {
                Middlename = "Petrovich",
                Nickname = "Petrusha",
                Birthday = "2",
                Birthmonth = "January",
                Birthyear = "1985",
                Anniversaryday = "20",
                Anniversarymonth = "September",
                Anniversaryyear = "2010",
                Title = "Title name 2",
                Company = "Company name 2",
                Address = "Moscow, Tvardovskogo 987/6, office 543",
                Home = "84959876543",
                Mobile = "+7 (916) 987-65-43",
                Work = "99-88-77",
                Fax = "84950987654",
                Email = "test1@yandex.ru",
                Email2 = "test2@yandex.ru",
                Email3 = "test3@yandex.ru",
                Homepage = "https://www.test.ru/",
                Address2 = "Moscow, Karla Marksa 987-65",
                Phone2 = "+7 (902) 987-65-43",
                Notes = "Text1 text1 text1"
            };

            oldContactsList[0].Firstname = contactData.Firstname;
            oldContactsList[0].Lastname = contactData.Lastname;
            string modifiedId = oldContactsList[0].Id;

            applicationManager.ContactHelper.Modify(contactData, modifiedId);
            List<Contact> newContactsList = Contact.GetAll();
            oldContactsList.Sort();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList, newContactsList);

            Contact modifiedContact = Contact.GetContactById(modifiedId);
            Assert.AreEqual(contactData.Firstname, modifiedContact.Firstname);
            Assert.AreEqual(contactData.Lastname, modifiedContact.Lastname);
            Assert.AreEqual(contactData.Middlename, modifiedContact.Middlename);
            Assert.AreEqual(contactData.Nickname, modifiedContact.Nickname);
            Assert.AreEqual(contactData.Birthday, modifiedContact.Birthday);
            Assert.AreEqual(contactData.Birthmonth.ToLower(), modifiedContact.Birthmonth.ToLower());
            Assert.AreEqual(contactData.Birthyear, modifiedContact.Birthyear);
            Assert.AreEqual(contactData.Anniversaryday, modifiedContact.Anniversaryday);
            Assert.AreEqual(contactData.Anniversarymonth.ToLower(), modifiedContact.Anniversarymonth.ToLower());
            Assert.AreEqual(contactData.Anniversaryyear, modifiedContact.Anniversaryyear);
            Assert.AreEqual(contactData.Title, modifiedContact.Title);
            Assert.AreEqual(contactData.Company, modifiedContact.Company);
            Assert.AreEqual(contactData.Address, modifiedContact.Address);
            Assert.AreEqual(contactData.Home, modifiedContact.Home);
            Assert.AreEqual(contactData.Mobile, modifiedContact.Mobile);
            Assert.AreEqual(contactData.Work, modifiedContact.Work);
            Assert.AreEqual(contactData.Fax, modifiedContact.Fax);
            Assert.AreEqual(contactData.Email, modifiedContact.Email);
            Assert.AreEqual(contactData.Email2, modifiedContact.Email2);
            Assert.AreEqual(contactData.Email3, modifiedContact.Email3);
            Assert.AreEqual(contactData.Homepage, modifiedContact.Homepage);
            Assert.AreEqual(contactData.Address2, modifiedContact.Address2);
            Assert.AreEqual(contactData.Phone2, modifiedContact.Phone2);
            Assert.AreEqual(contactData.Notes, modifiedContact.Notes);
        }

        [Test]
        public void ModifyContactBirthday()
        {
            applicationManager.ContactHelper.InitBirthdaysListAction();
            List<Contact> oldBirthdaysList = Contact.GetBirthdays();
            if (oldBirthdaysList.Count == 0)
            {
                applicationManager.ContactHelper.Create(applicationManager.ContactHelper.GetDefaultContactData());
                oldBirthdaysList = Contact.GetBirthdays();
            }

            Contact contactData = new Contact("Maksim", "Maksimov")
            {
                Middlename = "Maksimovich",
                Birthday = "1",
                Birthmonth = "January",
                Birthyear = "1900"
            };

            oldBirthdaysList[0].Firstname = contactData.Firstname;
            oldBirthdaysList[0].Lastname = contactData.Lastname;
            string modifiedId = oldBirthdaysList[0].Id;

            applicationManager.ContactHelper.Modify(contactData, modifiedId);
            List<Contact> newBirthdaysList = Contact.GetBirthdays();
            oldBirthdaysList.Sort();
            newBirthdaysList.Sort();

            Assert.AreEqual(oldBirthdaysList, newBirthdaysList);

            Contact modifiedContact = Contact.GetContactById(modifiedId);
            Assert.AreEqual(contactData.Firstname, modifiedContact.Firstname);
            Assert.AreEqual(contactData.Lastname, modifiedContact.Lastname);
            Assert.AreEqual(contactData.Middlename, modifiedContact.Middlename);
            Assert.AreEqual(contactData.Birthday, modifiedContact.Birthday);
            Assert.AreEqual(contactData.Birthmonth.ToLower(), modifiedContact.Birthmonth.ToLower());
            Assert.AreEqual(contactData.Birthyear, modifiedContact.Birthyear);
        }

        //[Test]
        public void OldModifyContactHome()
        {
            applicationManager.ContactHelper.InitContactsListAction();
            if (applicationManager.ContactHelper.IsContactsListEmpty())
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
                if (newContact.Id == oldContactsList[0].Id)
                {
                    Assert.AreEqual(oldContactsList[0].Firstname, newContact.Firstname);
                    Assert.AreEqual(oldContactsList[0].Lastname, newContact.Lastname);
                }
            }
        }

        //[Test]
        public void OldModifyContactBirthday()
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
            oldBirthdaysList[0].Initial = contactData.GenerateInitial();

            applicationManager.ContactHelper.Modify(contactData, 0);
            List<Contact> newBirthdaysList = applicationManager.ContactHelper.GetBirthdaysList();
            oldBirthdaysList.Sort();
            newBirthdaysList.Sort();

            Assert.AreEqual(oldBirthdaysList, newBirthdaysList);

            foreach (Contact newContact in newBirthdaysList)
            {
                if (newContact.Id == oldBirthdaysList[0].Id)
                {
                    Assert.AreEqual(oldBirthdaysList[0].Firstname, newContact.Firstname);
                    Assert.AreEqual(oldBirthdaysList[0].Initial, newContact.Initial);
                }
            }
        }
    }
}
