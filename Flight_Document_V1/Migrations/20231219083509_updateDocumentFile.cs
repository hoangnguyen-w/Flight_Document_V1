using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight_Document_V1.Migrations
{
    public partial class updateDocumentFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DocumentFile",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1,
                column: "CreateDateGroup",
                value: new DateTime(2023, 12, 19, 15, 35, 9, 575, DateTimeKind.Local).AddTicks(6118));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "DocumentFile",
                table: "Documents",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1,
                column: "CreateDateGroup",
                value: new DateTime(2023, 12, 14, 10, 39, 41, 634, DateTimeKind.Local).AddTicks(4514));
        }
    }
}
