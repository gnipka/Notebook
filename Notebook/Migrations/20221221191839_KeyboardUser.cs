using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class KeyboardUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodePhrase",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasKeyboard",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 21, 22, 18, 39, 234, DateTimeKind.Local).AddTicks(4866), new DateTime(2022, 12, 21, 22, 18, 39, 234, DateTimeKind.Local).AddTicks(4867) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CodePhrase", "DateRegister" },
                values: new object[] { "", new DateTime(2022, 12, 21, 22, 18, 39, 234, DateTimeKind.Local).AddTicks(5130) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodePhrase",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HasKeyboard",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 21, 0, 14, 55, 467, DateTimeKind.Local).AddTicks(4587), new DateTime(2022, 12, 21, 0, 14, 55, 467, DateTimeKind.Local).AddTicks(4588) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegister",
                value: new DateTime(2022, 12, 21, 0, 14, 55, 467, DateTimeKind.Local).AddTicks(4682));
        }
    }
}
