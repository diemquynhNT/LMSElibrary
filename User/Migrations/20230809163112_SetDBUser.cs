using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Migrations
{
    public partial class SetDBUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khoa",
                columns: table => new
                {
                    IdKhoa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameKhoa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoa", x => x.IdKhoa);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    IdPos = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NamePos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.IdPos);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nameus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Numphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdPos = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdKhoa = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImageUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_User_Khoa_IdKhoa",
                        column: x => x.IdKhoa,
                        principalTable: "Khoa",
                        principalColumn: "IdKhoa");
                    table.ForeignKey(
                        name: "FK_User_Position_IdPos",
                        column: x => x.IdPos,
                        principalTable: "Position",
                        principalColumn: "IdPos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_IdKhoa",
                table: "User",
                column: "IdKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdPos",
                table: "User",
                column: "IdPos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Khoa");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
