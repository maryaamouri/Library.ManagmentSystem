namespace Libro.Persistence.DbModels
{
    internal class Transaction
    {
        public Transaction(Guid transactionId,
            Guid bookId, Guid patronId, Guid? librarianId, DateTime reservationDate, DateTime? receiptDate, DateTime? dueDate, DateTime? returnedDate, bool isReceipted, bool isReturned, bool isCanceled, bool isDeleted)
        {
            TransactionId = transactionId;
            BookId = bookId;
            PatronId = patronId;
            LibrarianId = librarianId;
            ReservationDate = reservationDate;
            ReceiptDate = receiptDate;
            DueDate = dueDate;
            ReturnedDate = returnedDate;
            IsReceipted = isReceipted;
            IsReturned = isReturned;
            IsCanceled = isCanceled;
            IsDeleted = isDeleted;
        }

        public Guid TransactionId { private set; get; }
        public Guid BookId { get; set; }
        public Guid PatronId { get; set; }
        public Guid? LibrarianId { get; set; }
        public DateTime ReservationDate {  set; get; }
        public DateTime? ReceiptDate {  set; get; } = null;
        public DateTime? DueDate {  set; get; } = null;
        public DateTime? ReturnedDate {  set; get; } = null;
        public bool IsReceipted { get;  set; } = false;
        public bool IsReturned { get; set; } = false;
        public bool IsCanceled { get;  set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}
