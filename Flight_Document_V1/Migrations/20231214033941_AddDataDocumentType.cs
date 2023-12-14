using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight_Document_V1.Migrations
{
    public partial class AddDataDocumentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "DocumentTypeID", "DocumentTypeName" },
                values: new object[,]
                {
                    { 1, "Load Summary" },
                    { 2, "Summary" },
                    { 3, "Loading Instruction" }
                });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1,
                column: "CreateDateGroup",
                value: new DateTime(2023, 12, 14, 10, 39, 41, 634, DateTimeKind.Local).AddTicks(4514));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "DocumentTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "DocumentTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "DocumentTypeID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1,
                column: "CreateDateGroup",
                value: new DateTime(2023, 12, 7, 9, 55, 32, 47, DateTimeKind.Local).AddTicks(2709));
        }
    }
}
