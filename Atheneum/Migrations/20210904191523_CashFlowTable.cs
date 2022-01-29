using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atheneum.Migrations
{
    public partial class CashFlowTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cash",
                table: "Profiles",
                type: "decimal(18,10)",
                precision: 18,
                scale: 10,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CashFlow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserIdPassed = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserIdReceived = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cash = table.Column<decimal>(type: "decimal(18,10)", precision: 18, scale: 10, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlow", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashFlow");

            migrationBuilder.DropColumn(
                name: "Cash",
                table: "Profiles");
        }
    }
}
