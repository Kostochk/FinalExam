using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalExam.Migrations
{
    /// <inheritdoc />
    public partial class Initialll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gamesss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    MinPlayers = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 1),
                    MaxPlayers = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamesss", x => x.Id);
                    table.CheckConstraint("CK_Players_Game", "[MinPlayers] > 0 AND [MaxPlayers] > 0");
                });

            migrationBuilder.CreateTable(
                name: "Membersss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    JoinDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membersss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessionsss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GameId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MemberId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DurationMinutes = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessionsss", x => x.Id);
                    table.CheckConstraint("CK_DurationMinutes_Session", "[DurationMinutes] >= 0");
                    table.ForeignKey(
                        name: "FK_Sessionsss_Gamesss_GameId",
                        column: x => x.GameId,
                        principalTable: "Gamesss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessionsss_Membersss_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Membersss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessionsss_GameId",
                table: "Sessionsss",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessionsss_MemberId",
                table: "Sessionsss",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessionsss");

            migrationBuilder.DropTable(
                name: "Gamesss");

            migrationBuilder.DropTable(
                name: "Membersss");
        }
    }
}
