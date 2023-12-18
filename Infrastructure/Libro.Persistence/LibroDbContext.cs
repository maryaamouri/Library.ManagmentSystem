using Microsoft.EntityFrameworkCore;

using Libro.Persistence.Configurations;
using Libro.Persistence.DbModels;

namespace Libro.Persistence
{
    public sealed class LiboDbContext : DbContext
    {
        public LiboDbContext(DbContextOptions<LiboDbContext> options) : base(options)
        {
            Console.WriteLine(" ONE DBCONTEXT IS CREATED!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        internal DbSet<Author> Authors { get; set; }
        internal DbSet<Book> Books { get; set; }
        internal DbSet<UserProfile> UserProfile { get; set; }
        internal DbSet<Transaction> Transactions { get; set; }

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
