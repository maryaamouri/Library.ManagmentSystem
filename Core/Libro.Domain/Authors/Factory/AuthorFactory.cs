using Libro.Domain.Authors.AuthorEntity;
using Libro.Domain.Authors.AuthorIds;
using Libro.Domain.Authors.Descriptions;
using Libro.Domain.Authors.Names;
using Libro.Domain.Authors.Nationalities;
using Libro.Domain.Authors.Periods;
using Libro.Domain.Common.Results;

namespace Libro.Domain.Authors.Factory
{
    public class AuthorFactory : IAuthorFactory
    {
        public Result<Author> Create(string name, string description,string nationality,DateOnly birthdate, DateOnly death)
        {
            var authorId = new AuthorId(Guid.NewGuid());
            var NameResult = Name.Create(name);
            var PeriodResult = Period.Create(birthdate,death);
            var NationalityResult = Nationality.Create(nationality);
            var authorBooks = new List<Books.BookIds.BookId>();
            var DescriptionResult = Description.Create(description);

            if(NameResult.IsFailure)
            {
                return Result<Author>.Failure(NameResult.Error);
            }
            if (PeriodResult.IsFailure)
            {
                return Result<Author>.Failure(PeriodResult.Error);
            }
            if (NationalityResult.IsFailure)
            {
                return Result<Author>.Failure(NationalityResult.Error);
            }
            if (DescriptionResult.IsFailure)
            {
                return Result<Author>.Failure(DescriptionResult.Error);
            }
            var author = new Author(
                authorId,
                NameResult.Value,
                DescriptionResult.Value,
                NationalityResult.Value,
                PeriodResult.Value,
                authorBooks);
            return Result<Author>.Success(author);
        }
    }
}
