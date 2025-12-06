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
    }

    // *** ADDED a NEW NESTED CLASS ***
    public static class Authors
    {
        public const string Default = GroupName + ".Authors";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Resources
    {
        public const string BookResourceName = "Acme.BookStore.Books.Book";

        public const string ManageChangeBookName = GroupName + ".Resources.ManageChangeBookName";
        public const string ManageChangeBookType = GroupName + ".Resources.ManageChangeBookType";
        public const string ManageChangeBookPrice = GroupName + ".Resources.ManageChangeBookPrice";

        public const string ChangeBookName = "ChangeBookName";
        public const string ChangeBookType = "ChangeBookType";
        public const string ChangeBookPrice = "ChangeBookPrice";
    }
}
