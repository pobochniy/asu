using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atheneum.Migrations
{
    public partial class epic_assignee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriorityEnum",
                table: "Epic");

            migrationBuilder.AddColumn<Guid>(
                name: "Assignee",
                table: "Epic",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Epic",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assignee",
                table: "Epic");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Epic");

            migrationBuilder.AddColumn<int>(
                name: "PriorityEnum",
                table: "Epic",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
