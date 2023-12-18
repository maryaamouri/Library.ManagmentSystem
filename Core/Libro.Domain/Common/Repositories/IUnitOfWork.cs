using Libro.Domain.Books.Repositories;
using Libro.Domain.Transactions.Repository;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.Common.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserProfileRepository UserProfileRepository { get; }
        IBookRepository BookRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        Task CommitChangesAsync();
    }
}
