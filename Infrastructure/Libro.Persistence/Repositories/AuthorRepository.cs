using AutoMapper;
using Libro.Domain.Authors;

namespace Libro.Persistence.Repositories
{
    internal sealed class AuthorRepository : GenericRepository<Author, DbModels.Author>, IAuthorRepository
    {
        public AuthorRepository(LiboDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
