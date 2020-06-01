using Microsoft.EntityFrameworkCore.Migrations;

namespace Wordschatz.Infrastructure.Migrations
{
    public partial class UniqueIndexFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Themes_Dictionary_DictionaryId",
                table: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_Themes_ParentId",
                table: "Themes");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_ParentId",
                table: "Themes",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Themes_Dictionary_DictionaryId",
                table: "Themes",
                column: "DictionaryId",
                principalTable: "Dictionary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Themes_Dictionary_DictionaryId",
                table: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_Themes_ParentId",
                table: "Themes");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_ParentId",
                table: "Themes",
                column: "ParentId",
                unique: true,
                filter: "[ParentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Themes_Dictionary_DictionaryId",
                table: "Themes",
                column: "DictionaryId",
                principalTable: "Dictionary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
