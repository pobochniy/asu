using Microsoft.EntityFrameworkCore.Migrations;

namespace Atheneum.Migrations
{
    public partial class fix_finishDate_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinishtDate",
                table: "Sprint",
                newName: "FinishDate");

            migrationBuilder.RenameIndex(
                name: "IX_Sprint_FinishtDate",
                table: "Sprint",
                newName: "IX_Sprint_FinishDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinishDate",
                table: "Sprint",
                newName: "FinishtDate");

            migrationBuilder.RenameIndex(
                name: "IX_Sprint_FinishDate",
                table: "Sprint",
                newName: "IX_Sprint_FinishtDate");
        }
    }
}
