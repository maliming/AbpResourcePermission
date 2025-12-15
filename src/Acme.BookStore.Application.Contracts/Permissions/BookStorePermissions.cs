namespace Acme.BookStore.Permissions;

public static class BookStorePermissions
{
    public const string GroupName = "BookStore";

    public static class Books
    {
        public const string Default = GroupName + ".Books";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
        public const string ManagePermissions = Default + ".ManagePermissions";
        
        public static class Resources
        {
            public const string Name = "Acme.BookStore.Books.Book";
            public const string ChangeName = Name + ".ChangeName";
            public const string ChangeType = Name + ".ChangeType";
            public const string ChangePrice = Name + ".ChangePrice";
        }
    }

    public static class Authors
    {
        public const string Default = GroupName + ".Authors";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
