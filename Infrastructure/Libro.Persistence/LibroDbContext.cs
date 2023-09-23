﻿using Microsoft.EntityFrameworkCore;

using Libro.Persistence.Configurations;
using Libro.Infrastructure.Shared.UserProfiles;
using Libro.Persistence.DbModels;

namespace Libro.Persistence
{
    public sealed class LiboDbContext : DbContext
    {
        public LiboDbContext(DbContextOptions<LiboDbContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
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
