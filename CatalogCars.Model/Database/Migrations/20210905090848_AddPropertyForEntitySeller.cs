using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogCars.Model.Database.Migrations
{
    public partial class AddPropertyForEntitySeller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "f6f4fa1d-5faf-40a8-b7a7-a25cc6dbd541");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7bc61e3c-fedd-4666-bf70-36cc97773a14", "AQAAAAEAACcQAAAAEGqidiY1UMI567llgzjf5mNtEID742FIBfpICKOMYSxOoMymmaHjeW0PK3rg9+tE4Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sellers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "07c6b81d-7f07-417c-8e58-4b3d62c258a5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a7a5c66a-2da8-42d7-a8d5-e94591caddf5", "AQAAAAEAACcQAAAAEFKWie1sbKgqM3sXrZQrVciDJFN7cWd5bSqRsQ27xHBEqnh2OCeHTMrIfDoe7Tnz1g==" });
        }
    }
}
