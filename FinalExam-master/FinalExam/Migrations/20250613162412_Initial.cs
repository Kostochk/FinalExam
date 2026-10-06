using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalExam.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessionsss_Gamesss_GameId",
                table: "Sessionsss");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessionsss_Membersss_MemberId",
                table: "Sessionsss");

            migrationBuilder.DropIndex(
                name: "IX_Sessionsss_GameId",
                table: "Sessionsss");

            migrationBuilder.DropIndex(
                name: "IX_Sessionsss_MemberId",
                table: "Sessionsss");

            migrationBuilder.AddColumn<Guid>(
                name: "SessionId",
                table: "Membersss",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SessionId",
                table: "Gamesss",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Membersss_SessionId",
                table: "Membersss",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Gamesss_SessionId",
                table: "Gamesss",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gamesss_Sessionsss_SessionId",
                table: "Gamesss",
                column: "SessionId",
                principalTable: "Sessionsss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Membersss_Sessionsss_SessionId",
                table: "Membersss",
                column: "SessionId",
                principalTable: "Sessionsss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gamesss_Sessionsss_SessionId",
                table: "Gamesss");

            migrationBuilder.DropForeignKey(
                name: "FK_Membersss_Sessionsss_SessionId",
                table: "Membersss");

            migrationBuilder.DropIndex(
                name: "IX_Membersss_SessionId",
                table: "Membersss");

            migrationBuilder.DropIndex(
                name: "IX_Gamesss_SessionId",
                table: "Gamesss");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Membersss");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Gamesss");

            migrationBuilder.CreateIndex(
                name: "IX_Sessionsss_GameId",
                table: "Sessionsss",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessionsss_MemberId",
                table: "Sessionsss",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessionsss_Gamesss_GameId",
                table: "Sessionsss",
                column: "GameId",
                principalTable: "Gamesss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessionsss_Membersss_MemberId",
                table: "Sessionsss",
                column: "MemberId",
                principalTable: "Membersss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
