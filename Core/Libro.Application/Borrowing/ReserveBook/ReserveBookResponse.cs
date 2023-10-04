namespace Libro.Application.Borrowing.Reservation
{
    public class ReserveBookResponse
    {
        public Guid TransactionId {  set; get; }
        public Guid BookId { get;  set; }
        public Guid PatronId { get;  set; }
        public DateTime ReservationDate {  set; get; }
        public DateTime DueDate {  set; get; } 
    }
}

