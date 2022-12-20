using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notebook.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HasGraphKey = table.Column<bool>(type: "bit", nullable: false),
                    PathToImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GraphKeyPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    XValue = table.Column<double>(type: "float", nullable: false),
                    YValue = table.Column<double>(type: "float", nullable: false),
                    Delta = table.Column<double>(type: "float", nullable: false),
                    NumberOfPoint = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphKeyPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraphKeyPoints_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "NoteText" },
                values: new object[] { 1, new DateTime(2022, 12, 21, 0, 14, 55, 467, DateTimeKind.Local).AddTicks(4587), new DateTime(2022, 12, 21, 0, 14, 55, 467, DateTimeKind.Local).AddTicks(4588), "" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateRegister", "HasGraphKey", "NoteId", "Password", "PathToImage", "Username" },
                values: new object[] { 1, new DateTime(2022, 12, 21, 0, 14, 55, 467, DateTimeKind.Local).AddTicks(4682), false, 1, "\\u001e\\u000f\\u001d\\u001d\\u0019\\u0001\\u001c\\n", "", "login" });

            migrationBuilder.CreateIndex(
                name: "IX_GraphKeyPoints_UserId",
                table: "GraphKeyPoints",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NoteId",
                table: "Users",
                column: "NoteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GraphKeyPoints");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
