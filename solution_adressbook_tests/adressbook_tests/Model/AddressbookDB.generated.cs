﻿//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1591

using System;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

namespace DataModels
{
	/// <summary>
	/// Database       : addressbook
	/// Data Source    : localhost
	/// Server Version : 5.5.28
	/// </summary>
	public partial class AddressbookDB : LinqToDB.Data.DataConnection
	{
		public ITable<Addressbook>    Addressbooks    { get { return this.GetTable<Addressbook>(); } }
		public ITable<AddressInGroup> AddressInGroups { get { return this.GetTable<AddressInGroup>(); } }
		public ITable<GroupList>      GroupLists      { get { return this.GetTable<GroupList>(); } }
		public ITable<MonthLookup>    MonthLookups    { get { return this.GetTable<MonthLookup>(); } }
		public ITable<User>           Users           { get { return this.GetTable<User>(); } }

		public AddressbookDB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public AddressbookDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table("addressbook")]
	public partial class Addressbook
	{
		[Column("domain_id"),    NotNull              ] public uint      DomainId    { get; set; } // int(9) unsigned
		[Column("id"),           PrimaryKey,  Identity] public uint      Id          { get; set; } // int(9) unsigned
		[Column("firstname"),    NotNull              ] public string    Firstname   { get; set; } // varchar(255)
		[Column("middlename"),   NotNull              ] public string    Middlename  { get; set; } // varchar(255)
		[Column("lastname"),     NotNull              ] public string    Lastname    { get; set; } // varchar(255)
		[Column("nickname"),     NotNull              ] public string    Nickname    { get; set; } // varchar(255)
		[Column("company"),      NotNull              ] public string    Company     { get; set; } // varchar(255)
		[Column("title"),        NotNull              ] public string    Title       { get; set; } // varchar(255)
		[Column("address"),      NotNull              ] public string    Address     { get; set; } // text
		[Column("addr_long"),       Nullable          ] public string    AddrLong    { get; set; } // text
		[Column("addr_lat"),        Nullable          ] public string    AddrLat     { get; set; } // text
		[Column("addr_status"),     Nullable          ] public string    AddrStatus  { get; set; } // text
		[Column("home"),         NotNull              ] public string    Home        { get; set; } // text
		[Column("mobile"),       NotNull              ] public string    Mobile      { get; set; } // text
		[Column("work"),         NotNull              ] public string    Work        { get; set; } // text
		[Column("fax"),          NotNull              ] public string    Fax         { get; set; } // text
		[Column("email"),        NotNull              ] public string    Email       { get; set; } // text
		[Column("email2"),       NotNull              ] public string    Email2      { get; set; } // text
		[Column("email3"),       NotNull              ] public string    Email3      { get; set; } // text
		[Column("im"),           NotNull              ] public string    Im          { get; set; } // text
		[Column("im2"),          NotNull              ] public string    Im2         { get; set; } // text
		[Column("im3"),          NotNull              ] public string    Im3         { get; set; } // text
		[Column("homepage"),     NotNull              ] public string    Homepage    { get; set; } // text
		[Column("bday"),         NotNull              ] public sbyte     Bday        { get; set; } // tinyint(2)
		[Column("bmonth"),       NotNull              ] public string    Bmonth      { get; set; } // varchar(50)
		[Column("byear"),        NotNull              ] public string    Byear       { get; set; } // varchar(4)
		[Column("aday"),         NotNull              ] public sbyte     Aday        { get; set; } // tinyint(2)
		[Column("amonth"),       NotNull              ] public string    Amonth      { get; set; } // varchar(50)
		[Column("ayear"),        NotNull              ] public string    Ayear       { get; set; } // varchar(4)
		[Column("address2"),     NotNull              ] public string    Address2    { get; set; } // text
		[Column("phone2"),       NotNull              ] public string    Phone2      { get; set; } // text
		[Column("notes"),        NotNull              ] public string    Notes       { get; set; } // text
		[Column("photo"),           Nullable          ] public string    Photo       { get; set; } // mediumtext
		[Column("x_vcard"),         Nullable          ] public string    XVcard      { get; set; } // mediumtext
		[Column("x_activesync"),    Nullable          ] public string    XActivesync { get; set; } // mediumtext
		[Column("created"),         Nullable          ] public DateTime? Created     { get; set; } // datetime
		[Column("modified"),        Nullable          ] public DateTime? Modified    { get; set; } // datetime
		[Column("deprecated"),   NotNull              ] public DateTime  Deprecated  { get; set; } // datetime
		[Column("password"),        Nullable          ] public string    Password    { get; set; } // varchar(256)
		[Column("login"),           Nullable          ] public DateTime? Login       { get; set; } // date
		[Column("role"),            Nullable          ] public string    Role        { get; set; } // varchar(256)
	}

	[Table("address_in_groups")]
	public partial class AddressInGroup
	{
		[Column("domain_id"),                 NotNull] public uint      DomainId   { get; set; } // int(9) unsigned
		[Column("id"),         PrimaryKey(2), NotNull] public uint      Id         { get; set; } // int(9) unsigned
		[Column("group_id"),   PrimaryKey(1), NotNull] public uint      GroupId    { get; set; } // int(9) unsigned
		[Column("created"),       Nullable           ] public DateTime? Created    { get; set; } // datetime
		[Column("modified"),      Nullable           ] public DateTime? Modified   { get; set; } // datetime
		[Column("deprecated"),                NotNull] public DateTime  Deprecated { get; set; } // datetime
	}

	[Table("group_list")]
	public partial class GroupList
	{
		[Column("domain_id"),       NotNull              ] public uint      DomainId      { get; set; } // int(9) unsigned
		[Column("group_id"),        PrimaryKey,  Identity] public uint      GroupId       { get; set; } // int(9) unsigned
		[Column("group_parent_id"),    Nullable          ] public int?      GroupParentId { get; set; } // int(9)
		[Column("created"),            Nullable          ] public DateTime? Created       { get; set; } // datetime
		[Column("modified"),           Nullable          ] public DateTime? Modified      { get; set; } // datetime
		[Column("deprecated"),      NotNull              ] public DateTime  Deprecated    { get; set; } // datetime
		[Column("group_name"),      NotNull              ] public string    GroupName     { get; set; } // varchar(255)
		[Column("group_header"),    NotNull              ] public string    GroupHeader   { get; set; } // mediumtext
		[Column("group_footer"),    NotNull              ] public string    GroupFooter   { get; set; } // mediumtext
	}

	[Table("month_lookup")]
	public partial class MonthLookup
	{
		[Column("bmonth"),                   NotNull] public string Bmonth      { get; set; } // varchar(50)
		[Column("bmonth_short"),             NotNull] public string BmonthShort { get; set; } // char(3)
		[Column("bmonth_num"),   PrimaryKey, NotNull] public uint   BmonthNum   { get; set; } // int(2) unsigned
	}

	[Table("users")]
	public partial class User
	{
		[Column("user_id"),           PrimaryKey,  Identity] public int       UserId           { get; set; } // int(11)
		[Column("domain_id"),         NotNull              ] public uint      DomainId         { get; set; } // int(9) unsigned
		[Column("username"),          NotNull              ] public string    Username         { get; set; } // char(128)
		[Column("md5_pass"),          NotNull              ] public string    Md5Pass          { get; set; } // char(128)
		[Column("password_hint"),     NotNull              ] public string    PasswordHint     { get; set; } // varchar(255)
		[Column("sso_facebook_uid"),     Nullable          ] public string    SsoFacebookUid   { get; set; } // varchar(255)
		[Column("sso_google_uid"),       Nullable          ] public string    SsoGoogleUid     { get; set; } // varchar(255)
		[Column("sso_live_uid"),         Nullable          ] public string    SsoLiveUid       { get; set; } // varchar(255)
		[Column("sso_yahoo_uid"),        Nullable          ] public string    SsoYahooUid      { get; set; } // varchar(255)
		[Column("lastname"),          NotNull              ] public string    Lastname         { get; set; } // varchar(50)
		[Column("firstname"),         NotNull              ] public string    Firstname        { get; set; } // varchar(50)
		[Column("email"),             NotNull              ] public string    Email            { get; set; } // varchar(100)
		[Column("phone"),             NotNull              ] public string    Phone            { get; set; } // varchar(50)
		[Column("address1"),          NotNull              ] public string    Address1         { get; set; } // varchar(100)
		[Column("address2"),          NotNull              ] public string    Address2         { get; set; } // varchar(100)
		[Column("city"),              NotNull              ] public string    City             { get; set; } // varchar(80)
		[Column("state"),             NotNull              ] public string    State            { get; set; } // varchar(20)
		[Column("zip"),               NotNull              ] public string    Zip              { get; set; } // varchar(20)
		[Column("country"),           NotNull              ] public string    Country          { get; set; } // varchar(50)
		[Column("master_code"),       NotNull              ] public string    MasterCode       { get; set; } // char(128)
		[Column("confirmation_code"),    Nullable          ] public string    ConfirmationCode { get; set; } // char(128)
		[Column("pass_reset_code"),      Nullable          ] public string    PassResetCode    { get; set; } // char(128)
		/// <summary>
		/// New, Ready, Blocked
		/// </summary>
		[Column("status"),            NotNull              ] public string    Status           { get; set; } // char(128)
		[Column("trials"),            NotNull              ] public int       Trials           { get; set; } // int(11)
		[Column("created"),              Nullable          ] public DateTime? Created          { get; set; } // datetime
		[Column("modified"),             Nullable          ] public DateTime? Modified         { get; set; } // datetime
		[Column("deprecated"),           Nullable          ] public DateTime? Deprecated       { get; set; } // datetime
	}

	public static partial class TableExtensions
	{
		public static Addressbook Find(this ITable<Addressbook> table, uint Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static AddressInGroup Find(this ITable<AddressInGroup> table, uint Id, uint GroupId)
		{
			return table.FirstOrDefault(t =>
				t.Id      == Id &&
				t.GroupId == GroupId);
		}

		public static GroupList Find(this ITable<GroupList> table, uint GroupId)
		{
			return table.FirstOrDefault(t =>
				t.GroupId == GroupId);
		}

		public static MonthLookup Find(this ITable<MonthLookup> table, uint BmonthNum)
		{
			return table.FirstOrDefault(t =>
				t.BmonthNum == BmonthNum);
		}

		public static User Find(this ITable<User> table, int UserId)
		{
			return table.FirstOrDefault(t =>
				t.UserId == UserId);
		}
	}
}

#pragma warning restore 1591
