using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogCars.Model.Database.Migrations
{
    public partial class ChangeTypeProperiesNameAndRuNameFromBodyTypeGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b867520a-92db-4658-be39-84da53a601c0"),
                column: "ConcurrencyStamp",
                value: "77873325-fd92-4a24-bce5-b97dbcd87efb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21f7b496-c675-4e8a-a34c-fc5ec0762fdb"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0bb2212-7173-4e49-bc59-3f27dd525aa5", "AQAAAAEAACcQAAAAEJuyaoLLIfCUxDMnGI+FzweG23WE0bD48y3aLWMvf2/4ncrNol78iUHwSZ16SanNBQ==" });
        }
    }
}
