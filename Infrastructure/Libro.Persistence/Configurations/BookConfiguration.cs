using Libro.Persistence.DbModels;
using Libro.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libro.Persistence.Configurations
{
    internal sealed class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(book => book.BookId);

            builder.Property(book => book.BookId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(book => book.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(book => book.Description)
                .HasMaxLength(1000);

            builder.Property(book => book.Genre)
                .HasMaxLength(255);

            builder.Property(book => book.PublicationDate)
                .HasColumnType("date");

            builder.HasOne(book => book.Author)
            .WithMany()
            .HasForeignKey(b => b.AuthorId)
            .IsRequired(false);

            BookSeeder.Seed(builder);
        }
    }
}
