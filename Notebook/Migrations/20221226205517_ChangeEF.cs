using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class ChangeEF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 26, 23, 55, 16, 784, DateTimeKind.Local).AddTicks(9555), new DateTime(2022, 12, 26, 23, 55, 16, 784, DateTimeKind.Local).AddTicks(9556) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 26, 23, 47, 10, 878, DateTimeKind.Local).AddTicks(6474), new DateTime(2022, 12, 26, 23, 47, 10, 878, DateTimeKind.Local).AddTicks(6475) });
        }
    }
}
