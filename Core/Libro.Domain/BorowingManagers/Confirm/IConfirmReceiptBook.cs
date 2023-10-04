using Libro.Domain.Books;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.BorowingManagers.Confirm
{
    public interface IConfirmReceiptBookManager
    {
        Task<Transaction> Confirm(Book book, Transaction transaction, UserProfile librarian);
    }
}