using Libro.Domain.Books;
using Libro.Domain.Transactions;

namespace Libro.Domain.UserProfiles
{
    public class UserProfile
    {
        public Guid UserProfileId { get; set; }
        public IList<Transaction> Transactions { get; private set; } = new List<Transaction>();
        public IList<Book> BorrowdBooks { get; private set; } = new List<Book>();
        public void AddBorrowdBook(Book book)
        {
            if (book is not null)
                BorrowdBooks.Add(book);
        }
        public void AddTransaction(Transaction tran)
        {
            if (tran is not null)
                Transactions.Add(tran);
        }
    }
}
