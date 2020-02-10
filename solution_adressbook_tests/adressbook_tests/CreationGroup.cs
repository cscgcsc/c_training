using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class CreationGroup : TestBase
    {

        [Test]
        public void CreateGroup()
        {
            OpenURL();
            Login(new User("admin", "secret"));
            InitGroupCreation();
            Group groupData = new Group("Test groupname")
            {
                Groupheader = "Test groupheader",
                Groupfooter = "Test groupfooter"
            };
            FillingGroupData(groupData);
            SubmitForm();
            GoToGroupPage();
            GoToHomePage();
            Logout();
        }

       
    }
}
