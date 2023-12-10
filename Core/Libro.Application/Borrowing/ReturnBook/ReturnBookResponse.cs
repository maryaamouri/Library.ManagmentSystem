namespace Libro.Application.Borrowing.ReturnBook
{
    public sealed class ReturnBookResponse
    {
        public Guid TransactionId { set; get; }
        public Guid BookId { get; set; }
        public Guid PatronId { get; set; }
        public Guid? LibrarianId { get; set; }
        public DateTime ReservationDate { set; get; }
        public DateTime? ReceiptDate { set; get; } = null;
        public DateTime? DueDate { set; get; } = null;
        public DateTime? ReturnedDate { set; get; } = null;
        public bool IsReturned { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}
