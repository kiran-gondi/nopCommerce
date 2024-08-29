using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.Books;

public partial record BookSearchModel : BaseSearchModel
{
    public string Name { get; set; }
}
