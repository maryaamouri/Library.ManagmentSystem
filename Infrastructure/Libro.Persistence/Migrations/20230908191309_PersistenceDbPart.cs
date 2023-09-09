using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libro.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PersistenceDbPart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Library");

            migrationBuilder.CreateTable(
                name: "Authors",
                schema: "Library",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                schema: "Library",
                columns: table => new
                {
                    UserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.UserProfileId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "Library",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "Library",
                        principalTable: "Authors",
                        principalColumn: "AuthorId");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "Library",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatronId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibrarianId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BorrowedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualReturnedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "Library",
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_UserProfiles_LibrarianId",
                        column: x => x.LibrarianId,
                        principalSchema: "Library",
                        principalTable: "UserProfiles",
                        principalColumn: "UserProfileId");
                    table.ForeignKey(
                        name: "FK_Transactions_UserProfiles_PatronId",
                        column: x => x.PatronId,
                        principalSchema: "Library",
                        principalTable: "UserProfiles",
                        principalColumn: "UserProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Library",
                table: "Authors",
                columns: new[] { "AuthorId", "Name" },
                values: new object[,]
                {
                    { new Guid("1b4990dc-409a-43b9-9694-ef1b572a4fde"), "Naguib Mahfouz" },
                    { new Guid("2df4e17e-5cdd-4eed-8986-b832cf38e849"), "Gabriel Garcia Marquez" },
                    { new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "Ahmad Khalid Tawfeeq" },
                    { new Guid("50c84ade-07ca-4676-b9b2-d11715a5f4a1"), "Ghassan Kanafani" },
                    { new Guid("5a0c6e0f-d489-4e27-bcb0-3f860316773b"), "Fyodor Mikhailovich Dostoyevsky" },
                    { new Guid("7698d22f-95ac-47c0-a3f7-389f826e7512"), "George Orwell" },
                    { new Guid("7a7b6727-c07e-410d-b79d-def9fb359cb0"), "Ernest Hemingway" }
                });

            migrationBuilder.InsertData(
                schema: "Library",
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Description", "Genre", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("2e815914-3108-4231-b89d-be89b257b71c"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "It is a series of Egyptian literary novels that take place in a medical atmosphere in the African land in the State of Cameroon. Her hero, Dr. Alaa Abdel-Azim, and the author of the series, Dr. Ahmed Khaled Tawfik. Written in a scientific and satirical comic style. It was published in 1996 and has 53 issues.", "", null, "Safari" },
                    { new Guid("433f9c35-b00e-46ed-b265-a51231b71589"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "A fictional character of a retired Egyptian hematologist named Refaat Ismail about a series of supernatural incidents that he was exposed to in his life, starting in 1959, or the stories that reach him from different people around the world, who heard about his relationship with the supernatural world.\r\n\r\nThe Metaphysical series began in 1993, and until 2014 Issue 80 was issued, which is The Legend of Legends, Part Two, in which the writer ended Rifaat Ismail’s life with an incurable disease, with the promise of issuing stories that he had not yet told, found in his diaries after his death. Rifaat Ismail's 1993 debut was an account of his adventure with the mummy of Count Dracula in 1959 and the subsequent adventure in 1961 with a werewolf in Romania.", "Mystery, horror and thriller", null, "Metaphisics(supernatural)" },
                    { new Guid("6346e2b5-f217-42f8-a8e1-3d0aa1298b01"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "Between the events of war and peace, the events of the novel take place, in which Tolstoy merged many major and minor characters, historical and fictional, created by Tolstoy himself. It gives a broad and clear picture of the life of luxury that the nobility lived in Russia during the era of tsarist rule. There are those who believe that the main characters Kabier Bzoukub and Prince Andrey represent different aspects of Tolstoy himself.", "Novel, romantic, playful, and philosophical.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1869), "War and peace" },
                    { new Guid("6ea77da4-636b-4abc-97ea-2526e7f92e4e"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "the story of Abeer, who encounters Sherif, a brilliant computer expert seeking an ordinary girl for an experiment with his Dream Maker device. This device reprograms cultural experiences into adventures. Abeer's rich imagination makes her an ideal subject. She embarks on interactive journeys with iconic characters like Superman and Tarzan. Abeer's adventures span various worlds, encountering both fictional and real figures, including James Bond, Shakespeare, and Che Guevara. The narrative blends fantasy with reality, offering a diverse and exciting narrative landscape.", "fantasy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2015), "fantasy" },
                    { new Guid("d83c84c3-8d50-49dd-90f8-6e26d8d1557f"), new Guid("7a7b6727-c07e-410d-b79d-def9fb359cb0"), "The Old Man and the Sea is a novella written by the American author Ernest Hemingway in 1951 in Cayo Blanco (Cuba), It was the last major work of fiction written by Hemingway that was published during his lifetime. One of his most famous works, it tells the story of Santiago, an aging Cuban fisherman who struggles with a giant marlin far out in the Gulf Stream off the coast of Cuba.\r\nIn 1953, The Old Man and the Sea was awarded the Pulitzer Prize for Fiction, and it was cited by the Nobel Committee as contributing to their awarding of the Nobel Prize in Literature to Hemingway in 1954.", "Literary Fiction", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1952), "The Old Man and The see" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                schema: "Library",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BookId",
                schema: "Library",
                table: "Transactions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_LibrarianId",
                schema: "Library",
                table: "Transactions",
                column: "LibrarianId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PatronId",
                schema: "Library",
                table: "Transactions",
                column: "PatronId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Books",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "UserProfiles",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Authors",
                schema: "Library");
        }
    }
}
