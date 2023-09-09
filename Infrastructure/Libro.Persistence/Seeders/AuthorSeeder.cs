using Libro.Persistence.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Libro.Persistence.Seeders.AuthorSeeder;

namespace Libro.Persistence.Seeders
{
    internal static class AuthorSeeder
    {
        internal static void Seed(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
                new { AuthorId = AuthorIds.Author1Id, Name = "Ahmad Khalid Tawfeeq" },
                new { AuthorId = AuthorIds.Author2Id, Name = "Gabriel Garcia Marquez" },
                new { AuthorId = AuthorIds.Author3Id, Name = "Ernest Hemingway" },
                new { AuthorId = AuthorIds.Author4Id, Name = "Fyodor Mikhailovich Dostoyevsky" },
                new { AuthorId = AuthorIds.Author5Id, Name = "George Orwell" },
                new { AuthorId = AuthorIds.Author6Id, Name = "Naguib Mahfouz" },
                new { AuthorId = AuthorIds.Author7Id, Name = "Ghassan Kanafani" }
            );
        }
        internal static class AuthorIds
        {
            public static readonly Guid Author1Id = new ("4f6bf45f-8954-4882-88d8-40b1b7eee27f");
            public static readonly Guid Author2Id = new("2df4e17e-5cdd-4eed-8986-b832cf38e849");
            public static readonly Guid Author3Id = new("7a7b6727-c07e-410d-b79d-def9fb359cb0");

            public static readonly Guid Author4Id = new("5a0c6e0f-d489-4e27-bcb0-3f860316773b");
            public static readonly Guid Author5Id = new("7698d22f-95ac-47c0-a3f7-389f826e7512");
            public static readonly Guid Author6Id = new("1b4990dc-409a-43b9-9694-ef1b572a4fde");

            public static readonly Guid Author7Id = new("50c84ade-07ca-4676-b9b2-d11715a5f4a1");
        }
    }
}

