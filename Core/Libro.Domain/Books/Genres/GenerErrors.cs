using Libro.Domain.Common.Results;

namespace Libro.Domain.Books.Genres
{
    internal static class GenerErrors
    {
        public static readonly Error Empty = new(
            "Genre.Empty",
            "Genre is a required field and cannot be empty."
        );

        public static readonly Error MaxLength = new(
            "Genre.Toolong",
            "Genre should not exceed a certain character limit."
        );

        public static readonly Error MinLength = new(
            "Genre.TooShort",
            "Genre should be at least a certain character length."
        );

        public static readonly Error InvalidValue = new(
            "Genre.InvalidFormat",
            "Genre contains invalid characters or format."
        );
    }
}
