using Libro.Domain.Authors.AuthorIds;
using Libro.Domain.Books.Descriptions;
using Libro.Domain.Books.BookIds;
using Libro.Domain.Books.Genres;
using Libro.Domain.Books.Titles;
using Libro.Domain.Common.Results;
using Libro.Domain.Books.Availablity;
using Libro.Domain.Books.Publications;
using Libro.Domain.UserProfiles.UserId;

namespace Libro.Domain.Books.Entities
{
    public class Book
    {
        internal Book(
            BookId bookId,
            Title title,
            Description description,
            Gener genre,
            AuthorId authorId,
            Availability availability,
            Publication publicationDate,
            IList<UserId> borrowedBy)
        {
            BookId = bookId;
            Title = title;
            Description = description;
            Genre = genre;
            AuthorId = authorId;
            Availability = availability;
            PublicationDate = publicationDate;
            BorrowedBy = borrowedBy;
        }

        public BookId BookId { get; private set; }
        public Title Title { get; set; }
        public Description Description { get; set; }
        public Gener Genre { set; get; }
        public AuthorId AuthorId { get; set; }
        public Availability Availability { get; set; }
        public Publication PublicationDate { get; set; }
        public IList<UserId> BorrowedBy { get; private set; }

        // mark the book as unavailable, just check if there is available copis
        internal Result Reserve(Guid userId)
        {
            var result = Availability.Create(Availability.AvailableCopies-1);
            if(result.IsSuccess)
            {
                var borrower = new UserId(userId);
                BorrowedBy.Add(borrower);
            }
            return result;  
        }
        internal Result UnReserve(Guid userId)
        {
            // need to check wather it is the same person borrowed the book
            var result = Availability.Create(Availability.AvailableCopies + 1);
            if (result.IsSuccess)
            {
                var borrower = new UserId(userId);
                BorrowedBy.Remove(borrower);
            }
            return result;
        }
        internal Result<Availability> AddCopies(int copies)
        {
            var result = Availability.Create(copies + Availability.AvailableCopies);
            if(result.IsSuccess)
            {
                Availability = result.Value;
            }
            return result;

        }
        internal Result RemoveCopies(int copies)
        {
            var result = Availability.Create(Availability.AvailableCopies - copies);
            if (result.IsSuccess)
            {
                Availability = result.Value;
            }
            return result;
        }
    }
}
