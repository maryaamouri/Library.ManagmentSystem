namespace Libro.Application.Borrowing.CancleReservation
{
    public sealed class CancleReservationResponse
    {
        public Guid TransactionId { set; get; }
        public Guid BookId { get; set; }
        public Guid PatronId { get; set; }
        public DateTime ReservationDate { set; get; }
        public bool IsCanceled { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}
