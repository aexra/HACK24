using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hack24.Migrations
{
    /// <inheritdoc />
    public partial class IdentityAddedHalf25Oggento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoloSelfChallengeCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ChallengeTypeId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoloSelfChallengeCatalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoloSelfChallengeCatalogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoloSelfChallengeCatalogs_ChallengeTypes_ChallengeTypeId",
                        column: x => x.ChallengeTypeId,
                        principalTable: "ChallengeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoloSelfChallenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SoloSelfChallengeCatalog = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoloSelfChallenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoloSelfChallenges_SoloSelfChallengeCatalogs_SoloSelfChalle~",
                        column: x => x.SoloSelfChallengeCatalog,
                        principalTable: "SoloSelfChallengeCatalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepeatsForSoloSelfChallenge",
                columns: table => new
                {
                    SoloSelfChallengeId = table.Column<int>(type: "integer", nullable: false),
                    RestPeriodInDays = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepeatsForSoloSelfChallenge", x => x.SoloSelfChallengeId);
                    table.ForeignKey(
                        name: "FK_RepeatsForSoloSelfChallenge_SoloSelfChallenges_SoloSelfChal~",
                        column: x => x.SoloSelfChallengeId,
                        principalTable: "SoloSelfChallenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoloSelfChallengeCatalogs_ChallengeTypeId",
                table: "SoloSelfChallengeCatalogs",
                column: "ChallengeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SoloSelfChallengeCatalogs_UserId",
                table: "SoloSelfChallengeCatalogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SoloSelfChallenges_SoloSelfChallengeCatalog",
                table: "SoloSelfChallenges",
                column: "SoloSelfChallengeCatalog");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepeatsForSoloSelfChallenge");

            migrationBuilder.DropTable(
                name: "SoloSelfChallenges");

            migrationBuilder.DropTable(
                name: "SoloSelfChallengeCatalogs");
        }
    }
}
