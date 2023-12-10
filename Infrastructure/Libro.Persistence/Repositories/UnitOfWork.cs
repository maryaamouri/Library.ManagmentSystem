using AutoMapper;
using Libro.Domain.Books;
using Libro.Domain.Common;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;

namespace Libro.Persistence.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly LiboDbContext _context;
        private readonly IMapper _mapper;
        private IUserProfileRepository _userProfileRepository;
        private IBookRepository _bookRepository;
        private ITransactionRepository _transactionRepository;

        public UnitOfWork(LiboDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUserProfileRepository UserProfileRepository =>
            _userProfileRepository ??= new UserProfileRepository(_context, _mapper);

        public IBookRepository BookRepository =>
            _bookRepository ??= new BookRepository(_context, _mapper);

        public ITransactionRepository TransactionRepository =>
            _transactionRepository ??= new TransactionRepository(_context, _mapper);

        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
