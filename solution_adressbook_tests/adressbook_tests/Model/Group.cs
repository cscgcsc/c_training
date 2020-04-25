using System;

namespace WebAddressBookTests
{
    public class Group : IEquatable<Group>, IComparable<Group>
    {
        private string groupname;
        private string groupheader;
        private string groupfooter;

        public Group(string groupname)
        {
            this.groupname = groupname;
        }

        //пустой конструктор для XmlSerializer
        public Group()
        {          
        }

        public string Groupheader { get => groupheader; set => groupheader = value; }
        public string Groupfooter { get => groupfooter; set => groupfooter = value; }
        public string Groupname { get => groupname; set => groupname = value; }
        public string Id { get; set; }

        public int CompareTo(Group other)
        {
            //1 - текущий объект больше
            //0 - объекты равны
            //-1 - текущий объект меньше
             
            if (Object.ReferenceEquals(other, null))
            {
                return 1; 
            }

            return Groupname.CompareTo(other.Groupname);
        }

        public bool Equals(Group other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if(Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Groupname == other.Groupname;
        }

        public override int GetHashCode()
        {
            return Groupname.GetHashCode();
        }

        public override string ToString()
        {
            return Groupname; 
        }
    }
}
