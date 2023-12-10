using Libro.Application.Common.Absractions;

namespace Libro.Application.Books
{
    public interface IBookService : IService<BookRequest, BookDto>
    {
        public Task<BookDto> AddAuthor(Guid author, Guid book);
        public Task<BookDto> RemoveAuthor(Guid book);
    }
}
