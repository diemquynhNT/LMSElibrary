using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubjectService.Migrations
{
    public partial class DBSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NameSubject",
                table: "Subjects",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Describe",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdBoMon",
                table: "Subjects",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdTeacher",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Subjects",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "BoMons",
                columns: table => new
                {
                    IdBoMon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameBoMon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoMons", x => x.IdBoMon);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    IdClass = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameClass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdSubject = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.IdClass);
                    table.ForeignKey(
                        name: "FK_class_subject",
                        column: x => x.IdSubject,
                        principalTable: "Subjects",
                        principalColumn: "IdSubject");
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    IdTopic = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdSubject = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.IdTopic);
                    table.ForeignKey(
                        name: "FK_topic_subject",
                        column: x => x.IdSubject,
                        principalTable: "Subjects",
                        principalColumn: "IdSubject");
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    IdDocument = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TitleDoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdTopic = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdClass = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.IdDocument);
                    table.ForeignKey(
                        name: "FK_documents_class",
                        column: x => x.IdClass,
                        principalTable: "Class",
                        principalColumn: "IdClass");
                    table.ForeignKey(
                        name: "FK_documents_topic",
                        column: x => x.IdTopic,
                        principalTable: "Topics",
                        principalColumn: "IdTopic");
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    IdResources = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FormatFile = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Usercheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    statusResource = table.Column<byte>(type: "tinyint", nullable: false),
                    NoteRes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sentdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdDocument = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.IdResources);
                    table.ForeignKey(
                        name: "FK_document_res",
                        column: x => x.IdDocument,
                        principalTable: "Document",
                        principalColumn: "IdDocument");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_IdBoMon",
                table: "Subjects",
                column: "IdBoMon");

            migrationBuilder.CreateIndex(
                name: "IX_Class_IdSubject",
                table: "Class",
                column: "IdSubject");

            migrationBuilder.CreateIndex(
                name: "IX_Document_IdClass",
                table: "Document",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_Document_IdTopic",
                table: "Document",
                column: "IdTopic");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_IdDocument",
                table: "Resources",
                column: "IdDocument");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_IdSubject",
                table: "Topics",
                column: "IdSubject");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_BoMon",
                table: "Subjects",
                column: "IdBoMon",
                principalTable: "BoMons",
                principalColumn: "IdBoMon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_BoMon",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "BoMons");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_IdBoMon",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Describe",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "IdBoMon",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "IdTeacher",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Subjects");

            migrationBuilder.AlterColumn<string>(
                name: "NameSubject",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
