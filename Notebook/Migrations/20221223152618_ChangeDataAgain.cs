using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class ChangeDataAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 23, 18, 26, 18, 235, DateTimeKind.Local).AddTicks(3234), new DateTime(2022, 12, 23, 18, 26, 18, 235, DateTimeKind.Local).AddTicks(3234) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Username",
                value: "login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 23, 18, 23, 27, 173, DateTimeKind.Local).AddTicks(8635), new DateTime(2022, 12, 23, 18, 23, 27, 173, DateTimeKind.Local).AddTicks(8636) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Username",
                value: "\\u001a\\u0004\\u0015\\u001f\\u0005");
        }
    }
}
