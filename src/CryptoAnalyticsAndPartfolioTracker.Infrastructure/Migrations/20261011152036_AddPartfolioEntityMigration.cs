using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoAnalyticsAndPartfolioTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPartfolioEntityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partfolios",
                columns: table => new
                {
                    PartfolioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Operation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partfolios", x => x.PartfolioId);
                    table.ForeignKey(
                        name: "FK_Partfolios_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partfolios_UserId",
                table: "Partfolios",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partfolios");
        }
    }
}
