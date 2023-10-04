using AutoMapper;
using Libro.Domain.Transactions;
using Libro.Persistence.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Libro.Persistence.Repositories
{
    internal sealed class TransactionRepository : ITransactionRepository
    {
        private readonly IMapper _mapper;
        private readonly LiboDbContext _dbContext;

        public TransactionRepository(LiboDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Domain.Transactions.Transaction> CreateAsync(Domain.Transactions.Transaction transaction)
        {

            var dbTransaction = _mapper.Map<DbModels.Transaction>(transaction);
            _dbContext.Transactions.Add(dbTransaction);
            return _mapper.Map<Domain.Transactions.Transaction>(dbTransaction);
        }
        public async Task<IList<Domain.Transactions.Transaction>> GetAsync()
        {
            var dbTransactions = await _dbContext.Transactions.ToListAsync();
            return _mapper.Map<IList<Domain.Transactions.Transaction>>(dbTransactions);
        }

        public async Task<Domain.Transactions.Transaction> GetByIdAsync(Guid id)
        {
            var dbTransaction = await _dbContext.Transactions.FirstOrDefaultAsync(t => t.TransactionId == id);
            return _mapper.Map<Domain.Transactions.Transaction>(dbTransaction);
        }

        public async Task UpdateAsync(Domain.Transactions.Transaction transaction)
        {
            var dbTransaction = _mapper.Map<DbModels.Transaction>(transaction);
            _dbContext.Entry(dbTransaction).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
