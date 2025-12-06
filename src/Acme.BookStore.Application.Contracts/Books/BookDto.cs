using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Authorization.Permissions.Resources;

namespace Acme.BookStore.Books;

public class BookDto : AuditedEntityDto<Guid>, IHasResourcePermissions
{
    public string Name { get; set; }

    public BookType Type { get; set; }

    public DateTime PublishDate { get; set; }

    public float Price { get; set; }

    public Guid AuthorId { get; set; }

    public string AuthorName { get; set; }

    public Dictionary<string, bool> ResourcePermissions { get; set; }
}
