using Microsoft.AspNetCore.Mvc;
using Nop.Services.Books;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin;
using Nop.Web.Areas.Admin.Controllers;
using Nop.Web.Areas.Admin.Models.Books;

namespace Nop.Web.Controllers;
public class BookController : BaseAdminController
{
    protected readonly IBookService _bookService;
    protected readonly ILocalizationService _localizationService;

    public BookController(IBookService bookService, ILocalizationService localizationService)
    {
        _bookService = bookService;
        _localizationService = localizationService;
    }

    public IActionResult List()
    {
        var books = _bookService.GetAllBooks().Select(b => b.ToModel()).ToList();
        return View(books);
    }

    [HttpPost]
    public IActionResult List(BookSearchModel searchModel)
    {
        ViewBag.SearchName = searchModel.Name;
        //prepare model
        var books = _bookService.GetAllBooks().Where(b => b.Name.Contains(searchModel.Name)).Select(b => b.ToModel()).ToList();
        return View(books);
    }

    #region Create / Edit / Delete

    public virtual IActionResult Create()
    {
        //prepare model
        var model = new BookModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult Create(BookModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var book = model.ToEntity();
        book.CreatedOn = DateTime.UtcNow;
        _bookService.InsertBook(book);

        return RedirectToAction("List");
    }

    public IActionResult Edit(int id)
    {
        //try to get a category with the specified id
        var book = _bookService.GetBookById(id);
        if (book == null)
            return RedirectToAction("List");

        //prepare model
        var model = book.ToModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(BookModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        var book = model.ToEntity();
        _bookService.UpdateBook(book);

        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        //try to get a book with the specified id
        var book = _bookService.GetBookById(id);
        if (book == null)
            return RedirectToAction("List");

        _bookService.DeleteBook(book);

        //activity log
        return RedirectToAction("List");
    }

    #endregion
}
