using Libro.Persistence.DbModels;
using Libro.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libro.Persistence.Configurations
{
    internal sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.Property(author => author.AuthorId)
              .HasColumnType("uniqueidentifier")
              .IsRequired();

            builder.HasKey(author => author.AuthorId);

            builder.Property(author => author.Name)
                .IsRequired()
                .HasMaxLength(100);

            AuthorSeeder.Seed(builder);
        }
    }
}
