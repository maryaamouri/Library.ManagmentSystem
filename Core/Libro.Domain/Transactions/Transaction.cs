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
        public Status Status { get; set; }
        public DateTime? ActualReturnedDate { set; get; }
    }
    public enum Status
    {
        Accepted,
        Rejected,
        Pinned
    }
}
