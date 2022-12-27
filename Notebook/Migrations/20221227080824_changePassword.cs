using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class changePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 27, 11, 8, 22, 697, DateTimeKind.Local).AddTicks(748), new DateTime(2022, 12, 27, 11, 8, 22, 697, DateTimeKind.Local).AddTicks(749) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "иёжлчЪкє");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 27, 1, 49, 36, 828, DateTimeKind.Local).AddTicks(3193), new DateTime(2022, 12, 27, 1, 49, 36, 828, DateTimeKind.Local).AddTicks(3195) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "\\u0001\\0\\u0018\\u0002\\u0016\\u0004\\u0003\\u0005");
        }
    }
}
