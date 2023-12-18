using AutoMapper;
using Libro.Domain.Books.Repositories;
using Libro.Domain.Common.Repositories;
using Libro.Domain.Transactions.Repository;
using Libro.Domain.UserProfiles;

namespace Libro.Persistence.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly LiboDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ITransactionRepository _transactionRepository;

        public UnitOfWork(LiboDbContext context, IMapper mapper)
        {
            Console.WriteLine("------------------******The UOW is created");
            _context = context;
            _mapper = mapper;
            _userProfileRepository = new UserProfileRepository(_context, _mapper);
            _bookRepository = new BookRepository(_context, _mapper);
            _transactionRepository = new TransactionRepository(_context, _mapper);
        }

        public IUserProfileRepository UserProfileRepository =>
            _userProfileRepository;

        public IBookRepository BookRepository =>
            _bookRepository;

        public ITransactionRepository TransactionRepository =>
            _transactionRepository;

        public async Task CommitChangesAsync()
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                await _context.SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
