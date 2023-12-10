using Libro.Persistence.DbModels;
using Libro.Persistence.Seeders;
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

            builder.Property(transaction => transaction.ReservationDate)
              .HasColumnType("datetime");

            builder.Property(transaction => transaction.DueDate)
                .HasColumnType("datetime");

            builder.Property(transaction => transaction.ReceiptDate)
                .HasColumnType("datetime");

            builder.Property(transaction => transaction.ReturnedDate)
               .HasColumnType("datetime");

            builder.HasOne<Book>()
                .WithMany()
                .HasForeignKey(transaction => transaction.BookId);

            builder.HasOne<UserProfile>()
                .WithMany()
                .HasForeignKey(transaction => transaction.PatronId);

            builder.HasOne<UserProfile>()
                .WithMany()
                .HasForeignKey(transaction => transaction.LibrarianId);

        }
    }
}
