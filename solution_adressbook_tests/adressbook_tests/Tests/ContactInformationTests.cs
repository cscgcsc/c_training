using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthorizationTestBase
    {
        [Test]
        public void TestContactInformationFromTableHome()
        {
            app.ContactHelper.InitContactsListAction();
            if (Contact.GetAll().Count == 0) 
                app.ContactHelper.Create(app.ContactHelper.GetDefaultContactData());

            Contact contactDataFromTable = app.ContactHelper.GetContactInformationFromTable(0);
            Contact contactDataFromForm = app.ContactHelper.GetContactInformationFromEditForm(0);

            Assert.AreEqual(contactDataFromTable.Firstname, contactDataFromForm.Firstname);
            Assert.AreEqual(contactDataFromTable.Lastname, contactDataFromForm.Lastname);
            Assert.AreEqual(contactDataFromTable.Address, contactDataFromForm.Address);
            Assert.AreEqual(contactDataFromTable.AllEmail, contactDataFromForm.AllEmail);
            Assert.AreEqual(contactDataFromTable.AllPhones, contactDataFromForm.AllPhones);
        }

        [Test]
        public void TestContactInformationFromTableBirthday()
        {
            app.ContactHelper.InitBirthdaysListAction();
            if (Contact.GetBirthdays().Count == 0) 
                app.ContactHelper.Create(app.ContactHelper.GetDefaultContactData());

            Contact contactDataFromTable = app.ContactHelper.GetContactInformationFromBirthdaysTable(0);
            Contact contactDataFromForm = app.ContactHelper.GetContactInformationFromEditForm(0);

            Assert.AreEqual(contactDataFromTable.Initial, contactDataFromForm.Initial);
            Assert.AreEqual(contactDataFromTable.Firstname, contactDataFromForm.Firstname);
            Assert.AreEqual(contactDataFromTable.Age, contactDataFromForm.Age);
            Assert.AreEqual(contactDataFromTable.Email, contactDataFromForm.Email);
            Assert.AreEqual(contactDataFromTable.Home, contactDataFromForm.Home);
        }

        [Test]
        public void TestContactInformationFromPrintFormHome()
        {
            app.ContactHelper.InitContactsListAction();
            if (Contact.GetAll().Count == 0) 
                app.ContactHelper.Create(app.ContactHelper.GetDefaultContactData());

            string printText = app.ContactHelper.GetContactInformationFromPrintForm(0);
            Contact contactDataFromForm = app.ContactHelper.GetContactInformationFromEditForm(0);
            string concatPrintText = app.ContactHelper.ConcatPrintInformation(contactDataFromForm);

            Assert.AreEqual(printText, concatPrintText);
        }

        [Test]
        public void TestContactInformationFromPrintFormBirthday()
        {
            app.ContactHelper.InitBirthdaysListAction();
            if (Contact.GetBirthdays().Count == 0) 
                app.ContactHelper.Create(app.ContactHelper.GetDefaultContactData());

            string printText = app.ContactHelper.GetContactInformationFromPrintForm(0);
            Contact contactDataFromForm = app.ContactHelper.GetContactInformationFromEditForm(0);
            string concatPrintText = app.ContactHelper.ConcatPrintInformation(contactDataFromForm);

            Assert.AreEqual(printText, concatPrintText);
        }
    }
}
