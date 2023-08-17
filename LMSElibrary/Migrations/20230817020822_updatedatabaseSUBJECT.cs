using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubjectService.Migrations
{
    public partial class updatedatabaseSUBJECT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    IdDepartment = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameDepartment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.IdDepartment);
                });

            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    IdClass = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameClass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdTeacher = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop", x => x.IdClass);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    IdSubject = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameSubject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Schoolyear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescribeSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusSubject = table.Column<bool>(type: "bit", nullable: false),
                    IdDepartment = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.IdSubject);
                    table.ForeignKey(
                        name: "FK_MonHoc_BoMon",
                        column: x => x.IdDepartment,
                        principalTable: "departments",
                        principalColumn: "IdDepartment");
                });

            migrationBuilder.CreateTable(
                name: "classLists",
                columns: table => new
                {
                    IdClassList = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdClass = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdStudent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classLists", x => x.IdClassList);
                    table.ForeignKey(
                        name: "FK_dslop_lop",
                        column: x => x.IdClass,
                        principalTable: "Lop",
                        principalColumn: "IdClass");
                });

            migrationBuilder.CreateTable(
                name: "detailClasses",
                columns: table => new
                {
                    IdClass = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdSubject = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailClasses", x => new { x.IdClass, x.IdSubject });
                    table.ForeignKey(
                        name: "FK_ctlop_lop",
                        column: x => x.IdClass,
                        principalTable: "Lop",
                        principalColumn: "IdClass",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ctlop_monhoc",
                        column: x => x.IdSubject,
                        principalTable: "subjects",
                        principalColumn: "IdSubject",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subjectInfos",
                columns: table => new
                {
                    IdSubjectInfo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContentSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSubject = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjectInfos", x => x.IdSubjectInfo);
                    table.ForeignKey(
                        name: "FK_ttmh_monhoc",
                        column: x => x.IdSubject,
                        principalTable: "subjects",
                        principalColumn: "IdSubject");
                });

            migrationBuilder.CreateTable(
                name: "topics",
                columns: table => new
                {
                    IdTopic = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TitleTopic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdSubject = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_topics", x => x.IdTopic);
                    table.ForeignKey(
                        name: "FK_chude_monhoc",
                        column: x => x.IdSubject,
                        principalTable: "subjects",
                        principalColumn: "IdSubject");
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    IdLecture = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TitleLecture = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTopic = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClassSubjectIdClass = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.IdLecture);
                    table.ForeignKey(
                        name: "FK_baigiang_chude",
                        column: x => x.IdTopic,
                        principalTable: "topics",
                        principalColumn: "IdTopic");
                    table.ForeignKey(
                        name: "FK_Lectures_Lop_ClassSubjectIdClass",
                        column: x => x.ClassSubjectIdClass,
                        principalTable: "Lop",
                        principalColumn: "IdClass");
                });

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

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    IdResources = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FormatFile = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescribeFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusFile = table.Column<bool>(type: "bit", nullable: false),
                    NoteRes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdLecture = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.IdResources);
                    table.ForeignKey(
                        name: "FK_res_baigiang",
                        column: x => x.IdLecture,
                        principalTable: "Lectures",
                        principalColumn: "IdLecture");
                });

            migrationBuilder.CreateIndex(
                name: "IX_classLists_IdClass",
                table: "classLists",
                column: "IdClass");

            migrationBuilder.CreateIndex(
                name: "IX_detailClasses_IdSubject",
                table: "detailClasses",
                column: "IdSubject");

            migrationBuilder.CreateIndex(
                name: "IX_detailLectures_IdLectures",
                table: "detailLectures",
                column: "IdLectures");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_ClassSubjectIdClass",
                table: "Lectures",
                column: "ClassSubjectIdClass");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_IdTopic",
                table: "Lectures",
                column: "IdTopic");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_IdLecture",
                table: "Resources",
                column: "IdLecture");

            migrationBuilder.CreateIndex(
                name: "IX_subjectInfos_IdSubject",
                table: "subjectInfos",
                column: "IdSubject");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_IdDepartment",
                table: "subjects",
                column: "IdDepartment");

            migrationBuilder.CreateIndex(
                name: "IX_topics_IdSubject",
                table: "topics",
                column: "IdSubject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classLists");

            migrationBuilder.DropTable(
                name: "detailClasses");

            migrationBuilder.DropTable(
                name: "detailLectures");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "subjectInfos");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "topics");

            migrationBuilder.DropTable(
                name: "Lop");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
