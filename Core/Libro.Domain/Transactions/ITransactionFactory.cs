namespace Libro.Domain.Transactions
{
    public interface ITransactionFactory
    {
        internal Transaction Create(Guid bookId, Guid patronId);
        public Transaction CreateTransactionWithDetails(Guid bookId, Guid patronId, Guid? librarianId, DateTime reservationDate, DateTime dueDate, DateTime? receiptDate, DateTime? returnedDate, bool isReceipted);
    }
}