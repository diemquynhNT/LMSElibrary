using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubjectService.Migrations
{
    public partial class DBSubjectUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTeacher",
                table: "Subjects");

            migrationBuilder.AddColumn<string>(
                name: "IdTeacher",
                table: "Class",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetailClass",
                columns: table => new
                {
                    IdDetailClass = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdClass = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdStudent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailClass", x => x.IdDetailClass);
                    table.ForeignKey(
                        name: "FK_detailclasst_class",
                        column: x => x.IdClass,
                        principalTable: "Class",
                        principalColumn: "IdClass");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailClass_IdClass",
                table: "DetailClass",
                column: "IdClass");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailClass");

            migrationBuilder.DropColumn(
                name: "IdTeacher",
                table: "Class");

            migrationBuilder.AddColumn<string>(
                name: "IdTeacher",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
