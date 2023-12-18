namespace Libro.Application.Authors.CreateAuthor
{
    public record CreateAuthorResponse
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }    
        public DateOnly DateOfBirth { get; set; }
        public DateOnly DateOfDeath { get; set; }

    }
}
