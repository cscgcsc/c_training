using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ModifyContactTests : AuthorizationTestBase
    {
        [Test]
        public void ModifyContactFromHomePage()
        {
            applicationManager.NavigationHelper.GoToHomePage();
            if (applicationManager.ContactHelper.IsContactsListEmpty())
            {
                applicationManager.ContactHelper.Create(applicationManager.ContactHelper.GetDefaultContactData());
            }

            Contact contactData = new Contact("Petrov", "Petr")
            {
                Middlename = "Petrovich",
                Birthday = "25",
                Birthmonth = "May",
                Birthyear = "1985"
            };
            applicationManager.ContactHelper.ModifyFromHomePage(contactData, 1);
        }

        [Test]
        public void ModifyContactFromBirthdayPage()
        {
            applicationManager.NavigationHelper.GoToBirthdayPage();
            if (applicationManager.ContactHelper.IsBirthdaysListEmpty())
            {
                applicationManager.ContactHelper.Create(applicationManager.ContactHelper.GetDefaultContactData());
            }

            Contact contactData = new Contact("Maksimov", "Maksim")
            {
                Middlename = "Maksimovich",
                Birthday = "1",
                Birthmonth = "January",
                Birthyear = "1900"
            };
            applicationManager.ContactHelper.ModifyFromBirthdayPage(contactData, 1);
        }
    }
}
