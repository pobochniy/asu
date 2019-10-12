using Microsoft.EntityFrameworkCore.Migrations;

namespace Atheneum.Migrations
{
    public partial class chatPrivateFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Type",
                table: "ChatPrivate",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "ChatPrivate");
        }
    }
}
