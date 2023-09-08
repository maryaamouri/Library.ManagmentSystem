namespace Libro.Application.Common.Exceptions
{
    internal class BadRequestException : ApplicationException
    {
        public BadRequestException(string? message)
            : base(message)
        {
        }
    }
}
