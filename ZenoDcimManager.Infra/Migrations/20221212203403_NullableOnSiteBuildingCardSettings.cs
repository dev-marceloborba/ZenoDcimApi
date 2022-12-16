using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class NullableOnSiteBuildingCardSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteBuildingCardSettings_Building_BuildingId",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteBuildingCardSettings_Site_SiteId",
                table: "SiteBuildingCardSettings");

            migrationBuilder.AlterColumn<Guid>(
                name: "SiteId",
                table: "SiteBuildingCardSettings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "BuildingId",
                table: "SiteBuildingCardSettings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteBuildingCardSettings_Building_BuildingId",
                table: "SiteBuildingCardSettings",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteBuildingCardSettings_Site_SiteId",
                table: "SiteBuildingCardSettings",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteBuildingCardSettings_Building_BuildingId",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteBuildingCardSettings_Site_SiteId",
                table: "SiteBuildingCardSettings");

            migrationBuilder.AlterColumn<Guid>(
                name: "SiteId",
                table: "SiteBuildingCardSettings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BuildingId",
                table: "SiteBuildingCardSettings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteBuildingCardSettings_Building_BuildingId",
                table: "SiteBuildingCardSettings",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteBuildingCardSettings_Site_SiteId",
                table: "SiteBuildingCardSettings",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
