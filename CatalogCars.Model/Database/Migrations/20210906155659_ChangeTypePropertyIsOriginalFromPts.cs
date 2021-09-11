using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogCars.Model.Database.Migrations
{
    public partial class ChangeTypePropertyIsOriginalFromPts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsOriginal",
                table: "Pts",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "656da334-f0a8-4c97-8186-cb1fa17a5561");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8982dd2f-bb2a-48b6-832a-aa94366c2378", "AQAAAAEAACcQAAAAEGNuqBPwtcEgrSzZMN8OqWgB45C4HW1X6R7nmP8axww5cStUKeiDJ/0AJfUAk39mOA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsOriginal",
                table: "Pts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "129831a5-fdf6-4a36-80a8-1d0b80e160da");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "75f201f1-b194-44d9-bb53-bdb7a956d0de", "AQAAAAEAACcQAAAAEIqQLYShmn2f6yCRihyvX42wKFuTqjW3htpGCZLxoPN2Ctc6wypbYQsnPmtJTNzGpA==" });
        }
    }
}
