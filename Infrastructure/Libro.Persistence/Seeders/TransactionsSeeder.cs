using Libro.Persistence.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Libro.Infrastructure.Shared.UserProfiles;

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
                    BorrowedDate = new DateTime(2014,5,5),
                    DueDate = new DateTime(2014,6,5),
                    IsAccepted = true,
                    IsCanceled = false,
                    ActualReturnedDate = new DateTime(2014,6,2),
                    IsDeleted = false
                },
                new
                {
                    TransactionId = TransactionIds.Transaction2Id,
                    BookId = BookSeeder.BookIds.Book1Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(2022,6,2),
                    DueDate = new DateTime(2022, 8, 2),
                    IsAccepted = true,
                    IsCanceled = false,
                    ActualReturnedDate = new DateTime(2022, 7, 2),
                    IsDeleted = false
                },
                new
                {
                    TransactionId = TransactionIds.Transaction3Id,
                    BookId = BookSeeder.BookIds.Book3Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    IsCanceled = true,
                    IsDeleted = false
                },
                new
                {
                    TransactionId = TransactionIds.Transaction4Id,
                    BookId = BookSeeder.BookIds.Book3Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(2022, 8, 3),
                    DueDate = new DateTime(2022, 10, 3),
                    IsAccepted = true,
                    IsCanceled = false,
                    ActualReturnedDate = new DateTime(2022, 8, 30),
                    IsDeleted = false
                },
                new
                {
                    TransactionId = TransactionIds.Transaction5Id,
                    BookId = BookSeeder.BookIds.Book3Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(2023, 1, 15),
                    DueDate = new DateTime(2023, 3, 15),
                    IsAccepted = true,
                    IsCanceled = false,
                    ActualReturnedDate = new DateTime(2023, 2, 2),
                    IsDeleted = false
                },
                new
                {
                    TransactionId = TransactionIds.Transaction6Id,
                    BookId = BookSeeder.BookIds.Book3Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(2022, 2, 2),
                    DueDate = new DateTime(2022, 4, 2),
                    IsAccepted = true,
                    IsCanceled = false,
                    ActualReturnedDate = new DateTime(2022, 4, 19),
                    IsDeleted = false
                },
                new
                {
                    TransactionId = TransactionIds.Transaction7Id,
                    BookId = BookSeeder.BookIds.Book3Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(2022, 8, 31),
                    DueDate = new DateTime(2022, 11, 1),
                    IsAccepted = true,
                    IsCanceled = false,
                    ActualReturnedDate = new DateTime(2022, 10, 29),
                    IsDeleted = false
                },
                new
                {
                    TransactionId = TransactionIds.Transaction8Id,
                    BookId = BookSeeder.BookIds.Book3Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(2023, 1, 2),
                    DueDate = new DateTime(2023, 3, 2),
                    IsAccepted = true,
                    IsCanceled = false,
                    ActualReturnedDate = new DateTime(2023, 3, 1),
                    IsDeleted = false
                },
                new
                {
                    TransactionId = TransactionIds.Transaction9Id,
                    BookId = BookSeeder.BookIds.Book3Id,
                    PatronId = UserProfileIds.Profile3Id,
                    LibrarianId = UserProfileIds.Profile2Id,
                    BorrowedDate = new DateTime(2023, 4, 1),
                    DueDate = new DateTime(2023, 6, 2),
                    IsAccepted = true,
                    IsCanceled = false,
                    ActualReturnedDate = new DateTime(2023, 6, 2),
                    IsDeleted = false
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