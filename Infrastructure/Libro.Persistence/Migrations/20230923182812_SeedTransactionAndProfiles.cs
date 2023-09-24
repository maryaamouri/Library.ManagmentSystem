using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libro.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedTransactionAndProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("0ee6f7f9-e941-44ec-a085-29632f526914"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("3883ae5e-b3ef-4cc1-bdcf-d6a92dde2ff9"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("389a504d-40b6-4a88-8720-5f4bf1ef03c8"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("661f6856-7651-47bc-8cec-fc4870be6a77"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("88fb42ee-8e7f-4b07-b91a-c9f25fb4fb0a"));

            migrationBuilder.InsertData(
                schema: "Library",
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Description", "Genre", "IsAvailable", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("18ef09e4-41da-4bb5-a669-3cfc0cc3df9b"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "A fictional character of a retired Egyptian hematologist named Refaat Ismail about a series of supernatural incidents that he was exposed to in his life, starting in 1959, or the stories that reach him from different people around the world, who heard about his relationship with the supernatural world.\r\n\r\nThe Metaphysical series began in 1993, and until 2014 Issue 80 was issued, which is The Legend of Legends, Part Two, in which the writer ended Rifaat Ismail’s life with an incurable disease, with the promise of issuing stories that he had not yet told, found in his diaries after his death. Rifaat Ismail's 1993 debut was an account of his adventure with the mummy of Count Dracula in 1959 and the subsequent adventure in 1961 with a werewolf in Romania.", "Mystery, horror and thriller", null, null, "Metaphisics(supernatural)" },
                    { new Guid("d7dab5f9-2408-40c7-80c2-47cd50b16eed"), null, "Between the events of war and peace, the events of the novel take place, in which Tolstoy merged many major and minor characters, historical and fictional, created by Tolstoy himself. It gives a broad and clear picture of the life of luxury that the nobility lived in Russia during the era of tsarist rule. There are those who believe that the main characters Kabier Bzoukub and Prince Andrey represent different aspects of Tolstoy himself.", "Novel, romantic, playful, and philosophical.", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1869), "War and peace" },
                    { new Guid("e49950f8-5bf0-4df2-b9d2-d56c203b1ece"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "the story of Abeer, who encounters Sherif, a brilliant computer expert seeking an ordinary girl for an experiment with his Dream Maker device. This device reprograms cultural experiences into adventures. Abeer's rich imagination makes her an ideal subject. She embarks on interactive journeys with iconic characters like Superman and Tarzan. Abeer's adventures span various worlds, encountering both fictional and real figures, including James Bond, Shakespeare, and Che Guevara. The narrative blends fantasy with reality, offering a diverse and exciting narrative landscape.", "fantasy", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2015), "fantasy" },
                    { new Guid("e9f13de1-39c7-4198-8762-f087637b03ce"), new Guid("7a7b6727-c07e-410d-b79d-def9fb359cb0"), "The Old Man and the Sea is a novella written by the American author Ernest Hemingway in 1951 in Cayo Blanco (Cuba), It was the last major work of fiction written by Hemingway that was published during his lifetime. One of his most famous works, it tells the story of Santiago, an aging Cuban fisherman who struggles with a giant marlin far out in the Gulf Stream off the coast of Cuba.\r\nIn 1953, The Old Man and the Sea was awarded the Pulitzer Prize for Fiction, and it was cited by the Nobel Committee as contributing to their awarding of the Nobel Prize in Literature to Hemingway in 1954.", "Literary Fiction", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1952), "The Old Man and The see" },
                    { new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "It is a series of Egyptian literary novels that take place in a medical atmosphere in the African land in the State of Cameroon. Her hero, Dr. Alaa Abdel-Azim, and the author of the series, Dr. Ahmed Khaled Tawfik. Written in a scientific and satirical comic style. It was published in 1996 and has 53 issues.", "", null, null, "Safari" }
                });

            migrationBuilder.InsertData(
                schema: "Library",
                table: "UserProfiles",
                columns: new[] { "UserProfileId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("15826e76-8cc6-476c-bbc8-b21309de5186"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("41e93277-782b-492d-977a-e3902acabac6"), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                schema: "Library",
                table: "Transactions",
                columns: new[] { "TransactionId", "ActualReturnedDate", "BookId", "BorrowedDate", "DueDate", "IsAccepted", "IsCanceled", "IsDeleted", "LibrarianId", "PatronId" },
                values: new object[,]
                {
                    { new Guid("11b7ee53-2480-43f5-aad8-b47abb869970"), new DateTime(2022, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"), new DateTime(2022, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"), new Guid("41e93277-782b-492d-977a-e3902acabac6") },
                    { new Guid("1837db29-2100-49c1-b8af-cacc2520298a"), null, new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"), null, null, null, true, false, new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"), new Guid("41e93277-782b-492d-977a-e3902acabac6") },
                    { new Guid("2de78a2e-4b61-4bc6-b10f-213f18c2e1a1"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"), new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"), new Guid("41e93277-782b-492d-977a-e3902acabac6") },
                    { new Guid("38c48cd9-4435-4a06-aed6-bb6f6401ba3e"), new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e49950f8-5bf0-4df2-b9d2-d56c203b1ece"), new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"), new Guid("41e93277-782b-492d-977a-e3902acabac6") },
                    { new Guid("3a5712b9-d6f4-460a-933c-f6bf9349c03d"), new DateTime(2014, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e49950f8-5bf0-4df2-b9d2-d56c203b1ece"), new DateTime(2014, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2014, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"), new Guid("41e93277-782b-492d-977a-e3902acabac6") },
                    { new Guid("b074b06b-9be3-4e2c-93ff-62ee6472910a"), new DateTime(2022, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"), new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"), new Guid("41e93277-782b-492d-977a-e3902acabac6") },
                    { new Guid("df13218c-1292-46a5-9e01-fb6488419a31"), new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"), new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"), new Guid("41e93277-782b-492d-977a-e3902acabac6") },
                    { new Guid("e9f413bd-3282-43f6-9f01-499b6cf51cb0"), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"), new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"), new Guid("41e93277-782b-492d-977a-e3902acabac6") },
                    { new Guid("efd73efa-d566-4a8e-a3ed-420ab6cd74f2"), new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"), new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"), new Guid("41e93277-782b-492d-977a-e3902acabac6") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("18ef09e4-41da-4bb5-a669-3cfc0cc3df9b"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("d7dab5f9-2408-40c7-80c2-47cd50b16eed"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("e9f13de1-39c7-4198-8762-f087637b03ce"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("11b7ee53-2480-43f5-aad8-b47abb869970"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("1837db29-2100-49c1-b8af-cacc2520298a"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("2de78a2e-4b61-4bc6-b10f-213f18c2e1a1"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("38c48cd9-4435-4a06-aed6-bb6f6401ba3e"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("3a5712b9-d6f4-460a-933c-f6bf9349c03d"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("b074b06b-9be3-4e2c-93ff-62ee6472910a"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("df13218c-1292-46a5-9e01-fb6488419a31"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("e9f413bd-3282-43f6-9f01-499b6cf51cb0"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("efd73efa-d566-4a8e-a3ed-420ab6cd74f2"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "UserProfiles",
                keyColumn: "UserProfileId",
                keyValue: new Guid("15826e76-8cc6-476c-bbc8-b21309de5186"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("e49950f8-5bf0-4df2-b9d2-d56c203b1ece"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "UserProfiles",
                keyColumn: "UserProfileId",
                keyValue: new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "UserProfiles",
                keyColumn: "UserProfileId",
                keyValue: new Guid("41e93277-782b-492d-977a-e3902acabac6"));

            migrationBuilder.InsertData(
                schema: "Library",
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Description", "Genre", "IsAvailable", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("0ee6f7f9-e941-44ec-a085-29632f526914"), new Guid("7a7b6727-c07e-410d-b79d-def9fb359cb0"), "The Old Man and the Sea is a novella written by the American author Ernest Hemingway in 1951 in Cayo Blanco (Cuba), It was the last major work of fiction written by Hemingway that was published during his lifetime. One of his most famous works, it tells the story of Santiago, an aging Cuban fisherman who struggles with a giant marlin far out in the Gulf Stream off the coast of Cuba.\r\nIn 1953, The Old Man and the Sea was awarded the Pulitzer Prize for Fiction, and it was cited by the Nobel Committee as contributing to their awarding of the Nobel Prize in Literature to Hemingway in 1954.", "Literary Fiction", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1952), "The Old Man and The see" },
                    { new Guid("3883ae5e-b3ef-4cc1-bdcf-d6a92dde2ff9"), null, "Between the events of war and peace, the events of the novel take place, in which Tolstoy merged many major and minor characters, historical and fictional, created by Tolstoy himself. It gives a broad and clear picture of the life of luxury that the nobility lived in Russia during the era of tsarist rule. There are those who believe that the main characters Kabier Bzoukub and Prince Andrey represent different aspects of Tolstoy himself.", "Novel, romantic, playful, and philosophical.", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1869), "War and peace" },
                    { new Guid("389a504d-40b6-4a88-8720-5f4bf1ef03c8"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "It is a series of Egyptian literary novels that take place in a medical atmosphere in the African land in the State of Cameroon. Her hero, Dr. Alaa Abdel-Azim, and the author of the series, Dr. Ahmed Khaled Tawfik. Written in a scientific and satirical comic style. It was published in 1996 and has 53 issues.", "", null, null, "Safari" },
                    { new Guid("661f6856-7651-47bc-8cec-fc4870be6a77"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "A fictional character of a retired Egyptian hematologist named Refaat Ismail about a series of supernatural incidents that he was exposed to in his life, starting in 1959, or the stories that reach him from different people around the world, who heard about his relationship with the supernatural world.\r\n\r\nThe Metaphysical series began in 1993, and until 2014 Issue 80 was issued, which is The Legend of Legends, Part Two, in which the writer ended Rifaat Ismail’s life with an incurable disease, with the promise of issuing stories that he had not yet told, found in his diaries after his death. Rifaat Ismail's 1993 debut was an account of his adventure with the mummy of Count Dracula in 1959 and the subsequent adventure in 1961 with a werewolf in Romania.", "Mystery, horror and thriller", null, null, "Metaphisics(supernatural)" },
                    { new Guid("88fb42ee-8e7f-4b07-b91a-c9f25fb4fb0a"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "the story of Abeer, who encounters Sherif, a brilliant computer expert seeking an ordinary girl for an experiment with his Dream Maker device. This device reprograms cultural experiences into adventures. Abeer's rich imagination makes her an ideal subject. She embarks on interactive journeys with iconic characters like Superman and Tarzan. Abeer's adventures span various worlds, encountering both fictional and real figures, including James Bond, Shakespeare, and Che Guevara. The narrative blends fantasy with reality, offering a diverse and exciting narrative landscape.", "fantasy", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2015), "fantasy" }
                });
        }
    }
}
