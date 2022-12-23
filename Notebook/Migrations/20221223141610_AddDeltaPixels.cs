using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class AddDeltaPixels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delta",
                table: "GraphKeyPoints");

            migrationBuilder.AddColumn<double>(
                name: "DeltaPixels",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 23, 17, 16, 10, 408, DateTimeKind.Local).AddTicks(9954), new DateTime(2022, 12, 23, 17, 16, 10, 408, DateTimeKind.Local).AddTicks(9955) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateRegister", "DeltaPixels" },
                values: new object[] { new DateTime(2022, 12, 23, 17, 16, 10, 409, DateTimeKind.Local).AddTicks(72), 10.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeltaPixels",
                table: "Users");

            migrationBuilder.AddColumn<double>(
                name: "Delta",
                table: "GraphKeyPoints",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
    }
}
