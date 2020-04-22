using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class CreationContactTests : AuthorizationTestBase
    {
        public static List<Contact> RandomContactDataProvider()
        {
            List<Contact> contactDataList = new List<Contact>();

            for (int i = 0; i < 5; i++)
            {
                DateTime birthDate = GenerateRandomDate();
                DateTime anniversaryDate = GenerateRandomDate();

                contactDataList.Add(new Contact(GenerateRandomString(20), GenerateRandomString(20))
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

            return contactDataList;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void CreateContact(Contact contactData)
        {
            StartCalculationRunTime();
            List<Contact> oldContactsList = applicationManager.ContactHelper.GetContactsList();
            StopCalculationRunTime();
            oldContactsList.Add(contactData);
            oldContactsList.Sort();

            applicationManager.ContactHelper.Create(contactData);
            
            List<Contact> newContactsList = applicationManager.ContactHelper.GetContactsList();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList, newContactsList);           
        }
    }
}
