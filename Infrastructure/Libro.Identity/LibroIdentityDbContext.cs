using Libro.Identity.Configurations;
using Libro.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Libro.Infrastructure.Shared.UserProfiles;

namespace Libro.Identity
{
    public class LibroIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>

    {
        public LibroIdentityDbContext(DbContextOptions<LibroIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("Identity");
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
