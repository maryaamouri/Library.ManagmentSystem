using Libro.Domain.Books;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.BorowingManagers.ReturnBooks
{
    public interface IReturnBookManager
    {
        Task<Transaction> ReturnBook(Transaction transaction, Book book, UserProfile userProfile);
    }
}