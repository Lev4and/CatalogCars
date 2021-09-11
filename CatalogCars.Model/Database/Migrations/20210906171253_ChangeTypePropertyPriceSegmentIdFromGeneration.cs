using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogCars.Model.Database.Migrations
{
    public partial class ChangeTypePropertyPriceSegmentIdFromGeneration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Generations_PriceSegments_PriceSegmentId",
                table: "Generations");

            migrationBuilder.AlterColumn<Guid>(
                name: "PriceSegmentId",
                table: "Generations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Generations_PriceSegments_PriceSegmentId",
                table: "Generations",
                column: "PriceSegmentId",
                principalTable: "PriceSegments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Generations_PriceSegments_PriceSegmentId",
                table: "Generations");

            migrationBuilder.AlterColumn<Guid>(
                name: "PriceSegmentId",
                table: "Generations",
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
                value: "24f16f1d-08d0-4886-88cd-6c09272680e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4921bea4-899d-4ef9-8b72-9542e1f98c83", "AQAAAAEAACcQAAAAEN0A4gQslqWr+Ror6NQjlU4OShgCZyGNhUzF5V/y6nPUdz7+AYdLOEVUkPex5sJsqg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Generations_PriceSegments_PriceSegmentId",
                table: "Generations",
                column: "PriceSegmentId",
                principalTable: "PriceSegments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
