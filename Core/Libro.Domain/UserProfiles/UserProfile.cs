using Libro.Domain.Books;
using Libro.Domain.Transactions;

namespace Libro.Domain.UserProfiles
{
    public class UserProfile
    {
        public UserProfile(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
        public IList<Transaction> Transactions { get; private set; } = new List<Transaction>();
        public IList<Book> CurrentlyBorrowdBooks { get; private set; } = new List<Book>();
        public void AddBorrowdBook(Book book)
        {
            if (book is not null)
                CurrentlyBorrowdBooks.Add(book);
        }
        public void AddTransaction(Transaction tran)
        {
            if (tran is not null)
                Transactions.Add(tran);
        }
        public int GetNumberOfCurrentlyBorrowdBooks()
        {
            return CurrentlyBorrowdBooks.Count;  
        }
        public bool HasOverDutedBooks()
        {
            var overduted = Transactions
                .FirstOrDefault(trans => trans.DueDate < DateTime.UtcNow);
            return overduted == null;
        }
        internal void RemoveFromCurrentlyBorrowd(Book book)
        {
            CurrentlyBorrowdBooks.Remove(book);
        }
        internal void RemoveFromTransaction(Transaction tran)
        {
            Transactions.Remove(tran);  
        }
    }
}
