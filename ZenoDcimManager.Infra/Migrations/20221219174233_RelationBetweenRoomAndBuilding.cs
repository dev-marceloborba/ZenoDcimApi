using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class RelationBetweenRoomAndBuilding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BuildingId",
                table: "Room",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_BuildingId",
                table: "Room",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Building_BuildingId",
                table: "Room",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Building_BuildingId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_BuildingId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Room");
        }
    }
}
