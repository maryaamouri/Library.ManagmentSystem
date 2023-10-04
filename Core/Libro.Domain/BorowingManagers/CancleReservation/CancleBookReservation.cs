using Libro.Domain.Books;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.BorowingManagers.CancleReservation
{
    public class CancleReservationManager : ICancleReservationManager
    {

        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ITransactionRepository _transactionRepository;

        public CancleReservationManager(
            IUserProfileRepository userProfileRepository,
            IBookRepository bookRepository,
            ITransactionRepository transactionRepository)
        {
            _userProfileRepository = userProfileRepository;
            _bookRepository = bookRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction> Cancle(Book book, UserProfile profile, Transaction transaction)
        {
            if (book.BookId != transaction.BookId)
                profile.RemoveFromCurrentlyBorrowd(book);

            if (profile.UserId != transaction.PatronId)
                profile.RemoveFromCurrentlyBorrowd(book);

            profile.RemoveFromTransaction(transaction);
            profile.RemoveFromCurrentlyBorrowd(book);

            book.IsAvailable = true;
            transaction.CancleReservation();

            profile.AddTransaction(transaction);
            

            // unit of work
            await _transactionRepository.CreateAsync(transaction);
            await _userProfileRepository.UpdateAsync(profile);
            await _bookRepository.UpdateAsync(book);

            return transaction;
        }
    }
}
