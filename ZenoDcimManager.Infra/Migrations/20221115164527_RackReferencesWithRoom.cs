using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenoDcimManager.Infra.Migrations
{
    public partial class RackReferencesWithRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Rack",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rack_RoomId",
                table: "Rack",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rack_Room_RoomId",
                table: "Rack",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rack_Room_RoomId",
                table: "Rack");

            migrationBuilder.DropIndex(
                name: "IX_Rack_RoomId",
                table: "Rack");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Rack");
        }
    }
}
