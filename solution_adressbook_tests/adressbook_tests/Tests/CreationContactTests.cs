using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class CreationContactTests : AuthorizationTestBase
    {
        [Test]
        public void CreateContact()
        {
            Contact contactData = new Contact("Ivan", "Ivanov")
            {
                Middlename = "Ivanovich",
                Birthday = "30",
                Birthmonth = "July",
                Birthyear = "1990"
            };

            List<Contact> oldContactsList = applicationManager.ContactHelper.GetContactsList();
            oldContactsList.Add(contactData);
            oldContactsList.Sort();

            applicationManager.ContactHelper.Create(contactData);
            List<Contact> newContactsList = applicationManager.ContactHelper.GetContactsList();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList, newContactsList);           
        }
    }
}
