using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hack24.Migrations
{
    /// <inheritdoc />
    public partial class FixedMissedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTeamChallenge_TeamChallenge_TeamChallengeId",
                table: "CompletedTeamChallenge");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTeamChallenge_Team_TeamId",
                table: "CompletedTeamChallenge");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageForRequestToCompleteTeamChallenge_RequestToCompleteTea~",
                table: "ImageForRequestToCompleteTeamChallenge");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestToCompleteTeamChallenge_TeamChallenge_TeamChallengeId",
                table: "RequestToCompleteTeamChallenge");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestToCompleteTeamChallenge_Team_TeamId",
                table: "RequestToCompleteTeamChallenge");

            migrationBuilder.DropForeignKey(
                name: "FK_SoloChallengeCatalog_ChallengeTypes_ChallengeTypeId",
                table: "SoloChallengeCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_SoloChallenges_SoloChallengeCatalog_SoloChallengeCatalogId",
                table: "SoloChallenges");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_TeamType_TeamTypeId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamChallenge_TeamChallengeCatalog_TeamChallengeCatalogId",
                table: "TeamChallenge");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamChallengeCatalog_ChallengeTypes_ChallengeTypeId",
                table: "TeamChallengeCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamChallengeCatalog_TeamType_TeamTypeId",
                table: "TeamChallengeCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamChallengeExpPerPlace_TeamChallenge_TeamChallengeId",
                table: "TeamChallengeExpPerPlace");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamSelfChallenge_TeamSelfChallengeCatalog_TeamSelfChalleng~",
                table: "TeamSelfChallenge");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamSelfChallengeCatalog_ChallengeTypes_ChallengeTypeId",
                table: "TeamSelfChallengeCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamSelfChallengeCatalog_Team_TeamId",
                table: "TeamSelfChallengeCatalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamType",
                table: "TeamType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamSelfChallengeCatalog",
                table: "TeamSelfChallengeCatalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamSelfChallenge",
                table: "TeamSelfChallenge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamChallengeExpPerPlace",
                table: "TeamChallengeExpPerPlace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamChallengeCatalog",
                table: "TeamChallengeCatalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamChallenge",
                table: "TeamChallenge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoloChallengeCatalog",
                table: "SoloChallengeCatalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestToCompleteTeamChallenge",
                table: "RequestToCompleteTeamChallenge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageForRequestToCompleteTeamChallenge",
                table: "ImageForRequestToCompleteTeamChallenge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompletedTeamChallenge",
                table: "CompletedTeamChallenge");

            migrationBuilder.RenameTable(
                name: "TeamType",
                newName: "TeamTypes");

            migrationBuilder.RenameTable(
                name: "TeamSelfChallengeCatalog",
                newName: "TeamSelfChallengeCatalogs");

            migrationBuilder.RenameTable(
                name: "TeamSelfChallenge",
                newName: "TeamSelfChallenges");

            migrationBuilder.RenameTable(
                name: "TeamChallengeExpPerPlace",
                newName: "TeamChallengeExps");

            migrationBuilder.RenameTable(
                name: "TeamChallengeCatalog",
                newName: "TeamChallengeCatalogs");

            migrationBuilder.RenameTable(
                name: "TeamChallenge",
                newName: "TeamChallenges");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "SoloChallengeCatalog",
                newName: "SoloChallengeCatalogs");

            migrationBuilder.RenameTable(
                name: "RequestToCompleteTeamChallenge",
                newName: "RequestsToCompleteTeamChallenge");

            migrationBuilder.RenameTable(
                name: "ImageForRequestToCompleteTeamChallenge",
                newName: "ImagesForRequestToCompleteTeamChallenge");

            migrationBuilder.RenameTable(
                name: "CompletedTeamChallenge",
                newName: "CompletedTeamChallenges");

            migrationBuilder.RenameIndex(
                name: "IX_TeamSelfChallengeCatalog_TeamId",
                table: "TeamSelfChallengeCatalogs",
                newName: "IX_TeamSelfChallengeCatalogs_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamSelfChallengeCatalog_ChallengeTypeId",
                table: "TeamSelfChallengeCatalogs",
                newName: "IX_TeamSelfChallengeCatalogs_ChallengeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamSelfChallenge_TeamSelfChallengeCatalogId",
                table: "TeamSelfChallenges",
                newName: "IX_TeamSelfChallenges_TeamSelfChallengeCatalogId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamChallengeCatalog_TeamTypeId",
                table: "TeamChallengeCatalogs",
                newName: "IX_TeamChallengeCatalogs_TeamTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamChallengeCatalog_ChallengeTypeId",
                table: "TeamChallengeCatalogs",
                newName: "IX_TeamChallengeCatalogs_ChallengeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamChallenge_TeamChallengeCatalogId",
                table: "TeamChallenges",
                newName: "IX_TeamChallenges_TeamChallengeCatalogId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_TeamTypeId",
                table: "Teams",
                newName: "IX_Teams_TeamTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SoloChallengeCatalog_ChallengeTypeId",
                table: "SoloChallengeCatalogs",
                newName: "IX_SoloChallengeCatalogs_ChallengeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestToCompleteTeamChallenge_TeamId",
                table: "RequestsToCompleteTeamChallenge",
                newName: "IX_RequestsToCompleteTeamChallenge_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestToCompleteTeamChallenge_TeamChallengeId",
                table: "RequestsToCompleteTeamChallenge",
                newName: "IX_RequestsToCompleteTeamChallenge_TeamChallengeId");

            migrationBuilder.RenameIndex(
                name: "IX_ImageForRequestToCompleteTeamChallenge_RequestToCompleteTea~",
                table: "ImagesForRequestToCompleteTeamChallenge",
                newName: "IX_ImagesForRequestToCompleteTeamChallenge_RequestToCompleteTe~");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedTeamChallenge_TeamChallengeId",
                table: "CompletedTeamChallenges",
                newName: "IX_CompletedTeamChallenges_TeamChallengeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamTypes",
                table: "TeamTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamSelfChallengeCatalogs",
                table: "TeamSelfChallengeCatalogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamSelfChallenges",
                table: "TeamSelfChallenges",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamChallengeExps",
                table: "TeamChallengeExps",
                columns: new[] { "TeamChallengeId", "Place" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamChallengeCatalogs",
                table: "TeamChallengeCatalogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamChallenges",
                table: "TeamChallenges",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoloChallengeCatalogs",
                table: "SoloChallengeCatalogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestsToCompleteTeamChallenge",
                table: "RequestsToCompleteTeamChallenge",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesForRequestToCompleteTeamChallenge",
                table: "ImagesForRequestToCompleteTeamChallenge",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompletedTeamChallenges",
                table: "CompletedTeamChallenges",
                columns: new[] { "TeamId", "TeamChallengeId" });

            migrationBuilder.CreateTable(
                name: "RepeatsForTeamChallenge",
                columns: table => new
                {
                    TeamChallengeId = table.Column<int>(type: "integer", nullable: false),
                    RestPeriodInDays = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepeatsForTeamChallenge", x => x.TeamChallengeId);
                    table.ForeignKey(
                        name: "FK_RepeatsForTeamChallenge_TeamChallenges_TeamChallengeId",
                        column: x => x.TeamChallengeId,
                        principalTable: "TeamChallenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepeatsForTeamSelfChallenge",
                columns: table => new
                {
                    TeamSelfChallengeId = table.Column<int>(type: "integer", nullable: false),
                    RestPeriodInDays = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepeatsForTeamSelfChallenge", x => x.TeamSelfChallengeId);
                    table.ForeignKey(
                        name: "FK_RepeatsForTeamSelfChallenge_TeamSelfChallenges_TeamSelfChal~",
                        column: x => x.TeamSelfChallengeId,
                        principalTable: "TeamSelfChallenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTeams",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeams", x => new { x.UserId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_UserTeams_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTeams_TeamId",
                table: "UserTeams",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTeamChallenges_TeamChallenges_TeamChallengeId",
                table: "CompletedTeamChallenges",
                column: "TeamChallengeId",
                principalTable: "TeamChallenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTeamChallenges_Teams_TeamId",
                table: "CompletedTeamChallenges",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesForRequestToCompleteTeamChallenge_RequestsToCompleteT~",
                table: "ImagesForRequestToCompleteTeamChallenge",
                column: "RequestToCompleteTeamChallengeId",
                principalTable: "RequestsToCompleteTeamChallenge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsToCompleteTeamChallenge_TeamChallenges_TeamChalleng~",
                table: "RequestsToCompleteTeamChallenge",
                column: "TeamChallengeId",
                principalTable: "TeamChallenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsToCompleteTeamChallenge_Teams_TeamId",
                table: "RequestsToCompleteTeamChallenge",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoloChallengeCatalogs_ChallengeTypes_ChallengeTypeId",
                table: "SoloChallengeCatalogs",
                column: "ChallengeTypeId",
                principalTable: "ChallengeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoloChallenges_SoloChallengeCatalogs_SoloChallengeCatalogId",
                table: "SoloChallenges",
                column: "SoloChallengeCatalogId",
                principalTable: "SoloChallengeCatalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamChallengeCatalogs_ChallengeTypes_ChallengeTypeId",
                table: "TeamChallengeCatalogs",
                column: "ChallengeTypeId",
                principalTable: "ChallengeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamChallengeCatalogs_TeamTypes_TeamTypeId",
                table: "TeamChallengeCatalogs",
                column: "TeamTypeId",
                principalTable: "TeamTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamChallengeExps_TeamChallenges_TeamChallengeId",
                table: "TeamChallengeExps",
                column: "TeamChallengeId",
                principalTable: "TeamChallenges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamChallenges_TeamChallengeCatalogs_TeamChallengeCatalogId",
                table: "TeamChallenges",
                column: "TeamChallengeCatalogId",
                principalTable: "TeamChallengeCatalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_TeamTypes_TeamTypeId",
                table: "Teams",
                column: "TeamTypeId",
                principalTable: "TeamTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamSelfChallengeCatalogs_ChallengeTypes_ChallengeTypeId",
                table: "TeamSelfChallengeCatalogs",
                column: "ChallengeTypeId",
                principalTable: "ChallengeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamSelfChallengeCatalogs_Teams_TeamId",
                table: "TeamSelfChallengeCatalogs",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamSelfChallenges_TeamSelfChallengeCatalogs_TeamSelfChalle~",
                table: "TeamSelfChallenges",
                column: "TeamSelfChallengeCatalogId",
                principalTable: "TeamSelfChallengeCatalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTeamChallenges_TeamChallenges_TeamChallengeId",
                table: "CompletedTeamChallenges");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedTeamChallenges_Teams_TeamId",
                table: "CompletedTeamChallenges");

            migrationBuilder.DropForeignKey(
                name: "FK_ImagesForRequestToCompleteTeamChallenge_RequestsToCompleteT~",
                table: "ImagesForRequestToCompleteTeamChallenge");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestsToCompleteTeamChallenge_TeamChallenges_TeamChalleng~",
                table: "RequestsToCompleteTeamChallenge");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestsToCompleteTeamChallenge_Teams_TeamId",
                table: "RequestsToCompleteTeamChallenge");

            migrationBuilder.DropForeignKey(
                name: "FK_SoloChallengeCatalogs_ChallengeTypes_ChallengeTypeId",
                table: "SoloChallengeCatalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_SoloChallenges_SoloChallengeCatalogs_SoloChallengeCatalogId",
                table: "SoloChallenges");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamChallengeCatalogs_ChallengeTypes_ChallengeTypeId",
                table: "TeamChallengeCatalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamChallengeCatalogs_TeamTypes_TeamTypeId",
                table: "TeamChallengeCatalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamChallengeExps_TeamChallenges_TeamChallengeId",
                table: "TeamChallengeExps");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamChallenges_TeamChallengeCatalogs_TeamChallengeCatalogId",
                table: "TeamChallenges");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_TeamTypes_TeamTypeId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamSelfChallengeCatalogs_ChallengeTypes_ChallengeTypeId",
                table: "TeamSelfChallengeCatalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamSelfChallengeCatalogs_Teams_TeamId",
                table: "TeamSelfChallengeCatalogs");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamSelfChallenges_TeamSelfChallengeCatalogs_TeamSelfChalle~",
                table: "TeamSelfChallenges");

            migrationBuilder.DropTable(
                name: "RepeatsForTeamChallenge");

            migrationBuilder.DropTable(
                name: "RepeatsForTeamSelfChallenge");

            migrationBuilder.DropTable(
                name: "UserTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamTypes",
                table: "TeamTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamSelfChallenges",
                table: "TeamSelfChallenges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamSelfChallengeCatalogs",
                table: "TeamSelfChallengeCatalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamChallenges",
                table: "TeamChallenges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamChallengeExps",
                table: "TeamChallengeExps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamChallengeCatalogs",
                table: "TeamChallengeCatalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoloChallengeCatalogs",
                table: "SoloChallengeCatalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestsToCompleteTeamChallenge",
                table: "RequestsToCompleteTeamChallenge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesForRequestToCompleteTeamChallenge",
                table: "ImagesForRequestToCompleteTeamChallenge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompletedTeamChallenges",
                table: "CompletedTeamChallenges");

            migrationBuilder.RenameTable(
                name: "TeamTypes",
                newName: "TeamType");

            migrationBuilder.RenameTable(
                name: "TeamSelfChallenges",
                newName: "TeamSelfChallenge");

            migrationBuilder.RenameTable(
                name: "TeamSelfChallengeCatalogs",
                newName: "TeamSelfChallengeCatalog");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.RenameTable(
                name: "TeamChallenges",
                newName: "TeamChallenge");

            migrationBuilder.RenameTable(
                name: "TeamChallengeExps",
                newName: "TeamChallengeExpPerPlace");

            migrationBuilder.RenameTable(
                name: "TeamChallengeCatalogs",
                newName: "TeamChallengeCatalog");

            migrationBuilder.RenameTable(
                name: "SoloChallengeCatalogs",
                newName: "SoloChallengeCatalog");

            migrationBuilder.RenameTable(
                name: "RequestsToCompleteTeamChallenge",
                newName: "RequestToCompleteTeamChallenge");

            migrationBuilder.RenameTable(
                name: "ImagesForRequestToCompleteTeamChallenge",
                newName: "ImageForRequestToCompleteTeamChallenge");

            migrationBuilder.RenameTable(
                name: "CompletedTeamChallenges",
                newName: "CompletedTeamChallenge");

            migrationBuilder.RenameIndex(
                name: "IX_TeamSelfChallenges_TeamSelfChallengeCatalogId",
                table: "TeamSelfChallenge",
                newName: "IX_TeamSelfChallenge_TeamSelfChallengeCatalogId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamSelfChallengeCatalogs_TeamId",
                table: "TeamSelfChallengeCatalog",
                newName: "IX_TeamSelfChallengeCatalog_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamSelfChallengeCatalogs_ChallengeTypeId",
                table: "TeamSelfChallengeCatalog",
                newName: "IX_TeamSelfChallengeCatalog_ChallengeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_TeamTypeId",
                table: "Team",
                newName: "IX_Team_TeamTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamChallenges_TeamChallengeCatalogId",
                table: "TeamChallenge",
                newName: "IX_TeamChallenge_TeamChallengeCatalogId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamChallengeCatalogs_TeamTypeId",
                table: "TeamChallengeCatalog",
                newName: "IX_TeamChallengeCatalog_TeamTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamChallengeCatalogs_ChallengeTypeId",
                table: "TeamChallengeCatalog",
                newName: "IX_TeamChallengeCatalog_ChallengeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SoloChallengeCatalogs_ChallengeTypeId",
                table: "SoloChallengeCatalog",
                newName: "IX_SoloChallengeCatalog_ChallengeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestsToCompleteTeamChallenge_TeamId",
                table: "RequestToCompleteTeamChallenge",
                newName: "IX_RequestToCompleteTeamChallenge_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestsToCompleteTeamChallenge_TeamChallengeId",
                table: "RequestToCompleteTeamChallenge",
                newName: "IX_RequestToCompleteTeamChallenge_TeamChallengeId");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesForRequestToCompleteTeamChallenge_RequestToCompleteTe~",
                table: "ImageForRequestToCompleteTeamChallenge",
                newName: "IX_ImageForRequestToCompleteTeamChallenge_RequestToCompleteTea~");

            migrationBuilder.RenameIndex(
                name: "IX_CompletedTeamChallenges_TeamChallengeId",
                table: "CompletedTeamChallenge",
                newName: "IX_CompletedTeamChallenge_TeamChallengeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamType",
                table: "TeamType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamSelfChallenge",
                table: "TeamSelfChallenge",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamSelfChallengeCatalog",
                table: "TeamSelfChallengeCatalog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamChallenge",
                table: "TeamChallenge",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamChallengeExpPerPlace",
                table: "TeamChallengeExpPerPlace",
                columns: new[] { "TeamChallengeId", "Place" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamChallengeCatalog",
                table: "TeamChallengeCatalog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoloChallengeCatalog",
                table: "SoloChallengeCatalog",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestToCompleteTeamChallenge",
                table: "RequestToCompleteTeamChallenge",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageForRequestToCompleteTeamChallenge",
                table: "ImageForRequestToCompleteTeamChallenge",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompletedTeamChallenge",
                table: "CompletedTeamChallenge",
                columns: new[] { "TeamId", "TeamChallengeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTeamChallenge_TeamChallenge_TeamChallengeId",
                table: "CompletedTeamChallenge",
                column: "TeamChallengeId",
                principalTable: "TeamChallenge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedTeamChallenge_Team_TeamId",
                table: "CompletedTeamChallenge",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageForRequestToCompleteTeamChallenge_RequestToCompleteTea~",
                table: "ImageForRequestToCompleteTeamChallenge",
                column: "RequestToCompleteTeamChallengeId",
                principalTable: "RequestToCompleteTeamChallenge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestToCompleteTeamChallenge_TeamChallenge_TeamChallengeId",
                table: "RequestToCompleteTeamChallenge",
                column: "TeamChallengeId",
                principalTable: "TeamChallenge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestToCompleteTeamChallenge_Team_TeamId",
                table: "RequestToCompleteTeamChallenge",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoloChallengeCatalog_ChallengeTypes_ChallengeTypeId",
                table: "SoloChallengeCatalog",
                column: "ChallengeTypeId",
                principalTable: "ChallengeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoloChallenges_SoloChallengeCatalog_SoloChallengeCatalogId",
                table: "SoloChallenges",
                column: "SoloChallengeCatalogId",
                principalTable: "SoloChallengeCatalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_TeamType_TeamTypeId",
                table: "Team",
                column: "TeamTypeId",
                principalTable: "TeamType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamChallenge_TeamChallengeCatalog_TeamChallengeCatalogId",
                table: "TeamChallenge",
                column: "TeamChallengeCatalogId",
                principalTable: "TeamChallengeCatalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamChallengeCatalog_ChallengeTypes_ChallengeTypeId",
                table: "TeamChallengeCatalog",
                column: "ChallengeTypeId",
                principalTable: "ChallengeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamChallengeCatalog_TeamType_TeamTypeId",
                table: "TeamChallengeCatalog",
                column: "TeamTypeId",
                principalTable: "TeamType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamChallengeExpPerPlace_TeamChallenge_TeamChallengeId",
                table: "TeamChallengeExpPerPlace",
                column: "TeamChallengeId",
                principalTable: "TeamChallenge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamSelfChallenge_TeamSelfChallengeCatalog_TeamSelfChalleng~",
                table: "TeamSelfChallenge",
                column: "TeamSelfChallengeCatalogId",
                principalTable: "TeamSelfChallengeCatalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamSelfChallengeCatalog_ChallengeTypes_ChallengeTypeId",
                table: "TeamSelfChallengeCatalog",
                column: "ChallengeTypeId",
                principalTable: "ChallengeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamSelfChallengeCatalog_Team_TeamId",
                table: "TeamSelfChallengeCatalog",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
