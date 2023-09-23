using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libro.Identity.Migrations
{
    /// <inheritdoc />
    public partial class adsecstamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98024de3-2a03-4207-9730-793ecb9cc0a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserProfileId" },
                values: new object[] { "9e92743b-5e32-4ee8-abb4-c1c3ab35ffca", "AQAAAAIAAYagAAAAEI/fZ09si1GnK4zSZp6astWYxjYSG0zDpPfsaEflX0LPdtYKct4gCmx/8Vs2PvplPQ==", "9555c206-1f36-4695-8388-a3e6d424645e", new Guid("15429dfc-ca5b-4f88-bbbf-81f6875f6ce8") });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9927d9b1-8c7c-4504-86ca-38be99646145"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserProfileId" },
                values: new object[] { "c524bff2-f484-4740-a7d6-da9459f2f939", "AQAAAAIAAYagAAAAEP5EYsr70wS8z33XmLc/m0lr2iIwn97QAQe0VChaqs1qjOlcYMjRs0pc8yxD9n2wAw==", "a959da88-913e-4565-b3a0-2031715aa5dc", new Guid("84c28792-a7b8-40d9-b54c-5023e7818785") });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("afd1c581-ec6b-48e4-8c24-dcfeff6f185a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserProfileId" },
                values: new object[] { "c2809e2f-2751-461c-ae97-b64847eda446", "AQAAAAIAAYagAAAAEPaeA465t9L31T9+Fo48bSyoi8lLeZnOLaPM/PLt2waBsn58Fu+AiIZl+w29SK++aA==", "83535c9f-b361-4bdd-a7da-ca6984375015", new Guid("34bd7fe3-2a83-45fd-904c-71ebdab32087") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98024de3-2a03-4207-9730-793ecb9cc0a8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserProfileId" },
                values: new object[] { "64b7d3b1-c630-46ae-bac6-f7f20836c98d", "AQAAAAIAAYagAAAAEEg8VXeP+8oERyEpgmFjNwNZVATH85YMe6Yg/IXHND4vh2taBKF7LfvGBHL7OnbjLw==", null, new Guid("58ec5ba8-7861-4238-ac63-d40285a16814") });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9927d9b1-8c7c-4504-86ca-38be99646145"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserProfileId" },
                values: new object[] { "19293701-ee27-4333-a6db-ff12d1449dcd", "AQAAAAIAAYagAAAAEIfZCrXa5poWFILuOIzBGqeozpfMg1sGUekU84QawHoSdMguEITCWKX/eIYX914NKw==", null, new Guid("f524f584-905d-4530-8886-f60a9371ef72") });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("afd1c581-ec6b-48e4-8c24-dcfeff6f185a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserProfileId" },
                values: new object[] { "94768328-5ac0-4849-a6d8-252b6925aeef", "AQAAAAIAAYagAAAAEErfAbnqABCOK/EHzK5k8SRwvvKQDVQKNFL4lebweC4unv61N2KcJleYuxMvkEOMrw==", null, new Guid("b01e352f-3694-4885-9053-11beefcf8291") });
        }
    }
}
