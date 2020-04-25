using System;
using System.Text.RegularExpressions;

namespace WebAddressBookTests
{
    public class Contact : IEquatable<Contact>, IComparable<Contact>
    {
        private string initial;
        private string allEmail;
        private string allPhones;
        private string age;
        private string anniversary;

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Birthday { get; set; }
        public string Birthmonth { get; set; }
        public string Birthyear { get; set; }
        public string Anniversaryday { get; set; } 
        public string Anniversarymonth { get; set; }
        public string Anniversaryyear { get; set; }
        public string Address2 { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }
        public string Id { get; set; }

        public Contact(string firstname, string lastname)
        {
            this.Firstname  = firstname;
            this.Lastname   = lastname;
        }

        //пустой конструктор для XmlSerializer
        public Contact()
        {
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
                    string result = CleanUpInitial(Middlename);
                    result += CleanUpInitial(Lastname);
                    return result.Trim();
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
