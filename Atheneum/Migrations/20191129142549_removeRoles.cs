using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atheneum.Migrations
{
    public partial class removeRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInRole_Roles_RoleId",
                table: "UserInRole");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_UserInRole_RoleId",
                table: "UserInRole");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "UserInRole",
                nullable: false,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Assignee = table.Column<Guid>(nullable: true),
                    Reporter = table.Column<Guid>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    AssigneeEstimatedTime = table.Column<decimal>(nullable: true),
                    ReporterEstimatedTime = table.Column<decimal>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    EpicLink = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issue_Id",
                table: "Issue",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "UserInRole",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInRole_RoleId",
                table: "UserInRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInRole_Roles_RoleId",
                table: "UserInRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
