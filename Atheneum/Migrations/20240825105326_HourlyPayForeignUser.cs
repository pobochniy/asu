using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atheneum.Migrations
{
    public partial class HourlyPayForeignUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HourlyPay_UserId",
                table: "HourlyPay",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HourlyPay_Users_UserId",
                table: "HourlyPay",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HourlyPay_Users_UserId",
                table: "HourlyPay");

            migrationBuilder.DropIndex(
                name: "IX_HourlyPay_UserId",
                table: "HourlyPay");
        }
    }
}
