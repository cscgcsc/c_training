using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthorizationTestBase
    {
        [Test]
        public void TestContactInformationFromTableHome()
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
        public void TestContactInformationFromTableBirthday()
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
        }

        [Test]
        public void TestContactInformationFromPrintFormHome()
        {
            applicationManager.ContactHelper.InitContactsListAction();
            if (applicationManager.ContactHelper.IsContactsListEmpty())
            {
                applicationManager.ContactHelper.Create(applicationManager.ContactHelper.GetDefaultContactData());
            }

            string printText = applicationManager.ContactHelper.GetContactInformationFromPrintForm(3);
            Contact contactDataFromForm = applicationManager.ContactHelper.GetContactInformationFromEditForm(3);
            string concatPrintText = applicationManager.ContactHelper.ConcatPrintInformation(contactDataFromForm);

            Assert.AreEqual(printText, concatPrintText);
        }

        [Test]
        public void TestContactInformationFromPrintFormBirthday()
        {
            applicationManager.ContactHelper.InitBirthdaysListAction();
            if (applicationManager.ContactHelper.IsBirthdaysListEmpty())
            {
                applicationManager.ContactHelper.Create(applicationManager.ContactHelper.GetDefaultContactData());
            }

            string printText = applicationManager.ContactHelper.GetContactInformationFromPrintForm(0);
            Contact contactDataFromForm = applicationManager.ContactHelper.GetContactInformationFromEditForm(0);
            string concatPrintText = applicationManager.ContactHelper.ConcatPrintInformation(contactDataFromForm);

            Assert.AreEqual(printText, concatPrintText);
        }
    }
}
