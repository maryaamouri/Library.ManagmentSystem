using Libro.Persistence.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libro.Persistence.Configurations
{
    internal sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(transaction => transaction.TransactionId);

            builder.Property(transaction => transaction.BorrowedDate)
              .HasColumnType("datetime");

            builder.Property(transaction => transaction.DueDate)
                .HasColumnType("datetime");

            builder.Property(transaction => transaction.ActualReturnedDate)
                .HasColumnType("datetime");

            builder.HasOne<Book>()
                .WithMany()
                .HasForeignKey(t => t.BookId);

            builder.HasOne<UserProfile>()
                .WithMany()
                .HasForeignKey(u => u.LibrarianId);

            builder.HasOne<UserProfile>()
                .WithMany()
                .HasForeignKey(u => u.PatronId);
        }
    }
}
