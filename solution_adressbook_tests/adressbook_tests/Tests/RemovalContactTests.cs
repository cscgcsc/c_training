using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    class RemovalContactTests : AuthorizationTestBase
    {
        [Test]
        public void RemoveContact()
        {
            applicationManager.ContactHelper.Remove(1);
        }

        [Test]
        public void RemoveAllContacts()
        {
            applicationManager.ContactHelper.Remove();
        }
    }
}
