using Libro.Domain.Common.Results;

namespace Libro.Domain.BorowingManagers.Reservation
{
    public static class ReserveBookErrors
    {
        public static readonly Error MaxBorrowedBooks = new 
       (
            "MAX_BORR_LIMIT",
            "Maximum borrowed books limit (5) reached. Return books to reserve more."
        );

        public static readonly Error BookNotAvailable = new 
        (
            "BOOK_NOT_AVAIL",
            "Selected book not available. Try again in 7 days."
        );

        public static readonly Error ReturnOverdueBeforeReserve = new Error
         (
             "RETURN_OVERDUE",
             "You have overdue books that must be returned before you can reserve another book."
         );

    }
}
