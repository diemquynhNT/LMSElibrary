using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubjectService.Migrations
{
    public partial class fixQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cauhoi_baigiang",
                table: "questions");

            migrationBuilder.DropTable(
                name: "detailLectures");

            migrationBuilder.RenameColumn(
                name: "IdLecture",
                table: "questions",
                newName: "LecturesIdLecture");

            migrationBuilder.RenameIndex(
                name: "IX_questions_IdLecture",
                table: "questions",
                newName: "IX_questions_LecturesIdLecture");

            migrationBuilder.AddColumn<string>(
                name: "IdPC",
                table: "questions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "classAssignments",
                columns: table => new
                {
                    IdPC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdClass = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdLectures = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classAssignments", x => x.IdPC);
                    table.ForeignKey(
                        name: "FK_ctbaigiang_baigiang",
                        column: x => x.IdLectures,
                        principalTable: "Lectures",
                        principalColumn: "IdLecture",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ctbg_lop",
                        column: x => x.IdClass,
                        principalTable: "Lop",
                        principalColumn: "IdClass",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_questions_IdPC",
                table: "questions",
                column: "IdPC");

            migrationBuilder.CreateIndex(
                name: "IX_classAssignments_IdClass",
                table: "classAssignments",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_classAssignments_IdLectures",
                table: "classAssignments",
                column: "IdLectures");

            migrationBuilder.AddForeignKey(
                name: "FK_cauhoi_baigiang",
                table: "questions",
                column: "IdPC",
                principalTable: "classAssignments",
                principalColumn: "IdPC");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_Lectures_LecturesIdLecture",
                table: "questions",
                column: "LecturesIdLecture",
                principalTable: "Lectures",
                principalColumn: "IdLecture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cauhoi_baigiang",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_Lectures_LecturesIdLecture",
                table: "questions");

            migrationBuilder.DropTable(
                name: "classAssignments");

            migrationBuilder.DropIndex(
                name: "IX_questions_IdPC",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "IdPC",
                table: "questions");

            migrationBuilder.RenameColumn(
                name: "LecturesIdLecture",
                table: "questions",
                newName: "IdLecture");

            migrationBuilder.RenameIndex(
                name: "IX_questions_LecturesIdLecture",
                table: "questions",
                newName: "IX_questions_IdLecture");

            migrationBuilder.CreateTable(
                name: "detailLectures",
                columns: table => new
                {
                    IdClass = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdLectures = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailLectures", x => new { x.IdClass, x.IdLectures });
                    table.ForeignKey(
                        name: "FK_ctbaigiang_baigiang",
                        column: x => x.IdLectures,
                        principalTable: "Lectures",
                        principalColumn: "IdLecture",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ctbg_lop",
                        column: x => x.IdClass,
                        principalTable: "Lop",
                        principalColumn: "IdClass",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detailLectures_IdLectures",
                table: "detailLectures",
                column: "IdLectures");

            migrationBuilder.AddForeignKey(
                name: "FK_cauhoi_baigiang",
                table: "questions",
                column: "IdLecture",
                principalTable: "Lectures",
                principalColumn: "IdLecture");
        }
    }
}
