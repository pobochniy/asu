using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atheneum.Migrations
{
    public partial class chatTbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatPrivate",
                columns: table => new
                {
                    Tick = table.Column<long>(nullable: false),
                    SenderId = table.Column<Guid>(nullable: false),
                    ReceiverId = table.Column<Guid>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Privat = table.Column<string>(nullable: true),
                    Msg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatPrivate", x => new { x.Tick, x.SenderId, x.ReceiverId });
                });

            migrationBuilder.CreateTable(
                name: "ChatRoom",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Room = table.Column<int>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    Msg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoom", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatPrivate_Tick",
                table: "ChatPrivate",
                column: "Tick");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoom_Room",
                table: "ChatRoom",
                column: "Room");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatPrivate");

            migrationBuilder.DropTable(
                name: "ChatRoom");
        }
    }
}
