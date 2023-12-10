using Libro.Domain.Books;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.BorowingManagers.ReturnBooks
{
    public class ReturnBookManager : IReturnBookManager
    {
        private readonly IBookRepository _bookRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public ReturnBookManager
        (
            IBookRepository bookRepository,
            ITransactionRepository transactionRepository,
            IUserProfileRepository userProfileRepository)
        {
            _bookRepository = bookRepository;
            _transactionRepository = transactionRepository;
            _userProfileRepository = userProfileRepository;
        }

        public async Task<Transaction> ReturnBook(Transaction transaction, Book book, UserProfile userProfile)
        {
            if (transaction.BookId != book.BookId)
            {
                throw new Exception();
            }
            if (transaction.PatronId != userProfile.UserId)
            {
                throw new Exception();
            }

            transaction.ReturnBook();
            book.IsAvailable = true;
            userProfile.RemoveFromCurrentlyBorrowd(book);

            //UOW

            await _bookRepository.UpdateAsync(book);
            await _transactionRepository.UpdateAsync(transaction);
            await _userProfileRepository.UpdateAsync(userProfile);

            return transaction;
        }
    }
}
