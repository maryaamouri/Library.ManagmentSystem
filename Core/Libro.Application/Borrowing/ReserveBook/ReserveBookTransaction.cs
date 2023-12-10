namespace Libro.Application.Borrowing.Reservation
{
    internal class ReserveBookTransaction
    {
        public ReserveBookTransaction(
            Guid bookId,
            Guid patronId)
        {
            BookId = bookId;
            PatronId = patronId;
        }

        public Guid TransactionId { set; get; }
        public Guid BookId { get; set; }
        public Guid PatronId { get; set; }
    }
}
