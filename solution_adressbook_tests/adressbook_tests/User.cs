using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    class User
    {
        public string login { get; set; }
        public string password { get; set; }

        public User(string login, string password)
        {
            this.login    = login;
            this.password = password;
        }
    }
}
