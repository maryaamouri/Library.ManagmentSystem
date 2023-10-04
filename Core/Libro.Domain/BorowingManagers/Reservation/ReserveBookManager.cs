using Libro.Domain.Books;
using Libro.Domain.Common;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;
namespace Libro.Domain.BorowingManagers.Reservation
{
    public class ReserveBookManager : IReserveBookManager
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionFactory _transactionFactory;
        private readonly IUnitOfWork _unitOfWork;

        public ReserveBookManager(
            IUserProfileRepository userProfileRepository,
            IBookRepository bookRepository,
            ITransactionRepository transactionRepository,
            ITransactionFactory transactionFactory, 
            IUnitOfWork unitOfWork)
        {
            _userProfileRepository = userProfileRepository;
            _bookRepository = bookRepository;
            _transactionRepository = transactionRepository;
            _transactionFactory = transactionFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Transaction> ReserveBook(Book book, UserProfile profile)
        {
            if (profile.GetNumberOfCurrentlyBorrowdBooks() > 5)
                throw new Exception("You reached the maximum number of borrowd books already.");

            if (!book.IsAvailable)
                throw new Exception("The current book is not available, check in 7 days");

            if (profile.HasOverDutedBooks())
                throw new Exception("Cannot Reserve book before return the overduted.");

            profile.AddBorrowdBook(book);
            var transaction = _transactionFactory.Create(book.BookId, profile.UserId);
            book.IsAvailable = false;
            profile.AddTransaction(transaction);

            // unit of work
            await _transactionRepository.CreateAsync(transaction);
            await _userProfileRepository.UpdateAsync(profile);
            await _bookRepository.UpdateAsync(book);

            return transaction;
        }


    }
}
