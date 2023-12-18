using Libro.Domain.Common.Results;

namespace Libro.Domain.Books.Entities
{
    internal class BookErrors
    {
        public static Error MaxAvailableCopies = new(
           "AvailabileCopies.MaxLimit",
           "The number of copies exceeds the maximum limit.");

        public static Error MinAviableCopies = new(
            "AvailabileCopies.MinLimit",
            "No copies available.");
    }
}
