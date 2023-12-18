using Libro.Domain.Books.Entities;
using Libro.Domain.Common.Results;
using Libro.Domain.Transactions.TransactionEntity;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.BorowingManagers.Confirm
{
    public interface IConfirmReceiptBookManager
    {
        Result<Transaction> Confirm(Book book, Transaction transaction, UserProfile librarian);
    }
}