using Libro.Domain.Common.Results;

namespace Libro.Domain.Books.Descriptions
{
    internal static class DescriptionErrors
    {
        public static Error Empty = new(
            "Description.Empty",
            "Description is a required field and cannot be empty.");

        public static Error TooLong = new(
            "Description.TooLong",
            "Description should not exceed a certain character limit.");

        public static Error TooShort = new(
            "Description.Tooshort.",
            "Description should be at least a certain character length.");

        public static Error InvalidValue = new(
            " description.InvalidFormat.",
            "Description contains invalid characters or format.");
    }
}
