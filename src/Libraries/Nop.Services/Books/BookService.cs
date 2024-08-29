using Nop.Core.Domain.Books;
using Nop.Data;

namespace Nop.Services.Books;
public partial class BookService : IBookService
{
    private readonly IRepository<Book> _bookRepository; 
    public BookService(IRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public void InsertBook(Book book)
    {
        _bookRepository.Insert(book);
    }

    public void UpdateBook(Book book)
    {
        _bookRepository.Update(book);
    }

    public IList<Book> GetAllBooks(string name = null)
    {
        var bookQuery = _bookRepository.Table;
        if (!string.IsNullOrEmpty(name))
        {
            bookQuery = bookQuery.Where(b=>b.Name == name);
        }
        return bookQuery.ToList();
    }

    public Book GetBookById(int bookId)
    {
        return _bookRepository.GetById(bookId);
    }

    public void DeleteBook(Book book)
    {
        _bookRepository.Delete(book);
    }
}
