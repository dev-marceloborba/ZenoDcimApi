using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class FixRelationsOnCardSettngs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SiteBuildingCardSettings_BuildingId",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropIndex(
                name: "IX_SiteBuildingCardSettings_SiteId",
                table: "SiteBuildingCardSettings");

            migrationBuilder.CreateIndex(
                name: "IX_SiteBuildingCardSettings_BuildingId",
                table: "SiteBuildingCardSettings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteBuildingCardSettings_SiteId",
                table: "SiteBuildingCardSettings",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SiteBuildingCardSettings_BuildingId",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropIndex(
                name: "IX_SiteBuildingCardSettings_SiteId",
                table: "SiteBuildingCardSettings");

            migrationBuilder.CreateIndex(
                name: "IX_SiteBuildingCardSettings_BuildingId",
                table: "SiteBuildingCardSettings",
                column: "BuildingId",
                unique: true,
                filter: "[BuildingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SiteBuildingCardSettings_SiteId",
                table: "SiteBuildingCardSettings",
                column: "SiteId",
                unique: true,
                filter: "[SiteId] IS NOT NULL");
        }
    }
}
