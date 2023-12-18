using Libro.Domain.Books.Entities;
using Libro.Domain.Common.Results;
using Libro.Domain.Configurations;
using Libro.Domain.Transactions.Factory;
using Libro.Domain.Transactions.TransactionEntity;
using Libro.Domain.UserProfiles;
namespace Libro.Domain.BorowingManagers.Reservation
{
    public class ReserveBookManager : IReserveBookManager
    {
        private readonly ITransactionFactory _transactionFactory;

        public ReserveBookManager(ITransactionFactory transactionFactory)
        {
            Console.WriteLine("Inside Doamin");
            _transactionFactory = transactionFactory;
        }

        public Result<Transaction> ReserveBook(Book book, UserProfile profile)
        {
            if (profile.GetNumberOfCurrentlyBorrowdBooks() > BorrowingConfigurations.MaximumNumberOfBooks)
                return Result<Transaction>.Failure(ReserveBookErrors.MaxBorrowedBooks);

            if (!book.IsAvailable)
                return Result<Transaction>.Failure(ReserveBookErrors.BookNotAvailable);

            if (profile.HasOverDutedBooks())
                return Result<Transaction>.Failure(ReserveBookErrors.ReturnOverdueBeforeReserve);

            profile.AddBorrowdBook(book);
            var transaction = _transactionFactory.Create(book.BookId, profile.UserId);
            book.IsAvailable = false;
            profile.AddTransaction(transaction);
            return transaction;
        }
    }
}
