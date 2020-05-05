using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using System.Linq;

namespace WebAddressBookTests
{
    [Table("group_list")]
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

        [Column("group_header"), NotNull] public string Groupheader { get => groupheader; set => groupheader = value; }
        [Column("group_footer"), NotNull] public string Groupfooter { get => groupfooter; set => groupfooter = value; }
        [Column("group_name"), NotNull]  public string Groupname { get => groupname; set => groupname = value; }
        [Column("group_id"), PrimaryKey, Identity] public string Id { get; set; }

        public static List<Group> GetAll()
        {
            using (var db = new AddressbookDataBase())
            {
                var query =
                    from groups in db.Groups
                    select groups;

                return query.ToList();          
            }
        }

        public static Group GetGroupById(string id)
        {
            using (var db = new AddressbookDataBase())
            {
                var query =
                    from groups in db.Groups
                    where groups.Id == id
                    select groups;

                return query.FirstOrDefault();
            }
        }

        public static List<Contact> GetContactsInGroup(string id)
        {
            using (var db = new AddressbookDataBase())
            {
                var query =
                    from groupContactRelations in db.GroupContactRelations
                    join contacts in db.Contacts on groupContactRelations.Id equals contacts.Id
                    where groupContactRelations.Group_Id == id
                    //join groups in db.Groups on groupContactRelations.Group_Id equals groups.Id
                    select contacts;

                return query.ToList();
            }
        }

        public static List<Contact> GetContactsNotInGroups()
        {
            using (var db = new AddressbookDataBase())
            {
                var query =
                   from contacts in db.Contacts
                   join groupContactRelations in db.GroupContactRelations on contacts.Id equals groupContactRelations.Id into table1
                   from newcontacts in table1.DefaultIfEmpty()
                   where newcontacts.Group_Id == null
                   select contacts;

                return query.ToList();
            }
        }

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

        //var q1 =
        //       from contacts in db.Contacts
        //       join groupContactRelations in db.GroupContactRelations on contacts.Id equals groupContactRelations.Id into gj
        //       from subpet in gj.DefaultIfEmpty()
        //       select new
        //       {
        //           contacts.Id,
        //           contacts.Lastname,
        //           GroupId = subpet.Group_Id
        //       };
    }
}
