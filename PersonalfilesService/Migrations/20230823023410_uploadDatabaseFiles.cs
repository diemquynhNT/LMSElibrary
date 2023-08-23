using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalfilesService.Migrations
{
    public partial class uploadDatabaseFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FileDetails",
                table: "FileDetails");

            migrationBuilder.DropColumn(
                name: "FileData",
                table: "FileDetails");

            migrationBuilder.RenameTable(
                name: "FileDetails",
                newName: "fileDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Filetypes",
                table: "fileDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "fileDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Creator",
                table: "fileDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FileURL",
                table: "fileDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fileDetails",
                table: "fileDetails",
                column: "IdFile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_fileDetails",
                table: "fileDetails");

            migrationBuilder.DropColumn(
                name: "FileURL",
                table: "fileDetails");

            migrationBuilder.RenameTable(
                name: "fileDetails",
                newName: "FileDetails");

            migrationBuilder.AlterColumn<int>(
                name: "Filetypes",
                table: "FileDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "FileDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Creator",
                table: "FileDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileData",
                table: "FileDetails",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileDetails",
                table: "FileDetails",
                column: "IdFile");
        }
    }
}
