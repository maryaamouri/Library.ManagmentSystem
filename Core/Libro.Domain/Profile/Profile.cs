using Libro.Domain.Books;
using System.Transactions;

namespace Libro.Domain.Models
{
    public class Profile
    {
        public Guid ProfileId { get; set; }
        public IList<Transaction> Transactions { get; private set; } = new List<Transaction>();
        public IList<Book> BorrowdBooks { get; private set; } = new List<Book>();
        public void AddBorrowdBook(Book book)
        {
            if(book is not null) 
                BorrowdBooks.Add(book);
        }
        public void AddTransaction(Transaction tran)
        {
            if (tran is not null)
                Transactions.Add(tran);
        }
    }
}
