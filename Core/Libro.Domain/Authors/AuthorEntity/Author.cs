using Libro.Domain.Authors.AuthorIds;
using Libro.Domain.Authors.Descriptions;
using Libro.Domain.Authors.Names;
using Libro.Domain.Authors.Nationalities;
using Libro.Domain.Authors.Periods;
using Libro.Domain.Books.BookIds;
using Libro.Domain.Common.Results;

namespace Libro.Domain.Authors.AuthorEntity
{
    public class Author
    {
        internal Author(
            AuthorId authorId,
            Name name,
            Description description,
            Nationality nationality,
            Period period,
            IList<BookId> booksWrot)
        {
            AuthorId = authorId;
            Name = name;
            Description = description;
            Nationality = nationality;
            Period = period;
            BooksWrot = booksWrot;
        }

        public AuthorId AuthorId { get; private set; }
        public Name Name { get; private set; }
        public Description Description { get; set; }
        public Nationality Nationality { get; private set; }
        public Period Period { get; private set; }
        public IList<BookId> BooksWrot { get; private set; }

        public Result AddBook(BookId bookId)
        {
            if (BooksWrot.Contains(bookId))
                return Result.Failure(AuthorErrors.AlreadyHasThisBook);
            BooksWrot.Add(bookId);
            return Result.Success();
        }
        public Result RemoveBook(BookId bookId)
        {
            if (!BooksWrot.Contains(bookId))
                return Result.Failure(AuthorErrors.DoseNotHasBook);
            BooksWrot.Remove(bookId);
            return Result.Success();
        }

    }
}
