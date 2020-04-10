using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    class RemovalContactTests : AuthorizationTestBase
    {
        [Test]
        public void RemoveContact()
        {
            applicationManager.NavigationHelper.GoToHomePage();
            if (applicationManager.ContactHelper.IsContactsListEmpty())
            {
                applicationManager.ContactHelper.Create(new Contact("Ivanov", "Ivan"));
            }

            List<Contact> oldContactsList = applicationManager.ContactHelper.GetContactsList();
            oldContactsList.RemoveAt(0);
            oldContactsList.Sort();
 
            applicationManager.ContactHelper.Remove(0);
            List<Contact> newContactsList = applicationManager.ContactHelper.GetContactsList();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList, newContactsList);  
        }

        [Test]
        public void RemoveAllContacts()
        {
            applicationManager.NavigationHelper.GoToHomePage();
            if (applicationManager.ContactHelper.IsContactsListEmpty())
            {
                applicationManager.ContactHelper.Create(new Contact("Ivanov", "Ivan"));
            }

            applicationManager.ContactHelper.Remove();
            Assert.IsTrue(applicationManager.ContactHelper.GetContactsList().Count == 0);
        }
    }
}
