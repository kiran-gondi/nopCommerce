namespace Nop.Core.Domain.Books;
public partial class Book : BaseEntity
{
    public string Name { get; set; }

    public DateTime CreatedOn { get; set; }
}
