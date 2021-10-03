using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogCars.Model.Database.Migrations
{
    public partial class ChangeNamePropertyIsOficialOnIsOfficialEntitySalon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsOficial",
                table: "Salons",
                newName: "IsOfficial");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "85a98b49-fa77-448c-bdbe-1aba3c162fa0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c2f91154-e11f-45bf-8ac4-65429a3b2ae0", "AQAAAAEAACcQAAAAEG/JYnPbyLgN0SGBYoNw8p4nuqMfwX2dj4UF174w9ZJKOtJZmwxqEAw4Jx0LXDc6aw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsOfficial",
                table: "Salons",
                newName: "IsOficial");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "6c917c84-1114-4dc1-977a-8499ac6c5df0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d0285905-d21a-47dd-b7d7-e6b18666a07a", "AQAAAAEAACcQAAAAEBIIAY4UTke05aiL0lm0ugdS43Wo1+iXYc5EMXypwsP0MhzRtsq5diYjUJhzRZUUhw==" });
        }
    }
}
