namespace Libro.Application.Books.Exceptions
{
    internal class BookAlreadyHasAuthor : BadRequestException
    {
        public BookAlreadyHasAuthor(string bookName, string authorName, string preAuthorName)
            : base($"Book {bookName} already has author {preAuthorName} cannot add {authorName}")
        {
        }
    }
}
