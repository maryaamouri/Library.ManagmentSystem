namespace Libro.Application.Borrowing.ConfirmReceipt
{
    public sealed class ConfitmRecieptResponse
    {
        public Guid TransactionId {  set; get; }
        public Guid BookId { get;  set; }
        public Guid PatronId { get;  set; }
        public Guid? LibrarianId { get; set; }
        public DateTime ReservationDate {  set; get; }
        public DateTime? ReceiptDate {  set; get; } = null;
        public DateTime? DueDate {  set; get; } = null;

    }
}
