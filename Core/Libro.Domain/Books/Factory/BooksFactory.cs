using Libro.Domain.Authors.AuthorIds;
using Libro.Domain.Books.Availablity;
using Libro.Domain.Books.BookIds;
using Libro.Domain.Books.Descriptions;
using Libro.Domain.Books.Entities;
using Libro.Domain.Books.Genres;
using Libro.Domain.Books.Publications;
using Libro.Domain.Books.Titles;
using Libro.Domain.Common.Results;
using Libro.Domain.UserProfiles.UserId;

namespace Libro.Domain.Books.Factories
{
    public class BooksFactory
    {
        public Result<Book> Create(
            string title,
            string description,
            string gener,
            Guid authorId,
            DateOnly publicationDate,
            int copies,
            string publicatoinBy)
        {
            var bookId = new BookId(Guid.NewGuid());
            var newAuthorId = new AuthorId(authorId);
            var borrowedBy = new List<UserId>();

            var titleResult = Title.Create(title);
            var descriptionResult = Description.Create(description);
            var generResult = Gener.Create(gener);
            var avilabilityResult = Availability.Create(copies);
            var publicationResult = Publication.Create(publicationDate,publicatoinBy);

            if (titleResult.IsFailure)
                return Result<Book>.Failure(titleResult.Error);

            if (descriptionResult.IsFailure)
                return Result<Book>.Failure(descriptionResult.Error);

            if(publicationResult.IsFailure)    
                return Result<Book>.Failure(publicationResult.Error);

            if(generResult.IsFailure)
                return Result<Book>.Failure(generResult.Error);

            if (avilabilityResult.IsFailure)
                return Result<Book>.Failure(avilabilityResult.Error);

            var book = new Book(
                bookId,
                titleResult.Value,
                descriptionResult.Value,
                generResult.Value,
                newAuthorId,
                avilabilityResult.Value,
                publicationResult.Value,
                borrowedBy);

            return book;    

    }
}
}