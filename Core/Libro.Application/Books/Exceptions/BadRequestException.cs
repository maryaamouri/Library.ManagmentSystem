namespace Libro.Application.Books.Exceptions
{
    internal class BadRequestException : ApplicationException
    {
        public BadRequestException(string? message)
            : base(message)
        {
        }
    }
}
