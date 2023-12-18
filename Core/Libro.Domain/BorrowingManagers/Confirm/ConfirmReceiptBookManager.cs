using Libro.Domain.Books.Entities;
using Libro.Domain.Common.Results;
using Libro.Domain.Transactions.TransactionEntity;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.BorowingManagers.Confirm
{
    public class ConfirmReceiptBookManager : IConfirmReceiptBookManager
    {
        public Result<Transaction> Confirm(Book book, Transaction transaction, UserProfile librarian)
        {
            if (transaction.BookId != book.BookId)
                Result<Transaction>.Failure(ConfirmReceiptBookErrors.TransactionBookMismatch);

            transaction.ReceiptBook(librarian.UserId);
  
            return transaction;
        }
    }
}
