using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubjectService.Migrations
{
    public partial class fixDetailoClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTeacher",
                table: "Lop");

            migrationBuilder.AddColumn<string>(
                name: "IdTeacher",
                table: "detailClasses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTeacher",
                table: "detailClasses");

            migrationBuilder.AddColumn<string>(
                name: "IdTeacher",
                table: "Lop",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
