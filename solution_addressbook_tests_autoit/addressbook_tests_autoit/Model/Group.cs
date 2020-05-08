using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookAutoItTests
{
    public class Group : IComparable<Group>, IEquatable<Group>
    {
        private string groupname;
        private string path;

        public string Groupname
        {
            get 
            {
                return groupname;
            }
            set
            {
                groupname = value;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        public int CompareTo(Group other)
        {
            //1 - текущий объект больше
            //0 - объекты равны
            //-1 - текущий объект меньше

            if (Object.ReferenceEquals(other, null)) return 1;
            return Groupname.CompareTo(other.Groupname);
        }

        public bool Equals(Group other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(other, this)) return true;
            return Groupname == other.Groupname;
        }

        public override int GetHashCode()
        {
            if (Object.ReferenceEquals(this, null)) return 0;     
            return Groupname == null ? 0 : Groupname.GetHashCode();
        }

        public override string ToString()
        {
            return Groupname;
        }
    }
}
