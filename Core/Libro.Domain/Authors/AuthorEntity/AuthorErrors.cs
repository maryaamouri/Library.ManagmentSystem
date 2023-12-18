using Libro.Domain.Common.Results;

namespace Libro.Domain.Authors.AuthorEntity
{
    internal static class AuthorErrors
    {
        public static readonly Error AlreadyHasThisBook = new(
            "Author.Books.AlreadyHas",
            "Author already Has This Book.");

        public static readonly Error DoseNotHasBook = new(
            "Author.Books.HasNot", 
            "Author dose not has book.");
    }
}
