namespace Libro.Application.Books.Exceptions
{
    internal class BookAlreadyExists : BadRequestException
    {
        public BookAlreadyExists(string title)
            : base($"Book With Title {title} Already Exits")
        {
        }
    }
}
