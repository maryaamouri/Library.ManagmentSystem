using Libro.Persistence.DbModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Libro.Persistence.Seeders
{

    internal class BookSeeder
    {
        internal static void Seed(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new
                {
                    BookId = BookIds.Book1Id,
                    Title = "fantasy",
                    Description = "the story of Abeer, who encounters Sherif, a brilliant computer expert seeking an ordinary girl for an experiment with his Dream Maker device. This device reprograms cultural experiences into adventures. Abeer's rich imagination makes her an ideal subject. She embarks on interactive journeys with iconic characters like Superman and Tarzan. Abeer's adventures span various worlds, encountering both fictional and real figures, including James Bond, Shakespeare, and Che Guevara. The narrative blends fantasy with reality, offering a diverse and exciting narrative landscape.",
                    Genre = "fantasy",
                    AuthorId = AuthorSeeder.AuthorIds.Author1Id,
                    PublicationDate = new DateTime(2015)
                },
                new
                {
                    BookId = BookIds.Book2Id,
                    Title = "Metaphisics(supernatural)",
                    Description = "A fictional character of a retired Egyptian hematologist named Refaat Ismail about a series of supernatural incidents that he was exposed to in his life, starting in 1959, or the stories that reach him from different people around the world, who heard about his relationship with the supernatural world.\r\n\r\nThe Metaphysical series began in 1993, and until 2014 Issue 80 was issued, which is The Legend of Legends, Part Two, in which the writer ended Rifaat Ismail’s life with an incurable disease, with the promise of issuing stories that he had not yet told, found in his diaries after his death. Rifaat Ismail's 1993 debut was an account of his adventure with the mummy of Count Dracula in 1959 and the subsequent adventure in 1961 with a werewolf in Romania.",
                    Genre = "Mystery, horror and thriller",
                    AuthorId = AuthorSeeder.AuthorIds.Author1Id,

                },
                new
                {
                    BookId = BookIds.Book3Id,
                    Title = "Safari",
                    Description = "It is a series of Egyptian literary novels that take place in a medical atmosphere in the African land in the State of Cameroon. Her hero, Dr. Alaa Abdel-Azim, and the author of the series, Dr. Ahmed Khaled Tawfik. Written in a scientific and satirical comic style. It was published in 1996 and has 53 issues.",
                    Genre = "",
                    AuthorId = AuthorSeeder.AuthorIds.Author1Id,

                },
                new
                {
                    BookId = BookIds.Book4Id,
                    Title = "The Old Man and The see",
                    Description = "The Old Man and the Sea is a novella written by the American author Ernest Hemingway in 1951 in Cayo Blanco (Cuba), It was the last major work of fiction written by Hemingway that was published during his lifetime. One of his most famous works, it tells the story of Santiago, an aging Cuban fisherman who struggles with a giant marlin far out in the Gulf Stream off the coast of Cuba.\r\nIn 1953, The Old Man and the Sea was awarded the Pulitzer Prize for Fiction, and it was cited by the Nobel Committee as contributing to their awarding of the Nobel Prize in Literature to Hemingway in 1954.",
                    Genre = "Literary Fiction",
                    AuthorId = AuthorSeeder.AuthorIds.Author3Id,
                    PublicationDate = new DateTime(1952)
                },
                new
                {
                    BookId = BookIds.Book5Id,
                    Title = "War and peace",
                    Description = "Between the events of war and peace, the events of the novel take place, in which Tolstoy merged many major and minor characters, historical and fictional, created by Tolstoy himself. It gives a broad and clear picture of the life of luxury that the nobility lived in Russia during the era of tsarist rule. There are those who believe that the main characters Kabier Bzoukub and Prince Andrey represent different aspects of Tolstoy himself.",
                    Genre = "Novel, romantic, playful, and philosophical.",
                    PublicationDate = new DateTime(1869)
                }
                );
        }
        internal static class BookIds
        {
            public static readonly Guid Book1Id = Guid.NewGuid();
            public static readonly Guid Book2Id = Guid.NewGuid();
            public static readonly Guid Book3Id = Guid.NewGuid();
            public static readonly Guid Book4Id = Guid.NewGuid();
            public static readonly Guid Book5Id = Guid.NewGuid();
        }
    }
}
