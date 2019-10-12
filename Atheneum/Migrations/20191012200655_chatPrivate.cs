using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atheneum.Migrations
{
    public partial class chatPrivate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatRoom",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "IX_ChatRoom_Room",
                table: "ChatRoom",
                column: "Room",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatRoom");
        }
    }
}
