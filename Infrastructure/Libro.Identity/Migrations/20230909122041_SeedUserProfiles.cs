using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libro.Identity.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98024de3-2a03-4207-9730-793ecb9cc0a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "efb7bdf4-b581-4634-b366-0bc0560f9b81", "AQAAAAIAAYagAAAAEHAHCoK2xjwFexZBqhGVyUnLp/XVPDLaeykn9g1Nswfaf3j3/ZDNxER5fASD8CFldg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9927d9b1-8c7c-4504-86ca-38be99646145"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dca28df9-425c-4697-bb5b-485f759c048d", "AQAAAAIAAYagAAAAEJQcYggEcSI5oK1iuqlewPXeDVmeTftguONZZgBU4+Kb6l0OskComyrEcVKlTr4G9A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("afd1c581-ec6b-48e4-8c24-dcfeff6f185a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f230379f-0f2a-4af0-bb46-b380e0828706", "AQAAAAIAAYagAAAAEI0lqlGHgES1J+0vl9EodQo/ZJ5QmxsGogOrhQhkpv1PYoq9fh2GGcCPHmIOsz1zlg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98024de3-2a03-4207-9730-793ecb9cc0a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1a6ea45e-dc8e-4fd3-86ff-4e78cd22f3e4", "AQAAAAIAAYagAAAAEHeCMF9Tq8c/bQRB4/GS38g6HCl6MtOGBgjxexgz1ZVQ/OKoLbcATyCepSLsOee2ng==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9927d9b1-8c7c-4504-86ca-38be99646145"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "181e6c14-d8d3-45c2-91d1-e1544755c7fc", "AQAAAAIAAYagAAAAEN+U2h6IiybAcG6Vf32YK/OMahnNAtYcrJE+7b4Ll+BxD5dezIMRus7rRBu8PtV18g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("afd1c581-ec6b-48e4-8c24-dcfeff6f185a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4bf47825-6c33-4887-8b13-a410754faca1", "AQAAAAIAAYagAAAAENS3xjGMkH1tW8Kd07rOzTs5ajABj4XL3TKv0Rv1h6DIR032ZJQ7iVoqk2SOA+cJ1Q==" });
        }
    }
}
