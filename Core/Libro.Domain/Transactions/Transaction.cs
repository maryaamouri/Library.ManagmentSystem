using Microsoft.VisualBasic;

namespace Libro.Domain.Transactions
{
    public class Transaction
    {
        internal Transaction(
            Guid bookId, 
            Guid patronId,
            DateTime reservationDate,
            DateTime dueDate)
        : this(bookId, patronId)
        {
            TransactionId = Guid.NewGuid();
            ReservationDate = reservationDate;
            DueDate = dueDate;
        }

        internal Transaction(Guid bookId, 
            Guid patronId, 
            Guid? librarianId,
            DateTime reservationDate,
            DateTime dueDate,
            DateTime? receiptDate,
            DateTime? returnedDate, 
            bool isReceipted) : this(bookId, patronId)
        {
            LibrarianId = librarianId;
            ReservationDate = reservationDate;
            ReceiptDate = receiptDate;
            DueDate = dueDate;
            ReturnedDate = returnedDate;
            IsReceipted = isReceipted;
        }

        private Transaction(Guid bookId, Guid patronId)
        {
            BookId = bookId;
            PatronId = patronId;
        }

        public Guid TransactionId { private set; get; }
        public Guid BookId { get; private set; }
        public Guid PatronId { get; private set; }
        public Guid? LibrarianId { get;  private set; }
        public DateTime ReservationDate { private set; get; }
        public DateTime? ReceiptDate { private set; get; } = null;
        public DateTime? DueDate { private set; get; } = null;
        public DateTime? ReturnedDate { private set; get; } = null;
        public bool IsReceipted { get; private set; } = false;
        public bool IsReturned { get; private set; } = false;   
        public bool IsCanceled { get; private set; } = false;
        public bool IsDeleted { get; private set; } = false;
        
        public bool IOvereDuted()
        {
            return ReturnedDate < DueDate;
        }
        internal void ReceiptBook(Guid librarianId)
        {
            if (IsDeleted)
                throw new Exception("Cannot Receipt Book After Transaction Already Deleted.");

            if(IsCanceled)
                throw new Exception("Cannot Receipt Book After Transaction Canceled.");

            if (IsReceipted)
                throw new Exception("Book Already Receipted.");

            IsReceipted = true;
            this.LibrarianId = librarianId;
            ReceiptDate = DateTime.UtcNow;
        }
       
        internal void CancleReservation()
        {
            if (IsDeleted)
                throw new Exception("Cannot Return Book After Transaction is Deleted.");

            if (IsCanceled)
                throw new Exception("Book Reservation Already Canclled.");

            if (IsReceipted)
                throw new Exception("Cannot Cancle Reservation After Already Reciepted the Book.");
            IsCanceled = true;
        }
        internal void ReturnBook()
        {
            if (IsDeleted)
                throw new Exception("Cannot Return Book After Transaction Already Deleted.");

            if(!IsReceipted)
                throw new Exception("Cannot Return Book Before Receipted.");

            if (IsReturned)
                throw new Exception("Book Already Returned.");

            IsReturned = true;
            ReturnedDate = DateTime.UtcNow;
        }
        public void DeleteTransaction()
        {
            if (IsDeleted)
                throw new Exception("Book Transaction Already Deleted.");

            IsDeleted = true;
        }

    }
}
