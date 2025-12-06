using Acme.BookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.BookStore.Permissions;

public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var bookStoreGroup = context.AddGroup(BookStorePermissions.GroupName, L("Permission:BookStore"));

        var booksPermission = bookStoreGroup.AddPermission(BookStorePermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(BookStorePermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(BookStorePermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(BookStorePermissions.Books.Delete, L("Permission:Books.Delete"));

        var authorsPermission = bookStoreGroup.AddPermission(
            BookStorePermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(
            BookStorePermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(
            BookStorePermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(
            BookStorePermissions.Authors.Delete, L("Permission:Authors.Delete"));

        AddBookStoreResourcePermission(context);
    }

    protected virtual void AddBookStoreResourcePermission(IPermissionDefinitionContext context)
    {
        var bookStoreGroup = context.GetGroup(BookStorePermissions.GroupName);

        bookStoreGroup.AddPermission(BookStorePermissions.Resources.ManageChangeBookName, L("Manage change book name"));
        context.AddResourcePermission(BookStorePermissions.Resources.ChangeBookName,
            BookStorePermissions.Resources.BookResourceName,
            BookStorePermissions.Resources.ManageChangeBookName,
            L("Change book name"));

        bookStoreGroup.AddPermission(BookStorePermissions.Resources.ManageChangeBookType, L("Manage change book type"));
        context.AddResourcePermission(BookStorePermissions.Resources.ChangeBookPrice,
            BookStorePermissions.Resources.BookResourceName,
            BookStorePermissions.Resources.ManageChangeBookType,
            L("Change book type"));

        bookStoreGroup.AddPermission(BookStorePermissions.Resources.ManageChangeBookPrice, L("Manage change book price"));
        context.AddResourcePermission(BookStorePermissions.Resources.ChangeBookType,
            BookStorePermissions.Resources.BookResourceName,
            BookStorePermissions.Resources.ManageChangeBookPrice,
            L("Change book price"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookStoreResource>(name);
    }
}
