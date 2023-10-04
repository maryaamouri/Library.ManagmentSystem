using Libro.Domain.Books;
using Libro.Domain.Transactions;
using Libro.Domain.UserProfiles;

namespace Libro.Domain.BorowingManagers.Confirm
{
    public class ConfirmReceiptBookManager : IConfirmReceiptBookManager
    {
        private readonly ITransactionRepository _transactionRepository;

        public ConfirmReceiptBookManager(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction> Confirm(Book book, Transaction transaction, UserProfile librarian)
        {
            if (transaction.BookId != book.BookId)
                throw new Exception("");

            transaction.ReceiptBook(librarian.UserId);
            await _transactionRepository.UpdateAsync(transaction);
            return transaction;
        }
    }
}
