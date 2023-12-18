using Libro.Domain.Common.Results;

namespace Libro.Domain.Books.Availablity
{
    internal static class AvailabilityErrors
    {
        public static Error MaxLimit = new(
            "AvailabileCopies.MaxLimit",
            "The number of copies exceeds the maximum limit.");

        public static Error NegativeValue = new(
            "AvailabileCopies.NegativeValue",
            "No copies available.");

    }
}
