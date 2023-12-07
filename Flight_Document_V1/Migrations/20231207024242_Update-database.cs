using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight_Document_V1.Migrations
{
    public partial class Updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1,
                column: "CreateDateGroup",
                value: new DateTime(2023, 12, 7, 9, 42, 42, 456, DateTimeKind.Local).AddTicks(6451));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1,
                column: "CreateDateGroup",
                value: new DateTime(2023, 12, 6, 14, 49, 13, 555, DateTimeKind.Local).AddTicks(5788));
        }
    }
}
