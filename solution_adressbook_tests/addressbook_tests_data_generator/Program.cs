using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using WebAddressBookTests;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_tests_data_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            //args[0] - тип генерируемых данных
            //args[1] - количество генерируемых данных
            //args[2] - имя файла
            //args[3] - формат

            if (!int.TryParse(args[1], out int count))
            {
                Console.Out.Write("Wrong number \"" + args[1] + "\" of objects.");
            }

            if (args[0] == "groups")
            {
                List<Group> groupsDataList = GenerateGroupsDataList(count);

                if (args[3] == "xls" || args[3] == "xlsx")
                {
                    WriteGroupsDataToXlsxFile(groupsDataList, args[2]);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(args[2]);
                    if (args[3] == "csv")
                    {
                        WriteGroupsDataToCsvFile(groupsDataList, writer);
                    }
                    else if (args[3] == "xml")
                    {
                        WriteGroupsDataToXmlFile(groupsDataList, writer);
                    }
                    else if (args[3] == "json")
                    {
                        WriteGroupsDataToJsonFile(groupsDataList, writer);
                    }
                    else
                    {
                        Console.Out.Write("Format \"" + args[3] + "\" is not supported.");
                    }
                    writer.Close();
                }
            }
            else if(args[0] == "contacts")
            {
                List<Contact> contactsDataList = GenerateContactsDataList(count);

                if (args[3] == "xls" || args[3] == "xlsx")
                {
                    WriteContactsDataToXlsxFile(contactsDataList, args[2]);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(args[2]);
                    if (args[3] == "csv")
                    {
                        WriteContactsDataToCsvFile(contactsDataList, writer);
                    }
                    else if (args[3] == "xml")
                    {
                        WriteContactsDataToXmlFile(contactsDataList, writer);
                    }
                    else if (args[3] == "json")
                    {
                        WriteContactsDataToJsonFile(contactsDataList, writer);
                    }
                    else
                    {
                        Console.Out.Write("Format \"" + args[3] + "\" is not supported.");
                    }
                    writer.Close();
                }
            }
            else
            {
                Console.Out.Write("Type \"" + args[0] + "\" is not supported.");
            }                
        }

        static List<Group> GenerateGroupsDataList(int count)
        {
            List<Group> groupsDataList = new List<Group>();

            for (int i = 0; i < count; i++)
            {
                groupsDataList.Add(new Group(TestBase.GenerateRandomString(10))
                {
                    Groupheader = TestBase.GenerateRandomString(10),
                    Groupfooter = TestBase.GenerateRandomString(10)
                });
            }

            return groupsDataList;
        }

        static List<Contact> GenerateContactsDataList(int count)
        {
            List<Contact> contactsDataList = new List<Contact>();

            for (int i = 0; i < count; i++)
            {
                DateTime birthDate = TestBase.GenerateRandomDate();
                DateTime anniversaryDate = TestBase.GenerateRandomDate();

                contactsDataList.Add(new Contact(TestBase.GenerateRandomString(20), TestBase.GenerateRandomString(20))
                {
                    Middlename = TestBase.GenerateRandomString(20),
                    Nickname = TestBase.GenerateRandomString(20),
                    Birthday = TestBase.GetFormatDay(birthDate),
                    Birthmonth = TestBase.GetFormatMonth(birthDate),
                    Birthyear = birthDate.ToString("yyyy"),
                    Anniversaryday = TestBase.GetFormatDay(anniversaryDate),
                    Anniversarymonth = TestBase.GetFormatMonth(anniversaryDate),
                    Anniversaryyear = anniversaryDate.ToString("yyyy"),
                    Title = TestBase.GenerateRandomString(20),
                    Company = TestBase.GenerateRandomString(20),
                    Address = TestBase.GenerateRandomString(250),
                    Home = TestBase.GenerateRandomString(20),
                    Mobile = TestBase.GenerateRandomString(20),
                    Work = TestBase.GenerateRandomString(20),
                    Fax = TestBase.GenerateRandomString(20),
                    Email = TestBase.GenerateRandomString(20),
                    Email2 = TestBase.GenerateRandomString(20),
                    Email3 = TestBase.GenerateRandomString(20),
                    Homepage = TestBase.GenerateRandomString(20),
                    Address2 = TestBase.GenerateRandomString(250),
                    Phone2 = TestBase.GenerateRandomString(20),
                    Notes = TestBase.GenerateRandomString(250)
                }); ;
            }

            return contactsDataList;
        }

        private static void WriteContactsDataToCsvFile(List<Contact> contactsDataList, StreamWriter writer)
        {
            foreach (Contact contactData in contactsDataList)
            {
                writer.WriteLine(String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23}",
                                 contactData.Firstname,
                                 contactData.Lastname,
                                 contactData.Middlename,
                                 contactData.Nickname,
                                 contactData.Birthday,
                                 contactData.Birthmonth,
                                 contactData.Birthyear,
                                 contactData.Anniversaryday,
                                 contactData.Anniversarymonth,
                                 contactData.Anniversaryyear,
                                 contactData.Title,
                                 contactData.Company,
                                 contactData.Address,
                                 contactData.Home,
                                 contactData.Mobile,
                                 contactData.Work,
                                 contactData.Fax,
                                 contactData.Email,
                                 contactData.Email2,
                                 contactData.Email3,
                                 contactData.Homepage,
                                 contactData.Address2,
                                 contactData.Phone2,
                                 contactData.Notes));
            }
        }

        private static void WriteContactsDataToXmlFile(List<Contact> contactsDataList, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<Contact>)).Serialize(writer, contactsDataList);
        }

        private static void WriteContactsDataToJsonFile(List<Contact> contactsDataList, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contactsDataList, Newtonsoft.Json.Formatting.Indented));
        }

        private static void WriteContactsDataToXlsxFile(List<Contact> contactsDataList, string filename)
        {
            //запускаем excel
            Excel.Application app = new Excel.Application();
            //делаем окно приложения видимым. Это нужно на время отладки
            app.Visible = true;
            //создаем новый документ и получаем активную страницу 
            Excel.Workbook workbook = app.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)app.ActiveSheet;

            int i = 1;
            foreach (Contact contactData in contactsDataList)
            {
                worksheet.Cells[i, 1] = contactData.Firstname;
                worksheet.Cells[i, 2] = contactData.Lastname;
                worksheet.Cells[i, 3] = contactData.Middlename;
                worksheet.Cells[i, 4] = contactData.Nickname;
                worksheet.Cells[i, 5] = contactData.Birthday;
                worksheet.Cells[i, 6] = contactData.Birthmonth;
                worksheet.Cells[i, 7] = contactData.Birthyear;
                worksheet.Cells[i, 8] = contactData.Anniversaryday;
                worksheet.Cells[i, 9] = contactData.Anniversarymonth;
                worksheet.Cells[i, 10] = contactData.Anniversaryyear;
                worksheet.Cells[i, 11] = contactData.Title;
                worksheet.Cells[i, 12] = contactData.Company;
                worksheet.Cells[i, 13] = contactData.Address;
                worksheet.Cells[i, 14] = contactData.Home;
                worksheet.Cells[i, 15] = contactData.Mobile;
                worksheet.Cells[i, 16] = contactData.Work;
                worksheet.Cells[i, 17] = contactData.Fax;
                worksheet.Cells[i, 18] = contactData.Email;
                worksheet.Cells[i, 19] = contactData.Email2;
                worksheet.Cells[i, 20] = contactData.Email3;
                worksheet.Cells[i, 21] = contactData.Homepage;
                worksheet.Cells[i, 22] = contactData.Address2;
                worksheet.Cells[i, 23] = contactData.Phone2;
                worksheet.Cells[i, 24] = contactData.Notes;
                i++;
            }
            //string path = Path.Combine(Directory.GetCurrentDirectory(), filename);
            //не спрашивать разрешение на запись поверх существующего документа
            app.DisplayAlerts = false;
            workbook.SaveAs(filename);
            workbook.Close();
            //убираем окно excel
            app.Visible = false;
        }

        static void WriteGroupsDataToCsvFile(List<Group> groupsDataList, StreamWriter writer)
        {
            foreach (Group groupData in groupsDataList)
            {
                writer.WriteLine(String.Format("{0},{1},{2}",
                                 groupData.Groupname,
                                 groupData.Groupheader,
                                 groupData.Groupfooter));
            }
        }

        static void WriteGroupsDataToXmlFile(List<Group> groupsDataList, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<Group>)).Serialize(writer, groupsDataList);
        }

        static void WriteGroupsDataToJsonFile(List<Group> groupsDataList, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groupsDataList, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteGroupsDataToXlsxFile(List<Group> groupsDataList, string filename)
        {
            //запускаем excel
            Excel.Application app = new Excel.Application();
            //делаем окно приложения видимым. Это нужно на время отладки
            app.Visible = true;
            //создаем новый документ и получаем активную страницу 
            Excel.Workbook workbook = app.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)app.ActiveSheet;

            int i = 1;
            foreach(Group groupData in groupsDataList)
            {
                worksheet.Cells[i, 1] = groupData.Groupname;
                worksheet.Cells[i, 2] = groupData.Groupheader;
                worksheet.Cells[i, 3] = groupData.Groupfooter;
                i++;
            }
            //string path = Path.Combine(Directory.GetCurrentDirectory(), filename);
            //не спрашивать разрешение на запись поверх существующего документа
            app.DisplayAlerts = false;
            workbook.SaveAs(filename);
            workbook.Close();
            //убираем окно excel
            app.Visible = false;
        }
    }
}
