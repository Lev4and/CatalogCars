using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogCars.Model.Database.Migrations
{
    public partial class ChangeTypePropertyLoyaltyProgramFromSalon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "LoyaltyProgram",
                table: "Salons",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "LoyaltyProgram",
                table: "Salons",
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
                value: "9b9f4b9a-2298-4c70-be7a-af5804e1c27b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8a8c1531-1561-4e7a-bff4-9797a5583e32", "AQAAAAEAACcQAAAAECGykTCd6I0yKVmyWtSfD0Uqxyh1Q/L412VfR2ziFwUWehEgrhSj8WZ/l/YNmpuGNQ==" });
        }
    }
}
