namespace Libro.Persistence.DbModels
{
    public class Transaction
    {
        public Guid TransactionId { private set; get; }
        public Guid BookId { get; set; }
        public Guid PatronId { get; set; }
        public Guid? LibrarianId { get; set; }
        public DateTime? BorrowedDate { set; get; }
        public DateTime? DueDate { set; get; }
        public bool? IsAccepted { get; set; } = null;
        public bool IsCancled { get; set; } = false;   
        public DateTime? ActualReturnedDate { set; get; }
    }
}
