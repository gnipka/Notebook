using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class ChangeAppContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 26, 23, 56, 42, 16, DateTimeKind.Local).AddTicks(2523), new DateTime(2022, 12, 26, 23, 56, 42, 16, DateTimeKind.Local).AddTicks(2524) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmountOfSymbol", "ErrorRate" },
                values: new object[] { 1, 30 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 26, 23, 55, 16, 784, DateTimeKind.Local).AddTicks(9555), new DateTime(2022, 12, 26, 23, 55, 16, 784, DateTimeKind.Local).AddTicks(9556) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmountOfSymbol", "ErrorRate" },
                values: new object[] { 0, 0 });
        }
    }
}
