using Libro.Domain.Authors.AuthorEntity;

namespace Libro.Application.Books
{
    public class BookDto
    {
        public Guid BookId { get; private set; }
        public required string Title { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string? Genre { set; get; } = string.Empty;
        public Guid? AuthorId { get; set; } = null;
        public Author? Author { get; set; } = null;
        public DateTime? PublicationDate { get; set; } = null;
        public bool IsAvailable { get; internal set; } = true;
    }
}
