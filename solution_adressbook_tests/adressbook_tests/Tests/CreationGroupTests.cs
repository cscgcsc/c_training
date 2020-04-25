using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressBookTests
{
    [TestFixture]
    public class CreationGroupTests : AuthorizationTestBase
    {
        public static List<Group> RandomGroupDataProvider()
        {
            List<Group> groupsDataList = new List<Group>();

            for(int i = 0; i<5; i++)
            {
                groupsDataList.Add(new Group(GenerateRandomString(10))
                    {
                        Groupheader = GenerateRandomString(10),
                        Groupfooter = GenerateRandomString(10)
                    });
            }

            return groupsDataList;
        }

        public static List<Group> GroupDataFromCsvProvider()
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

        public static List<Group> GroupDataFromXmlProvider()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"groups.xml");
            return (List<Group>) new XmlSerializer(typeof(List<Group>)).Deserialize(new StreamReader(path));
        }

        public static List<Group> GroupDataFromJsonProvider()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"groups.json");
            return JsonConvert.DeserializeObject<List<Group>>(File.ReadAllText(path));
            
        }

        [Test, TestCaseSource("GroupDataFromJsonProvider")]
        public void CreateGroup(Group groupData)
        {
            applicationManager.GroupHelper.InitGroupsListAction();

            List<Group> oldGroupsList = applicationManager.GroupHelper.GetGroupsList();
            oldGroupsList.Add(groupData);
            oldGroupsList.Sort();

            applicationManager.GroupHelper.Create(groupData);            
            List<Group> newGroupsList = applicationManager.GroupHelper.GetGroupsList();
            newGroupsList.Sort();

            Assert.AreEqual(oldGroupsList, newGroupsList);
        }
    }
}
