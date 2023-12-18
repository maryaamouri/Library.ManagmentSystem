using Libro.Domain.Common.Results;

namespace Libro.Domain.BorowingManagers.CancleReservation
{
    internal static class CancleReservationErrors
    {
        public static readonly Error UnauthorizedCancellation = new 
        (
            "UNAUTHORIZED_CANCELLATION",
            "You are not authorized to cancel this reservation since it wasn't made by you."
        );
        public static readonly Error InvalidBookCancellation = new 
        (
            "INVALID_BOOK_CANCELLATION",
            "You can only cancel reservations for the book you originally reserved."
        );

    }
}
