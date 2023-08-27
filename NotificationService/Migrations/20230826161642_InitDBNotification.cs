using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationService.Migrations
{
    public partial class InitDBNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    IdNotification = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ContentNotification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IdSender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.IdNotification);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receivers");

            migrationBuilder.DropTable(
                name: "notifications");
        }
    }
}
