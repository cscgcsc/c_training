using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class CreationContact : TestBase
    {
        [Test]
        public void CreateContact()
        {
            OpenURL();
            Login(new User("admin", "secret"));
            InitContactCreation(); 
            Contact contactData = new Contact("Ivanov", "Ivan")
            {
                Middlename = "Ivanovich",
                Birthday = "30",
                Birthmonth = "July",
                Birthyear = "1990"
            };
            FillingContactData(contactData);
            SubmitForm();
            GoToHomePage();
            Logout();
        }
    }
}
