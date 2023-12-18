using Libro.Domain.Configurations;
using Libro.Domain.Transactions.TransactionEntity;

namespace Libro.Domain.Transactions.Factory
{
    public class TransactionFactory : ITransactionFactory
    {
        public Transaction Create
        (
            Guid bookId,
            Guid patronId
        )
        {
            var reservationDate = DateTime.UtcNow;
            var DueDate = SetDueToDate();
            return new Transaction(bookId, patronId, reservationDate, DueDate.Result);
        }

        public Transaction CreateTransactionWithDetails(
            Guid bookId,
            Guid patronId,
            Guid? confirmedReturnBookLibrarianId,
            Guid? confirmedReceiptBookLibrarianId,
            DateTime reservationDate,
            DateTime? receiptDate,
            DateTime? dueDate,
            DateTime? returnedDate)
        {
            var isReturned = returnedDate != null;
            var isReceipted = receiptDate != null;
            var isCanceled = false;
            var isDeleted = false;

            if (dueDate < reservationDate)
                throw new Exception("Due Date Must be before Reservation Date.");

            if (isReceipted)
            {
                if (receiptDate < reservationDate)
                    throw new Exception("Reservation Date must be befor Receiption.");
            }
            if (isReturned && !isReceipted)
            {
                throw new Exception("The Book Cannot be returned before Recipted");
            }
            if (isReturned)
            {
                if (returnedDate < reservationDate)
                    throw new Exception("Return Date Must be before Reservation Date.");
                if (returnedDate < receiptDate)
                    throw new Exception("Return Date Must be before Reservation Date.");
            }




            return new Transaction(
                bookId,
                patronId,
                confirmedReturnBookLibrarianId,
                confirmedReceiptBookLibrarianId,
                reservationDate,
                receiptDate,
                dueDate,
                returnedDate,
                isReceipted,
                isReturned,
                isCanceled,
                isDeleted);
        }
        private async Task<DateTime> SetDueToDate()
        {
            var today = DateTime.UtcNow;
            return today.AddDays(BorrowingConfigurations.DueToDays);
        }

    }
}
