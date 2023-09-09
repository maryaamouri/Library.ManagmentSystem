﻿// <auto-generated />
using System;
using Libro.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Libro.Identity.Migrations
{
    [DbContext(typeof(LibroIdentityDbContext))]
    [Migration("20230908191041_IdentityDbPart")]
    partial class IdentityDbPart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Libro.Identity.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("afd1c581-ec6b-48e4-8c24-dcfeff6f185a"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4bf47825-6c33-4887-8b13-a410754faca1",
                            Email = "admin1@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            LastName = "One",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN1@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN1",
                            PasswordHash = "AQAAAAIAAYagAAAAENS3xjGMkH1tW8Kd07rOzTs5ajABj4XL3TKv0Rv1h6DIR032ZJQ7iVoqk2SOA+cJ1Q==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "admin1"
                        },
                        new
                        {
                            Id = new Guid("9927d9b1-8c7c-4504-86ca-38be99646145"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "181e6c14-d8d3-45c2-91d1-e1544755c7fc",
                            Email = "librarian1@localhost.com",
                            EmailConfirmed = false,
                            FirstName = "Librarian",
                            LastName = "One",
                            LockoutEnabled = false,
                            NormalizedEmail = "LIBRARIAN1@LOCALHOST.COM",
                            NormalizedUserName = "LIBRARIAN1",
                            PasswordHash = "AQAAAAIAAYagAAAAEN+U2h6IiybAcG6Vf32YK/OMahnNAtYcrJE+7b4Ll+BxD5dezIMRus7rRBu8PtV18g==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "librarian1"
                        },
                        new
                        {
                            Id = new Guid("98024de3-2a03-4207-9730-793ecb9cc0a8"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1a6ea45e-dc8e-4fd3-86ff-4e78cd22f3e4",
                            Email = "user1@localhost.com",
                            EmailConfirmed = false,
                            FirstName = "User",
                            LastName = "One",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER1@LOCALHOST.COM",
                            NormalizedUserName = "USER1",
                            PasswordHash = "AQAAAAIAAYagAAAAEHeCMF9Tq8c/bQRB4/GS38g6HCl6MtOGBgjxexgz1ZVQ/OKoLbcATyCepSLsOee2ng==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "user1"
                        });
                });

            modelBuilder.Entity("Libro.Identity.Entities.UserProfile", b =>
                {
                    b.Property<Guid>("UserProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserProfileId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfiles", (string)null);

                    b.HasData(
                        new
                        {
                            UserProfileId = new Guid("17f36ca0-0fa9-42ff-8956-b1bb29f4862a"),
                            UserId = new Guid("afd1c581-ec6b-48e4-8c24-dcfeff6f185a")
                        },
                        new
                        {
                            UserProfileId = new Guid("d2c33467-dd45-40bf-89cf-82689ac7140f"),
                            UserId = new Guid("9927d9b1-8c7c-4504-86ca-38be99646145")
                        },
                        new
                        {
                            UserProfileId = new Guid("36191df0-1b18-43a7-b66f-314c0e7e79ba"),
                            UserId = new Guid("98024de3-2a03-4207-9730-793ecb9cc0a8")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6b9f32ae-cc8d-4469-865f-4841396b27c6"),
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("4616af6d-91a5-43be-abdb-165a75fb2b65"),
                            Name = "Librarian",
                            NormalizedName = "LIBRARIAN"
                        },
                        new
                        {
                            Id = new Guid("2281be69-93a7-4d40-840d-96e34e1102e0"),
                            Name = "Patron",
                            NormalizedName = "PATRON"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("afd1c581-ec6b-48e4-8c24-dcfeff6f185a"),
                            RoleId = new Guid("6b9f32ae-cc8d-4469-865f-4841396b27c6")
                        },
                        new
                        {
                            UserId = new Guid("9927d9b1-8c7c-4504-86ca-38be99646145"),
                            RoleId = new Guid("4616af6d-91a5-43be-abdb-165a75fb2b65")
                        },
                        new
                        {
                            UserId = new Guid("98024de3-2a03-4207-9730-793ecb9cc0a8"),
                            RoleId = new Guid("2281be69-93a7-4d40-840d-96e34e1102e0")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Libro.Identity.Entities.UserProfile", b =>
                {
                    b.HasOne("Libro.Identity.Entities.ApplicationUser", "User")
                        .WithOne()
                        .HasForeignKey("Libro.Identity.Entities.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Libro.Identity.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Libro.Identity.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libro.Identity.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Libro.Identity.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
