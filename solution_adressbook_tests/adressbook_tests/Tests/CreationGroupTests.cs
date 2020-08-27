using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebAddressBookTests
{
    [TestFixture]
    public class CreationGroupTests : GroupTestBase
    {
        public static List<Group> RandomGroupDataProvider()
        {
            List<Group> groupsDataList = new List<Group>();

            for(int i = 0; i < 5; i++)
            {
                groupsDataList.Add(new Group(GenerateRandomString(10))
                    {
                        Groupheader = GenerateRandomString(10),
                        Groupfooter = GenerateRandomString(10)
                    });
            }

            return groupsDataList;
        }

        public static List<Group> GroupsDataFromCsvProvider()
        {
            List<Group> groupsDataList = new List<Group>();
            string[] lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"groups.csv"));
            
            foreach(string line in lines)
            {
                string[] substring = line.Split(char.Parse(",")); 
                groupsDataList.Add(new Group(substring[0])
                {
                    Groupheader = substring[1],
                    Groupfooter = substring[2]
                });
            }

            return groupsDataList;
        }

        public static List<Group> GroupsDataFromXmlProvider()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"groups.xml");
            return (List<Group>) new XmlSerializer(typeof(List<Group>)).Deserialize(new StreamReader(path));
        }

        public static List<Group> GroupsDataFromJsonProvider()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"groups.json");
            return JsonConvert.DeserializeObject<List<Group>>(File.ReadAllText(path));           
        }

        public static List<Group> GroupsDataFromXlsxProvider()
        {
            //запускаем excel
            Excel.Application app = new Excel.Application();
            //делаем окно приложения видимым. Это нужно на время отладки
            app.Visible = true;
            Excel.Workbook workbook = app.Workbooks.Open(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"groups.xlsx"));
            Excel.Worksheet worksheet = (Excel.Worksheet)app.ActiveSheet;
            //ячейки, которые содержат какие-то данные
            Excel.Range range = worksheet.UsedRange;

            List<Group> groupsDataList = new List<Group>();
            for(int i = 1; i <= range.Rows.Count; i++)
            {
                groupsDataList.Add(new Group(range.Cells[i, 1].Value)
                {
                    Groupheader = range.Cells[i, 2].Value,
                    Groupfooter = range.Cells[i, 3].Value
                });
            }

            workbook.Close();
            //убираем окно excel
            app.Visible = false;

            return groupsDataList;
        }

        [Test, TestCaseSource("GroupsDataFromCsvProvider")]
        public void CreateGroup(Group groupData)
        {
            app.GroupHelper.InitGroupsListAction();
            List<Group> oldGroupsList = Group.GetAll();
            oldGroupsList.Add(groupData);
                   
            app.GroupHelper.Create(groupData);
            List<Group> newGroupsList = Group.GetAll();
            oldGroupsList.Sort();
            newGroupsList.Sort();

            Assert.AreEqual(oldGroupsList, newGroupsList);
        }

        //[Test, TestCaseSource("GroupsDataFromCsvProvider")]
        public void OldCreateGroup(Group groupData)
        {
            app.GroupHelper.InitGroupsListAction();

            List<Group> oldGroupsList = app.GroupHelper.GetGroupsList();
            oldGroupsList.Add(groupData);
            oldGroupsList.Sort();

            app.GroupHelper.Create(groupData);
            List<Group> newGroupsList = app.GroupHelper.GetGroupsList();
            newGroupsList.Sort();

            Assert.AreEqual(oldGroupsList, newGroupsList);
        }
    }
}
