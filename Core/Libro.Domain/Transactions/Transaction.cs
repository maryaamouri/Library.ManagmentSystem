namespace Libro.Domain.Transactions
{
    public class Transaction
    {
        public Guid TransactionId { set; get; }
        public Guid BookId { get; set; }
        public Guid PatronId { get; set; }
        public Guid? LibrarianId { get; set; }
        public DateTime BorrowedDate { set; get; }
        public DateTime? DueDate { set; get; }
        public bool? IsAcepted { get; set; }
        public bool IsCanceled { get; set; } = false;   
        public DateTime? ActualReturnedDate { set; get; }
    }
}
