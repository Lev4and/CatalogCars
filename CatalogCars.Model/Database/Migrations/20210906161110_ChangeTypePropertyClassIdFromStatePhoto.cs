using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogCars.Model.Database.Migrations
{
    public partial class ChangeTypePropertyClassIdFromStatePhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatePhotos_PhotoClasses_ClassId",
                table: "StatePhotos");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClassId",
                table: "StatePhotos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "cace9a02-ed06-4ef8-bac3-b0a54ad1998a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9ca65835-4827-4de5-ad1e-5b54112e3290", "AQAAAAEAACcQAAAAEKKLJJLhnKX9RrUv/b4OBwoI8HTQzud5BRTwmwI/vmGGHpx0tc7UkWhY2P0nICojBQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_StatePhotos_PhotoClasses_ClassId",
                table: "StatePhotos",
                column: "ClassId",
                principalTable: "PhotoClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatePhotos_PhotoClasses_ClassId",
                table: "StatePhotos");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClassId",
                table: "StatePhotos",
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
                value: "656da334-f0a8-4c97-8186-cb1fa17a5561");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8982dd2f-bb2a-48b6-832a-aa94366c2378", "AQAAAAEAACcQAAAAEGNuqBPwtcEgrSzZMN8OqWgB45C4HW1X6R7nmP8axww5cStUKeiDJ/0AJfUAk39mOA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_StatePhotos_PhotoClasses_ClassId",
                table: "StatePhotos",
                column: "ClassId",
                principalTable: "PhotoClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
