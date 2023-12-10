namespace Libro.Application.Books
{
    public interface ISearchFroBookService
    {
        public Task<IList<BookDto>> SearchByTitle(string title);
        public Task<IList<BookDto>> SearchByPublishDate(DateTime dateTime);
        public Task<IList<BookDto>> SearchByAuthor(Guid AuthorId); 
        public Task<IList<BookDto>> SearchByGenre(string authorName);
    }
}
