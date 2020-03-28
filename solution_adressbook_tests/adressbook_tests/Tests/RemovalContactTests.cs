using NUnit.Framework;

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

            applicationManager.ContactHelper.Remove(1);
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
        }
    }
}
