using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogCars.Model.Database.Migrations
{
    public partial class ChangeTypePropertyTrunkVolumeMinFromConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TrunkVolumeMin",
                table: "Configurations",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "cd3afb95-ac44-4283-aa42-97e16c15150d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "55fe79b5-afe4-4140-b152-97ea11ade19d", "AQAAAAEAACcQAAAAEAeT6mkawIlx4VoHf453Na4fjcYc1CNH8W8TQLtdqhfr37cM00zmNMAj7nCEIiz1PA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TrunkVolumeMin",
                table: "Configurations",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "e051c4e0-471b-4603-9216-72f51d9e2c8e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "19ddf9e1-a0f9-4bcc-acef-37367eb79065", "AQAAAAEAACcQAAAAEBp0fy3f61e/MzmKtFivRc5ls3PIf7qV3kTcAuj3Gc5M9bh9ixwFkoz4UgDGxcSaOQ==" });
        }
    }
}
