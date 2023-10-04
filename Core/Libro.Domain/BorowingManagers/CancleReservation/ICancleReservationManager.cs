using Libro.Domain.Books;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.BorowingManagers.CancleReservation
{
    public interface ICancleReservationManager
    {
        Task<Transaction> Cancle(Book book, UserProfile profile, Transaction transaction);
    }
}