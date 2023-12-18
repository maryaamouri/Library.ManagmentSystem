using Libro.Domain.Common.Results;

namespace Libro.Domain.Authors.Names
{
    internal static class NameErrors
    {
        public static readonly Error TooLong = new
            ("AuthorName.TooLong",
            "Author name is too long");
        public static readonly Error TooShort = new
             ("AuthorName.TooShort",
            "Author name is too long");
        public static readonly Error InValidFormat = new
            ("AuthorName.InValidFormat",
            "Author name is not in valid format.");
        public static readonly Error Empty = new
             ("AuthorName.Empty",
            "Author name is Empty");
    }
}
