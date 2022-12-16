using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class MissingFieldOnSiteBuildingCardSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EquipmentParameter4Id",
                table: "SiteBuildingCardSettings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EquipmentParameter5Id",
                table: "SiteBuildingCardSettings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EquipmentParameter6Id",
                table: "SiteBuildingCardSettings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parameter4Description",
                table: "SiteBuildingCardSettings",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parameter5Description",
                table: "SiteBuildingCardSettings",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parameter6Description",
                table: "SiteBuildingCardSettings",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SiteBuildingCardSettings_EquipmentParameter4Id",
                table: "SiteBuildingCardSettings",
                column: "EquipmentParameter4Id");

            migrationBuilder.CreateIndex(
                name: "IX_SiteBuildingCardSettings_EquipmentParameter5Id",
                table: "SiteBuildingCardSettings",
                column: "EquipmentParameter5Id");

            migrationBuilder.CreateIndex(
                name: "IX_SiteBuildingCardSettings_EquipmentParameter6Id",
                table: "SiteBuildingCardSettings",
                column: "EquipmentParameter6Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteBuildingCardSettings_EquipmentParameter_EquipmentParameter4Id",
                table: "SiteBuildingCardSettings",
                column: "EquipmentParameter4Id",
                principalTable: "EquipmentParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteBuildingCardSettings_EquipmentParameter_EquipmentParameter5Id",
                table: "SiteBuildingCardSettings",
                column: "EquipmentParameter5Id",
                principalTable: "EquipmentParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteBuildingCardSettings_EquipmentParameter_EquipmentParameter6Id",
                table: "SiteBuildingCardSettings",
                column: "EquipmentParameter6Id",
                principalTable: "EquipmentParameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteBuildingCardSettings_EquipmentParameter_EquipmentParameter4Id",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteBuildingCardSettings_EquipmentParameter_EquipmentParameter5Id",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteBuildingCardSettings_EquipmentParameter_EquipmentParameter6Id",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropIndex(
                name: "IX_SiteBuildingCardSettings_EquipmentParameter4Id",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropIndex(
                name: "IX_SiteBuildingCardSettings_EquipmentParameter5Id",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropIndex(
                name: "IX_SiteBuildingCardSettings_EquipmentParameter6Id",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropColumn(
                name: "EquipmentParameter4Id",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropColumn(
                name: "EquipmentParameter5Id",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropColumn(
                name: "EquipmentParameter6Id",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropColumn(
                name: "Parameter4Description",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropColumn(
                name: "Parameter5Description",
                table: "SiteBuildingCardSettings");

            migrationBuilder.DropColumn(
                name: "Parameter6Description",
                table: "SiteBuildingCardSettings");
        }
    }
}
