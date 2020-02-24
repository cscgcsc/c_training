using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class CreationContactTests : TestBase
    {
        [Test]
        public void CreateContact()
        {
            Contact contactData = new Contact("Ivanov", "Ivan")
            {
                Middlename = "Ivanovich",
                Birthday = "30",
                Birthmonth = "July",
                Birthyear = "1990"
            };
            applicationManager.ContactHelper.Create(contactData);
        }
    }
}
