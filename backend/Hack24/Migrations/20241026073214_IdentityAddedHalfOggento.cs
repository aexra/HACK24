using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hack24.Migrations
{
    /// <inheritdoc />
    public partial class IdentityAddedHalfOggento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Post_PostId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Posts",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ChallengeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChallengeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallengeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MinimalExp = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(type: "text", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoloChallengeCatalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsVoting = table.Column<bool>(type: "boolean", nullable: false),
                    ChallengeTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoloChallengeCatalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoloChallengeCatalog_ChallengeTypes_ChallengeTypeId",
                        column: x => x.ChallengeTypeId,
                        principalTable: "ChallengeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoloChallenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SoloChallengeCatalogId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoloChallenges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoloChallenges_SoloChallengeCatalog_SoloChallengeCatalogId",
                        column: x => x.SoloChallengeCatalogId,
                        principalTable: "SoloChallengeCatalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedSoloChallenges",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    SoloChallengeId = table.Column<int>(type: "integer", nullable: false),
                    Place = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedSoloChallenges", x => new { x.UserId, x.SoloChallengeId });
                    table.ForeignKey(
                        name: "FK_CompletedSoloChallenges_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompletedSoloChallenges_SoloChallenges_SoloChallengeId",
                        column: x => x.SoloChallengeId,
                        principalTable: "SoloChallenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepeatsForSoloChallenge",
                columns: table => new
                {
                    SoloChallengeId = table.Column<int>(type: "integer", nullable: false),
                    RestPeriodInDays = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepeatsForSoloChallenge", x => x.SoloChallengeId);
                    table.ForeignKey(
                        name: "FK_RepeatsForSoloChallenge_SoloChallenges_SoloChallengeId",
                        column: x => x.SoloChallengeId,
                        principalTable: "SoloChallenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestsToCompleteSoloChallenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    SoloChallengeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsToCompleteSoloChallenge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestsToCompleteSoloChallenge_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestsToCompleteSoloChallenge_SoloChallenges_SoloChalleng~",
                        column: x => x.SoloChallengeId,
                        principalTable: "SoloChallenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoloChallengeExpsPerPlace",
                columns: table => new
                {
                    SoloChallengeId = table.Column<int>(type: "integer", nullable: false),
                    Place = table.Column<int>(type: "integer", nullable: false),
                    Experience = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoloChallengeExpsPerPlace", x => new { x.SoloChallengeId, x.Place });
                    table.ForeignKey(
                        name: "FK_SoloChallengeExpsPerPlace_SoloChallenges_SoloChallengeId",
                        column: x => x.SoloChallengeId,
                        principalTable: "SoloChallenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagesForRequestToCompleteSoloChallenge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    RequestToCompleteSoloChallengeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesForRequestToCompleteSoloChallenge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagesForRequestToCompleteSoloChallenge_RequestsToCompleteS~",
                        column: x => x.RequestToCompleteSoloChallengeId,
                        principalTable: "RequestsToCompleteSoloChallenge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletedSoloChallenges_SoloChallengeId",
                table: "CompletedSoloChallenges",
                column: "SoloChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesForRequestToCompleteSoloChallenge_RequestToCompleteSo~",
                table: "ImagesForRequestToCompleteSoloChallenge",
                column: "RequestToCompleteSoloChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsToCompleteSoloChallenge_SoloChallengeId",
                table: "RequestsToCompleteSoloChallenge",
                column: "SoloChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsToCompleteSoloChallenge_UserId",
                table: "RequestsToCompleteSoloChallenge",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SoloChallengeCatalog_ChallengeTypeId",
                table: "SoloChallengeCatalog",
                column: "ChallengeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SoloChallenges_SoloChallengeCatalogId",
                table: "SoloChallenges",
                column: "SoloChallengeCatalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Posts_PostId",
                table: "AspNetUsers",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Posts_PostId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CompletedSoloChallenges");

            migrationBuilder.DropTable(
                name: "ImagesForRequestToCompleteSoloChallenge");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "RepeatsForSoloChallenge");

            migrationBuilder.DropTable(
                name: "SoloChallengeExpsPerPlace");

            migrationBuilder.DropTable(
                name: "RequestsToCompleteSoloChallenge");

            migrationBuilder.DropTable(
                name: "SoloChallenges");

            migrationBuilder.DropTable(
                name: "SoloChallengeCatalog");

            migrationBuilder.DropTable(
                name: "ChallengeTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Post",
                newName: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Post_PostId",
                table: "AspNetUsers",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId");
        }
    }
}
