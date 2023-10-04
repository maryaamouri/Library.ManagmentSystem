using Libro.Domain.Books;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IUserProfileRepository UserProfileRepository { get; }
        IBookRepository BookRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        Task CommitChangesAsync();
    }
}
