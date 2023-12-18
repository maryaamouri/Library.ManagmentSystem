using Libro.Domain.Common.Results;

namespace Libro.Domain.Authors.Descriptions
{
    internal static class DescriptionErrors
    {
        public static readonly Error TooLong = new
            ("Author.Description.TooLong",
            "Author Description is too long");
        public static readonly Error TooShort = new
             ("Author.Description.TooShort",
            "Description is too long");
        public static readonly Error InValidFormat = new
            ("Author.Description.InValidFormat",
            "Author Description is not in valid format.");
        public static readonly Error Empty = new
             ("Author.Description.Empty",
            "Author Description is Empty");
    }
}
