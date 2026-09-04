using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelfLife.Migrations
{
    /// <inheritdoc />
    public partial class AddReadingRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReadingRecords",
                columns: table => new
                {
                    ReadingRecordId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Review = table.Column<string>(type: "TEXT", nullable: true),
                    Rating = table.Column<int>(type: "INTEGER", nullable: true),
                    DateStarted = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateFinished = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingRecords", x => x.ReadingRecordId);
                    table.ForeignKey(
                        name: "FK_ReadingRecords_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReadingRecords_BookId",
                table: "ReadingRecords",
                column: "BookId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadingRecords");
        }
    }
}
