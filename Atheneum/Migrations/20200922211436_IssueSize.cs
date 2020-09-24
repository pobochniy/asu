using Microsoft.EntityFrameworkCore.Migrations;

namespace Atheneum.Migrations
{
    public partial class IssueSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssigneeEstimatedTime",
                table: "Issue");

            migrationBuilder.RenameColumn(
                name: "ReporterEstimatedTime",
                table: "Issue",
                newName: "EstimatedTime");

            migrationBuilder.AddColumn<byte>(
                name: "Size",
                table: "Issue",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Issue");

            migrationBuilder.RenameColumn(
                name: "EstimatedTime",
                table: "Issue",
                newName: "ReporterEstimatedTime");

            migrationBuilder.AddColumn<decimal>(
                name: "AssigneeEstimatedTime",
                table: "Issue",
                nullable: true);
        }
    }
}
