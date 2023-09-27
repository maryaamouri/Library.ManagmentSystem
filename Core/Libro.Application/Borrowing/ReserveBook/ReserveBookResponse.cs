namespace Libro.Application.Borrowing.Reservation
{
    public class ReserveBookResponse
    {
        public ReserveBookResponse(
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

