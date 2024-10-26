using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hack24.Migrations
{
    /// <inheritdoc />
    public partial class IdentityAddedHalf3ggento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TeamTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_TeamType_TeamTypeId",
                        column: x => x.TeamTypeId,
                        principalTable: "TeamType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamChallengeCatalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ChallengeTypeId = table.Column<int>(type: "integer", nullable: false),
                    TeamTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsVoting = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamChallengeCatalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamChallengeCatalog_ChallengeTypes_ChallengeTypeId",
                        column: x => x.ChallengeTypeId,
                        principalTable: "ChallengeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamChallengeCatalog_TeamType_TeamTypeId",
                        column: x => x.TeamTypeId,
                        principalTable: "TeamType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamSelfChallengeCatalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ChallengeTypeId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSelfChallengeCatalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamSelfChallengeCatalog_ChallengeTypes_ChallengeTypeId",
                        column: x => x.ChallengeTypeId,
                        principalTable: "ChallengeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSelfChallengeCatalog_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamChallenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TeamChallengeCatalogId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamChallenge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamChallenge_TeamChallengeCatalog_TeamChallengeCatalogId",
                        column: x => x.TeamChallengeCatalogId,
                        principalTable: "TeamChallengeCatalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamSelfChallenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TeamSelfChallengeCatalogId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSelfChallenge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamSelfChallenge_TeamSelfChallengeCatalog_TeamSelfChalleng~",
                        column: x => x.TeamSelfChallengeCatalogId,
                        principalTable: "TeamSelfChallengeCatalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedTeamChallenge",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamChallengeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedTeamChallenge", x => new { x.TeamId, x.TeamChallengeId });
                    table.ForeignKey(
                        name: "FK_CompletedTeamChallenge_TeamChallenge_TeamChallengeId",
                        column: x => x.TeamChallengeId,
                        principalTable: "TeamChallenge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompletedTeamChallenge_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestToCompleteTeamChallenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    TeamChallengeId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestToCompleteTeamChallenge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestToCompleteTeamChallenge_TeamChallenge_TeamChallengeId",
                        column: x => x.TeamChallengeId,
                        principalTable: "TeamChallenge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestToCompleteTeamChallenge_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamChallengeExpPerPlace",
                columns: table => new
                {
                    TeamChallengeId = table.Column<int>(type: "integer", nullable: false),
                    Place = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamChallengeExpPerPlace", x => new { x.TeamChallengeId, x.Place });
                    table.ForeignKey(
                        name: "FK_TeamChallengeExpPerPlace_TeamChallenge_TeamChallengeId",
                        column: x => x.TeamChallengeId,
                        principalTable: "TeamChallenge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageForRequestToCompleteTeamChallenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestToCompleteTeamChallengeId = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageForRequestToCompleteTeamChallenge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageForRequestToCompleteTeamChallenge_RequestToCompleteTea~",
                        column: x => x.RequestToCompleteTeamChallengeId,
                        principalTable: "RequestToCompleteTeamChallenge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedTeamChallenge_TeamChallengeId",
                table: "CompletedTeamChallenge",
                column: "TeamChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageForRequestToCompleteTeamChallenge_RequestToCompleteTea~",
                table: "ImageForRequestToCompleteTeamChallenge",
                column: "RequestToCompleteTeamChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestToCompleteTeamChallenge_TeamChallengeId",
                table: "RequestToCompleteTeamChallenge",
                column: "TeamChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestToCompleteTeamChallenge_TeamId",
                table: "RequestToCompleteTeamChallenge",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_TeamTypeId",
                table: "Team",
                column: "TeamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamChallenge_TeamChallengeCatalogId",
                table: "TeamChallenge",
                column: "TeamChallengeCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamChallengeCatalog_ChallengeTypeId",
                table: "TeamChallengeCatalog",
                column: "ChallengeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamChallengeCatalog_TeamTypeId",
                table: "TeamChallengeCatalog",
                column: "TeamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSelfChallenge_TeamSelfChallengeCatalogId",
                table: "TeamSelfChallenge",
                column: "TeamSelfChallengeCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSelfChallengeCatalog_ChallengeTypeId",
                table: "TeamSelfChallengeCatalog",
                column: "ChallengeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSelfChallengeCatalog_TeamId",
                table: "TeamSelfChallengeCatalog",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletedTeamChallenge");

            migrationBuilder.DropTable(
                name: "ImageForRequestToCompleteTeamChallenge");

            migrationBuilder.DropTable(
                name: "TeamChallengeExpPerPlace");

            migrationBuilder.DropTable(
                name: "TeamSelfChallenge");

            migrationBuilder.DropTable(
                name: "RequestToCompleteTeamChallenge");

            migrationBuilder.DropTable(
                name: "TeamSelfChallengeCatalog");

            migrationBuilder.DropTable(
                name: "TeamChallenge");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "TeamChallengeCatalog");

            migrationBuilder.DropTable(
                name: "TeamType");
        }
    }
}
