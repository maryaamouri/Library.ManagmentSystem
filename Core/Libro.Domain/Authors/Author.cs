namespace Libro.Domain.Authors
{
    public class Author
    {
        public Author(string name)
        {
            AuthorId = Guid.NewGuid();
            Name = name;
        }

        public Guid AuthorId { get;private set; }
        public string Name { get; set; }
    }
}
