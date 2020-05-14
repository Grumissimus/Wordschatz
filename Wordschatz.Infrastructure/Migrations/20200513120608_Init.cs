using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wordschatz.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dictionary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: true, defaultValue: ""),
                    Description = table.Column<string>(maxLength: 400, nullable: true, defaultValue: ""),
                    Visibility = table.Column<int>(nullable: false, defaultValue: 3),
                    EditPermission = table.Column<int>(nullable: false, defaultValue: 0),
                    Salt = table.Column<byte[]>(maxLength: 256, nullable: true),
                    Hash = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: true, defaultValue: ""),
                    Description = table.Column<string>(maxLength: 400, nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: true, defaultValue: ""),
                    DictionaryId = table.Column<long>(nullable: false),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Themes_Dictionary_DictionaryId",
                        column: x => x.DictionaryId,
                        principalTable: "Dictionary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Themes_Themes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryMarks",
                columns: table => new
                {
                    MarkId = table.Column<long>(nullable: false),
                    DictionaryId = table.Column<long>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ThemeMarks",
                columns: table => new
                {
                    MarkId = table.Column<long>(nullable: false),
                    ThemeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThemeMarks", x => new { x.ThemeId, x.MarkId });
                    table.ForeignKey(
                        name: "FK_ThemeMarks_Marks_MarkId",
                        column: x => x.MarkId,
                        principalTable: "Marks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThemeMarks_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Term = table.Column<string>(nullable: false),
                    Meaning = table.Column<string>(nullable: false),
                    ThemeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordMarks",
                columns: table => new
                {
                    MarkId = table.Column<long>(nullable: false),
                    WordId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordMarks", x => new { x.WordId, x.MarkId });
                    table.ForeignKey(
                        name: "FK_WordMarks_Marks_MarkId",
                        column: x => x.MarkId,
                        principalTable: "Marks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WordMarks_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DictionaryMarks_MarkId",
                table: "DictionaryMarks",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_ThemeMarks_MarkId",
                table: "ThemeMarks",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_DictionaryId",
                table: "Themes",
                column: "DictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Themes_ParentId",
                table: "Themes",
                column: "ParentId",
                unique: true,
                filter: "[ParentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WordMarks_MarkId",
                table: "WordMarks",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_ThemeId",
                table: "Words",
                column: "ThemeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DictionaryMarks");

            migrationBuilder.DropTable(
                name: "ThemeMarks");

            migrationBuilder.DropTable(
                name: "WordMarks");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "Dictionary");
        }
    }
}
