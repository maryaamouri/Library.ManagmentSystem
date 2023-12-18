using Libro.Domain.Common.Results;

namespace Libro.Domain.Books.Titles
{
    public static class TitleErrors
    {
        public static readonly Error TooLong =
            new("Title.TooLong",
                "The title is too long");

        public static readonly Error Empty =
            new("Title.Empty",
             "The title is empty");

        public static readonly Error TooShort =
           new("Title.TooShort",
               "The title is too short");

        public static readonly Error InvalidValue =
           new("Title.InvalidValue",
               "The title must be in valid format");
    }
}
