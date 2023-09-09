using AutoMapper;
using Libro.Domain.Transactions;

namespace Libro.Persistence.Repositories
{
    public sealed class TransactionRepository : GenericRepository<Transaction, DbModels.Transaction>, ITransactionRepository
    {
        public TransactionRepository(LiboDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
