﻿using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }
       
        public void Create(Contact contactData)
        {
            applicationManager.NavigationHelper.GoToNewGroupPage();
            FillingContactData(contactData);
            FormSubmit();
            applicationManager.NavigationHelper.ReturnToHomePage();
        }

        public void ModifyFromHomePage(Contact contactData, int index)
        {
            applicationManager.NavigationHelper.GoToHomePage();
            ModifyContact(index);
            FillingContactData(contactData);
            FormUpdate();
            applicationManager.NavigationHelper.ReturnToHomePage();
        }

        public void ModifyContactFromBirthdayPage(Contact contactData, int index)
        {
            applicationManager.NavigationHelper.GoToBirthdayPage();
            ModifyContact(index);
            FillingContactData(contactData);
            FormUpdate();
            applicationManager.NavigationHelper.ReturnToHomePage();
        }

        public void Remove(int index)
        {
            applicationManager.NavigationHelper.GoToHomePage();
            SelectContact(index);
            FormDelete();
        }

        public void FillingContactData(Contact contactData)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contactData.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contactData.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contactData.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contactData.Nickname);
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(contactData.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contactData.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contactData.Address);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contactData.Home);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contactData.Mobile);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contactData.Work);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(contactData.Fax);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contactData.Email);
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(contactData.Email2);
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(contactData.Email3);
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(contactData.Homepage);
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contactData.Birthday);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contactData.Birthmonth);
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contactData.Birthyear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contactData.Anniversaryday);
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contactData.Anniversarymonth);
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(contactData.Anniversaryyear);
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(contactData.Address2);
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(contactData.Phone2);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(contactData.Notes);
        }

        public void ModifyContact(int index) 
        {
            By Element = By.XPath("(//table//a[contains(@href,'edit.php')])[" + index + "]");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        public void SelectContact(int index)
        {
            By Element = By.XPath("(//input[@name='selected[]'])[" + index + "]");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        public void FormSubmit()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[1]")).Click();
        }

        public void FormUpdate()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[1]")).Click();
        }

        public void FormDelete()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(true), "^Delete 1 addresses[\\s\\S]$"));
        }
    }
}