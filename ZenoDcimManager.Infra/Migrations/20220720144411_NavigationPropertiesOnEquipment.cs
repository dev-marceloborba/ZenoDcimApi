using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class NavigationPropertiesOnEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_Site_SiteId",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "Alarms",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "Campus",
                table: "Building");

            migrationBuilder.AddColumn<Guid>(
                name: "BuildingId",
                table: "Equipment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FloorId",
                table: "Equipment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SiteId",
                table: "Building",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_BuildingId",
                table: "Equipment",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_FloorId",
                table: "Equipment",
                column: "FloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Site_SiteId",
                table: "Building",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Building_BuildingId",
                table: "Equipment",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Floor_FloorId",
                table: "Equipment",
                column: "FloorId",
                principalTable: "Floor",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_Site_SiteId",
                table: "Building");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Building_BuildingId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Floor_FloorId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_BuildingId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_FloorId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "FloorId",
                table: "Equipment");

            migrationBuilder.AddColumn<int>(
                name: "Alarms",
                table: "Equipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Equipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "SiteId",
                table: "Building",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Campus",
                table: "Building",
                type: "varchar(28)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Site_SiteId",
                table: "Building",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
