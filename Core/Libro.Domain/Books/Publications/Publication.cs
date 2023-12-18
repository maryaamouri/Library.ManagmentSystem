using Libro.Domain.Common.Results;
using Libro.Domain.Common.ValueObjects;

namespace Libro.Domain.Books.Publications
{
    public class Publication : ValueObject
    {
        public DateOnly PublicationDate { get; }
        public string PublicationBy { get; }

        private Publication(DateOnly publicationDate, string publicationBy)
        {
            PublicationDate = publicationDate;
            PublicationBy = publicationBy;
        }

        public static Result<Publication> Create(DateOnly publicationDate, string publicationBy)
        {
            if (publicationDate <= DateOnly.MinValue)
            {
                return Result<Publication>.Failure(PublicationErrors.InvalidPublicationDate);
            }
            if (publicationDate > DateOnly.FromDateTime(DateTime.UtcNow))
            {
                return Result<Publication>.Failure(PublicationErrors.PublicationInFuture);
            }
            if (string.IsNullOrWhiteSpace(publicationBy))
            {
                return Result<Publication>.Failure(PublicationErrors.PublicationByRequired);
            }

            return Result<Publication>.Success(new Publication(publicationDate, publicationBy));
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return PublicationDate;
            yield return PublicationBy;
        }
    }
}
