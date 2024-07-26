using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atheneum.Migrations
{
    public partial class TimeTrackingDateOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "To",
                table: "TimeTracking",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "From",
                table: "TimeTracking",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "TimeTracking",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "To",
                table: "TimeTracking",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "TimeTracking",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TimeTracking",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
