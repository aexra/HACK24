using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hack24.Migrations
{
    /// <inheritdoc />
    public partial class AcceptedChallengesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcceptedSoloChallenges",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    SoloChallengeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedSoloChallenges", x => new { x.UserId, x.SoloChallengeId });
                    table.ForeignKey(
                        name: "FK_AcceptedSoloChallenges_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcceptedSoloChallenges_SoloChallenges_SoloChallengeId",
                        column: x => x.SoloChallengeId,
                        principalTable: "SoloChallenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcceptedTeamChallenges",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamChallengeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedTeamChallenges", x => new { x.TeamId, x.TeamChallengeId });
                    table.ForeignKey(
                        name: "FK_AcceptedTeamChallenges_TeamChallenges_TeamChallengeId",
                        column: x => x.TeamChallengeId,
                        principalTable: "TeamChallenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcceptedTeamChallenges_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedSoloChallenges_SoloChallengeId",
                table: "AcceptedSoloChallenges",
                column: "SoloChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedTeamChallenges_TeamChallengeId",
                table: "AcceptedTeamChallenges",
                column: "TeamChallengeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceptedSoloChallenges");

            migrationBuilder.DropTable(
                name: "AcceptedTeamChallenges");
        }
    }
}
