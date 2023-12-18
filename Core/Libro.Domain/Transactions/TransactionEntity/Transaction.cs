using Libro.Domain.Books.BookIds;
using Libro.Domain.Transactions.TransactionIds;
using Libro.Domain.UserProfiles.UserId;

namespace Libro.Domain.Transactions.TransactionEntity
{
    public class Transaction
    {
        //internal Transaction(
        //    Guid bookId, 
        //    Guid patronId,
        //    DateTime reservationDate,
        //    DateTime dueDate)
        //: this(bookId, patronId)
        //{
        //    TransactionId = Guid.NewGuid();
        //    ReservationDate = reservationDate;
        //    DueDate = dueDate;
        //}



        //private Transaction(Guid bookId, Guid patronId)
        //{
        //    BookId = bookId;
        //    PatronId = patronId;
        //}

        //public Transaction(Guid bookId,
        //                   Guid patronId,
        //                   Guid? confirmedReturnBookLibrarianId,
        //                   Guid? confirmedReceiptBookLibrarianId,
        //                   DateTime reservationDate,
        //                   DateTime? receiptDate,
        //                   DateTime? dueDate,
        //                   DateTime? returnedDate,
        //                   bool isReceipted,
        //                   bool isReturned,
        //                   bool isCanceled,
        //                   bool isDeleted) : this(bookId, patronId)
        //{
        //    ConfirmedReturnBookLibrarianId = confirmedReturnBookLibrarianId;
        //    ConfirmedReceiptBookLibrarianId = confirmedReceiptBookLibrarianId;
        //    ReservationDate = reservationDate;
        //    ReceiptDate = receiptDate;
        //    DueDate = dueDate;
        //    ReturnedDate = returnedDate;
        //    IsReceipted = isReceipted;
        //    IsReturned = isReturned;
        //    IsCanceled = isCanceled;
        //    IsDeleted = isDeleted;
        //}

        public TransactionId TransactionId { private set; get; }
        public BookId BookId { get; private set; }
        public UserId PatronId { get; private set; }
        public UserId? ConfirmedReturnBookLibrarianId { get; private set; }
        public UserId? ConfirmedReceiptBookLibrarianId { get; private set; }
        public DateTime ReservationDate { private set; get; }
        public DateTime? ReceiptDate { private set; get; } = null;
        public DateTime? DueDate { private set; get; } = null;
        public DateTime? ReturnedDate { private set; get; } = null;
        public bool IsReceipted { get; private set; } = false;
        public bool IsReturned { get; private set; } = false;
        public bool IsCanceled { get; private set; } = false;
        public bool IsDeleted { get; private set; } = false;

        public bool IsOvereDuted()
        {
            return ReturnedDate < DueDate;
        }
        internal void ReceiptBook(Guid librarianId)
        {
            if (IsDeleted)
                throw new Exception("Cannot Receipt Book After Transaction Already Deleted.");

            if (IsCanceled)
                throw new Exception("Cannot Receipt Book After Transaction Canceled.");

            if (IsReceipted)
                throw new Exception("Book Already Receipted.");

            IsReceipted = true;
            ConfirmedReceiptBookLibrarianId = librarianId;
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
        internal void ReturnBook(Guid librarianId)
        {
            if (IsDeleted)
                throw new Exception("Cannot Return Book After Transaction Already Deleted.");

            if (!IsReceipted)
                throw new Exception("Cannot Return Book Before Receipted.");

            if (IsReturned)
                throw new Exception("Book Already Returned.");

            IsReturned = true;
            ConfirmedReturnBookLibrarianId = librarianId;
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
