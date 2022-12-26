using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class AddAmountSymbol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountOfSymbol",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 26, 23, 47, 10, 878, DateTimeKind.Local).AddTicks(6474), new DateTime(2022, 12, 26, 23, 47, 10, 878, DateTimeKind.Local).AddTicks(6475) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfSymbol",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 23, 18, 28, 49, 574, DateTimeKind.Local).AddTicks(6743), new DateTime(2022, 12, 23, 18, 28, 49, 574, DateTimeKind.Local).AddTicks(6744) });
        }
    }
}
