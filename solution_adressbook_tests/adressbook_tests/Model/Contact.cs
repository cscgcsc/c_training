using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using System.Linq;

namespace WebAddressBookTests
{
    [Table("addressbook")]
    public class Contact : IEquatable<Contact>, IComparable<Contact>
    {
        private string initial;
        private string allEmail;
        private string allPhones;
        private string age;
        private string anniversary;

        [Column("firstname")] public string Firstname { get; set; }
        [Column("lastname")] public string Lastname { get; set; }
        [Column("middlename")] public string Middlename { get; set; }
        [Column("nickname")] public string Nickname { get; set; }
        [Column("title")] public string Title { get; set; }
        [Column("company")] public string Company { get; set; }
        [Column("address")] public string Address { get; set; }
        [Column("home")] public string Home { get; set; }
        [Column("mobile")] public string Mobile { get; set; }
        [Column("work")] public string Work { get; set; }
        [Column("fax")] public string Fax { get; set; }
        [Column("email")] public string Email { get; set; }
        [Column("email2")] public string Email2 { get; set; }
        [Column("email3")] public string Email3 { get; set; }
        [Column("homepage")] public string Homepage { get; set; }
        [Column("bday")] public string Birthday { get; set; }
        [Column("bmonth")] public string Birthmonth { get; set; }
        [Column("byear")] public string Birthyear { get; set; }
        [Column("aday")] public string Anniversaryday { get; set; }
        [Column("amonth")] public string Anniversarymonth { get; set; }
        [Column("ayear")] public string Anniversaryyear { get; set; }
        [Column("address2")] public string Address2 { get; set; }
        [Column("phone2")] public string Phone2 { get; set; }
        [Column("notes")] public string Notes { get; set; }
        [Column("id"), PrimaryKey, Identity] public string Id { get; set; }

        public Contact(string firstname, string lastname)
        {
            this.Firstname  = firstname;
            this.Lastname   = lastname;
        }

        //пустой конструктор для XmlSerializer
        public Contact()
        {
        }

        public static List<Contact> GetAll()
        {
            using (var db = new AddressbookDataBase())
            {
                var query =
                    from contacts in db.Contacts
                    select contacts;

                return query.ToList();
            }
        }

        public static Contact GetContactById(string id)
        {
            using (var db = new AddressbookDataBase())
            {
                var query =
                    from contacts in db.Contacts
                    where contacts.Id == id
                    select contacts;

                return query.FirstOrDefault();
            }
        }

        public static List<Contact> GetBirthdays()
        {
            using (var db = new AddressbookDataBase())
            {
                var query =
                    from contacts in db.Contacts
                    where contacts.Birthday != "0"
                    && contacts.Birthyear != "-"
                    select contacts;

                return query.ToList();
            }
        }

        public string Initial
        {
            get
            {
                if(initial != null)
                {
                    return initial;
                }
                else
                {
                    return GenerateInitial();
                }               
            }
            set
            {
                initial = value;
            }
        }

        public string Age
        {
            get
            {
                if (age != null)
                {
                    return age;
                }

                if (int.TryParse(Birthyear, out int intBirthyear))
                {
                    //Если, кроме года заполнены месяц и день, то попытаемся сделать из этого дату
                    if (!string.IsNullOrWhiteSpace(Birthday)
                        && !string.IsNullOrWhiteSpace(Birthmonth)
                        && DateTime.TryParse(Birthday + " " + Birthmonth + " " + Birthyear, out DateTime birthDate))
                    {
                        //Дата корректная, рассчитаем количество лет
                        return CountNumberOfYears(birthDate);
                    }
                    else
                    {
                        //Не удалось получить дату или не заполнен месяц/день, тогда рассчитаем количество лет от 1 января
                        return CountNumberOfYears(new DateTime(intBirthyear, 1, 1));
                    }
                }
                else
                {
                    //Год заполнен неверно
                    return "";
                }                        
            }
            set
            {
                age = value;
            }
        }

        public string Anniversary
        {
            get
            {
                if (anniversary != null)
                {
                    return anniversary;
                }

                if (int.TryParse(Anniversaryyear, out int intAnniversaryyear))
                {
                    //Если, кроме года заполнены месяц и день, то попытаемся сделать из этого дату
                    if (!string.IsNullOrWhiteSpace(Anniversaryday)
                        && !string.IsNullOrWhiteSpace(Anniversarymonth)
                        && DateTime.TryParse(Anniversaryday + " " + Anniversarymonth + " " + Anniversaryyear, out DateTime anniversaryDate))
                    {
                        //Дата корректная, рассчитаем количество лет
                        return CountNumberOfYears(anniversaryDate);
                    }
                    else
                    {
                        //Не удалось получить дату или не заполнен месяц/день, тогда рассчитаем количество лет от 1 января
                        return CountNumberOfYears(new DateTime(intAnniversaryyear, 1, 1));
                    }
                }
                else
                {
                    //Год заполнен неверно
                    return "";
                }
            }
            set
            {
                anniversary = value;
            }
        }

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    string result = CleanUpEmail(Email);
                    result += CleanUpEmail(Email2);
                    result += CleanUpEmail(Email3);

                    return result.Trim();      
                }
            }
            set
            {
                allEmail = value;
            }
        }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    string result = CleanUpPhone(Home);
                    result += CleanUpPhone(Mobile);
                    result += CleanUpPhone(Work);
                    result += CleanUpPhone(Phone2);

                    return result.Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string GenerateInitial()
        {
            string result = CleanUpInitial(Middlename);
            result += CleanUpInitial(Lastname);
            
            return result.Trim();
        }      

        private string CleanUpPhone(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }

            return Regex.Replace(text, "[ \\-()]", "") + "\r\n";
        }

        private string CleanUpEmail(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }

            return text.Trim() + "\r\n";
        }

        private string CleanUpInitial(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }

            return text.Trim() + " ";
        }

        private string CountNumberOfYears(DateTime birthDate)
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int birth = int.Parse(birthDate.ToString("yyyyMMdd"));
            int age = (now - birth) / 10000;

            return age.ToString();
        }

        //Example 2
        //public string Firstname { get => firstname; set => firstname = value; }

        public int CompareTo(Contact other)
        {
            //1 - текущий объект больше
            //0 - объекты равны
            //-1 - текущий объект меньше
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int result = Firstname.CompareTo(other.Firstname);
            if (result != 0)
            {
                return result;
            }

            return Lastname.CompareTo(other.Lastname);      
        }

        public bool Equals(Contact other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (Firstname != other.Firstname)
            {
                return false;
            }

            return Lastname == other.Lastname;            
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = result * 13 + Firstname.GetHashCode();

            return result * 13 + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname: " + Firstname + " Lastname: " + Lastname;
        }
    }
}
