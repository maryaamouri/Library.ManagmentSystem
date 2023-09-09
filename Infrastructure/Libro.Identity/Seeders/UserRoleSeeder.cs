using Microsoft.AspNetCore.Identity;

namespace Libro.Identity.Seeders
{
    internal class UserRoleSeeder
    {
        internal static IdentityUserRole<Guid>[] Seed()
        {
            IdentityUserRole<Guid> userRole1 = new()
            {
                UserId = UserSeeder.UserConstants.User1Id,
                RoleId = RoleSeeder.RoleConstants.AdminRoleId
            };
            IdentityUserRole<Guid> userRole2 = new()
            {
                UserId = UserSeeder.UserConstants.User2Id,
                RoleId = RoleSeeder.RoleConstants.LibrarianRoleId
            };
            IdentityUserRole<Guid> userRole3 = new()
            {
                UserId = UserSeeder.UserConstants.User3Id,
                RoleId = RoleSeeder.RoleConstants.PatronRoleId
            };
            return new IdentityUserRole<Guid>[] { userRole1, userRole2, userRole3 };
        }
    }
}
