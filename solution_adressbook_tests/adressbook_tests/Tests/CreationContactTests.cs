using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebAddressBookTests
{
    [TestFixture]
    public class CreationContactTests : ContactTestBase
    {
        public static List<Contact> RandomContactDataProvider()
        {
            List<Contact> contactsDataList = new List<Contact>();

            for (int i = 0; i < 5; i++)
            {
                DateTime birthDate = GenerateRandomDate();
                DateTime anniversaryDate = GenerateRandomDate();

                contactsDataList.Add(new Contact(GenerateRandomString(20), GenerateRandomString(20))
                {
                    Middlename = GenerateRandomString(20),
                    Nickname = GenerateRandomString(20),
                    Birthday = GetFormatDay(birthDate),
                    Birthmonth = GetFormatMonth(birthDate),
                    Birthyear = birthDate.ToString("yyyy"),
                    Anniversaryday = GetFormatDay(anniversaryDate),
                    Anniversarymonth = GetFormatMonth(anniversaryDate),
                    Anniversaryyear = anniversaryDate.ToString("yyyy"),
                    Title = GenerateRandomString(20),
                    Company = GenerateRandomString(20),
                    Address = GenerateRandomString(250),
                    Home = GenerateRandomString(20),
                    Mobile = GenerateRandomString(20),
                    Work = GenerateRandomString(20),
                    Fax = GenerateRandomString(20),
                    Email = GenerateRandomString(20),
                    Email2 = GenerateRandomString(20),
                    Email3 = GenerateRandomString(20),
                    Homepage = GenerateRandomString(20),
                    Address2 = GenerateRandomString(250),
                    Phone2 = GenerateRandomString(20),
                    Notes = GenerateRandomString(250)
                }); ;
            }

            return contactsDataList;
        }

        public static List<Contact> ContactsDataFromCsvProvider()
        {
            List<Contact> contactsDataList = new List<Contact>();
            string[] lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"contacts.csv"));

            foreach (string line in lines)
            {
                string[] substring = line.Split(char.Parse(","));
                contactsDataList.Add(new Contact(substring[0], substring[1])
                {
                    Middlename = substring[2],
                    Nickname = substring[3],
                    Birthday = substring[4],
                    Birthmonth = substring[5],
                    Birthyear = substring[6],
                    Anniversaryday = substring[7],
                    Anniversarymonth = substring[8],
                    Anniversaryyear = substring[9],
                    Title = substring[10],
                    Company = substring[11],
                    Address = substring[12],
                    Home = substring[13],
                    Mobile = substring[14],
                    Work = substring[15],
                    Fax = substring[16],
                    Email = substring[17],
                    Email2 = substring[18],
                    Email3 = substring[19],
                    Homepage = substring[20],
                    Address2 = substring[21],
                    Phone2 = substring[22],
                    Notes = substring[23]
                });
            }

            return contactsDataList;
        }

        public static List<Contact> ContactsDataFromXmlProvider()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"contacts.xml");
            return (List<Contact>)new XmlSerializer(typeof(List<Contact>)).Deserialize(new StreamReader(path));
        }

        public static List<Contact> ContactsDataFromJsonProvider()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"contacts.json");
            return JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText(path));
        }

        public static List<Contact> ContactsDataFromXlsxProvider()
        {
            //запускаем excel
            Excel.Application app = new Excel.Application();
            //делаем окно приложения видимым. Это нужно на время отладки
            app.Visible = true;
            Excel.Workbook workbook = app.Workbooks.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"contacts.xlsx"));
            Excel.Worksheet worksheet = (Excel.Worksheet)app.ActiveSheet;
            //ячейки, которые содержат какие-то данные
            Excel.Range range = worksheet.UsedRange;

            List<Contact> contactsDataList = new List<Contact>();
            
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                contactsDataList.Add(new Contact(Convert.ToString(range.Cells[i, 1].Value), Convert.ToString(range.Cells[i, 2].Value))
                {
                    Middlename = Convert.ToString(range.Cells[i, 3].Value),
                    Nickname = Convert.ToString(range.Cells[i, 4].Value),
                    Birthday = Convert.ToString(range.Cells[i, 5].Value),
                    Birthmonth = Convert.ToString(range.Cells[i, 6].Value),
                    Birthyear = Convert.ToString(range.Cells[i, 7].Value),
                    Anniversaryday = Convert.ToString(range.Cells[i, 8].Value),
                    Anniversarymonth = Convert.ToString(range.Cells[i, 9].Value),
                    Anniversaryyear = Convert.ToString(range.Cells[i, 10].Value),
                    Title = Convert.ToString(range.Cells[i, 11].Value),
                    Company = Convert.ToString(range.Cells[i, 12].Value),
                    Address = Convert.ToString(range.Cells[i, 13].Value),
                    Home = Convert.ToString(range.Cells[i, 14].Value),
                    Mobile = Convert.ToString(range.Cells[i, 15].Value),
                    Work = Convert.ToString(range.Cells[i, 16].Value),
                    Fax = Convert.ToString(range.Cells[i, 17].Value),
                    Email = Convert.ToString(range.Cells[i, 18].Value),
                    Email2 = Convert.ToString(range.Cells[i, 19].Value),
                    Email3 = Convert.ToString(range.Cells[i, 20].Value),
                    Homepage = Convert.ToString(range.Cells[i, 21].Value),
                    Address2 = Convert.ToString(range.Cells[i, 22].Value),
                    Phone2 = Convert.ToString(range.Cells[i, 23].Value),
                    Notes = Convert.ToString(range.Cells[i, 24])
                });
            }

            workbook.Close();         
            //убираем окно excel
            app.Visible = false;

            return contactsDataList;
        }

        [Test, TestCaseSource("ContactsDataFromXmlProvider")]
        public void CreateContact(Contact contactData)
        {           
            List<Contact> oldContactsList = Contact.GetAll();
            oldContactsList.Add(contactData);
            
            app.ContactHelper.Create(contactData);
            List<Contact> newContactsList = Contact.GetAll();
            oldContactsList.Sort();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList, newContactsList);
        }

        //[Test, TestCaseSource("ContactsDataFromXmlProvider")]
        public void OldCreateContact(Contact contactData)
        {
            List<Contact> oldContactsList = app.ContactHelper.GetContactsList();
            oldContactsList.Add(contactData);
            oldContactsList.Sort();

            app.ContactHelper.Create(contactData);

            List<Contact> newContactsList = app.ContactHelper.GetContactsList();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList, newContactsList);
        }
    }
}
