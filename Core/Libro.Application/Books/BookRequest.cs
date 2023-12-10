namespace Libro.Application.Books
{
    public class BookRequest
    {
        public required string Title { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string? Genre { set; get; } = string.Empty;
        public Guid? AuthorId { get; set; }
        public DateTime? PublicationDate { get; set; } = null;
    }
}
