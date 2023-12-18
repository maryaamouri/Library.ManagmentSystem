using Libro.Domain.Books.Entities;
using Libro.Domain.Common.Repositories;

namespace Libro.Domain.Books.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
    }
}
