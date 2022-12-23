using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class ChangeDataAgain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 23, 18, 28, 49, 574, DateTimeKind.Local).AddTicks(6743), new DateTime(2022, 12, 23, 18, 28, 49, 574, DateTimeKind.Local).AddTicks(6744) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "\\u0001\\0\\u0018\\u0002\\u0016\\u0004\\u0003\\u0005");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "Password",
                value: "\\u0006\\n\\u0001\\u0005\\u001c\\u001d\\u0004\\u000f");
        }
    }
}
