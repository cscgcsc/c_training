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
            applicationManager.NavigationHelper.GoToHomePage();
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

            applicationManager.ContactHelper.ModifyFromHomePage(contactData, 0);
            List<Contact> newContactsList = applicationManager.ContactHelper.GetContactsList();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList, newContactsList);
        }

        [Test]
        public void ModifyContactFromBirthdayPage()
        {
            applicationManager.NavigationHelper.GoToBirthdayPage();
            if (applicationManager.ContactHelper.IsBirthdaysListEmpty())
            {
                applicationManager.ContactHelper.Create(applicationManager.ContactHelper.GetDefaultContactData());
            }

            Contact contactData = new Contact("Maksimov", "Maksim")
            {
                Middlename = "Maksimovich",
                Birthday = "1",
                Birthmonth = "January",
                Birthyear = "1900"
            };
            applicationManager.ContactHelper.ModifyFromBirthdayPage(contactData, 0);
        }
    }
}
