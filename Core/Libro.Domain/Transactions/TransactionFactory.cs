namespace Libro.Domain.Transactions
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
            Guid? librarianId,
            DateTime reservationDate,
            DateTime dueDate,
            DateTime? receiptDate,
            DateTime? returnedDate,
            bool isReceipted = false)
        {
            // Add validation to the Dates
            if (dueDate < reservationDate)
                throw new Exception("Due Date Must be before Reservation Date.");
            if (returnedDate < reservationDate)
                throw new Exception("Return Date Must be before Reservation Date.");
            if (returnedDate < reservationDate)
                throw new Exception("Return Date Must be before Reservation Date.");
            if (receiptDate < reservationDate == null)
                throw new Exception("Reservation Date must be befor Receiption.");

            return new Transaction(bookId, patronId, librarianId, reservationDate, receiptDate.Value, dueDate, returnedDate, isReceipted);
        }
        private async Task<DateTime> SetDueToDate()
        {
            var today = DateTime.UtcNow;
            var MaxTime = 7;
            return today.AddDays(MaxTime);
        }
    }
}
