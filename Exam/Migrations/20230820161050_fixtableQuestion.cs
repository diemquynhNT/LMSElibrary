using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamService.Migrations
{
    public partial class fixtableQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_answer_questions",
                table: "answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_answers",
                table: "answers");

            migrationBuilder.DropIndex(
                name: "IX_answers_IdQuestion",
                table: "answers");

            migrationBuilder.RenameTable(
                name: "answers",
                newName: "Answer");

            migrationBuilder.AddColumn<string>(
                name: "AnswerQuestions",
                table: "questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "IdQuestion",
                table: "Answer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "questionsIdQuestion",
                table: "Answer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answer",
                table: "Answer",
                column: "IdAnswer");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_questionsIdQuestion",
                table: "Answer",
                column: "questionsIdQuestion");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_questions_questionsIdQuestion",
                table: "Answer",
                column: "questionsIdQuestion",
                principalTable: "questions",
                principalColumn: "IdQuestion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_questions_questionsIdQuestion",
                table: "Answer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answer",
                table: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_questionsIdQuestion",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "AnswerQuestions",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "questionsIdQuestion",
                table: "Answer");

            migrationBuilder.RenameTable(
                name: "Answer",
                newName: "answers");

            migrationBuilder.AlterColumn<string>(
                name: "IdQuestion",
                table: "answers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_answers",
                table: "answers",
                column: "IdAnswer");

            migrationBuilder.CreateIndex(
                name: "IX_answers_IdQuestion",
                table: "answers",
                column: "IdQuestion");

            migrationBuilder.AddForeignKey(
                name: "FK_answer_questions",
                table: "answers",
                column: "IdQuestion",
                principalTable: "questions",
                principalColumn: "IdQuestion");
        }
    }
}
