using Microsoft.EntityFrameworkCore.Migrations;

namespace Wordschatz.Infrastructure.Migrations
{
    public partial class MarkChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DictionaryMarks");

            migrationBuilder.AddColumn<long>(
                name: "DictionaryId",
                table: "Marks",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Marks_DictionaryId",
                table: "Marks",
                column: "DictionaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Dictionary_DictionaryId",
                table: "Marks",
                column: "DictionaryId",
                principalTable: "Dictionary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Dictionary_DictionaryId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_DictionaryId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "DictionaryId",
                table: "Marks");

            migrationBuilder.CreateTable(
                name: "DictionaryMarks",
                columns: table => new
                {
                    DictionaryId = table.Column<long>(type: "bigint", nullable: false),
                    MarkId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryMarks", x => new { x.DictionaryId, x.MarkId });
                    table.ForeignKey(
                        name: "FK_DictionaryMarks_Dictionary_DictionaryId",
                        column: x => x.DictionaryId,
                        principalTable: "Dictionary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DictionaryMarks_Marks_MarkId",
                        column: x => x.MarkId,
                        principalTable: "Marks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryMarks_MarkId",
                table: "DictionaryMarks",
                column: "MarkId");
        }
    }
}
