using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class Group
    {
        private string groupname;
        private string groupheader;
        private string groupfooter;
        public Group(string groupname)
        {
            this.groupname = groupname;
        }

        public string Groupheader { get => groupheader; set => groupheader = value; }
        public string Groupfooter { get => groupfooter; set => groupfooter = value; }
        public string Groupname { get => groupname; set => groupname = value; }
    }
}
