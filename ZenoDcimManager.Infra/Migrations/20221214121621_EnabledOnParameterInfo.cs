using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class EnabledOnParameterInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Parameter1Enabled",
                table: "SiteBuildingCardSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Parameter2Enabled",
                table: "SiteBuildingCardSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Parameter3Enabled",
                table: "SiteBuildingCardSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Parameter4Enabled",
                table: "SiteBuildingCardSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Parameter5Enabled",
                table: "SiteBuildingCardSettings",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Parameter6Enabled",
                table: "SiteBuildingCardSettings",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parameter1Enabled",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropColumn(
                name: "Parameter2Enabled",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropColumn(
                name: "Parameter3Enabled",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropColumn(
                name: "Parameter4Enabled",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropColumn(
                name: "Parameter5Enabled",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropColumn(
                name: "Parameter6Enabled",
                table: "SiteBuildingCardSettings");
        }
    }
}
