using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atheneum.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CashFlow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserIdPassed = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UserIdReceived = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Cash = table.Column<decimal>(type: "decimal(18,10)", precision: 18, scale: 10, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlow", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChatPrivate",
                columns: table => new
                {
                    Tick = table.Column<long>(type: "bigint", nullable: false),
                    SenderId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ReceiverId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Login = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    To = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Privat = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Msg = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatPrivate", x => new { x.Tick, x.SenderId, x.ReceiverId });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ChatRoom",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Room = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    Login = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    To = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Msg = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoom", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Epic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Assignee = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Reporter = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DueDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epic", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HourlyPay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StartedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Cash = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    UserIdCreated = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlyPay", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Assignee = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Reporter = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Summary = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    EstimatedTime = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "Date", nullable: true),
                    EpicLink = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "Date", nullable: false),
                    IsEnded = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Avatar",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ImgData = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avatar", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Avatar_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserName = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cash = table.Column<decimal>(type: "decimal(18,10)", precision: 18, scale: 10, nullable: false, defaultValue: 0m),
                    Comment = table.Column<string>(type: "nvarchar(4000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TimeTracking",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    From = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    To = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IssueId = table.Column<long>(type: "bigint", nullable: true),
                    EpicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTracking_Epic_EpicId",
                        column: x => x.EpicId,
                        principalTable: "Epic",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TimeTracking_Issue_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TimeTracking_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserInRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserInRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ChatPrivate_Tick",
                table: "ChatPrivate",
                column: "Tick");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRoom_Room",
                table: "ChatRoom",
                column: "Room");

            migrationBuilder.CreateIndex(
                name: "IX_HourlyPay_Id",
                table: "HourlyPay",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_Id",
                table: "Issue",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Email",
                table: "Profiles",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_PhoneNumber",
                table: "Profiles",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserName",
                table: "Profiles",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_FinishDate",
                table: "Sprint",
                column: "FinishDate",
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
                name: "Avatar");

            migrationBuilder.DropTable(
                name: "CashFlow");

            migrationBuilder.DropTable(
                name: "ChatPrivate");

            migrationBuilder.DropTable(
                name: "ChatRoom");

            migrationBuilder.DropTable(
                name: "HourlyPay");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "SprintIssues");

            migrationBuilder.DropTable(
                name: "TimeTracking");

            migrationBuilder.DropTable(
                name: "UserInRole");

            migrationBuilder.DropTable(
                name: "Sprint");

            migrationBuilder.DropTable(
                name: "Epic");

            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
