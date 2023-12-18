using AutoMapper;
using Libro.Domain.Transactions.Repository;
using Libro.Domain.Transactions.TransactionEntity;
using Microsoft.EntityFrameworkCore;

namespace Libro.Persistence.Repositories
{
    internal sealed class TransactionRepository : ITransactionRepository
    {
        private readonly IMapper _mapper;
        private readonly LiboDbContext _dbContext;

        public TransactionRepository(LiboDbContext dbContext, IMapper mapper)
        {
            Console.WriteLine("--------------------------The Transaction Repository is created----------------------------");
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Transaction> CreateAsync(Transaction transaction)
        {

            var dbTransaction = _mapper.Map<DbModels.Transaction>(transaction);
            _dbContext.Transactions.Add(dbTransaction);
            return _mapper.Map<Transaction>(dbTransaction);
        }
        public async Task<IList<Transaction>> GetAsync()
        {
            var dbTransactions = await _dbContext.Transactions.ToListAsync();
            return _mapper.Map<IList<Transaction>>(dbTransactions);
        }

        public async Task<Transaction> GetByIdAsync(Guid id)
        {
            var dbTransaction = await _dbContext.Transactions.FirstOrDefaultAsync(t => t.TransactionId == id);
            return _mapper.Map<Transaction>(dbTransaction);
        }

        public async Task UpdateAsync(Transaction transaction)
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
