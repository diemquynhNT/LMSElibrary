using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationService.Migrations
{
    public partial class updateDBNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receivers");

            migrationBuilder.AddColumn<string>(
                name: "Idreceiver",
                table: "notifications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idreceiver",
                table: "notifications");

            migrationBuilder.CreateTable(
                name: "receivers",
                columns: table => new
                {
                    Idreceiver = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdNotification = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receivers", x => x.Idreceiver);
                    table.ForeignKey(
                        name: "FK_nguoinhan_thongbao",
                        column: x => x.IdNotification,
                        principalTable: "notifications",
                        principalColumn: "IdNotification",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_receivers_IdNotification",
                table: "receivers",
                column: "IdNotification");
        }
    }
}
