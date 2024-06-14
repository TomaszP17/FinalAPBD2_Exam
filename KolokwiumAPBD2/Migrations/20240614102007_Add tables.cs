using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KolokwiumAPBD2.Migrations
{
    /// <inheritdoc />
    public partial class Addtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characterss",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    current_weig = table.Column<int>(type: "int", nullable: false),
                    max_weight = table.Column<int>(type: "int", nullable: false),
                    money = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characterss", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Itemss",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    weig = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itemss", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Titless",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titless", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Backpack_Slotss",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_item = table.Column<int>(type: "int", nullable: false),
                    FK_character = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backpack_Slotss", x => x.PK);
                    table.ForeignKey(
                        name: "FK_Backpack_Slotss_Characterss_FK_character",
                        column: x => x.FK_character,
                        principalTable: "Characterss",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Backpack_Slotss_Itemss_FK_item",
                        column: x => x.FK_item,
                        principalTable: "Itemss",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters_Titless",
                columns: table => new
                {
                    FK_charact = table.Column<int>(type: "int", nullable: false),
                    FK_title = table.Column<int>(type: "int", nullable: false),
                    aquire_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters_Titless", x => new { x.FK_charact, x.FK_title });
                    table.ForeignKey(
                        name: "FK_Characters_Titless_Characterss_FK_charact",
                        column: x => x.FK_charact,
                        principalTable: "Characterss",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Titless_Titless_FK_title",
                        column: x => x.FK_title,
                        principalTable: "Titless",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characterss",
                columns: new[] { "PK", "current_weig", "first_name", "last_name", "max_weight", "money" },
                values: new object[,]
                {
                    { 1, 10, "Gerald", "Z Rivii", 300, 100 },
                    { 2, 69, "Szczur", "Mysiur", 250, 200 }
                });

            migrationBuilder.InsertData(
                table: "Itemss",
                columns: new[] { "PK", "name", "weig" },
                values: new object[,]
                {
                    { 1, "Miecz połksiezyca", 2 },
                    { 2, "Sierp drwala", 1 }
                });

            migrationBuilder.InsertData(
                table: "Titless",
                columns: new[] { "PK", "nam" },
                values: new object[,]
                {
                    { 1, "Rycerz" },
                    { 2, "Mag" }
                });

            migrationBuilder.InsertData(
                table: "Backpack_Slotss",
                columns: new[] { "PK", "FK_character", "FK_item" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Characters_Titless",
                columns: new[] { "FK_charact", "FK_title", "aquire_at" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 14, 12, 20, 7, 26, DateTimeKind.Local).AddTicks(9329) },
                    { 2, 2, new DateTime(2024, 6, 14, 12, 20, 7, 29, DateTimeKind.Local).AddTicks(2577) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_Slotss_FK_character",
                table: "Backpack_Slotss",
                column: "FK_character");

            migrationBuilder.CreateIndex(
                name: "IX_Backpack_Slotss_FK_item",
                table: "Backpack_Slotss",
                column: "FK_item");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Titless_FK_title",
                table: "Characters_Titless",
                column: "FK_title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Backpack_Slotss");

            migrationBuilder.DropTable(
                name: "Characters_Titless");

            migrationBuilder.DropTable(
                name: "Itemss");

            migrationBuilder.DropTable(
                name: "Characterss");

            migrationBuilder.DropTable(
                name: "Titless");
        }
    }
}
