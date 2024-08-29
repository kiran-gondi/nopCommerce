using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Books;

namespace Nop.Data.Mapping.Builders.Books;
public partial class BookMap : NopEntityBuilder<Book>
{
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(Book.Id)).AsInt32().PrimaryKey().Identity()
             .WithColumn(nameof(Book.Name)).AsString(int.MaxValue).NotNullable()
             .WithColumn(nameof(Book.CreatedOn)).AsDateTime().NotNullable();
    }
}
