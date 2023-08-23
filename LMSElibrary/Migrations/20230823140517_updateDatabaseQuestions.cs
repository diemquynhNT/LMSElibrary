using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubjectService.Migrations
{
    public partial class updateDatabaseQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    IdQuestions = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContentQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Favorite = table.Column<bool>(type: "bit", nullable: false),
                    IdLecture = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.IdQuestions);
                    table.ForeignKey(
                        name: "FK_cauhoi_baigiang",
                        column: x => x.IdLecture,
                        principalTable: "Lectures",
                        principalColumn: "IdLecture");
                });

            migrationBuilder.CreateIndex(
                name: "IX_questions_IdLecture",
                table: "questions",
                column: "IdLecture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questions");
        }
    }
}
