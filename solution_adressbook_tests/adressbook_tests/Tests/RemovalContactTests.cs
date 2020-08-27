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
            app.ContactHelper.InitContactsListAction();
            List<Contact> oldContactsList = Contact.GetAll();
            if (oldContactsList.Count == 0)
            {
                app.ContactHelper.Create(new Contact("Ivanov", "Ivan"));
                oldContactsList = Contact.GetAll();
            }

            string deletedId = oldContactsList[0].Id;
            oldContactsList.RemoveAt(0);
           
            app.ContactHelper.Remove(deletedId);
            List<Contact> newContactsList = Contact.GetAll();
            oldContactsList.Sort();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList, newContactsList);
            Assert.IsTrue(Contact.GetContactById(deletedId) == null);
        }

        [Test]
        public void RemoveAllContacts()
        {
            app.ContactHelper.InitContactsListAction();
            if (Contact.GetAll().Count == 0)
                app.ContactHelper.Create(new Contact("Ivanov", "Ivan"));

            app.ContactHelper.Remove();
            Assert.IsTrue(Contact.GetAll().Count == 0);
        }

        //[Test]
        public void OldRemoveContact()
        {
            app.ContactHelper.InitContactsListAction();
            if (app.ContactHelper.IsContactsListEmpty())
                app.ContactHelper.Create(new Contact("Ivanov", "Ivan"));

            List<Contact> oldContactsList = app.ContactHelper.GetContactsList();
            string deletedId = oldContactsList[0].Id;
            oldContactsList.RemoveAt(0);
            oldContactsList.Sort();

            app.ContactHelper.Remove(0);
            List<Contact> newContactsList = app.ContactHelper.GetContactsList();
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
            app.ContactHelper.InitContactsListAction();
            if (app.ContactHelper.IsContactsListEmpty())
                app.ContactHelper.Create(new Contact("Ivanov", "Ivan"));

            app.ContactHelper.Remove();
            Assert.IsTrue(app.ContactHelper.IsContactsListEmpty());
        }
    }
}
