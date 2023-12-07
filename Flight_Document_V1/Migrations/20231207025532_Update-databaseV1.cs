using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight_Document_V1.Migrations
{
    public partial class UpdatedatabaseV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenCreated",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpires",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1,
                column: "CreateDateGroup",
                value: new DateTime(2023, 12, 7, 9, 55, 32, 47, DateTimeKind.Local).AddTicks(2709));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "TokenCreated",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "TokenExpires",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1,
                column: "CreateDateGroup",
                value: new DateTime(2023, 12, 7, 9, 42, 42, 456, DateTimeKind.Local).AddTicks(6451));
        }
    }
}
