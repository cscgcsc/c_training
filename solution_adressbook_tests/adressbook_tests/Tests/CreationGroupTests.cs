using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class CreationGroupTests : TestBase
    {

        [Test]
        public void CreateGroup()
        {
            Group groupData = new Group("Test groupname")
            {
                Groupheader = "Test groupheader",
                Groupfooter = "Test groupfooter"
            };
            applicationManager.GroupHelper.Create(groupData);
        }
    }
}
