    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    #nullable disable

    #pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

    namespace Libro.Identity.Migrations
    {
        /// <inheritdoc />
        public partial class IdentityDbPart : Migration
        {
            /// <inheritdoc />
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.CreateTable(
                    name: "AspNetRoles",
                    columns: table => new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                    });

                migrationBuilder.CreateTable(
                    name: "AspNetUsers",
                    columns: table => new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    });

                migrationBuilder.CreateTable(
                    name: "AspNetRoleClaims",
                    columns: table => new
                    {
                        Id = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                        table.ForeignKey(
                            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                            column: x => x.RoleId,
                            principalTable: "AspNetRoles",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

                migrationBuilder.CreateTable(
                    name: "AspNetUserClaims",
                    columns: table => new
                    {
                        Id = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                        table.ForeignKey(
                            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                            column: x => x.UserId,
                            principalTable: "AspNetUsers",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

                migrationBuilder.CreateTable(
                    name: "AspNetUserLogins",
                    columns: table => new
                    {
                        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                        ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                        table.ForeignKey(
                            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                            column: x => x.UserId,
                            principalTable: "AspNetUsers",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

                migrationBuilder.CreateTable(
                    name: "AspNetUserRoles",
                    columns: table => new
                    {
                        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                        table.ForeignKey(
                            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                            column: x => x.RoleId,
                            principalTable: "AspNetRoles",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                            column: x => x.UserId,
                            principalTable: "AspNetUsers",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

                migrationBuilder.CreateTable(
                    name: "AspNetUserTokens",
                    columns: table => new
                    {
                        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                        Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                        table.ForeignKey(
                            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                            column: x => x.UserId,
                            principalTable: "AspNetUsers",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

                migrationBuilder.CreateTable(
                    name: "UserProfiles",
                    columns: table => new
                    {
                        UserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_UserProfiles", x => x.UserProfileId);
                        table.ForeignKey(
                            name: "FK_UserProfiles_AspNetUsers_UserId",
                            column: x => x.UserId,
                            principalTable: "AspNetUsers",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade);
                    });

                migrationBuilder.InsertData(
                    table: "AspNetRoles",
                    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                    values: new object[,]
                    {
                        { new Guid("2281be69-93a7-4d40-840d-96e34e1102e0"), null, "Patron", "PATRON" },
                        { new Guid("4616af6d-91a5-43be-abdb-165a75fb2b65"), null, "Librarian", "LIBRARIAN" },
                        { new Guid("6b9f32ae-cc8d-4469-865f-4841396b27c6"), null, "Admin", "ADMIN" }
                    });

                migrationBuilder.InsertData(
                    table: "AspNetUsers",
                    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                    values: new object[,]
                    {
                        { new Guid("98024de3-2a03-4207-9730-793ecb9cc0a8"), 0, "1a6ea45e-dc8e-4fd3-86ff-4e78cd22f3e4", "user1@localhost.com", false, "User", "One", false, null, "USER1@LOCALHOST.COM", "USER1", "AQAAAAIAAYagAAAAEHeCMF9Tq8c/bQRB4/GS38g6HCl6MtOGBgjxexgz1ZVQ/OKoLbcATyCepSLsOee2ng==", null, false, null, false, "user1" },
                        { new Guid("9927d9b1-8c7c-4504-86ca-38be99646145"), 0, "181e6c14-d8d3-45c2-91d1-e1544755c7fc", "librarian1@localhost.com", false, "Librarian", "One", false, null, "LIBRARIAN1@LOCALHOST.COM", "LIBRARIAN1", "AQAAAAIAAYagAAAAEN+U2h6IiybAcG6Vf32YK/OMahnNAtYcrJE+7b4Ll+BxD5dezIMRus7rRBu8PtV18g==", null, false, null, false, "librarian1" },
                        { new Guid("afd1c581-ec6b-48e4-8c24-dcfeff6f185a"), 0, "4bf47825-6c33-4887-8b13-a410754faca1", "admin1@localhost.com", true, "Admin", "One", false, null, "ADMIN1@LOCALHOST.COM", "ADMIN1", "AQAAAAIAAYagAAAAENS3xjGMkH1tW8Kd07rOzTs5ajABj4XL3TKv0Rv1h6DIR032ZJQ7iVoqk2SOA+cJ1Q==", null, false, null, false, "admin1" }
                    });

                migrationBuilder.InsertData(
                    table: "AspNetUserRoles",
                    columns: new[] { "RoleId", "UserId" },
                    values: new object[,]
                    {
                        { new Guid("2281be69-93a7-4d40-840d-96e34e1102e0"), new Guid("98024de3-2a03-4207-9730-793ecb9cc0a8") },
                        { new Guid("4616af6d-91a5-43be-abdb-165a75fb2b65"), new Guid("9927d9b1-8c7c-4504-86ca-38be99646145") },
                        { new Guid("6b9f32ae-cc8d-4469-865f-4841396b27c6"), new Guid("afd1c581-ec6b-48e4-8c24-dcfeff6f185a") }
                    });

                migrationBuilder.InsertData(
                    table: "UserProfiles",
                    columns: new[] { "UserProfileId", "UserId" },
                    values: new object[,]
                    {
                        { new Guid("17f36ca0-0fa9-42ff-8956-b1bb29f4862a"), new Guid("afd1c581-ec6b-48e4-8c24-dcfeff6f185a") },
                        { new Guid("36191df0-1b18-43a7-b66f-314c0e7e79ba"), new Guid("98024de3-2a03-4207-9730-793ecb9cc0a8") },
                        { new Guid("d2c33467-dd45-40bf-89cf-82689ac7140f"), new Guid("9927d9b1-8c7c-4504-86ca-38be99646145") }
                    });

                migrationBuilder.CreateIndex(
                    name: "IX_AspNetRoleClaims_RoleId",
                    table: "AspNetRoleClaims",
                    column: "RoleId");

                migrationBuilder.CreateIndex(
                    name: "RoleNameIndex",
                    table: "AspNetRoles",
                    column: "NormalizedName",
                    unique: true,
                    filter: "[NormalizedName] IS NOT NULL");

                migrationBuilder.CreateIndex(
                    name: "IX_AspNetUserClaims_UserId",
                    table: "AspNetUserClaims",
                    column: "UserId");

                migrationBuilder.CreateIndex(
                    name: "IX_AspNetUserLogins_UserId",
                    table: "AspNetUserLogins",
                    column: "UserId");

                migrationBuilder.CreateIndex(
                    name: "IX_AspNetUserRoles_RoleId",
                    table: "AspNetUserRoles",
                    column: "RoleId");

                migrationBuilder.CreateIndex(
                    name: "EmailIndex",
                    table: "AspNetUsers",
                    column: "NormalizedEmail");

                migrationBuilder.CreateIndex(
                    name: "UserNameIndex",
                    table: "AspNetUsers",
                    column: "NormalizedUserName",
                    unique: true,
                    filter: "[NormalizedUserName] IS NOT NULL");

                migrationBuilder.CreateIndex(
                    name: "IX_UserProfiles_UserId",
                    table: "UserProfiles",
                    column: "UserId",
                    unique: true);
            }

            /// <inheritdoc />
            protected override void Down(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.DropTable(
                    name: "AspNetRoleClaims");

                migrationBuilder.DropTable(
                    name: "AspNetUserClaims");

                migrationBuilder.DropTable(
                    name: "AspNetUserLogins");

                migrationBuilder.DropTable(
                    name: "AspNetUserRoles");

                migrationBuilder.DropTable(
                    name: "AspNetUserTokens");

                migrationBuilder.DropTable(
                    name: "UserProfiles");

                migrationBuilder.DropTable(
                    name: "AspNetRoles");

                migrationBuilder.DropTable(
                    name: "AspNetUsers");
            }
        }
    }
