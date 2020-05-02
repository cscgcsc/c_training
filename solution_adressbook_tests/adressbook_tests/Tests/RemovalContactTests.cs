using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    class RemovalContactTests : ContactTestBase
    {
        [Test]
        public void RemoveContact()
        {
            applicationManager.ContactHelper.InitContactsListAction();
            List<Contact> oldContactsList = Contact.GetAll();
            if (oldContactsList.Count == 0)
            {
                applicationManager.ContactHelper.Create(new Contact("Ivanov", "Ivan"));
                oldContactsList = Contact.GetAll();
            }

            string deletedId = oldContactsList[0].Id;
            oldContactsList.RemoveAt(0);
           
            applicationManager.ContactHelper.Remove(deletedId);
            List<Contact> newContactsList = Contact.GetAll();
            oldContactsList.Sort();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList, newContactsList);
            Assert.IsTrue(Contact.GetContactById(deletedId) == null);
        }

        [Test]
        public void RemoveAllContacts()
        {
            applicationManager.ContactHelper.InitContactsListAction();
            if (Contact.GetAll().Count == 0)
            {
                applicationManager.ContactHelper.Create(new Contact("Ivanov", "Ivan"));
            }

            applicationManager.ContactHelper.Remove();
            Assert.IsTrue(Contact.GetAll().Count == 0);
        }

        //[Test]
        public void OldRemoveContact()
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

            foreach (Contact contact in newContactsList)
            {
                Assert.AreNotEqual(contact.Id, deletedId);
            }
        }

        //[Test]
        public void OldRemoveAllContacts()
        {
            applicationManager.ContactHelper.InitContactsListAction();
            if (applicationManager.ContactHelper.IsContactsListEmpty())
            {
                applicationManager.ContactHelper.Create(new Contact("Ivanov", "Ivan"));
            }

            applicationManager.ContactHelper.Remove();
            Assert.IsTrue(applicationManager.ContactHelper.IsContactsListEmpty());
        }
    }
}
