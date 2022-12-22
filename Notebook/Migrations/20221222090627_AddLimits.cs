using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class AddLimits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LeftLimit",
                table: "KeyboardPoints",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RightLimit",
                table: "KeyboardPoints",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 22, 12, 6, 25, 816, DateTimeKind.Local).AddTicks(2237), new DateTime(2022, 12, 22, 12, 6, 25, 816, DateTimeKind.Local).AddTicks(2239) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegister",
                value: new DateTime(2022, 12, 22, 12, 6, 25, 816, DateTimeKind.Local).AddTicks(2603));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeftLimit",
                table: "KeyboardPoints");

            migrationBuilder.DropColumn(
                name: "RightLimit",
                table: "KeyboardPoints");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 21, 23, 15, 24, 642, DateTimeKind.Local).AddTicks(1737), new DateTime(2022, 12, 21, 23, 15, 24, 642, DateTimeKind.Local).AddTicks(1738) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegister",
                value: new DateTime(2022, 12, 21, 23, 15, 24, 642, DateTimeKind.Local).AddTicks(2016));
        }
    }
}
