using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    class Contact
    {
        private string firstname;        
        private string lastname;
        public string middlename { get; set; } = "";
        public string nickname { get; set; } = "";
        public string title { get; set; } = "";
        public string company { get; set; } = "";
        public string address { get; set; } = "";
        public string home { get; set; } = "";
        public string mobile { get; set; } = "";
        public string work { get; set; } = "";
        public string fax { get; set; } = "";
        public string email { get; set; } = "";
        public string email2 { get; set; } = "";
        public string email3 { get; set; } = "";
        public string homepage { get; set; } = "";
        public string birthday { get; set; } = "";
        public string birthmonth { get; set; } = "-";
        public string birthyear { get; set; } = "";
        public string anniversaryday { get; set; } = "";
        public string anniversarymonth { get; set; } = "-";
        public string anniversaryyear { get; set; } = "";
        public string address2 { get; set; } = "";
        public string phone2 { get; set; } = "";
        public string notes { get; set; } = "";

        public Contact(string firstname, string lastname)
        {
            this.firstname  = firstname;
            this.lastname   = lastname;
        }

        public string Firstname 
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
    }
}
