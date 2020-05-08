using System.Collections.Generic;
using AutoIt;

namespace AddressBookAutoItTests
{
    public class GroupHelper : HelperBase
    {
        private string GROUPSLIST_TITLE = "Group editor";
        
        public GroupHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public void Create(Group group)
        {
            AutoItX.ControlClick(GROUPSLIST_TITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            AutoItX.Send(group.Groupname);          
            AutoItX.Send("{ENTER}");
        }

        public void Remove(string path)
        {
            //if(AutoItX.ControlTreeView(GROUPSLIST_TITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Exists", path, "") == "0") return;            
            SelectGroup(path);
            AutoItX.ControlClick(GROUPSLIST_TITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            WaitAndActivateWindow("Delete group");
            AutoItX.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d51");
            AutoItX.ControlClick("Delete group", "", "WindowsForms10.BUTTON.app.0.2c908d53");
        }

        public List<Group> GetGroupsList()
        {
            return ReadGroupsTree("#0", new List<Group>());
        }

        public bool IsGroupSingle()
        {
            string count = AutoItX.ControlTreeView(GROUPSLIST_TITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            return int.Parse(count) < 2;
        }

        private List<Group> ReadGroupsTree(string currentElement, List<Group> groupsList)
        {
            groupsList.Add(
                new Group()
                {              
                    Groupname = AutoItX.ControlTreeView(GROUPSLIST_TITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", currentElement, ""),                                   
                    Path = currentElement
                              
                });

            string count = AutoItX.ControlTreeView(GROUPSLIST_TITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", currentElement, "");
            
            for (int i = 0; i < int.Parse(count); i++)
            {               
                ReadGroupsTree(currentElement + "|#" + i, groupsList);
            }

            return groupsList;
        }      

        public void RemoveTreeNodes(List<Group> groupsList, string removalElement)
        {
            groupsList.RemoveAll(x => x.Path.StartsWith(removalElement));
        }

        private void SelectGroup(string item)
        {
            AutoItX.ControlTreeView(GROUPSLIST_TITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", item, "");
        }
    
        private void OpenGroupsList()
        {
             AutoItX.ControlClick(ApplicationManager.PROGRAM_TITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
        }

        public void CompleteGroupsAction()
        {
            AutoItX.ControlClick(GROUPSLIST_TITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        public void InitGroupsAction()
        {
            if (AutoItX.WinExists(GROUPSLIST_TITLE) == 0)
            {
                OpenGroupsList();
                WaitAndActivateWindow(GROUPSLIST_TITLE);
            }
        }
    }
}
