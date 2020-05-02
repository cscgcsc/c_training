﻿using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    public class GroupHelper : HelperBase
    {
        private List<Group> groupsListCache = null;

        public GroupHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public void Create(Group groupData)
        {
            AddGroup();
            FillingGroupData(groupData);
            FormSubmit();
            applicationManager.NavigationHelper.ReturnToGroupPage();
        }

        public void Modify(Group groupData, int index)
        {
            SelectGroup(index);
            ModifyGroup();
            FillingGroupData(groupData);
            FormUpdate();
            applicationManager.NavigationHelper.ReturnToGroupPage();
        }

        public void Modify(Group groupData, string id)
        {
            SelectGroup(id);
            ModifyGroup();
            FillingGroupData(groupData);
            FormUpdate();
            applicationManager.NavigationHelper.ReturnToGroupPage();
        }

        public void Remove(int index)
        {
            SelectGroup(index);
            RemoveGroup();
            applicationManager.NavigationHelper.ReturnToGroupPage();
        }

        public void Remove(string id)
        {
            SelectGroup(id);
            RemoveGroup();
            applicationManager.NavigationHelper.ReturnToGroupPage();
        }

        private void FillingGroupData(Group groupData)
        {
            Type(By.Name("group_name"), groupData.Groupname);
            Type(By.Name("group_header"), groupData.Groupheader);
            Type(By.Name("group_footer"), groupData.Groupfooter);
        }

        public bool IsGroupsListEmpty()
        {
            return !IsElementPresent(By.XPath("//span[@class='group']"));
        }

        public List<Group> GetGroupsList()
        {
            if (groupsListCache == null)
            {
                groupsListCache = new List<Group>();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//span[@class='group']"));

                foreach (IWebElement element in elements)
                {
                    groupsListCache.Add(new Group(element.Text) {
                        Id = element.FindElement(By.XPath("./input")).GetAttribute("value")
                    }) ;
                }
            }

            return new List<Group>(groupsListCache);
        } 

        private void AddGroup()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        private void ModifyGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='edit'])[1]")).Click();
        }

        private void RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[1]")).Click();
            groupsListCache = null;
        }

        private void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
        }

        private void SelectGroup(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
        }

        private void FormSubmit()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[1]")).Click();
            groupsListCache = null;
        }

        private void FormUpdate()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[1]")).Click();
            groupsListCache = null;
        }

        public void InitGroupsListAction()
        {
            applicationManager.NavigationHelper.GoToGroupPage();
            applicationManager.NavigationHelper.SetStartPage();
        }
    }
}
