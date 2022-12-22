using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class RrrorRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyboardPoint_Users_UserId",
                table: "KeyboardPoint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KeyboardPoint",
                table: "KeyboardPoint");

            migrationBuilder.RenameTable(
                name: "KeyboardPoint",
                newName: "KeyboardPoints");

            migrationBuilder.RenameIndex(
                name: "IX_KeyboardPoint_UserId",
                table: "KeyboardPoints",
                newName: "IX_KeyboardPoints_UserId");

            migrationBuilder.AddColumn<int>(
                name: "ErrorRate",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KeyboardPoints",
                table: "KeyboardPoints",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_KeyboardPoints_Users_UserId",
                table: "KeyboardPoints",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyboardPoints_Users_UserId",
                table: "KeyboardPoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KeyboardPoints",
                table: "KeyboardPoints");

            migrationBuilder.DropColumn(
                name: "ErrorRate",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "KeyboardPoints",
                newName: "KeyboardPoint");

            migrationBuilder.RenameIndex(
                name: "IX_KeyboardPoints_UserId",
                table: "KeyboardPoint",
                newName: "IX_KeyboardPoint_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KeyboardPoint",
                table: "KeyboardPoint",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2022, 12, 21, 22, 43, 31, 981, DateTimeKind.Local).AddTicks(5051), new DateTime(2022, 12, 21, 22, 43, 31, 981, DateTimeKind.Local).AddTicks(5053) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegister",
                value: new DateTime(2022, 12, 21, 22, 43, 31, 981, DateTimeKind.Local).AddTicks(5373));

            migrationBuilder.AddForeignKey(
                name: "FK_KeyboardPoint_Users_UserId",
                table: "KeyboardPoint",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
