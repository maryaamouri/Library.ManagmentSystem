using AutoMapper;
using Libro.Domain.Books.Entities;
using Libro.Domain.Books.Repositories;

namespace Libro.Persistence.Repositories
{
    internal sealed class BookRepository : GenericRepository<Book, DbModels.Book>, IBookRepository
    {
        public BookRepository(LiboDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            Console.WriteLine("--------------------------The Book Repository is created----------------------------");
        }
    }
}
