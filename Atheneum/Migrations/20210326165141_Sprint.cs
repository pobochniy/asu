using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atheneum.Migrations
{
    public partial class Sprint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    FinishtDate = table.Column<DateTime>(type: "Date", nullable: false),
                    IsEnded = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SprintIssues",
                columns: table => new
                {
                    SprintId = table.Column<long>(type: "bigint", nullable: false),
                    IssueId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprintIssues", x => new { x.SprintId, x.IssueId });
                    table.ForeignKey(
                        name: "FK_SprintIssues_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SprintIssues_Sprint_SprintId",
                        column: x => x.SprintId,
                        principalTable: "Sprint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_FinishtDate",
                table: "Sprint",
                column: "FinishtDate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_StartDate",
                table: "Sprint",
                column: "StartDate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SprintIssues_IssueId",
                table: "SprintIssues",
                column: "IssueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SprintIssues");

            migrationBuilder.DropTable(
                name: "Sprint");
        }
    }
}
