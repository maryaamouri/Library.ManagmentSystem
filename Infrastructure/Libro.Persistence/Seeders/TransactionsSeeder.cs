using Libro.Persistence.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.UserProfile;

namespace Libro.Persistence.Seeders
{
    internal static class TransactionsSeeder
    {
        internal static void Seed(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasData(
                new
                {
                    TransactionId = TransactionIds.Transaction1Id,
                    BookId = BookSeeder.BookIds.Book1Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(5, 5, 2014),
                    DueDate = new DateTime(5, 6, 2014),
                    IsAccepted = true,
                    IsCancelled = false,
                    ActualReturnedDate = new DateTime(2, 6, 2014)
                },
                new
                {
                    TransactionId = TransactionIds.Transaction2Id,
                    BookId = BookSeeder.BookIds.Book1Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(2, 6, 2022),
                    DueDate = new DateTime(2, 6, 2022),
                    IsAccepted = true,
                    IsCancelled = false,
                    ActualReturnedDate = new DateTime(2, 6, 2014)
                },
                new
                {
                    TransactionId = TransactionIds.Transaction3Id,
                    BookId = BookSeeder.BookIds.Book3Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    IsCancelled = true,
                },
                new
                {
                    TransactionId = TransactionIds.Transaction4Id,
                    BookId = BookSeeder.BookIds.Book3Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(3, 8, 2022),
                    DueDate = new DateTime(3, 10, 2022),
                    IsAccepted = true,
                    IsCancelled = false,
                    ActualReturnedDate = new DateTime(30, 8, 2022),
                },
                new
                {
                    TransactionId = TransactionIds.Transaction5Id,
                    BookId = BookSeeder.BookIds.Book3Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(15, 1, 2023),
                    DueDate = new DateTime(15, 3, 2023),
                    IsAccepted = true,
                    IsCancelled = false,
                    ActualReturnedDate = new DateTime(2, 2, 2023),
                },
                new
                {
                    TransactionId = TransactionIds.Transaction6Id,
                    BookId = BookSeeder.BookIds.Book3Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(2, 2, 2022),
                    DueDate = new DateTime(2, 4, 2022),
                    IsAccepted = true,
                    IsCancelled = false,
                    ActualReturnedDate = new DateTime(19, 4, 2022),
                },
                new
                {
                    TransactionId = TransactionIds.Transaction7Id,
                    BookId = BookSeeder.BookIds.Book3Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(31, 8, 2022),
                    DueDate = new DateTime(1, 11, 2022),
                    IsAccepted = true,
                    IsCancelled = false,
                    ActualReturnedDate = new DateTime(29, 10, 2022),
                },
                new
                {
                    TransactionId = TransactionIds.Transaction8Id,
                    BookId = BookSeeder.BookIds.Book3Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(2, 1, 2023),
                    DueDate = new DateTime(2, 3, 2023),
                    IsAccepted = true,
                    IsCancelled = false,
                    ActualReturnedDate = new DateTime(1, 3, 2023),
                },
                new
                {
                    TransactionId = TransactionIds.Transaction9Id,
                    BookId = BookSeeder.BookIds.Book3Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(1, 4, 2023),
                    DueDate = new DateTime(2, 6, 2023),
                    IsAccepted = true,
                    IsCancelled = false,
                    ActualReturnedDate = new DateTime(2, 6, 2023)
                }
                );
        }      
    }
    internal static class TransactionIds
    {
        public static readonly Guid Transaction1Id = Guid.NewGuid();
        public static readonly Guid Transaction2Id = Guid.NewGuid();
        public static readonly Guid Transaction3Id = Guid.NewGuid();

        public static readonly Guid Transaction4Id = Guid.NewGuid();
        public static readonly Guid Transaction5Id = Guid.NewGuid();
        public static readonly Guid Transaction6Id = Guid.NewGuid();

        public static readonly Guid Transaction7Id = Guid.NewGuid();
        public static readonly Guid Transaction8Id = Guid.NewGuid();
        public static readonly Guid Transaction9Id = Guid.NewGuid();
    }
}