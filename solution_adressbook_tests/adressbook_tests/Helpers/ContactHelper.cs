using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public void Create(Contact contactData)
        {
            applicationManager.NavigationHelper.GoToNewContactPage();
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

        public void ModifyFromBirthdayPage(Contact contactData, int index)
        {    
            applicationManager.NavigationHelper.GoToBirthdayPage();      
            ModifyContact(index);
            FillingContactData(contactData);
            FormUpdate();
            applicationManager.NavigationHelper.ReturnToHomePage();
        }

        public void Remove(int index)
        {
            SelectContact(index);
            FormDelete();
        }

        public void Remove()
        {
            SelectAllContacts();
            FormDelete();
        }

        public List<Contact> GetContactsList()
        {          
            List<Contact> contacts = new List<Contact>();
            
            By Element = By.XPath("//table[@id='maintable']/tbody/tr");
            WaitForElementPresent(Element);
            ICollection<IWebElement> rows = driver.FindElements(Element);

            foreach (IWebElement row in rows)
            {
                List<IWebElement> cells = row.FindElements(By.XPath("./td")).ToList();
                //Если это заголовок таблицы <th>
                if (cells.Count == 0)
                {
                    continue;
                }
                contacts.Add(new Contact(cells[2].Text, cells[1].Text));
            }
            return contacts;
        }

        private void FillingContactData(Contact contactData)
        {
            Type(By.Name("firstname"), contactData.Firstname);
            Type(By.Name("middlename"), contactData.Middlename);
            Type(By.Name("lastname"), contactData.Lastname);
            Type(By.Name("nickname"), contactData.Nickname);
            Type(By.Name("title"), contactData.Title);
            Type(By.Name("company"), contactData.Company);
            Type(By.Name("address"), contactData.Address);
            Type(By.Name("home"), contactData.Home);
            Type(By.Name("mobile"), contactData.Mobile);
            Type(By.Name("work"), contactData.Work);
            Type(By.Name("fax"), contactData.Fax);
            Type(By.Name("email"), contactData.Email);
            Type(By.Name("email2"), contactData.Email2);
            Type(By.Name("email3"), contactData.Email3);
            Type(By.Name("homepage"), contactData.Homepage);
            Select(By.Name("bday"), contactData.Birthday);
            Select(By.Name("bmonth"), contactData.Birthmonth);       
            Type(By.Name("byear"), contactData.Birthyear);
            Select(By.Name("aday"), contactData.Anniversaryday);
            Select(By.Name("amonth"), contactData.Anniversarymonth);
            Type(By.Name("ayear"), contactData.Anniversaryyear);
            Type(By.Name("address2"), contactData.Address2);
            Type(By.Name("phone2"), contactData.Phone2);
            Type(By.Name("notes"), contactData.Notes);
        }

        public bool IsContactsListEmpty()
        {
            ClearContactGroupFilter();
            return driver.FindElement(By.XPath("//span[@id='search_count']")).Text == "0";
        }

        public bool IsBirthdaysListEmpty()
        {
            applicationManager.NavigationHelper.GoToBirthdayPage();
            return !IsElementPresent(By.XPath("//table[@id='birthdays']//tr"));
        }

        private void ModifyContact(int index) 
        {
            By Element = By.XPath("(//table//a[contains(@href,'edit.php')])[" + (index + 1) + "]");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        private void SelectContact(int index)
        {
            By Element = By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();      
        }

        private void SelectAllContacts()
        {
            By Element = By.XPath("//input[@id='MassCB']");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        public Contact GetDefaultContactData()
        {
            Contact contactData = new Contact("Ivan", "Ivanov")
            {
                Birthday = "1",
                Birthmonth = "January",
                Birthyear = "1900"
            };
            return contactData;
        }

        private void ClearContactGroupFilter()
        {
            By Element = By.XPath("//select[@name='group']");
            WaitForElementPresent(Element);
            new SelectElement(driver.FindElement(Element)).SelectByText("[all]");
            driver.FindElement(By.XPath("//option[@value='']")).Click();
        }

        public bool IsContactListEmpty()
        {
            return driver.FindElement(By.XPath("//span[@id='search_count']")).Text == "0";
        }

        private void FormSubmit()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[1]")).Click();
        }

        private void FormUpdate()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[1]")).Click();
        }

        private void FormDelete()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(true), "^Delete \\d* addresses[\\s\\S]$"));

            WaitForElementPresent(By.XPath("//div[@class='msgbox'][contains(text(),'Record successful deleted')]"));
        }
    }
}
