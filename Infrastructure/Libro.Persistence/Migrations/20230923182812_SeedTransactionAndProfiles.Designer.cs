﻿// <auto-generated />
using System;
using Libro.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Libro.Persistence.Migrations
{
    [DbContext(typeof(LiboDbContext))]
    [Migration("20230923182812_SeedTransactionAndProfiles")]
    partial class SeedTransactionAndProfiles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Library")
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Libro.Infrastructure.Shared.UserProfiles.UserProfile", b =>
                {
                    b.Property<Guid>("UserProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserProfileId");

                    b.ToTable("UserProfiles", "Library");

                    b.HasData(
                        new
                        {
                            UserProfileId = new Guid("15826e76-8cc6-476c-bbc8-b21309de5186"),
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            UserProfileId = new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"),
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            UserProfileId = new Guid("41e93277-782b-492d-977a-e3902acabac6"),
                            UserId = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Libro.Persistence.DbModels.Author", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors", "Library");

                    b.HasData(
                        new
                        {
                            AuthorId = new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"),
                            Name = "Ahmad Khalid Tawfeeq"
                        },
                        new
                        {
                            AuthorId = new Guid("2df4e17e-5cdd-4eed-8986-b832cf38e849"),
                            Name = "Gabriel Garcia Marquez"
                        },
                        new
                        {
                            AuthorId = new Guid("7a7b6727-c07e-410d-b79d-def9fb359cb0"),
                            Name = "Ernest Hemingway"
                        },
                        new
                        {
                            AuthorId = new Guid("5a0c6e0f-d489-4e27-bcb0-3f860316773b"),
                            Name = "Fyodor Mikhailovich Dostoyevsky"
                        },
                        new
                        {
                            AuthorId = new Guid("7698d22f-95ac-47c0-a3f7-389f826e7512"),
                            Name = "George Orwell"
                        },
                        new
                        {
                            AuthorId = new Guid("1b4990dc-409a-43b9-9694-ef1b572a4fde"),
                            Name = "Naguib Mahfouz"
                        },
                        new
                        {
                            AuthorId = new Guid("50c84ade-07ca-4676-b9b2-d11715a5f4a1"),
                            Name = "Ghassan Kanafani"
                        });
                });

            modelBuilder.Entity("Libro.Persistence.DbModels.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Genre")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books", "Library");

                    b.HasData(
                        new
                        {
                            BookId = new Guid("e49950f8-5bf0-4df2-b9d2-d56c203b1ece"),
                            AuthorId = new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"),
                            Description = "the story of Abeer, who encounters Sherif, a brilliant computer expert seeking an ordinary girl for an experiment with his Dream Maker device. This device reprograms cultural experiences into adventures. Abeer's rich imagination makes her an ideal subject. She embarks on interactive journeys with iconic characters like Superman and Tarzan. Abeer's adventures span various worlds, encountering both fictional and real figures, including James Bond, Shakespeare, and Che Guevara. The narrative blends fantasy with reality, offering a diverse and exciting narrative landscape.",
                            Genre = "fantasy",
                            PublicationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2015),
                            Title = "fantasy"
                        },
                        new
                        {
                            BookId = new Guid("18ef09e4-41da-4bb5-a669-3cfc0cc3df9b"),
                            AuthorId = new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"),
                            Description = "A fictional character of a retired Egyptian hematologist named Refaat Ismail about a series of supernatural incidents that he was exposed to in his life, starting in 1959, or the stories that reach him from different people around the world, who heard about his relationship with the supernatural world.\r\n\r\nThe Metaphysical series began in 1993, and until 2014 Issue 80 was issued, which is The Legend of Legends, Part Two, in which the writer ended Rifaat Ismail’s life with an incurable disease, with the promise of issuing stories that he had not yet told, found in his diaries after his death. Rifaat Ismail's 1993 debut was an account of his adventure with the mummy of Count Dracula in 1959 and the subsequent adventure in 1961 with a werewolf in Romania.",
                            Genre = "Mystery, horror and thriller",
                            Title = "Metaphisics(supernatural)"
                        },
                        new
                        {
                            BookId = new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"),
                            AuthorId = new Guid("4f6bf45f-8954-4882-88d8-40b1b7eee27f"),
                            Description = "It is a series of Egyptian literary novels that take place in a medical atmosphere in the African land in the State of Cameroon. Her hero, Dr. Alaa Abdel-Azim, and the author of the series, Dr. Ahmed Khaled Tawfik. Written in a scientific and satirical comic style. It was published in 1996 and has 53 issues.",
                            Genre = "",
                            Title = "Safari"
                        },
                        new
                        {
                            BookId = new Guid("e9f13de1-39c7-4198-8762-f087637b03ce"),
                            AuthorId = new Guid("7a7b6727-c07e-410d-b79d-def9fb359cb0"),
                            Description = "The Old Man and the Sea is a novella written by the American author Ernest Hemingway in 1951 in Cayo Blanco (Cuba), It was the last major work of fiction written by Hemingway that was published during his lifetime. One of his most famous works, it tells the story of Santiago, an aging Cuban fisherman who struggles with a giant marlin far out in the Gulf Stream off the coast of Cuba.\r\nIn 1953, The Old Man and the Sea was awarded the Pulitzer Prize for Fiction, and it was cited by the Nobel Committee as contributing to their awarding of the Nobel Prize in Literature to Hemingway in 1954.",
                            Genre = "Literary Fiction",
                            PublicationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1952),
                            Title = "The Old Man and The see"
                        },
                        new
                        {
                            BookId = new Guid("d7dab5f9-2408-40c7-80c2-47cd50b16eed"),
                            Description = "Between the events of war and peace, the events of the novel take place, in which Tolstoy merged many major and minor characters, historical and fictional, created by Tolstoy himself. It gives a broad and clear picture of the life of luxury that the nobility lived in Russia during the era of tsarist rule. There are those who believe that the main characters Kabier Bzoukub and Prince Andrey represent different aspects of Tolstoy himself.",
                            Genre = "Novel, romantic, playful, and philosophical.",
                            PublicationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1869),
                            Title = "War and peace"
                        });
                });

            modelBuilder.Entity("Libro.Persistence.DbModels.Transaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ActualReturnedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BorrowedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LibrarianId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatronId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TransactionId");

                    b.HasIndex("BookId");

                    b.HasIndex("LibrarianId");

                    b.HasIndex("PatronId");

                    b.ToTable("Transactions", "Library");

                    b.HasData(
                        new
                        {
                            TransactionId = new Guid("3a5712b9-d6f4-460a-933c-f6bf9349c03d"),
                            ActualReturnedDate = new DateTime(2014, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookId = new Guid("e49950f8-5bf0-4df2-b9d2-d56c203b1ece"),
                            BorrowedDate = new DateTime(2014, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2014, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAccepted = true,
                            IsCanceled = false,
                            IsDeleted = false,
                            LibrarianId = new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"),
                            PatronId = new Guid("41e93277-782b-492d-977a-e3902acabac6")
                        },
                        new
                        {
                            TransactionId = new Guid("38c48cd9-4435-4a06-aed6-bb6f6401ba3e"),
                            ActualReturnedDate = new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookId = new Guid("e49950f8-5bf0-4df2-b9d2-d56c203b1ece"),
                            BorrowedDate = new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAccepted = true,
                            IsCanceled = false,
                            IsDeleted = false,
                            LibrarianId = new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"),
                            PatronId = new Guid("41e93277-782b-492d-977a-e3902acabac6")
                        },
                        new
                        {
                            TransactionId = new Guid("1837db29-2100-49c1-b8af-cacc2520298a"),
                            BookId = new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"),
                            IsCanceled = true,
                            IsDeleted = false,
                            LibrarianId = new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"),
                            PatronId = new Guid("41e93277-782b-492d-977a-e3902acabac6")
                        },
                        new
                        {
                            TransactionId = new Guid("11b7ee53-2480-43f5-aad8-b47abb869970"),
                            ActualReturnedDate = new DateTime(2022, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookId = new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"),
                            BorrowedDate = new DateTime(2022, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2022, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAccepted = true,
                            IsCanceled = false,
                            IsDeleted = false,
                            LibrarianId = new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"),
                            PatronId = new Guid("41e93277-782b-492d-977a-e3902acabac6")
                        },
                        new
                        {
                            TransactionId = new Guid("df13218c-1292-46a5-9e01-fb6488419a31"),
                            ActualReturnedDate = new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookId = new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"),
                            BorrowedDate = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAccepted = true,
                            IsCanceled = false,
                            IsDeleted = false,
                            LibrarianId = new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"),
                            PatronId = new Guid("41e93277-782b-492d-977a-e3902acabac6")
                        },
                        new
                        {
                            TransactionId = new Guid("b074b06b-9be3-4e2c-93ff-62ee6472910a"),
                            ActualReturnedDate = new DateTime(2022, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookId = new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"),
                            BorrowedDate = new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAccepted = true,
                            IsCanceled = false,
                            IsDeleted = false,
                            LibrarianId = new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"),
                            PatronId = new Guid("41e93277-782b-492d-977a-e3902acabac6")
                        },
                        new
                        {
                            TransactionId = new Guid("2de78a2e-4b61-4bc6-b10f-213f18c2e1a1"),
                            ActualReturnedDate = new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookId = new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"),
                            BorrowedDate = new DateTime(2022, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAccepted = true,
                            IsCanceled = false,
                            IsDeleted = false,
                            LibrarianId = new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"),
                            PatronId = new Guid("41e93277-782b-492d-977a-e3902acabac6")
                        },
                        new
                        {
                            TransactionId = new Guid("e9f413bd-3282-43f6-9f01-499b6cf51cb0"),
                            ActualReturnedDate = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookId = new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"),
                            BorrowedDate = new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAccepted = true,
                            IsCanceled = false,
                            IsDeleted = false,
                            LibrarianId = new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"),
                            PatronId = new Guid("41e93277-782b-492d-977a-e3902acabac6")
                        },
                        new
                        {
                            TransactionId = new Guid("efd73efa-d566-4a8e-a3ed-420ab6cd74f2"),
                            ActualReturnedDate = new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BookId = new Guid("f8b1eb22-9d46-457e-a15f-00c513fb5d6e"),
                            BorrowedDate = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsAccepted = true,
                            IsCanceled = false,
                            IsDeleted = false,
                            LibrarianId = new Guid("0f295e3a-a347-455d-a39f-93fc6bdefee6"),
                            PatronId = new Guid("41e93277-782b-492d-977a-e3902acabac6")
                        });
                });

            modelBuilder.Entity("Libro.Persistence.DbModels.Book", b =>
                {
                    b.HasOne("Libro.Persistence.DbModels.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Libro.Persistence.DbModels.Transaction", b =>
                {
                    b.HasOne("Libro.Persistence.DbModels.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libro.Infrastructure.Shared.UserProfiles.UserProfile", null)
                        .WithMany()
                        .HasForeignKey("LibrarianId");

                    b.HasOne("Libro.Infrastructure.Shared.UserProfiles.UserProfile", null)
                        .WithMany()
                        .HasForeignKey("PatronId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}