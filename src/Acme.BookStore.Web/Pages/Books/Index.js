$(function () {
    var l = abp.localization.getResource('BookStore');
    var createModal = new abp.ModalManager(abp.appPath + 'Books/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Books/EditModal');
    var _resourcePermissionsModal = new abp.ModalManager({
        viewUrl: abp.appPath + "AbpPermissionManagement/ResourcePermissionManagementModal",
        modalClass: 'ResourcePermissionManagement'
    });

    var dataTable = $('#BooksTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.bookStore.books.book.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('BookStore.Books.Edit'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('BookStore.Books.Delete'), //CHECK for the PERMISSION
                                    confirmMessage: function (data) {
                                        return l(
                                            'BookDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        acme.bookStore.books.book
                                            .delete(data.record.id)
                                            .then(function() {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                },
                                {
                                    text: l('ResourcePermissions'),
                                    visible: abp.auth.isGranted('BookStore.Books.ManagePermissions'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        _resourcePermissionsModal.open({
                                            resourceName: 'Acme.BookStore.Books.Book',
                                            resourceKey: data.record.id,
                                            resourceDisplayName: data.record.name
                                        });

                                    },
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('ResourcePermissions'),
                    data: "type",
                    render: function (data, type, row) {
                        return "<code>" + JSON.stringify(row.resourcePermissions, null, 2) + "</code>";
                    }
                },
                {
                    title: l('Author'),
                    data: "authorName"
                },
                {
                    title: l('Type'),
                    data: "type",
                    render: function (data) {
                        return l('Enum:BookType.' + data);
                    }
                },
                {
                    title: l('PublishDate'),
                    data: "publishDate",
                    dataFormat: "datetime"
                },
                {
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    dataFormat: "datetime"
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    _resourcePermissionsModal.onClose(function () {
        dataTable.ajax.reload();
    });

    $('#NewBookButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
