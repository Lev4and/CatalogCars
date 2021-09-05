using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogCars.Model.Database.Migrations
{
    public partial class AddPropertyForEntityVendorColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMainColor",
                table: "VendorColors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "99650a9c-baa6-4dca-8cdd-f6469710504c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a6e8a9b8-efd0-4eba-9a0c-a3deb2af95f4", "AQAAAAEAACcQAAAAELcljTuGPZX9Y5F7jBerYRZ+URiBSgeWM1UYYZvUZ25olD6hwgdJtJ4p/JvWq+k4VA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMainColor",
                table: "VendorColors");

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
    }
}
