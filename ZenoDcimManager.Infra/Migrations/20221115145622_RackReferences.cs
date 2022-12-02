using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class RackReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BuildingId",
                table: "Rack",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FloorId",
                table: "Rack",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SiteId",
                table: "Rack",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Rack",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rack_BuildingId",
                table: "Rack",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rack_FloorId",
                table: "Rack",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rack_SiteId",
                table: "Rack",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rack_Building_BuildingId",
                table: "Rack",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rack_Floor_FloorId",
                table: "Rack",
                column: "FloorId",
                principalTable: "Floor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rack_Site_SiteId",
                table: "Rack",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rack_Building_BuildingId",
                table: "Rack");

            migrationBuilder.DropForeignKey(
                name: "FK_Rack_Floor_FloorId",
                table: "Rack");

            migrationBuilder.DropForeignKey(
                name: "FK_Rack_Site_SiteId",
                table: "Rack");

            migrationBuilder.DropIndex(
                name: "IX_Rack_BuildingId",
                table: "Rack");

            migrationBuilder.DropIndex(
                name: "IX_Rack_FloorId",
                table: "Rack");

            migrationBuilder.DropIndex(
                name: "IX_Rack_SiteId",
                table: "Rack");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Rack");

            migrationBuilder.DropColumn(
                name: "FloorId",
                table: "Rack");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Rack");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Rack");
        }
    }
}
