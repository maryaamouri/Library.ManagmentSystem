namespace Libro.Persistence.DbModels
{
    internal class Transaction
    {
        public Guid TransactionId { set; get; }
        public Guid BookId { get; set; }
        public Guid PatronId { get; set; }
        public Guid? ConfirmedReturnBookLibrarianId { get; set; }
        public Guid? ConfirmedReceiptBookLibrarianId { get;  set; }
        public DateTime ReservationDate { private set; get; }
        public DateTime? ReceiptDate { private set; get; } = null;
        public DateTime? DueDate { private set; get; } = null;
        public DateTime? ReturnedDate { set; get; } = null;
        public bool IsReceipted { get; set; } = false;
        public bool IsReturned { get; set; } = false;
        public bool IsCanceled { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}
