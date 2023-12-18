using Libro.Persistence.DbModels;
using Libro.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libro.Persistence.Configurations
{
    internal sealed class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("UserProfiles");
            builder.HasKey(user => user.UserId);

            builder
               .HasMany(userProfile => userProfile.Transactions)
               .WithOne();

            builder
               .HasMany(userProfile => userProfile.CurrentlyBorrowdBooks)
               .WithOne();

            builder
                    .HasData(UserProfileSeeder.Seed());

        }
    }
}
