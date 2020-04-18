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
                    Assert.AreEqual(oldContactsList[0].Firstname, newContact.Firstname);
                    Assert.AreEqual(oldContactsList[0].Lastname, newContact.Lastname);
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
            StartCalculationRunTime();
            List<Contact> oldBirthdaysList = applicationManager.ContactHelper.GetBirthdaysList();
            StopCalculationRunTime();
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
                    Assert.AreEqual(oldBirthdaysList[0].Firstname, newContact.Firstname);
                    Assert.AreEqual(oldBirthdaysList[0].Lastname, newContact.Lastname);
                }
            }        
        }     
    }
}
