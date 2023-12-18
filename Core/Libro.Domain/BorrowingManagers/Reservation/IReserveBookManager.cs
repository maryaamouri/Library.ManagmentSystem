using Libro.Domain.Books.Entities;
using Libro.Domain.Common.Results;
using Libro.Domain.Transactions.TransactionEntity;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.BorowingManagers.Reservation
{
    public interface IReserveBookManager
    {
        Result<Transaction> ReserveBook(Book book, UserProfile profile);
    }
}