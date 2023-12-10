using Libro.Domain.Books;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.BorowingManagers.Reservation
{
    public interface IReserveBookManager
    {
        Task<Transaction> ReserveBook(Book book, UserProfile profile);
    }
}