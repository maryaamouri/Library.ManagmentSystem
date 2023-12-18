using Libro.Domain.Authors.AuthorEntity;
using Libro.Domain.Common.Results;

namespace Libro.Domain.Authors.Factory
{
    public interface IAuthorFactory
    {
        public Result<Author> Create(string name, string description, string nationality, DateOnly birthdate, DateOnly death);

    }
}