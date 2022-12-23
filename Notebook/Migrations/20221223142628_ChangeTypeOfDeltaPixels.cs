using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class ChangeTypeOfDeltaPixels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DeltaPixels",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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
                columns: new[] { "DateRegister", "DeltaPixels" },
                values: new object[] { new DateTime(2022, 12, 23, 17, 26, 27, 845, DateTimeKind.Local).AddTicks(5846), 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DeltaPixels",
                table: "Users",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
