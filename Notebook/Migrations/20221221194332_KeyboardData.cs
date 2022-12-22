using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class KeyboardData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyboardPoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Time = table.Column<long>(type: "bigint", nullable: false),
                    NumberOfChar = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyboardPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyboardPoint_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_KeyboardPoint_UserId",
                table: "KeyboardPoint",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyboardPoint");

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
                column: "DateRegister",
                value: new DateTime(2022, 12, 21, 22, 18, 39, 234, DateTimeKind.Local).AddTicks(5130));
        }
    }
}
