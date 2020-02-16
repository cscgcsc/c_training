using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class CreationGroup : TestBase
    {

        [Test]
        public void CreateGroup()
        {
            applicationManager.NavigationHelper.OpenURL();
            applicationManager.LoginHelper.Login(new User("admin", "secret"));
            applicationManager.GroupHelper.InitGroupAction();
            Group groupData = new Group("Test groupname")
            {
                Groupheader = "Test groupheader",
                Groupfooter = "Test groupfooter"
            };
            applicationManager.GroupHelper.FillingGroupData(groupData);
            applicationManager.GroupHelper.SubmitForm();
            applicationManager.NavigationHelper.GoToGroupPage();
            applicationManager.NavigationHelper.GoToHomePage();
            applicationManager.LoginHelper.Logout();
        }

       
    }
}
