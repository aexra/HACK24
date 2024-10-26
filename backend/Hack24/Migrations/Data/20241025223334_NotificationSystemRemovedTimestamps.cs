using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hack24.Migrations.Data
{
    /// <inheritdoc />
    public partial class NotificationSystemRemovedTimestamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadTimestamp",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "SendTimestamp",
                table: "Notifications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReadTimestamp",
                table: "Notifications",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SendTimestamp",
                table: "Notifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
