namespace Libro.Application.Transations
{
 
    public class TransactionDto
    {
        public Guid TransactionId {  set; get; }
        public Guid BookId { get; set; }
        public Guid PatronId { get; set; }
        public Guid? ConfirmedReturnBookLibrarianId { get; set; }
        public Guid? ConfirmedReceiptBookLibrarianId { get;  set; }
        public DateTime ReservationDate {  set; get; }
        public DateTime? ReceiptDate {  set; get; } 
        public DateTime? DueDate {  set; get; } 
        public DateTime? ReturnedDate {  set; get; }
        public bool IsReceipted { get; set; } 
        public bool IsReturned { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsDeleted { get; set; }

        public bool IOvereDuted()
        {
            return ReturnedDate < DueDate;
        }
    }

}
