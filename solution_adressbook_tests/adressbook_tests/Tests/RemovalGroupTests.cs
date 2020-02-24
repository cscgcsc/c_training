using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class RemovalGroupTests : TestBase
    {
        [Test]
        public void RemoveGroup()
        {
            applicationManager.GroupHelper.Remove(1);
        }
    }
}
