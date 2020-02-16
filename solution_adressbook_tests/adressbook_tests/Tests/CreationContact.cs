using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class CreationContact : TestBase
    {
        [Test]
        public void CreateContact()
        {
            applicationManager.NavigationHelper.OpenURL();
            applicationManager.LoginHelper.Login(new User("admin", "secret"));
            applicationManager.ContactHelper.InitContactCreation(); 
            Contact contactData = new Contact("Ivanov", "Ivan")
            {
                Middlename = "Ivanovich",
                Birthday = "30",
                Birthmonth = "July",
                Birthyear = "1990"
            };
            applicationManager.ContactHelper.FillingContactData(contactData);
            applicationManager.ContactHelper.SubmitForm();
            applicationManager.NavigationHelper.GoToHomePage();
            applicationManager.LoginHelper.Logout();
        }
    }
}
