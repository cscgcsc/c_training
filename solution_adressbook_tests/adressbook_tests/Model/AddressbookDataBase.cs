using LinqToDB;

namespace WebAddressBookTests
{
    class AddressbookDataBase : LinqToDB.Data.DataConnection
    {
        public AddressbookDataBase() : base("Addressbook")
        {
        }

        public ITable<Group> Groups { get { return GetTable<Group>(); } }

        public ITable<Contact> Contacts { get { return GetTable<Contact>(); } }

        public ITable<GroupContactRelation> GroupContactRelations { get { return GetTable<GroupContactRelation>(); } }
    }
}
