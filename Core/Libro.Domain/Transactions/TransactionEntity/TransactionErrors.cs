using Libro.Domain.Common.Results;

namespace Libro.Domain.Transactions.TransactionEntity
{
    internal static class TransactionErrors
    {

        public static readonly Error ReceiptAfterDelete = new
        (
            "RECEIPT_AFTER_DELETE",
            "Cannot receipt a book after the transaction has been deleted."
        );

        public static readonly Error ReceiptAfterCancellation = new
        (
            "RECEIPT_AFTER_CANCELLATION",
            "Cannot receipt a book after the reservation has been canceled."
        );

        public static readonly Error AlreadyReceipted = new
        (
            "ALREADY_RECEIPTED",
            "The book has already been receipted."
        );

        public static readonly Error CancellationAfterReceipt = new
        (
            "CANCELLATION_AFTER_RECEIPT",
            "Cannot cancel a reservation after the book has been receipted."
        );

        public static readonly Error ReturnAfterDelete = new
        (
            "RETURN_AFTER_DELETE",
            "Cannot return a book after the transaction has been deleted."
        );

        public static readonly Error ReturnBeforeReceipt = new
        (
            "RETURN_BEFORE_RECEIPT",
            "Cannot return a book before it has been receipted."
        );

        public static readonly Error AlreadyReturned = new
        (
            "ALREADY_RETURNED",
            "The book has already been returned."
        );

        public static readonly Error DeleteAlreadyDeleted = new Error
        (
            "DELETE_ALREADY_DELETED",
            "The transaction has already been deleted."
        );
    }
}
