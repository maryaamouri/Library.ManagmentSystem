using Libro.Identity.Entities;
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
                PasswordHash = hasher.HashPassword(null, "P@ssword")
            };
            return new ApplicationUser[] { user1, user2, user3 };
        }

        internal static class UserConstants
        {
            public static Guid User1Id = new("afd1c581-ec6b-48e4-8c24-dcfeff6f185a");
            public static Guid User2Id = new("9927d9b1-8c7c-4504-86ca-38be99646145");
            public static Guid User3Id = new("98024de3-2a03-4207-9730-793ecb9cc0a8");
        }

    }
}
