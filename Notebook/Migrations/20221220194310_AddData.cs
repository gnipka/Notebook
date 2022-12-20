using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateRegister", "HasGraphKey", "Password", "PathToImage", "Username" },
                values: new object[] { 1, new DateTime(2022, 12, 20, 22, 43, 10, 703, DateTimeKind.Local).AddTicks(4364), false, "\\u001e\\u000f\\u001d\\u001d\\u0019\\u0001\\u001c\\n", "", "login" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
