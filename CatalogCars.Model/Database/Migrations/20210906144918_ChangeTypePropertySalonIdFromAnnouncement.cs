using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogCars.Model.Database.Migrations
{
    public partial class ChangeTypePropertySalonIdFromAnnouncement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Salons_SalonId",
                table: "Announcements");

            migrationBuilder.AlterColumn<Guid>(
                name: "SalonId",
                table: "Announcements",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "ce13e6ce-1eff-4774-b5e3-af29aff90b72");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7fc3728c-b729-4476-8f21-1fae02b1e151", "AQAAAAEAACcQAAAAEAmgk4fJzoWgaQnJGdVnUs38QTVG6QraZv8LSqKlLntlMUHdMzfG7msTOZIhTw84KQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Salons_SalonId",
                table: "Announcements",
                column: "SalonId",
                principalTable: "Salons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Salons_SalonId",
                table: "Announcements");

            migrationBuilder.AlterColumn<Guid>(
                name: "SalonId",
                table: "Announcements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "577c8155-60b5-485f-ab52-dde00368761a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b8b01008-1e33-4c27-82f2-6f6b3c9664a7", "AQAAAAEAACcQAAAAEEYxQJLDLRi8MYIbRc5DLBI5wqxl08JjeuQR40StpXXm0+kofjfWkPHvVnbAn2OaSA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Salons_SalonId",
                table: "Announcements",
                column: "SalonId",
                principalTable: "Salons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
