using Libro.Domain.Books.Entities;
using Libro.Domain.Common.Results;
using Libro.Domain.Transactions.TransactionEntity;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.BorowingManagers.CancleReservation
{
    public class CancleReservationManager : ICancleReservationManager
    {
        public Result<Transaction> Cancle(Book book, UserProfile profile, Transaction transaction)
        {
            if (book.BookId != transaction.BookId)
                return Result<Transaction>.Failure(CancleReservationErrors.InvalidBookCancellation);

            if (profile.UserId != transaction.PatronId)
                return Result<Transaction>.Failure(CancleReservationErrors.UnauthorizedCancellation);

            profile.RemoveFromTransaction(transaction);
            profile.RemoveFromCurrentlyBorrowd(book);

            book.IsAvailable = true;
            transaction.CancleReservation();

            profile.AddTransaction(transaction);

            return transaction;
        }
    }
}
