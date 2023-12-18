using Libro.Domain.Books.Entities;
using Libro.Domain.Common.Results;
using Libro.Domain.Transactions.TransactionEntity;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.BorowingManagers.ReturnBooks
{
    public interface IReturnBookManager
    {
        Result<Transaction> ReturnBook(Transaction transaction, Book book, UserProfile patronProfile, Guid librarianId);
    }
}