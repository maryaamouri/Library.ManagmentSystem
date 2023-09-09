using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libro.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("1a148993-4ed3-4aa4-806a-15e60d7cf51d"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("1c7c36bc-0637-4da8-b5aa-f085678268c2"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("3482addf-f2bc-48a4-974e-25205504e64f"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("4c6b1e10-76a8-40fa-ab84-fff5968305bf"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("ffac5c65-40e5-4f74-9341-2273baec2e74"));

            migrationBuilder.InsertData(
                schema: "Library",
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Description", "Genre", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("15a075a6-82e3-44e8-8bae-1bd236dec079"), new Guid("7a7b6727-c07e-410d-b79d-def9fb359cb0"), "The Old Man and the Sea is a novella written by the American author Ernest Hemingway in 1951 in Cayo Blanco (Cuba), It was the last major work of fiction written by Hemingway that was published during his lifetime. One of his most famous works, it tells the story of Santiago, an aging Cuban fisherman who struggles with a giant marlin far out in the Gulf Stream off the coast of Cuba.\r\nIn 1953, The Old Man and the Sea was awarded the Pulitzer Prize for Fiction, and it was cited by the Nobel Committee as contributing to their awarding of the Nobel Prize in Literature to Hemingway in 1954.", "Literary Fiction", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1952), "The Old Man and The see" },
                    { new Guid("1cf16454-b5a6-41ca-b0f9-8805474fe075"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "the story of Abeer, who encounters Sherif, a brilliant computer expert seeking an ordinary girl for an experiment with his Dream Maker device. This device reprograms cultural experiences into adventures. Abeer's rich imagination makes her an ideal subject. She embarks on interactive journeys with iconic characters like Superman and Tarzan. Abeer's adventures span various worlds, encountering both fictional and real figures, including James Bond, Shakespeare, and Che Guevara. The narrative blends fantasy with reality, offering a diverse and exciting narrative landscape.", "fantasy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2015), "fantasy" },
                    { new Guid("1ff1b083-f478-4cef-a6da-c9a38f63827d"), null, "Between the events of war and peace, the events of the novel take place, in which Tolstoy merged many major and minor characters, historical and fictional, created by Tolstoy himself. It gives a broad and clear picture of the life of luxury that the nobility lived in Russia during the era of tsarist rule. There are those who believe that the main characters Kabier Bzoukub and Prince Andrey represent different aspects of Tolstoy himself.", "Novel, romantic, playful, and philosophical.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1869), "War and peace" },
                    { new Guid("8a57b14e-32fb-443d-bafe-bde5ef6c94b2"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "It is a series of Egyptian literary novels that take place in a medical atmosphere in the African land in the State of Cameroon. Her hero, Dr. Alaa Abdel-Azim, and the author of the series, Dr. Ahmed Khaled Tawfik. Written in a scientific and satirical comic style. It was published in 1996 and has 53 issues.", "", null, "Safari" },
                    { new Guid("f61a5f0d-90bd-4601-bfe3-ff0f8baf6aa8"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "A fictional character of a retired Egyptian hematologist named Refaat Ismail about a series of supernatural incidents that he was exposed to in his life, starting in 1959, or the stories that reach him from different people around the world, who heard about his relationship with the supernatural world.\r\n\r\nThe Metaphysical series began in 1993, and until 2014 Issue 80 was issued, which is The Legend of Legends, Part Two, in which the writer ended Rifaat Ismail’s life with an incurable disease, with the promise of issuing stories that he had not yet told, found in his diaries after his death. Rifaat Ismail's 1993 debut was an account of his adventure with the mummy of Count Dracula in 1959 and the subsequent adventure in 1961 with a werewolf in Romania.", "Mystery, horror and thriller", null, "Metaphisics(supernatural)" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("15a075a6-82e3-44e8-8bae-1bd236dec079"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("1cf16454-b5a6-41ca-b0f9-8805474fe075"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("1ff1b083-f478-4cef-a6da-c9a38f63827d"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("8a57b14e-32fb-443d-bafe-bde5ef6c94b2"));

            migrationBuilder.DeleteData(
                schema: "Library",
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("f61a5f0d-90bd-4601-bfe3-ff0f8baf6aa8"));

            migrationBuilder.InsertData(
                schema: "Library",
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Description", "Genre", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { new Guid("1a148993-4ed3-4aa4-806a-15e60d7cf51d"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "A fictional character of a retired Egyptian hematologist named Refaat Ismail about a series of supernatural incidents that he was exposed to in his life, starting in 1959, or the stories that reach him from different people around the world, who heard about his relationship with the supernatural world.\r\n\r\nThe Metaphysical series began in 1993, and until 2014 Issue 80 was issued, which is The Legend of Legends, Part Two, in which the writer ended Rifaat Ismail’s life with an incurable disease, with the promise of issuing stories that he had not yet told, found in his diaries after his death. Rifaat Ismail's 1993 debut was an account of his adventure with the mummy of Count Dracula in 1959 and the subsequent adventure in 1961 with a werewolf in Romania.", "Mystery, horror and thriller", null, "Metaphisics(supernatural)" },
                    { new Guid("1c7c36bc-0637-4da8-b5aa-f085678268c2"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "the story of Abeer, who encounters Sherif, a brilliant computer expert seeking an ordinary girl for an experiment with his Dream Maker device. This device reprograms cultural experiences into adventures. Abeer's rich imagination makes her an ideal subject. She embarks on interactive journeys with iconic characters like Superman and Tarzan. Abeer's adventures span various worlds, encountering both fictional and real figures, including James Bond, Shakespeare, and Che Guevara. The narrative blends fantasy with reality, offering a diverse and exciting narrative landscape.", "fantasy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2015), "fantasy" },
                    { new Guid("3482addf-f2bc-48a4-974e-25205504e64f"), new Guid("7a7b6727-c07e-410d-b79d-def9fb359cb0"), "The Old Man and the Sea is a novella written by the American author Ernest Hemingway in 1951 in Cayo Blanco (Cuba), It was the last major work of fiction written by Hemingway that was published during his lifetime. One of his most famous works, it tells the story of Santiago, an aging Cuban fisherman who struggles with a giant marlin far out in the Gulf Stream off the coast of Cuba.\r\nIn 1953, The Old Man and the Sea was awarded the Pulitzer Prize for Fiction, and it was cited by the Nobel Committee as contributing to their awarding of the Nobel Prize in Literature to Hemingway in 1954.", "Literary Fiction", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1952), "The Old Man and The see" },
                    { new Guid("4c6b1e10-76a8-40fa-ab84-fff5968305bf"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "Between the events of war and peace, the events of the novel take place, in which Tolstoy merged many major and minor characters, historical and fictional, created by Tolstoy himself. It gives a broad and clear picture of the life of luxury that the nobility lived in Russia during the era of tsarist rule. There are those who believe that the main characters Kabier Bzoukub and Prince Andrey represent different aspects of Tolstoy himself.", "Novel, romantic, playful, and philosophical.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1869), "War and peace" },
                    { new Guid("ffac5c65-40e5-4f74-9341-2273baec2e74"), new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"), "It is a series of Egyptian literary novels that take place in a medical atmosphere in the African land in the State of Cameroon. Her hero, Dr. Alaa Abdel-Azim, and the author of the series, Dr. Ahmed Khaled Tawfik. Written in a scientific and satirical comic style. It was published in 1996 and has 53 issues.", "", null, "Safari" }
                });
        }
    }
}
