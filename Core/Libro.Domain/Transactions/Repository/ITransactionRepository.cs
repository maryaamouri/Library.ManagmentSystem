using Libro.Domain.Transactions.TransactionEntity;

namespace Libro.Domain.Transactions.Repository
{
    public interface ITransactionRepository
    {
        Task<Transaction> CreateAsync(Transaction transaction);
        Task UpdateAsync(Transaction transaction);
        Task<Transaction> GetByIdAsync(Guid id);
        Task<IList<Transaction>> GetAsync();
        Task SaveChangesAsync();
    }
}
