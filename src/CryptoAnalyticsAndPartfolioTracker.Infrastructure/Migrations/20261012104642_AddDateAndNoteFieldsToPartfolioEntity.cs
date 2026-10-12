using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDateAndNoteFieldsToPartfolioEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Partfolios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Partfolios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Partfolios");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Partfolios");
        }
    }
}
