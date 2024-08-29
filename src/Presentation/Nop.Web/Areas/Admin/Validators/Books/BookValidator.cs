using FluentValidation;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.Books;
using Nop.Web.Framework.Validators;

namespace Nop.Web.Areas.Admin.Validators.Books;

public class BookValidator : BaseNopValidator<BookModel>
{
    public BookValidator(ILocalizationService localizationService)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Name is Required."));
    }
}
