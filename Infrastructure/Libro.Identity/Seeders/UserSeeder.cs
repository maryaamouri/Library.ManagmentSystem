using Libro.Identity.Entities;
using Libro.Infrastructure.Shared.UserProfiles;
using Microsoft.AspNetCore.Identity;

namespace Libro.Identity.Seeders
{
    internal static class UserSeeder
    {
        public static ApplicationUser[] Seed()
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            ApplicationUser user1 = new()
            {
                Id = UserConstants.User1Id,
                Email = "admin1@localhost.com",
                NormalizedEmail = "ADMIN1@LOCALHOST.COM", 
                FirstName = "Admin",
                LastName = "One",
                UserName = "admin1",
                NormalizedUserName = "ADMIN1",
                PasswordHash = hasher.HashPassword(null, "P@ssword"),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true
            };
            ApplicationUser user2 = new()
            {
                Id = UserConstants.User2Id,
                Email = "librarian1@localhost.com",
                NormalizedEmail = "LIBRARIAN1@LOCALHOST.COM", 
                FirstName = "Librarian",
                LastName = "One",
                UserName = "librarian1",
                NormalizedUserName = "LIBRARIAN1",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "P@ssword")
            };
            ApplicationUser user3 = new()
            {
                Id = UserConstants.User3Id,
                Email = "user1@localhost.com",
                NormalizedEmail = "USER1@LOCALHOST.COM", 
                FirstName = "User",
                LastName = "One",
                UserName = "user1",
                NormalizedUserName = "USER1",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "P@ssword")
            };
            return new ApplicationUser[] { user1, user2, user3 };
        }

        

    }
}
