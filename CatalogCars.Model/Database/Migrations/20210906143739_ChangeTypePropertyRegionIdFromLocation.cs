using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogCars.Model.Database.Migrations
{
    public partial class ChangeTypePropertyRegionIdFromLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Regions_RegionId",
                table: "Locations");

            migrationBuilder.AlterColumn<Guid>(
                name: "RegionId",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                name: "FK_Locations_Regions_RegionId",
                table: "Locations",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Regions_RegionId",
                table: "Locations");

            migrationBuilder.AlterColumn<Guid>(
                name: "RegionId",
                table: "Locations",
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
                value: "99650a9c-baa6-4dca-8cdd-f6469710504c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a6e8a9b8-efd0-4eba-9a0c-a3deb2af95f4", "AQAAAAEAACcQAAAAELcljTuGPZX9Y5F7jBerYRZ+URiBSgeWM1UYYZvUZ25olD6hwgdJtJ4p/JvWq+k4VA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Regions_RegionId",
                table: "Locations",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
