using Libro.Domain.Authors.AuthorEntity;
using Libro.Domain.Common.Repositories;

namespace Libro.Domain.Authors.Repository
{
    public interface IAuthorRepository : IRepository<Author>
    {
    }
}
