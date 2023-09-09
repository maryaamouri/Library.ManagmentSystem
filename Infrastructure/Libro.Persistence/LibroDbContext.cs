using Microsoft.EntityFrameworkCore;
using Libro.Persistence.DbModels;
using Libro.Persistence.Configurations;

namespace Libro.Persistence
{
    public sealed class LiboDbContext : DbContext
    {
        public LiboDbContext(DbContextOptions<LiboDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Library");
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

}
