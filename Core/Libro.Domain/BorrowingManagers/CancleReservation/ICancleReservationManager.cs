using Libro.Domain.Books.Entities;
using Libro.Domain.Common.Results;
using Libro.Domain.Transactions.TransactionEntity;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.BorowingManagers.CancleReservation
{
    public interface ICancleReservationManager
    {
        Result<Transaction> Cancle(Book book, UserProfile profile, Transaction transaction);
    }
}