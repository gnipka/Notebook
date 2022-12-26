using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class ChangeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Time",
                table: "KeyboardPoints",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "RightLimit",
                table: "KeyboardPoints",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "LeftLimit",
                table: "KeyboardPoints",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 27, 1, 49, 36, 828, DateTimeKind.Local).AddTicks(3193), new DateTime(2022, 12, 27, 1, 49, 36, 828, DateTimeKind.Local).AddTicks(3195) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Time",
                table: "KeyboardPoints",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "RightLimit",
                table: "KeyboardPoints",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<long>(
                name: "LeftLimit",
                table: "KeyboardPoints",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 26, 23, 56, 42, 16, DateTimeKind.Local).AddTicks(2523), new DateTime(2022, 12, 26, 23, 56, 42, 16, DateTimeKind.Local).AddTicks(2524) });
        }
    }
}
