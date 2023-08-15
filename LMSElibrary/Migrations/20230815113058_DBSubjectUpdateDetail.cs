using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubjectService.Migrations
{
    public partial class DBSubjectUpdateDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailClass",
                table: "DetailClass");

            migrationBuilder.RenameTable(
                name: "DetailClass",
                newName: "DetailClasses");

            migrationBuilder.RenameIndex(
                name: "IX_DetailClass_IdClass",
                table: "DetailClasses",
                newName: "IX_DetailClasses_IdClass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailClasses",
                table: "DetailClasses",
                column: "IdDetailClass");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailClasses",
                table: "DetailClasses");

            migrationBuilder.RenameTable(
                name: "DetailClasses",
                newName: "DetailClass");

            migrationBuilder.RenameIndex(
                name: "IX_DetailClasses_IdClass",
                table: "DetailClass",
                newName: "IX_DetailClass_IdClass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailClass",
                table: "DetailClass",
                column: "IdDetailClass");
        }
    }
}
