using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class CreationContactTests : AuthorizationTestBase
    {
        [Test]
        public void CreateContact()
        {
            Contact contactData = new Contact("Ivan", "Ivanov")
            {
                Middlename = "Ivanovich",
                Nickname = "Vanechka",
                Birthday = "30",
                Birthmonth = "July",
                Birthyear = "1990",
                Anniversaryday = "10",
                Anniversarymonth = "May",
                Anniversaryyear = "1995",
                Title = "Title name",
                Company = "Company name",
                Address = "Moscow, Arbat 123/4, office 567",
                Home = "84951234567",
                Mobile = "+7 (916) 123-45-67",
                Work = "33-44-55",
                Fax = "84950123456",
                Email = "qwerty1@yandex.ru",
                Email2 = "qwerty2@yandex.ru",
                Email3 = "qwerty3@yandex.ru",
                Homepage = "https://www.qwerty.ru/",               
                Address2 = "Moscow, Tallinskaya 123-45",
                Phone2 = "+7 (902) 987-65-43",
                Notes = "Text text text"
            };
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


        //[Test]
        //public void CreateContact2()
        //{
        //    Contact contactData = new Contact("Ivan", "Ivanov")
        //    {
        //        Middlename = "Ivanovich",
        //        Nickname = "Vanechka",
        //        Birthday = "30",
        //        Birthmonth = "July",
        //        Birthyear = "1987"
        //    };

        //    for (int i = 0; i < 70; i++)
        //    {
        //        applicationManager.ContactHelper.Modify(contactData, i);
        //    }
          
        //}
    }
}
