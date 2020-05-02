using LinqToDB;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    [Table("address_in_groups")]
    class GroupContactRelation : LinqToDB.Data.DataConnection
    {
        public GroupContactRelation() : base("Addressbook")
        {

        }

        [Column("id"), PrimaryKey(2), NotNull] public string Id { get; set; }
        [Column("group_id"), PrimaryKey(1), NotNull] public string Group_Id { get; set; }
        [Column("deprecated")] public string Deprecated { get; set; }

        public ITable<GroupContactRelation> GroupsContacts { get { return GetTable<GroupContactRelation>(); } }
    }
}
