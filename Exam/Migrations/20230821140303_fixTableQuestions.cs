using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamService.Migrations
{
    public partial class fixTableQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "optionQuestions");

            migrationBuilder.AddColumn<string>(
                name: "ChoiceA",
                table: "questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChoiceB",
                table: "questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChoiceC",
                table: "questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChoiceD",
                table: "questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "STT",
                table: "questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChoiceA",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "ChoiceB",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "ChoiceC",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "ChoiceD",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "STT",
                table: "questions");

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    IdAnswer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    questionsIdQuestion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContentAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.IdAnswer);
                    table.ForeignKey(
                        name: "FK_Answer_questions_questionsIdQuestion",
                        column: x => x.questionsIdQuestion,
                        principalTable: "questions",
                        principalColumn: "IdQuestion");
                });

            migrationBuilder.CreateTable(
                name: "optionQuestions",
                columns: table => new
                {
                    IdOptions = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdQuestion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContentOption = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                name: "IX_Answer_questionsIdQuestion",
                table: "Answer",
                column: "questionsIdQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_optionQuestions_IdQuestion",
                table: "optionQuestions",
                column: "IdQuestion");
        }
    }
}
