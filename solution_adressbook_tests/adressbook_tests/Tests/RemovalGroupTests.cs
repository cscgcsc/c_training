using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class RemovalGroupTests : AuthorizationTestBase
    {
        [Test]
        public void RemoveGroup()
        {
            applicationManager.GroupHelper.Remove(1);
        }
    }
}
