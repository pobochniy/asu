using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atheneum.Migrations
{
    public partial class TimeTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeTracking",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    IssueId = table.Column<long>(nullable: true),
                    EpicId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTracking_Epic_EpicId",
                        column: x => x.EpicId,
                        principalTable: "Epic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeTracking_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeTracking_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracking_EpicId",
                table: "TimeTracking",
                column: "EpicId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracking_IssueId",
                table: "TimeTracking",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracking_UserId",
                table: "TimeTracking",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeTracking");
        }
    }
}
