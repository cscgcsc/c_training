using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        private List<Contact> contactsListCache = null;
        private List<Contact> birthdaysListCache = null;

        public ContactHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public void Create(Contact contactData)
        {
            applicationManager.NavigationHelper.GoToNewContactPage();
            FillingContactData(contactData);
            FormSubmit();
            applicationManager.NavigationHelper.ReturnToStartPage();
        }

        public void Modify(Contact contactData, int index)
        {
            OpenEditForm(index);
            FillingContactData(contactData);
            FormUpdate();
            applicationManager.NavigationHelper.ReturnToStartPage();
        }

        public void Modify(Contact contactData, string id)
        {
            OpenEditForm(id);
            FillingContactData(contactData);
            FormUpdate();
            applicationManager.NavigationHelper.ReturnToStartPage();
        }

        public void Remove(int index)
        {
            SelectContact(index);
            FormDelete();
        }

        public void Remove(string id)
        {
            SelectContact(id);
            FormDelete();
        }

        public void Remove()
        {
            SelectAllContacts();
            FormDelete();
        }

        //Таблицы
        public List<Contact> GetContactsList()
        {
            if (contactsListCache == null)
            {
                contactsListCache = new List<Contact>();

                By Element = By.XPath("//table[@id='maintable']/tbody/tr");
                WaitForElementPresent(Element);
                ICollection<IWebElement> rows = driver.FindElements(Element);

                foreach (IWebElement row in rows)
                {
                    List<IWebElement> cells = row.FindElements(By.XPath("./td")).ToList();
                    
                    //Если это заголовок таблицы <th>
                    if(cells.Count == 0)
                    {
                        continue;
                    }

                    contactsListCache.Add(new Contact(cells[2].Text, cells[1].Text)
                    {
                        Id = cells[0].FindElement(By.XPath("./input")).GetAttribute("value")
                    });
                }
            }

            return new List<Contact>(contactsListCache);
        }

        public List<Contact> GetBirthdaysList()
        {
            if (IsBirthdaysListEmpty())
            {
                return new List<Contact>();
            }

            if (birthdaysListCache == null)
            {
                birthdaysListCache = new List<Contact>();               
                
                By Element = By.XPath("//table[@id='birthdays']/tbody/tr");
                WaitForElementPresent(Element);
                ICollection<IWebElement> rows = driver.FindElements(Element);

                foreach (IWebElement row in rows)
                {
                    List<IWebElement> cells = row.FindElements(By.XPath("./td")).ToList();

                    //Если это заголовок таблицы <th> или colspan
                    if (cells.Count < 2)
                    {
                        continue;
                    }

                    string href = cells[6].FindElement(By.XPath("./a")).GetAttribute("href");
                    birthdaysListCache.Add(new Contact(cells[2].Text, "")
                    {
                        Id = href.Substring(href.IndexOf("?id=") + 4),
                        Initial = cells[1].Text
                    });
                }
            }

            return new List<Contact>(birthdaysListCache);
        }

        public Contact GetContactInformationFromTable(int index)
        {
            By Element = By.XPath("//table[@id='maintable']/tbody/tr[@name='entry'][" + (index + 1) + "]");
            IWebElement row = driver.FindElement(Element);

            List<IWebElement> cells = row.FindElements(By.XPath("./td")).ToList();
            return new Contact(cells[2].Text, cells[1].Text)
            {
                Address = cells[3].Text,
                AllEmail = cells[4].Text,
                AllPhones = cells[5].Text
            };
        }

        public Contact GetContactInformationFromBirthdaysTable(int index)
        {
            By Element = By.XPath("//table[@id='birthdays']/tbody/tr[contains(@class, 'odd') or contains(@class ,'even')][" + (index + 1) + "]");
            IWebElement row = driver.FindElement(Element);

            List<IWebElement> cells = row.FindElements(By.XPath("./td")).ToList();
            return new Contact(cells[2].Text, "")
            {
                Initial = cells[1].Text,
                Age = cells[3].Text,
                Email = cells[4].Text,
                Home = cells[5].Text               
            };
        }

        public bool IsContactsListEmpty()
        {
            ClearContactGroupFilter();
            return driver.FindElement(By.XPath("//span[@id='search_count']")).Text == "0";
        }

        public bool IsBirthdaysListEmpty()
        {
            return !IsElementPresent(By.XPath("//table[@id='birthdays']//tr"));
        }

        //Действия в таблице
        private void OpenEditForm(int index)
        {
            By Element = By.XPath("(//table//a[contains(@href,'edit.php')])[" + (index + 1) + "]");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        private void OpenEditForm(string id)
        {
            By Element = By.XPath("(//table//a[contains(@href,'edit.php?id=" + id + "')])");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        private void OpenPrintForm(int index)
        {
            By Element = By.XPath("(//table//a[contains(@href,'view.php')])[" + (index + 1) + "]");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        private void SelectContact(int index)
        {
            By Element = By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        private void SelectContact(string id)
        {
            By Element = By.XPath("(//input[@id='" + id + "'])");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        private void SelectAllContacts()
        {
            By Element = By.XPath("//input[@id='MassCB']");
            WaitForElementPresent(Element);
            driver.FindElement(Element).Click();
        }

        private void ClearContactGroupFilter()
        {
            By Element = By.XPath("//select[@name='group']");
            WaitForElementPresent(Element);
            new SelectElement(driver.FindElement(Element)).SelectByText("[all]");
            driver.FindElement(By.XPath("//option[@value='']")).Click();
        }

        //Формы
        public Contact GetContactInformationFromEditForm(int index)
        {
            OpenEditForm(index);          

            return new Contact(
                driver.FindElement(By.XPath("//input[@name='firstname']")).GetAttribute("value"), 
                driver.FindElement(By.XPath("//input[@name='lastname']")).GetAttribute("value"))
            {
                Middlename = driver.FindElement(By.XPath("//input[@name='middlename']")).GetAttribute("value"),
                Nickname = driver.FindElement(By.XPath("//input[@name='nickname']")).GetAttribute("value"),
                Birthday = driver.FindElement(By.XPath("//select[@name='bday']/option[@selected]")).GetAttribute("value"),
                Birthmonth = driver.FindElement(By.XPath("//select[@name='bmonth']/option[@selected]")).GetAttribute("value"),
                Birthyear = driver.FindElement(By.XPath("//input[@name='byear']")).GetAttribute("value"),
                Anniversaryday = driver.FindElement(By.XPath("//select[@name='aday']/option[@selected]")).GetAttribute("value"),
                Anniversarymonth = driver.FindElement(By.XPath("//select[@name='amonth']/option[@selected]")).GetAttribute("value"),
                Anniversaryyear = driver.FindElement(By.XPath("//input[@name='ayear']")).GetAttribute("value"),
                Title = driver.FindElement(By.XPath("//input[@name='title']")).GetAttribute("value"),
                Company = driver.FindElement(By.XPath("//input[@name='company']")).GetAttribute("value"),
                Address = driver.FindElement(By.XPath("//textarea[@name='address']")).Text,
                Home = driver.FindElement(By.XPath("//input[@name='home']")).GetAttribute("value"),
                Mobile = driver.FindElement(By.XPath("//input[@name='mobile']")).GetAttribute("value"),
                Work = driver.FindElement(By.XPath("//input[@name='work']")).GetAttribute("value"),
                Fax = driver.FindElement(By.XPath("//input[@name='fax']")).GetAttribute("value"),
                Email = driver.FindElement(By.XPath("//input[@name='email']")).GetAttribute("value"),
                Email2 = driver.FindElement(By.XPath("//input[@name='email2']")).GetAttribute("value"),
                Email3 = driver.FindElement(By.XPath("//input[@name='email3']")).GetAttribute("value"),
                Homepage = driver.FindElement(By.XPath("//input[@name='homepage']")).GetAttribute("value"),
                Address2 = driver.FindElement(By.XPath("//textarea[@name='address2']")).Text,
                Phone2 = driver.FindElement(By.XPath("//input[@name='phone2']")).GetAttribute("value"),
                Notes = driver.FindElement(By.XPath("//textarea[@name='notes']")).Text
            };
        }

        public string GetContactInformationFromPrintForm(int index)
        {
            OpenPrintForm(index);
            string printText = driver.FindElement(By.XPath("//div[@id='content']")).Text;
            printText = Regex.Replace(printText, @"[\r\n]{2,}\s*[\r\n]", "\r\n");

            applicationManager.NavigationHelper.ReturnToStartPage();

            return printText;
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

        //Действия на форме
        private void FormSubmit()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[1]")).Click();
            contactsListCache = null;
            birthdaysListCache = null;
        }

        private void FormUpdate()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[1]")).Click();
            WaitForElementPresent(By.XPath("//div[@class='msgbox'][contains(text(),'Address book updated')]"));
            contactsListCache = null;
            birthdaysListCache = null;
        }

        private void FormDelete()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactsListCache = null;
            birthdaysListCache = null;
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(true), "^Delete \\d* addresses[\\s\\S]$"));
            WaitForElementPresent(By.XPath("//div[@class='msgbox'][contains(text(),'Record successful deleted')]"));
        }

        //Служебные
        public string ConcatPrintInformation(Contact contactData)
        {
            string result = "";
            
            result += CleanUp(contactData.Firstname, false) + " ";
            result += CleanUp(contactData.Initial);
            result = CleanUp(result);

            result += CleanUp(contactData.Nickname);
            result += CleanUp(contactData.Title);
            result += CleanUp(contactData.Company);
            result += CleanUpMultilineText(contactData.Address);         

            //Телефоны
            if (!string.IsNullOrEmpty(contactData.Home))
            {
                result += CleanUp(("H: " + CleanUp(contactData.Home, false)));
            }

            if (!string.IsNullOrEmpty(contactData.Mobile))
            {
                result += CleanUp(("M: " + CleanUp(contactData.Mobile, false)));
            }

            if (!string.IsNullOrEmpty(contactData.Work))
            {
                result += CleanUp(("W: " + CleanUp(contactData.Work, false)));
            }

            if (!string.IsNullOrEmpty(contactData.Fax))
            {
                result += CleanUp(("F: " + CleanUp(contactData.Fax, false)));
            }

            //Почта
            result += CleanUp(contactData.AllEmail);

            //Сайт
            if (!string.IsNullOrEmpty(contactData.Homepage))
            {
                result += CleanUp("Homepage:\r\n" + CleanUp(Regex.Replace(contactData.Homepage, "(http://)|(https://)", ""), false));
            }          

            //День рождения
            string temp = "";
            if (!string.IsNullOrWhiteSpace(contactData.Birthday) 
                && contactData.Birthday != "0")
            {
                temp += contactData.Birthday + ". ";
            }

            if (!string.IsNullOrWhiteSpace(contactData.Birthmonth)
                && contactData.Birthmonth != "-")
            {
                temp += contactData.Birthmonth + " ";
            }

            if (!string.IsNullOrEmpty(contactData.Birthyear))
            {
                temp += contactData.Birthyear.Trim() + " ";
            }

            if (!string.IsNullOrEmpty(contactData.Age))
            {
                temp += "(" + contactData.Age + ")";
            }

            if(temp != "")
            {
                result += CleanUp("Birthday " + temp);
            }

            //Юбилей
            temp = "";
            if (!string.IsNullOrWhiteSpace(contactData.Anniversaryday)
                && contactData.Anniversaryday != "0")
            {
                temp += contactData.Anniversaryday + ". ";
            }

            if (!string.IsNullOrWhiteSpace(contactData.Anniversarymonth)
                && contactData.Anniversarymonth != "-")
            {
                temp += contactData.Anniversarymonth + " ";
            }

            if (!string.IsNullOrEmpty(contactData.Anniversaryyear))
            {
                temp += contactData.Anniversaryyear.Trim() + " ";
            }

            if (!string.IsNullOrEmpty(contactData.Anniversary))
            {
                temp += "(" + contactData.Anniversary + ")";
            }

            if (temp != "")
            {
                result += CleanUp("Anniversary " + temp);
            }

            //Адрес
            result += CleanUpMultilineText(contactData.Address2);

            //Телефон
            if (!string.IsNullOrEmpty(contactData.Phone2))
            {
                result += CleanUp("P: " + CleanUp(contactData.Phone2, false));
            }

            //Заметка
            result += CleanUpMultilineText(contactData.Notes);
            
            return result.Trim();
        }

        public string CleanUp(string text, bool lineBreak = true)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }

            if (lineBreak)
            {
                //несколько пробелов переделаем в один
                return Regex.Replace(text.Trim(), @"[ ]{2,}", " ") + "\r\n";
            }

            return Regex.Replace(text.Trim(), @"[ ]{2,}", " ");
        }

        public string CleanUpMultilineText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }
            //несколько пробелов переделаем в один
            text = Regex.Replace(text, @"[ ]{2,}", " ");
            //удалим пробелы в начале и конце каждой строки 
            text = Regex.Replace(text, @"([ ]*\r\n[ ]*)", "\r\n");
            //несколько переносов строк переделаем в один
            text = Regex.Replace(text, @"[\r\n]{2,}\s*[\r\n]", "\r\n");
            return text.Trim() + "\r\n";
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

        public void InitContactsListAction()
        {
            applicationManager.NavigationHelper.GoToHomePage();
            applicationManager.NavigationHelper.SetStartPage();
        }

        public void InitBirthdaysListAction()
        {
            applicationManager.NavigationHelper.GoToBirthdayPage();
            applicationManager.NavigationHelper.SetStartPage();
        }
    }
}
