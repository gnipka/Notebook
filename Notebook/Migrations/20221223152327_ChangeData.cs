using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class ChangeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "DateRegister", "Password", "Username" },
                values: new object[] { new DateTime(2022, 12, 23, 17, 33, 13, 0, DateTimeKind.Unspecified), "\\u0006\\n\\u0001\\u0005\\u001c\\u001d\\u0004\\u000f", "\\u001a\\u0004\\u0015\\u001f\\u0005" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 23, 17, 33, 13, 945, DateTimeKind.Local).AddTicks(974), new DateTime(2022, 12, 23, 17, 33, 13, 945, DateTimeKind.Local).AddTicks(975) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateRegister", "Password", "Username" },
                values: new object[] { new DateTime(2022, 12, 23, 17, 33, 13, 945, DateTimeKind.Local).AddTicks(1085), "\\u001e\\u000f\\u001d\\u001d\\u0019\\u0001\\u001c\\n", "login" });
        }
    }
}
