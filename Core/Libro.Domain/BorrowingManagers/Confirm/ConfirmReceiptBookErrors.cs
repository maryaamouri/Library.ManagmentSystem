using Libro.Domain.Common.Results;

namespace Libro.Domain.BorowingManagers.Confirm
{
    internal static class ConfirmReceiptBookErrors
    {
       
        public static readonly Error TransactionBookMismatch = new
        (
            "TRANSACTION_BOOK_MISMATCH",
            "The transaction does not match the specified book. Unable to confirm receipt."
        );
    }
}
