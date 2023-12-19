using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight_Document_V1.Migrations
{
    public partial class updateDocumentFileV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateDocument",
                table: "Documents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1,
                column: "CreateDateGroup",
                value: new DateTime(2023, 12, 19, 15, 51, 23, 178, DateTimeKind.Local).AddTicks(9833));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDateDocument",
                table: "Documents");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1,
                column: "CreateDateGroup",
                value: new DateTime(2023, 12, 19, 15, 43, 37, 238, DateTimeKind.Local).AddTicks(5334));
        }
    }
}
