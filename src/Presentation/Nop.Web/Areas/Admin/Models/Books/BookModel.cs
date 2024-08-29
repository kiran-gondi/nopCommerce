using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Books;

public partial record BookModel : BaseNopEntityModel
{
    public string Name { get; set; }
    public DateTime CreatedOn { get; set; }
}
