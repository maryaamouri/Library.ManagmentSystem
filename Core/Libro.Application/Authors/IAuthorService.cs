using Libro.Application.Common.Absractions;

namespace Libro.Application.Authors
{
    public interface IAuthorService : IService<AuthorRequest, AuthorDto>
    {
    }
}