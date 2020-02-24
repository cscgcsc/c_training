using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    class RemovalContactTests : TestBase
    {
        [Test]
        public void RemoveContact()
        {
            applicationManager.ContactHelper.Remove(1);
        }       
    }
}
