using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamService.Migrations
{
    public partial class DBExamInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exams",
                columns: table => new
                {
                    IdExam = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameExam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FormatExam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TimeExam = table.Column<int>(type: "int", nullable: false),
                    IdTeacher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusExam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FormatFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateExam = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.IdExam);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    IdQuestion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevelQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdMon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.IdQuestion);
                });

            migrationBuilder.CreateTable(
                name: "answers",
                columns: table => new
                {
                    IdAnswer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdQuestion = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answers", x => x.IdAnswer);
                    table.ForeignKey(
                        name: "FK_answer_questions",
                        column: x => x.IdQuestion,
                        principalTable: "questions",
                        principalColumn: "IdQuestion");
                });

            migrationBuilder.CreateTable(
                name: "detailExams",
                columns: table => new
                {
                    IdExam = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdQuestion = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailExams", x => new { x.IdQuestion, x.IdExam });
                    table.ForeignKey(
                        name: "FK_detailexam_exam",
                        column: x => x.IdExam,
                        principalTable: "exams",
                        principalColumn: "IdExam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailexam_question",
                        column: x => x.IdQuestion,
                        principalTable: "questions",
                        principalColumn: "IdQuestion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "optionQuestions",
                columns: table => new
                {
                    IdOptions = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentOption = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdQuestion = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_optionQuestions", x => x.IdOptions);
                    table.ForeignKey(
                        name: "FK_op_questions",
                        column: x => x.IdQuestion,
                        principalTable: "questions",
                        principalColumn: "IdQuestion");
                });

            migrationBuilder.CreateIndex(
                name: "IX_answers_IdQuestion",
                table: "answers",
                column: "IdQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_detailExams_IdExam",
                table: "detailExams",
                column: "IdExam");

            migrationBuilder.CreateIndex(
                name: "IX_optionQuestions_IdQuestion",
                table: "optionQuestions",
                column: "IdQuestion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answers");

            migrationBuilder.DropTable(
                name: "detailExams");

            migrationBuilder.DropTable(
                name: "optionQuestions");

            migrationBuilder.DropTable(
                name: "exams");

            migrationBuilder.DropTable(
                name: "questions");
        }
    }
}
