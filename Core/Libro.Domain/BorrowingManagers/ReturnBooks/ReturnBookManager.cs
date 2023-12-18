using Libro.Domain.Books.Entities;
using Libro.Domain.Common.Results;
using Libro.Domain.Transactions.TransactionEntity;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.BorowingManagers.ReturnBooks
{
    public class ReturnBookManager : IReturnBookManager
    {
        public Result<Transaction> ReturnBook(Transaction transaction, Book book ,UserProfile patronProfile,Guid librarianProfile)
        {
            if (transaction.BookId != book.BookId)
            {
                return Result<Transaction>.Failure(ReturnBookErrors.TransactionBookMismatch);
            }

            transaction.ReturnBook(librarianProfile);
            patronProfile.RemoveFromTransaction(transaction);
            patronProfile.RemoveFromCurrentlyBorrowd(book);

            book.IsAvailable = true;
            transaction.CancleReservation();

            patronProfile.AddTransaction(transaction);

            return transaction;
        }

    }
}
