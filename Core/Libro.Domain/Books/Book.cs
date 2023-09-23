using Libro.Domain.Authors;

namespace Libro.Domain.Books
{
    public class Book
    {
        public Guid BookId { get; private set; }
        public required string Title { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string? Genre { set; get; } = string.Empty;
        public Guid? AuthorId { get; set; }
        public Author? Author { get; set; } = null;
        public DateTime? PublicationDate { get; set; } = null;
        public bool IsAvailable { get; set; } = true;

    }
}
