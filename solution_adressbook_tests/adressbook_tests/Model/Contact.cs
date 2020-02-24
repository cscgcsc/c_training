using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class Contact
    {
        private string firstname;        
        private string lastname;
        public string Middlename { get; set; } = "";
        public string Nickname { get; set; } = "";
        public string Title { get; set; } = "";
        public string Company { get; set; } = "";
        public string Address { get; set; } = "";
        public string Home { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string Work { get; set; } = "";
        public string Fax { get; set; } = "";
        public string Email { get; set; } = "";
        public string Email2 { get; set; } = "";
        public string Email3 { get; set; } = "";
        public string Homepage { get; set; } = "";
        public string Birthday { get; set; } = "";
        public string Birthmonth { get; set; } = "-";
        public string Birthyear { get; set; } = "";
        public string Anniversaryday { get; set; } = "-";
        public string Anniversarymonth { get; set; } = "-";
        public string Anniversaryyear { get; set; } = "";
        public string Address2 { get; set; } = "";
        public string Phone2 { get; set; } = "";
        public string Notes { get; set; } = "";

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
