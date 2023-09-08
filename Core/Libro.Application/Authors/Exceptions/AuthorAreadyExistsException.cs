using Libro.Application.Common.Exceptions;

namespace Libro.Application.Authors.Exceptions
{
    internal class AuthorAreadyExistsException : BadRequestException
    {
        public AuthorAreadyExistsException(string name)
            : base($"Author With Name {name} Already Exits")
        {
        }
    }
}