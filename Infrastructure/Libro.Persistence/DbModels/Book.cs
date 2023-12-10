namespace Libro.Persistence.DbModels
{
    internal class Book
    {
        internal Book(Guid bookId,
            string title,
                string? description,
            string? genre,
            Guid? authorId,
            DateTime? publicationDate, 
            bool isAvailable)
        {
            BookId = bookId;
            Title = title;
            Description = description;
            Genre = genre;
            AuthorId = authorId;
            PublicationDate = publicationDate;
            IsAvailable = isAvailable;
        }

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
