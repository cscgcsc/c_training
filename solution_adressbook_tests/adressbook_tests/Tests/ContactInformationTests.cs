using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthorizationTestBase
    {
        [Test]
        public void TestContactInformationFromHomePage()
        {
            applicationManager.ContactHelper.InitContactsListAction();
            if (applicationManager.ContactHelper.IsContactsListEmpty())
            {
                applicationManager.ContactHelper.Create(applicationManager.ContactHelper.GetDefaultContactData());
            }

            Contact contactDataFromTable = applicationManager.ContactHelper.GetContactInformationFromTable(0);
            Contact contactDataFromForm = applicationManager.ContactHelper.GetContactInformationFromEditForm(0);

            Assert.AreEqual(contactDataFromTable.Firstname, contactDataFromForm.Firstname);
            Assert.AreEqual(contactDataFromTable.Lastname, contactDataFromForm.Lastname);
            Assert.AreEqual(contactDataFromTable.Address, contactDataFromForm.Address);
            Assert.AreEqual(contactDataFromTable.AllEmail, contactDataFromForm.AllEmail);
            Assert.AreEqual(contactDataFromTable.AllPhones, contactDataFromForm.AllPhones);

        }

        [Test]
        public void TestContactInformationFromBirthdayPage()
        {
            applicationManager.ContactHelper.InitBirthdaysListAction();
            if (applicationManager.ContactHelper.IsBirthdaysListEmpty())
            {
                applicationManager.ContactHelper.Create(applicationManager.ContactHelper.GetDefaultContactData());
            }

            Contact contactDataFromTable = applicationManager.ContactHelper.GetContactInformationFromBirthdaysTable(0);
            Contact contactDataFromForm = applicationManager.ContactHelper.GetContactInformationFromEditForm(0);

            Assert.AreEqual(contactDataFromTable.Initial, contactDataFromForm.Initial);
            Assert.AreEqual(contactDataFromTable.Firstname, contactDataFromForm.Firstname);
            Assert.AreEqual(contactDataFromTable.Age, contactDataFromForm.Age);
            Assert.AreEqual(contactDataFromTable.Email, contactDataFromForm.Email);
            Assert.AreEqual(contactDataFromTable.Home, contactDataFromForm.Home);

            //Contact qwerty = new Contact("q", "w")
            //{
            //    Birthday = "29",
            //    Birthmonth = "January",
            //    Birthyear = "1989"
            //};
            //System.Console.WriteLine("Лет: " + qwerty.Age);

            //qwerty = new Contact("q", "w")
            //{
            //    Birthday = "",
            //    Birthmonth = "January",
            //    Birthyear = "1989"
            //};
            //System.Console.WriteLine("Лет: " + qwerty.Age);

            //qwerty = new Contact("q", "w")
            //{
            //    Birthday = "29",
            //    Birthmonth = "",
            //    Birthyear = "1989"
            //};
            //System.Console.WriteLine("Лет: " + qwerty.Age);

            //qwerty = new Contact("q", "w")
            //{
            //    Birthday = "29",
            //    Birthmonth = "January",
            //    Birthyear = ""
            //};
            //System.Console.WriteLine("Лет: " + qwerty.Age);

            //qwerty = new Contact("q", "w")
            //{
            //    Birthday = "29",
            //    Birthmonth = "January",
            //    Birthyear = "qwer"
            //};
            //System.Console.WriteLine("Лет: " + qwerty.Age);

            //qwerty = new Contact("q", "w")
            //{
            //    Birthday = "29",
            //    Birthmonth = "January",
            //    Birthyear = "0038"
            //};
            //System.Console.WriteLine("Лет: " + qwerty.Age);

            //qwerty = new Contact("q", "w")
            //{
            //    Birthyear = "1989"
            //};
            //System.Console.WriteLine("Лет: " + qwerty.Age);

            //qwerty = new Contact("q", "w")
            //{
            //    Birthmonth = "January"
            //};
            //System.Console.WriteLine("Лет: " + qwerty.Age);

            //qwerty = new Contact("q", "w")
            //{
            //    Birthday = "29"
            //};
            //System.Console.WriteLine("Лет: " + qwerty.Age);

            //qwerty = new Contact("q", "w")
            //{
            //    Birthday = "31",
            //    Birthmonth = "February",
            //    Birthyear = "1989"
            //};
            //System.Console.WriteLine("Лет: " + qwerty.Age);


            //qwerty = new Contact("q", "w")
            //{
            //    Birthday = "zz",
            //    Birthmonth = "February",
            //    Birthyear = "1989"
            //};
            //System.Console.WriteLine("Лет: " + qwerty.Age);

            //qwerty = new Contact("q", "w")
            //{
            //    Birthday = "31",
            //    Birthmonth = "February111",
            //    Birthyear = "1989"
            //};
            //System.Console.WriteLine("Лет: " + qwerty.Age);

            //qwerty = new Contact("q", "w")
            //{
            //    Birthday = "31",
            //    Birthmonth = "February",
            //    Birthyear = "-"
            //};
            //System.Console.WriteLine("Лет: " + qwerty.Age);
        }
    }
}
