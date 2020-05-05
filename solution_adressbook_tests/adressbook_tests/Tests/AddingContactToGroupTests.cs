using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressBookTests
{
    [TestFixture]
    public class AddingContactToGroupTests : AddingContactToGroupTestBase
    {
        [Test]
        public void AddingContactToGroupFromTable() 
        {            
            //если групп нет
            List<Group> groupsList = Group.GetAll();
            if (groupsList.Count == 0)
            {
                applicationManager.GroupHelper.InitGroupsListAction();
                applicationManager.GroupHelper.Create(new Group("Test groupname"));
                groupsList = Group.GetAll();
            }

            applicationManager.ContactHelper.InitContactsListAction();
            applicationManager.ContactHelper.ClearGroupFilter();
            //если контактов нет
            List<Contact> contactsList = Contact.GetAll();
            if (contactsList.Count == 0)
            {
                applicationManager.ContactHelper.Create(applicationManager.ContactHelper.GetDefaultContactData());
                contactsList = Contact.GetAll();
            }

            List<Contact> oldContactsInGroupList = Group.GetContactsInGroup(groupsList[0].Id);
            List<Contact> contactsNotInGroupList = contactsList.Except(oldContactsInGroupList, new ContactComparer()).ToList();
            //если все контакты входят в группу
            if (contactsNotInGroupList.Count == 0)
            {
                applicationManager.ContactHelper.Create(applicationManager.ContactHelper.GetDefaultContactData());
                contactsList = Contact.GetAll();
                contactsNotInGroupList = contactsList.Except(oldContactsInGroupList, new ContactComparer()).ToList();
            }
            
            applicationManager.ContactHelper.AddContactToGroup(contactsNotInGroupList[0].Id, groupsList[0].Id);          
            List<Contact> newContactsInGroupList = Group.GetContactsInGroup(groupsList[0].Id);
            oldContactsInGroupList.Add(contactsNotInGroupList[0]);
            oldContactsInGroupList.Sort();
            newContactsInGroupList.Sort();
            
            Assert.AreEqual(oldContactsInGroupList, newContactsInGroupList);
        }

        [Test]
        public void AddingContactToGroupFromEditForm()
        {
            //если групп нет
            List<Group> groupsList = Group.GetAll();
            if (groupsList.Count == 0)
            {
                applicationManager.GroupHelper.InitGroupsListAction();
                applicationManager.GroupHelper.Create(new Group("Test groupname"));
                groupsList = Group.GetAll();
            }

            applicationManager.ContactHelper.InitContactsListAction();
            Contact contactData = new Contact("Maksim", "Maksimov")
            {          
                GroupId = groupsList[0].Id
            };

            List<Contact> oldContactsInGroupList = Group.GetContactsInGroup(groupsList[0].Id);
            applicationManager.ContactHelper.Create(contactData);
            List<Contact> newContactsInGroupList = Group.GetContactsInGroup(groupsList[0].Id);
            oldContactsInGroupList.Add(contactData);
            oldContactsInGroupList.Sort();
            newContactsInGroupList.Sort();

            Assert.AreEqual(oldContactsInGroupList, newContactsInGroupList);
        }
    }
}
