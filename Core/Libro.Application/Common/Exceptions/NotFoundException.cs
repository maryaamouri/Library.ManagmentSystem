namespace Libro.Application.Common.Exceptions
{
    internal class NotFoundException : ApplicationException
    {
        public NotFoundException(string? name)
            : base($"{name} Not Was Found")
        {
        }

        public NotFoundException(string name, object key)
            : base($"{name} ({key}) was not found.")
        {
        }
    }
}
