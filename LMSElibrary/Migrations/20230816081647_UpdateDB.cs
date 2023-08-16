using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubjectService.Migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "boMons",
                columns: table => new
                {
                    IdBoMon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenBoMon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boMons", x => x.IdBoMon);
                });

            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    IdLop = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLop = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdTeacher = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop", x => x.IdLop);
                });

            migrationBuilder.CreateTable(
                name: "monHocs",
                columns: table => new
                {
                    IdMonHoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenMonHoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NienKhoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    IdBoMon = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monHocs", x => x.IdMonHoc);
                    table.ForeignKey(
                        name: "FK_MonHoc_BoMon",
                        column: x => x.IdBoMon,
                        principalTable: "boMons",
                        principalColumn: "IdBoMon");
                });

            migrationBuilder.CreateTable(
                name: "danhsachLops",
                columns: table => new
                {
                    IdDSLop = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdLop = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdStudent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_danhsachLops", x => x.IdDSLop);
                    table.ForeignKey(
                        name: "FK_dslop_lop",
                        column: x => x.IdLop,
                        principalTable: "Lop",
                        principalColumn: "IdLop");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietLop",
                columns: table => new
                {
                    IdLop = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdMonHoc = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietLop", x => new { x.IdLop, x.IdMonHoc });
                    table.ForeignKey(
                        name: "FK_ctlop_lop",
                        column: x => x.IdLop,
                        principalTable: "Lop",
                        principalColumn: "IdLop",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ctlop_monhoc",
                        column: x => x.IdMonHoc,
                        principalTable: "monHocs",
                        principalColumn: "IdMonHoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chuDes",
                columns: table => new
                {
                    IdChuDe = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdMonHoc = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chuDes", x => x.IdChuDe);
                    table.ForeignKey(
                        name: "FK_chude_monhoc",
                        column: x => x.IdMonHoc,
                        principalTable: "monHocs",
                        principalColumn: "IdMonHoc");
                });

            migrationBuilder.CreateTable(
                name: "thongtinMonhoc",
                columns: table => new
                {
                    IdThongtin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMonHoc = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thongtinMonhoc", x => x.IdThongtin);
                    table.ForeignKey(
                        name: "FK_ttmh_monhoc",
                        column: x => x.IdMonHoc,
                        principalTable: "monHocs",
                        principalColumn: "IdMonHoc");
                });

            migrationBuilder.CreateTable(
                name: "BaiGiang",
                columns: table => new
                {
                    IdBaiGiang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TitleBaiGiang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdChuDe = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LopIdLop = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiGiang", x => x.IdBaiGiang);
                    table.ForeignKey(
                        name: "FK_baigiang_chude",
                        column: x => x.IdChuDe,
                        principalTable: "chuDes",
                        principalColumn: "IdChuDe");
                    table.ForeignKey(
                        name: "FK_BaiGiang_Lop_LopIdLop",
                        column: x => x.LopIdLop,
                        principalTable: "Lop",
                        principalColumn: "IdLop");
                });

            migrationBuilder.CreateTable(
                name: "ChitietBaiGiang",
                columns: table => new
                {
                    IdLop = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdBaiGiang = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChitietBaiGiang", x => new { x.IdLop, x.IdBaiGiang });
                    table.ForeignKey(
                        name: "FK_ctbaigiang_baigiang",
                        column: x => x.IdBaiGiang,
                        principalTable: "BaiGiang",
                        principalColumn: "IdBaiGiang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ctbg_lop",
                        column: x => x.IdLop,
                        principalTable: "Lop",
                        principalColumn: "IdLop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    IdResources = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FormatFile = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiDuyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TinhTrangDuyet = table.Column<bool>(type: "bit", nullable: false),
                    NoteRes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdBaiGiang = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.IdResources);
                    table.ForeignKey(
                        name: "FK_res_baigiang",
                        column: x => x.IdBaiGiang,
                        principalTable: "BaiGiang",
                        principalColumn: "IdBaiGiang");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiGiang_IdChuDe",
                table: "BaiGiang",
                column: "IdChuDe");

            migrationBuilder.CreateIndex(
                name: "IX_BaiGiang_LopIdLop",
                table: "BaiGiang",
                column: "LopIdLop");

            migrationBuilder.CreateIndex(
                name: "IX_ChitietBaiGiang_IdBaiGiang",
                table: "ChitietBaiGiang",
                column: "IdBaiGiang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietLop_IdMonHoc",
                table: "ChiTietLop",
                column: "IdMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_chuDes_IdMonHoc",
                table: "chuDes",
                column: "IdMonHoc");

            migrationBuilder.CreateIndex(
                name: "IX_danhsachLops_IdLop",
                table: "danhsachLops",
                column: "IdLop");

            migrationBuilder.CreateIndex(
                name: "IX_monHocs_IdBoMon",
                table: "monHocs",
                column: "IdBoMon");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_IdBaiGiang",
                table: "Resources",
                column: "IdBaiGiang");

            migrationBuilder.CreateIndex(
                name: "IX_thongtinMonhoc_IdMonHoc",
                table: "thongtinMonhoc",
                column: "IdMonHoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChitietBaiGiang");

            migrationBuilder.DropTable(
                name: "ChiTietLop");

            migrationBuilder.DropTable(
                name: "danhsachLops");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "thongtinMonhoc");

            migrationBuilder.DropTable(
                name: "BaiGiang");

            migrationBuilder.DropTable(
                name: "chuDes");

            migrationBuilder.DropTable(
                name: "Lop");

            migrationBuilder.DropTable(
                name: "monHocs");

            migrationBuilder.DropTable(
                name: "boMons");
        }
    }
}
