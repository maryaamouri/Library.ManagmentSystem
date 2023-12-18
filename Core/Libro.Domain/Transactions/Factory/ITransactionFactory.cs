using Libro.Domain.Transactions.TransactionEntity;

namespace Libro.Domain.Transactions.Factory
{
    public interface ITransactionFactory
    {
        internal Transaction Create
       (
           Guid bookId,
           Guid patronId
       );
        public Transaction CreateTransactionWithDetails(
            Guid bookId,
            Guid patronId,
            Guid? confirmedReturnBookLibrarianId,
            Guid? confirmedReceiptBookLibrarianId,
            DateTime reservationDate,
            DateTime? receiptDate,
            DateTime? dueDate,
            DateTime? returnedDate);
    }
}