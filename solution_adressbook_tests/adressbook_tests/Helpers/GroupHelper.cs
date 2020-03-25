﻿using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebAddressBookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public void Create(Group groupData)
        {
            applicationManager.NavigationHelper.GoToGroupPage();
            AddGroup();
            FillingGroupData(groupData);
            FormSubmit();
            applicationManager.NavigationHelper.ReturnToGroupPage();
        }

        public void Modify(Group groupData, int index)
        {
            applicationManager.NavigationHelper.GoToGroupPage();
            InitGroup();
            SelectGroup(index);
            ModifyGroup();
            FillingGroupData(groupData);
            FormUpdate();
            applicationManager.NavigationHelper.ReturnToGroupPage();
        }

        public void Remove(int index)
        {
            applicationManager.NavigationHelper.GoToGroupPage();
            InitGroup();
            SelectGroup(index);
            RemoveGroup();
            applicationManager.NavigationHelper.ReturnToGroupPage();
        }

        public void FillingGroupData(Group groupData)
        {
            Type(By.Name("group_name"), groupData.Groupname);
            Type(By.Name("group_header"), groupData.Groupheader);
            Type(By.Name("group_footer"), groupData.Groupfooter);
        }

        private void InitGroup()
        {
            if (!IsElementPresent(By.XPath("//span[@class='group']")))
            {
                Create(new Group("Test groupname"));
            }
        }

        public void AddGroup()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        public void ModifyGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='edit'])[1]")).Click();
        }

        public void RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[1]")).Click();
        }

        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }

        public void FormSubmit()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[1]")).Click();
        }

        public void FormUpdate()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[1]")).Click();
        }
    }
}
