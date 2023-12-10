namespace Libro.Persistence.DbModels
{
    internal class UserProfile
    {
        public UserProfile(Guid userId)
        {
            UserId = userId;
            Transactions = new List<Transaction>();  
            BorrowedBooks = new List<Book>();
        }

        public Guid UserId { get; set; }
        public IList<Transaction> Transactions { get;  set;}
        public IList<Book> BorrowedBooks { get;  set; }
    }
}
