using Libro.Identity.Entities;
using Libro.Identity.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libro.Identity.Configurations
{
    internal class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(up => up.UserProfileId);
            builder.ToTable("UserProfiles");
            builder.HasOne(up => up.User)
                    .WithOne()
                    .HasForeignKey<UserProfile>(up => up.UserId);      

            builder.Property(up => up.UserId)
                .IsRequired()
                .ValueGeneratedNever();

            builder.HasData(UserProfielSeeder.Seed());
        }
    }
}
