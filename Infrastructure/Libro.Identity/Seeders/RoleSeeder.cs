using Microsoft.AspNetCore.Identity;

namespace Libro.Identity.Seeders
{
    internal static class RoleSeeder
    {
        public static IdentityRole<Guid>[] Seed()
        {
            IdentityRole <Guid>role1 = new()
            {
                Id = RoleConstants.AdminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
            };
            IdentityRole<Guid> role2 = new()
            {
                Id = RoleConstants.LibrarianRoleId,
                Name = "Librarian",
                NormalizedName = "LIBRARIAN",
            };
            IdentityRole<Guid> role3 = new()
            {
                Id = RoleConstants.PatronRoleId,
                Name = "Patron",
                NormalizedName = "PATRON",
            };

            return new IdentityRole<Guid>[] { role1, role2, role3 };
        }
        internal static class RoleConstants
        {
            public static Guid AdminRoleId = new("6b9f32ae-cc8d-4469-865f-4841396b27c6");
            public static Guid LibrarianRoleId = new("4616af6d-91a5-43be-abdb-165a75fb2b65");
            public static Guid PatronRoleId = new("2281be69-93a7-4d40-840d-96e34e1102e0");
        }

    }
}
