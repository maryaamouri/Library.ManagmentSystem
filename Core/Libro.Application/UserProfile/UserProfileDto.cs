using Libro.Domain.Books.Entities;
using Libro.Domain.Transactions.TransactionEntity;

namespace Libro.Application.UserProfile
{
    public class UserProfileDto
    {
        public Guid UserId { get; set; }
        public ICollection<Transaction> Transactions { get;  set; } 
        public ICollection<Book> CurrentlyBorrowdBooks { get;  set; } 
    }
}
