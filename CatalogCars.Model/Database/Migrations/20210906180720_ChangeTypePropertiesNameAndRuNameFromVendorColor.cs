using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogCars.Model.Database.Migrations
{
    public partial class ChangeTypePropertiesNameAndRuNameFromVendorColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RuName",
                table: "VendorColors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VendorColors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "7bcb40f8-8b99-44af-bd0f-2851d7577060");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b7779469-89e4-4801-b09f-2b880d66c889", "AQAAAAEAACcQAAAAEEH8cGLzpGeSBZEqpMUxtUQOkbNPL/RJ5sHcVGOJFssg8c8OykGsM62Sw+WQlOGIgg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RuName",
                table: "VendorColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VendorColors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "4b5521c0-ff29-4ffe-9926-7c4b3601331b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5c194ab7-d760-424f-ad88-9b58c08e6be6", "AQAAAAEAACcQAAAAELiUhMiNhEh2nAqJw+Eff9jsLAx7UulBzL7ChFji5/N3x0AYJPSIKOoUIVl/uIVHhA==" });
        }
    }
}
