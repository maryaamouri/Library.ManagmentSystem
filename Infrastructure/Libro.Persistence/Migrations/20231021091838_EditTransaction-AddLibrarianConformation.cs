using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libro.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditTransactionAddLibrarianConformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_UserProfiles_LibrarianId",
                schema: "Library",
                table: "Transactions");

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("01a469d2-2947-42c4-ad24-28da01510185"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("045ad683-f8e3-4352-a34f-5bd6b8078ca0"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("53788cb9-7421-4aa8-aa90-cac86c2f0b87"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("588c75f9-8886-4bb7-949d-afa544ca7654"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("d00990ed-ab55-47c1-aced-9490b8e7a146"));

            migrationBuilder.RenameColumn(
                name: "LibrarianId",
                schema: "Library",
                table: "Transactions",
                newName: "ConfirmedReturnBookLibrarianId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_LibrarianId",
                schema: "Library",
                table: "Transactions",
                newName: "IX_Transactions_ConfirmedReturnBookLibrarianId");

            migrationBuilder.AddColumn<Guid>(
                name: "ConfirmedReceiptBookLibrarianId",
                schema: "Library",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "Library",
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Description", "Genre", "PublicationDate", "Title", "UserProfileUserId" },
                values: new object[,]
                {
                    { new Guid("436bcaad-ea54-413c-97b2-29cb0ce7ed4c"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "the story of Abeer, who encounters Sherif, a brilliant computer expert seeking an ordinary girl for an experiment with his Dream Maker device. This device reprograms cultural experiences into adventures. Abeer's rich imagination makes her an ideal subject. She embarks on interactive journeys with iconic characters like Superman and Tarzan. Abeer's adventures span various worlds, encountering both fictional and real figures, including James Bond, Shakespeare, and Che Guevara. The narrative blends fantasy with reality, offering a diverse and exciting narrative landscape.", "fantasy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2015), "fantasy", null },
                    { new Guid("5d87719d-ea32-43b1-bcc2-5bd74c78be4f"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "It is a series of Egyptian literary novels that take place in a medical atmosphere in the African land in the State of Cameroon. Her hero, Dr. Alaa Abdel-Azim, and the author of the series, Dr. Ahmed Khaled Tawfik. Written in a scientific and satirical comic style. It was published in 1996 and has 53 issues.", "", null, "Safari", null },
                    { new Guid("88ef6c82-f6c4-4ddd-96d6-b7ba541cb537"), new Guid("7a7b6727-c07e-410d-b79d-def9fb359cb0"), "The Old Man and the Sea is a novella written by the American author Ernest Hemingway in 1951 in Cayo Blanco (Cuba), It was the last major work of fiction written by Hemingway that was published during his lifetime. One of his most famous works, it tells the story of Santiago, an aging Cuban fisherman who struggles with a giant marlin far out in the Gulf Stream off the coast of Cuba.\r\nIn 1953, The Old Man and the Sea was awarded the Pulitzer Prize for Fiction, and it was cited by the Nobel Committee as contributing to their awarding of the Nobel Prize in Literature to Hemingway in 1954.", "Literary Fiction", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1952), "The Old Man and The see", null },
                    { new Guid("bf390ea0-a376-411b-b2f2-05ec9ea9bafa"), null, "Between the events of war and peace, the events of the novel take place, in which Tolstoy merged many major and minor characters, historical and fictional, created by Tolstoy himself. It gives a broad and clear picture of the life of luxury that the nobility lived in Russia during the era of tsarist rule. There are those who believe that the main characters Kabier Bzoukub and Prince Andrey represent different aspects of Tolstoy himself.", "Novel, romantic, playful, and philosophical.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1869), "War and peace", null },
                    { new Guid("f429f827-4712-4666-bce3-161c14c62b58"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "A fictional character of a retired Egyptian hematologist named Refaat Ismail about a series of supernatural incidents that he was exposed to in his life, starting in 1959, or the stories that reach him from different people around the world, who heard about his relationship with the supernatural world.\r\n\r\nThe Metaphysical series began in 1993, and until 2014 Issue 80 was issued, which is The Legend of Legends, Part Two, in which the writer ended Rifaat Ismail’s life with an incurable disease, with the promise of issuing stories that he had not yet told, found in his diaries after his death. Rifaat Ismail's 1993 debut was an account of his adventure with the mummy of Count Dracula in 1959 and the subsequent adventure in 1961 with a werewolf in Romania.", "Mystery, horror and thriller", null, "Metaphisics(supernatural)", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ConfirmedReceiptBookLibrarianId",
                schema: "Library",
                table: "Transactions",
                column: "ConfirmedReceiptBookLibrarianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_UserProfiles_ConfirmedReceiptBookLibrarianId",
                schema: "Library",
                table: "Transactions",
                column: "ConfirmedReceiptBookLibrarianId",
                principalSchema: "Library",
                principalTable: "UserProfiles",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_UserProfiles_ConfirmedReturnBookLibrarianId",
                schema: "Library",
                table: "Transactions",
                column: "ConfirmedReturnBookLibrarianId",
                principalSchema: "Library",
                principalTable: "UserProfiles",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_UserProfiles_ConfirmedReceiptBookLibrarianId",
                schema: "Library",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_UserProfiles_ConfirmedReturnBookLibrarianId",
                schema: "Library",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ConfirmedReceiptBookLibrarianId",
                schema: "Library",
                table: "Transactions");

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("436bcaad-ea54-413c-97b2-29cb0ce7ed4c"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("5d87719d-ea32-43b1-bcc2-5bd74c78be4f"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("88ef6c82-f6c4-4ddd-96d6-b7ba541cb537"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("bf390ea0-a376-411b-b2f2-05ec9ea9bafa"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("f429f827-4712-4666-bce3-161c14c62b58"));

            migrationBuilder.DropColumn(
                name: "ConfirmedReceiptBookLibrarianId",
                schema: "Library",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ConfirmedReturnBookLibrarianId",
                schema: "Library",
                table: "Transactions",
                newName: "LibrarianId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_ConfirmedReturnBookLibrarianId",
                schema: "Library",
                table: "Transactions",
                newName: "IX_Transactions_LibrarianId");

            migrationBuilder.InsertData(
                schema: "Library",
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Description", "Genre", "PublicationDate", "Title", "UserProfileUserId" },
                values: new object[,]
                {
                    { new Guid("01a469d2-2947-42c4-ad24-28da01510185"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "A fictional character of a retired Egyptian hematologist named Refaat Ismail about a series of supernatural incidents that he was exposed to in his life, starting in 1959, or the stories that reach him from different people around the world, who heard about his relationship with the supernatural world.\r\n\r\nThe Metaphysical series began in 1993, and until 2014 Issue 80 was issued, which is The Legend of Legends, Part Two, in which the writer ended Rifaat Ismail’s life with an incurable disease, with the promise of issuing stories that he had not yet told, found in his diaries after his death. Rifaat Ismail's 1993 debut was an account of his adventure with the mummy of Count Dracula in 1959 and the subsequent adventure in 1961 with a werewolf in Romania.", "Mystery, horror and thriller", null, "Metaphisics(supernatural)", null },
                    { new Guid("045ad683-f8e3-4352-a34f-5bd6b8078ca0"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "the story of Abeer, who encounters Sherif, a brilliant computer expert seeking an ordinary girl for an experiment with his Dream Maker device. This device reprograms cultural experiences into adventures. Abeer's rich imagination makes her an ideal subject. She embarks on interactive journeys with iconic characters like Superman and Tarzan. Abeer's adventures span various worlds, encountering both fictional and real figures, including James Bond, Shakespeare, and Che Guevara. The narrative blends fantasy with reality, offering a diverse and exciting narrative landscape.", "fantasy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2015), "fantasy", null },
                    { new Guid("53788cb9-7421-4aa8-aa90-cac86c2f0b87"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "It is a series of Egyptian literary novels that take place in a medical atmosphere in the African land in the State of Cameroon. Her hero, Dr. Alaa Abdel-Azim, and the author of the series, Dr. Ahmed Khaled Tawfik. Written in a scientific and satirical comic style. It was published in 1996 and has 53 issues.", "", null, "Safari", null },
                    { new Guid("588c75f9-8886-4bb7-949d-afa544ca7654"), new Guid("7a7b6727-c07e-410d-b79d-def9fb359cb0"), "The Old Man and the Sea is a novella written by the American author Ernest Hemingway in 1951 in Cayo Blanco (Cuba), It was the last major work of fiction written by Hemingway that was published during his lifetime. One of his most famous works, it tells the story of Santiago, an aging Cuban fisherman who struggles with a giant marlin far out in the Gulf Stream off the coast of Cuba.\r\nIn 1953, The Old Man and the Sea was awarded the Pulitzer Prize for Fiction, and it was cited by the Nobel Committee as contributing to their awarding of the Nobel Prize in Literature to Hemingway in 1954.", "Literary Fiction", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1952), "The Old Man and The see", null },
                    { new Guid("d00990ed-ab55-47c1-aced-9490b8e7a146"), null, "Between the events of war and peace, the events of the novel take place, in which Tolstoy merged many major and minor characters, historical and fictional, created by Tolstoy himself. It gives a broad and clear picture of the life of luxury that the nobility lived in Russia during the era of tsarist rule. There are those who believe that the main characters Kabier Bzoukub and Prince Andrey represent different aspects of Tolstoy himself.", "Novel, romantic, playful, and philosophical.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1869), "War and peace", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_UserProfiles_LibrarianId",
                schema: "Library",
                table: "Transactions",
                column: "LibrarianId",
                principalSchema: "Library",
                principalTable: "UserProfiles",
                principalColumn: "UserId");
        }
    }
}
