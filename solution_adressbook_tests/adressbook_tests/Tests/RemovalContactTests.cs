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
            applicationManager.ContactHelper.InitContactsListAction();
            if (applicationManager.ContactHelper.IsContactsListEmpty())
            {
                applicationManager.ContactHelper.Create(new Contact("Ivanov", "Ivan"));
            }

            List<Contact> oldContactsList = applicationManager.ContactHelper.GetContactsList();
            string deletedId = oldContactsList[0].Id;
            oldContactsList.RemoveAt(0);
            oldContactsList.Sort();
 
            applicationManager.ContactHelper.Remove(0);
            List<Contact> newContactsList = applicationManager.ContactHelper.GetContactsList();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList, newContactsList); 
            
            foreach(Contact contact in newContactsList)
            {
                Assert.AreNotEqual(deletedId, contact.Id);
            }
        }

        [Test]
        public void RemoveAllContacts()
        {
            applicationManager.ContactHelper.InitContactsListAction();
            if (applicationManager.ContactHelper.IsContactsListEmpty())
            {
                applicationManager.ContactHelper.Create(new Contact("Ivanov", "Ivan"));
            }

            applicationManager.ContactHelper.Remove();
            Assert.IsTrue(applicationManager.ContactHelper.GetContactsList().Count == 0);
        }
    }
}
