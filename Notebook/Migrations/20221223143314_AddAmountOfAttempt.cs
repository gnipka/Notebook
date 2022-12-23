using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class AddAmountOfAttempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountOfAttempt",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "AmountOfAttempt", "DateRegister" },
                values: new object[] { 3, new DateTime(2022, 12, 23, 17, 33, 13, 945, DateTimeKind.Local).AddTicks(1085) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfAttempt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 23, 17, 26, 27, 845, DateTimeKind.Local).AddTicks(5739), new DateTime(2022, 12, 23, 17, 26, 27, 845, DateTimeKind.Local).AddTicks(5739) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegister",
                value: new DateTime(2022, 12, 23, 17, 26, 27, 845, DateTimeKind.Local).AddTicks(5846));
        }
    }
}
