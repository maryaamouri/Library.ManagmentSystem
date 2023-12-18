namespace Libro.Persistence.DbModels
{
    internal class UserProfile
    {        public Guid UserId { get; set; }
        public IList<Transaction> Transactions { get;  set;} = new List<Transaction>();
        public IList<Book> CurrentlyBorrowdBooks { get; set; } = new List<Book>();  
    }
}
