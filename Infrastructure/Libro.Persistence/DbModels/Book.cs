namespace Libro.Persistence.DbModels
{
    internal class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; } 
        public string? Genre { set; get; }
        public Guid? AuthorId { get; set; }
        public DateTime? PublicationDate { get; set; } 
        public bool IsAvailable { get; set; }
        public Guid? BorrowedBy { get; set; }
    }
}
