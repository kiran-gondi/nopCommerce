using AutoMapper;
using Nop.Core.Domain.Books;
using Nop.Web.Areas.Admin.Models.Books;

namespace Nop.Web.Areas.Admin;

public static class MappingExtensions
{
    public static BookModel ToModel(this Book entity)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Book, BookModel>();
        });
        IMapper iMapper = config.CreateMapper();
        return iMapper.Map<Book, BookModel>(entity);
    }

    public static Book ToEntity(this BookModel model)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Book, BookModel>();
            cfg.CreateMap<BookModel, Book>();
        });
        IMapper iMapper = config.CreateMapper();
        return iMapper.Map<BookModel, Book>(model);
    }
}
